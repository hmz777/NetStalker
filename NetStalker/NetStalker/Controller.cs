using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using MetroFramework;
using NetStalker;
using NetStalker.ToastNotifications;
using SharpPcap;
using SharpPcap.AirPcap;
using SharpPcap.WinPcap;

namespace CSArp
{
    public class Controller
    {
        #region fields
        private IView _view;
        #endregion

        #region constructor
        public Controller(IView view = null)
        {
            _view = view;
        }
        #endregion

        /// <summary>
        /// Populate the available network cards
        /// </summary>
        public List<string> PopulateInterfaces()//Not used
        {
            CaptureDeviceList capturedevicelist = CaptureDeviceList.Instance;
            List<string> capturedevicelistofstring = new List<string>();
            capturedevicelist.ToList().ForEach((ICaptureDevice capturedevice) =>
            {
                if (capturedevice is WinPcapDevice)
                {
                    WinPcapDevice winpcapdevice = (WinPcapDevice)capturedevice;
                    capturedevicelistofstring.Add(winpcapdevice.Interface.FriendlyName);
                }
                else if (capturedevice is AirPcapDevice)
                {
                    AirPcapDevice airpcapdevice = (AirPcapDevice)capturedevice;
                    capturedevicelistofstring.Add(airpcapdevice.Interface.FriendlyName);
                }
            });
            return capturedevicelistofstring;
        }

        /// <summary>
        /// Populate the LAN clients
        /// </summary>
        public void RefreshClients()
        {
            if (!string.IsNullOrWhiteSpace(NetStalker.Properties.Settings.Default.friendlyname)) //if a network interface has been selected
            {
                if (_view.StatusLabel.Text.IndexOf("Scanning") == -1) //if a scan isn't active already
                {
                    DisconnectReconnect.Reconnect(); //first disengage spoofing threads
                    _view.StatusLabel.BeginInvoke(new Action(() => { _view.StatusLabel.Text = "Ready"; }));
                    GetClientList.GetAllClients(_view, NetStalker.Properties.Settings.Default.friendlyname);
                }

            }
            else
            {
                MessageBox.Show("Please select a network interface!", "Interface", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        /// <summary>
        /// Disconnects clients selected in the listview
        /// </summary>
        public void DisconnectSelectedClients()//Not used
        {
            try
            {
                if (_view.ListView1.SelectedObjects.Count > 0)
                {
                    Dictionary<IPAddress, PhysicalAddress> targetlist = new Dictionary<IPAddress, PhysicalAddress>();
                    int parseindex = 0;
                    foreach (Device listitem in _view.ListView1.SelectedObjects)
                    {

                        targetlist.Add(listitem.IP,
                            listitem.MAC);
                        listitem.DeviceStatus = "Offline";
                        _view.ListView1.UpdateObject(listitem);
                        _view.MainForm.BeginInvoke(new Action(() =>
                        {
                            _view.StatusLabel.Text = "Spoofing active";

                        }));
                    }

                    DisconnectReconnect.Disconnect(_view.ListView1, targetlist,
                        GetGatewayIP(NetStalker.Properties.Settings.Default.friendlyname),
                        GetGatewayMAC(NetStalker.Properties.Settings.Default.friendlyname),
                        NetStalker.Properties.Settings.Default.friendlyname);

                    _view.PictureBox.BeginInvoke(new Action(() =>
                    {
                        _view.PictureBox.Image = NetStalker.Properties.Resources.image__4_25;
                    }));
                }
            }
            catch (GatewayTargeted e)
            {
                MetroMessageBox.Show(_view.MainForm, "This operation can not target the gateway!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (LocalHostTargeted e)
            {
                MetroMessageBox.Show(_view.MainForm, "This operation can not target your own ip address!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        public class LocalHostTargeted : Exception
        {

            public LocalHostTargeted() : base() { }

            public LocalHostTargeted(string message) : base(message) { }
        }

        public class GatewayTargeted : Exception
        {

            public GatewayTargeted() : base() { }

            public GatewayTargeted(string message) : base(message) { }
        }

        /// <summary>
        /// Reconnects clients by stopping fake ARP requests
        /// </summary>
        public void ReconnectClients()//Not used
        {
            DisconnectReconnect.Reconnect();
            IEnumerable<Device> list = _view.ListView1.Objects.Cast<Device>().ToList();
            foreach (Device entry in list)
            {
                entry.DeviceStatus = "Online";
                _view.ListView1.UpdateObject(entry);
            }
            _view.StatusLabel.Text = "Stopped";

            _view.PictureBox.BeginInvoke(new Action(() =>
            {
                _view.PictureBox.Image = NetStalker.Properties.Resources.icons8_ok_96px;
            }));
        }

        public void AttachOnExitEventHandler()
        {
            Application.ApplicationExit += (object sender, EventArgs e) =>
            {
                try
                {

                    var devices = _view.ListView1.Objects.Cast<Device>().ToList();

                    foreach (var device in devices)
                    {
                        device.Redirected = false;
                        device.Blocked = false;
                        device.LimiterStarted = false;
                    }

                    GetClientList.CloseAllCaptures(_view);
                    NotificationAPI.ClearNotifications();


                }
                catch (Exception exception)
                {

                }

            };

        }


        #region Private helper functions
        /// <summary>
        /// Return the gateway IPAddress of the selected network interface's
        /// </summary>
        /// <param name="friendlyname">The friendly name of the selected network interface</param>
        /// <returns>Returns the gateway IPAddress of the selected network interface's</returns>
        private IPAddress GetGatewayIP(string friendlyname)
        {
            IPAddress retval = null;
            string interfacename = "";
            foreach (ICaptureDevice capturedevice in CaptureDeviceList.Instance)
            {
                if (capturedevice is WinPcapDevice)
                {
                    WinPcapDevice winpcapdevice = (WinPcapDevice)capturedevice;
                    if (winpcapdevice.Interface.FriendlyName == friendlyname)
                    {
                        interfacename = winpcapdevice.Interface.Name;
                    }
                }
                else if (capturedevice is AirPcapDevice)
                {
                    AirPcapDevice airpcapdevice = (AirPcapDevice)capturedevice;
                    if (airpcapdevice.Interface.FriendlyName == friendlyname)
                    {
                        interfacename = airpcapdevice.Interface.Name;
                    }
                }
            }
            if (interfacename != "")
            {
                foreach (var networkinterface in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (networkinterface.Name == friendlyname)
                    {
                        foreach (var gateway in networkinterface.GetIPProperties().GatewayAddresses)
                        {
                            if (gateway.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) //filter ipv4 gateway ip address
                                retval = gateway.Address;
                        }
                    }
                }
            }
            return retval;
        }
        private PhysicalAddress GetGatewayMAC(string friendlyname)
        {
            PhysicalAddress retval = null;
            string gatewayip = GetGatewayIP(friendlyname).ToString();
            foreach (Device listviewitem in _view.ListView1.Objects)
            {
                if (listviewitem.IP.ToString() == gatewayip)
                {
                    retval = listviewitem.MAC;
                }
            }
            return retval;
        }
        #endregion
    }
}
