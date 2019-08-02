using MetroFramework;
using PacketDotNet;
using NetStalker;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;


namespace CSArp
{
    public static class GetClientList
    {
        private static ICaptureDevice capturedevice;
        private static Dictionary<IPAddress, PhysicalAddress> clientlist;
        private static string ipp;
        public static bool StopFlag;
        private static int Size;
        private static bool GatewayCalled;
        public static bool CalledFromToast;
        public static bool CalledFromSniffer;
        public static bool LoadingBarCalled;
        private static PhysicalAddress GatewayMAC = PhysicalAddress.Parse(NetStalker.Properties.Settings.Default.gatewaymac);
        private static IPAddress GatewayIP = IPAddress.Parse(NetStalker.Properties.Settings.Default.Gateway);


        /// <summary>
        /// Populates listview with machines connected to the LAN
        /// </summary>
        /// <param name="view"></param>
        /// <param name="interfacefriendlyname"></param>
        public static void GetAllClients(IView view, string interfacefriendlyname)
        {
            #region initialization
            view.MainForm.Invoke(new Action(() => view.StatusLabel.Text = "Please wait..."));
            if (capturedevice != null)
            {
                try
                {
                    capturedevice.StopCapture(); //stop previous capture
                    capturedevice.Close(); //close previous instances
                    StopFlag = false;
                    GatewayCalled = false;
                    capturedevice.OnPacketArrival += null;
                    StopTheLoadingBar(view);

                }
                catch (PcapException ex)
                {
                }
            }
            clientlist = new Dictionary<IPAddress, PhysicalAddress>();
            view.ListView1.BeginInvoke(new Action(() =>
            {

                view.ListView1.ClearObjects();

            }));
            #endregion

            CaptureDeviceList capturedevicelist = CaptureDeviceList.Instance;
            capturedevicelist.Refresh(); //crucial for reflection of any network changes
            capturedevice = (from devicex in capturedevicelist where ((SharpPcap.WinPcap.WinPcapDevice)devicex).Interface.FriendlyName == interfacefriendlyname select devicex).ToList()[0];
            capturedevice.Open(DeviceMode.Promiscuous, 1000); //open device with 1000ms timeout
            capturedevice.Filter = "arp";
            IPAddress myipaddress = IPAddress.Parse(NetStalker.Properties.Settings.Default.localip);

            Size = NetStalker.Properties.Settings.Default.NetSize;
            var Root = GetRoot(myipaddress, Size);
            if (string.IsNullOrEmpty(Root))
            {
                view.MainForm.Invoke(new Action(() => view.StatusLabel.Text = "Network Error"));
                return;
            }

            #region Sending ARP requests to probe for all possible IP addresses on LAN
            new Thread(() =>
            {
                try
                {
                    if (Size == 1)
                    {
                        for (int ipindex = 1; ipindex <= 255; ipindex++)
                        {
                            ARPPacket arprequestpacket = new ARPPacket(ARPOperation.Request, PhysicalAddress.Parse("00-00-00-00-00-00"), IPAddress.Parse(Root + ipindex), capturedevice.MacAddress, myipaddress);
                            EthernetPacket ethernetpacket = new EthernetPacket(capturedevice.MacAddress, PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"), EthernetPacketType.Arp);
                            ethernetpacket.PayloadPacket = arprequestpacket;
                            capturedevice.SendPacket(ethernetpacket);
                        }

                    }

                    else if (Size == 2)
                    {
                        for (int i = 1; i <= 255; i++)
                        {
                            for (int j = 1; j <= 255; j++)
                            {
                                ARPPacket arprequestpacket = new ARPPacket(ARPOperation.Request, PhysicalAddress.Parse("00-00-00-00-00-00"), IPAddress.Parse(Root + i + '.' + j), capturedevice.MacAddress, myipaddress);
                                EthernetPacket ethernetpacket = new EthernetPacket(capturedevice.MacAddress, PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"), EthernetPacketType.Arp);
                                ethernetpacket.PayloadPacket = arprequestpacket;
                                capturedevice.SendPacket(ethernetpacket);
                                if (!GatewayCalled)
                                {
                                    ARPPacket ArpForGateway = new ARPPacket(ARPOperation.Request, PhysicalAddress.Parse("00-00-00-00-00-00"), GatewayIP, capturedevice.MacAddress, myipaddress);//???
                                    EthernetPacket EtherForGateway = new EthernetPacket(capturedevice.MacAddress, PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"), EthernetPacketType.Arp);
                                    EtherForGateway.PayloadPacket = ArpForGateway;
                                    capturedevice.SendPacket(EtherForGateway);
                                    GatewayCalled = true;
                                }
                            }
                        }
                    }

                    else if (Size == 3)
                    {
                        if (MetroMessageBox.Show(view.MainForm,
                                "The network you're scanning is very large, it will take sometime before the scanner can find all the devices, proceed?",
                                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {


                            for (int i = 1; i <= 255; i++)
                            {
                                for (int j = 1; j <= 255; j++)
                                {
                                    for (int k = 1; k <= 255; k++)
                                    {
                                        ARPPacket arprequestpacket = new ARPPacket(ARPOperation.Request,
                                            PhysicalAddress.Parse("00-00-00-00-00-00"),
                                            IPAddress.Parse(Root + i + '.' + j + '.' + k), capturedevice.MacAddress,
                                            myipaddress);
                                        EthernetPacket ethernetpacket = new EthernetPacket(capturedevice.MacAddress,
                                            PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"), EthernetPacketType.Arp);
                                        ethernetpacket.PayloadPacket = arprequestpacket;
                                        capturedevice.SendPacket(ethernetpacket);
                                        if (!GatewayCalled)
                                        {
                                            ARPPacket ArpForGateway = new ARPPacket(ARPOperation.Request, PhysicalAddress.Parse("00-00-00-00-00-00"), GatewayIP, capturedevice.MacAddress, myipaddress);//???
                                            EthernetPacket EtherForGateway = new EthernetPacket(capturedevice.MacAddress, PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"), EthernetPacketType.Arp);//???
                                            EtherForGateway.PayloadPacket = ArpForGateway;
                                            capturedevice.SendPacket(EtherForGateway);
                                            GatewayCalled = true;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            return;
                        }

                    }


                }
                catch (Exception ex)
                {

                }
            }).Start();
            #endregion

            #region Retrieving ARP packets floating around and finding out the senders' IP and MACs
            capturedevice.Filter = "arp";
            RawCapture rawcapture = null;
            long scanduration = 8000;
            new Thread(() =>
            {
                try
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    while ((rawcapture = capturedevice.GetNextPacket()) != null && stopwatch.ElapsedMilliseconds <= scanduration)
                    {

                        Packet packet = Packet.ParsePacket(rawcapture.LinkLayerType, rawcapture.Data);
                        ARPPacket arppacket = (ARPPacket)packet.Extract(typeof(ARPPacket));
                        if (!clientlist.ContainsKey(arppacket.SenderProtocolAddress) && arppacket.SenderProtocolAddress.ToString() != "0.0.0.0" && areCompatibleIPs(arppacket.SenderProtocolAddress, myipaddress, Size))
                        {
                            clientlist.Add(arppacket.SenderProtocolAddress, arppacket.SenderHardwareAddress);
                            view.ListView1.Invoke(new Action(() =>
                            {
                                string mac = GetMACString(arppacket.SenderHardwareAddress);
                                string machineName = "";
                                int id = clientlist.Count - 1;
                                string ip = arppacket.SenderProtocolAddress.ToString();
                                var obj = new Device();
                                new Thread(() =>
                                {
                                    try
                                    {

                                        ipp = ip;

                                        IPHostEntry hostEntry = Dns.GetHostEntry(ip);

                                        view.ListView1.BeginInvoke(new Action(() =>
                                        {
                                            obj.DeviceName = hostEntry.HostName;
                                            view.ListView1.UpdateObject(obj);
                                        }));
                                    }
                                    catch (Exception ex)
                                    {

                                        view.ListView1.BeginInvoke(new Action(() =>
                                        {
                                            obj.DeviceName = ip;
                                            view.ListView1.UpdateObject(obj);
                                        }));

                                    }
                                }).Start();

                                new Thread(() =>
                                {
                                    var Name = VendorAPI.GetVendorInfo(mac);
                                    if (Name != null)
                                    {
                                        obj.ManName = Name.data.organization_name;
                                    }
                                    else
                                    {
                                        obj.ManName = "";
                                    }
                                    view.ListView1.UpdateObject(obj);
                                }).Start();

                                obj.IP = arppacket.SenderProtocolAddress;
                                obj.MAC = PhysicalAddress.Parse(mac.Replace(":", ""));
                                obj.DeviceName = "Resolving";
                                obj.ManName = "Getting information...";
                                obj.DeviceStatus = "Online";
                                view.ListView1.AddObject(obj);

                            }));

                        }
                        int percentageprogress = (int)((float)stopwatch.ElapsedMilliseconds / scanduration * 100);
                        view.MainForm.Invoke(new Action(() => view.StatusLabel.Text = "Scanning " + percentageprogress + "%"));



                    }
                    stopwatch.Stop();
                    Main.operationinprogress = false;
                    view.MainForm.Invoke(new Action(() => view.StatusLabel.Text = clientlist.Count.ToString() + " device(s) found"));
                    capturedevice.Close();
                    capturedevice = null;
                    BackgroundScanStart(view, interfacefriendlyname); //start passive monitoring
                }
                catch (PcapException ex)
                {
                    view.MainForm.Invoke(new Action(() => view.StatusLabel.Text = "Refresh for scan"));
                }
                catch (Exception ex)
                {

                }

            }).Start();
            #endregion
        }


        /// <summary>
        /// Actively monitor ARP packets for signs of new clients after GetAllClients active scan is done
        /// </summary>
        public static void BackgroundScanStart(IView view, string interfacefriendlyname)
        {
            try
            {
                view.MainForm.BeginInvoke(new Action(() => view.StatusLabel.Text = "Starting background scan..."));
                StopFlag = false;
                CalledFromToast = false;
                CalledFromSniffer = false;
                capturedevice = CaptureDeviceList.New()[NetStalker.Properties.Settings.Default.AdapterName];
                capturedevice.Open(DeviceMode.Promiscuous, 1000);
                capturedevice.Filter = "arp";


                IPAddress myipaddress = IPAddress.Parse(NetStalker.Properties.Settings.Default.localip);
                Size = NetStalker.Properties.Settings.Default.NetMask.Count(c => c == '0');
                var Root = GetRoot(myipaddress, Size);

                #region Sending ARP requests to probe for all possible IP addresses on LAN
                new Thread(() =>
                {
                    Thread.Sleep(5000);

                    view.PictureBox.BeginInvoke(new Action((() =>
                    {
                        view.PictureBox.Image = NetStalker.Properties.Resources.icons8_ok_96px;
                    })));
                    view.StatusLabel2.BeginInvoke(new Action(() => { view.StatusLabel2.Text = "Ready"; }));

                    view.MainForm.BeginInvoke(new Action(() =>
                    {
                        view.Tile.Enabled = true;
                        view.Tile2.Enabled = true;
                    }));
                    try
                    {
                        while (capturedevice != null && !StopFlag)
                        {

                            if (Size == 1)
                            {
                                if (!LoadingBarCalled)
                                {
                                    CallTheLoadingBar(view);
                                    view.MainForm.BeginInvoke(new Action(() => view.StatusLabel.Text = "Scanning..."));
                                }

                                for (int ipindex = 1; ipindex <= 255; ipindex++)
                                {
                                    ARPPacket arprequestpacket = new ARPPacket(ARPOperation.Request, PhysicalAddress.Parse("00-00-00-00-00-00"), IPAddress.Parse(Root + ipindex), capturedevice.MacAddress, myipaddress);
                                    EthernetPacket ethernetpacket = new EthernetPacket(capturedevice.MacAddress, PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"), EthernetPacketType.Arp);
                                    ethernetpacket.PayloadPacket = arprequestpacket;
                                    capturedevice.SendPacket(ethernetpacket);
                                    if (NetStalker.Properties.Settings.Default.SpoofProtection)
                                    {
                                        ARPPacket ArpPacketForGatewayProtection = new ARPPacket(ARPOperation.Request, capturedevice.MacAddress, myipaddress, GatewayMAC, GatewayIP);
                                        EthernetPacket EtherPacketForGatewayProtection = new EthernetPacket(GatewayMAC, capturedevice.MacAddress, EthernetPacketType.Arp);
                                        EtherPacketForGatewayProtection.PayloadPacket = ArpPacketForGatewayProtection;
                                        capturedevice.SendPacket(EtherPacketForGatewayProtection);
                                    }
                                }
                            }

                            else if (Size == 2)
                            {
                                if (!LoadingBarCalled)
                                {
                                    CallTheLoadingBar(view);
                                    view.MainForm.BeginInvoke(new Action(() => view.StatusLabel.Text = "Scanning..."));
                                }
                                for (int i = 1; i <= 255; i++)
                                {
                                    for (int j = 1; j <= 255; j++)
                                    {
                                        ARPPacket arprequestpacket = new ARPPacket(ARPOperation.Request, PhysicalAddress.Parse("00-00-00-00-00-00"), IPAddress.Parse(Root + i + '.' + j), capturedevice.MacAddress, myipaddress);//???
                                        EthernetPacket ethernetpacket = new EthernetPacket(capturedevice.MacAddress, PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"), EthernetPacketType.Arp);
                                        capturedevice.SendPacket(ethernetpacket);
                                        if (NetStalker.Properties.Settings.Default.SpoofProtection)
                                        {
                                            ARPPacket ArpPacketForGatewayProtection = new ARPPacket(ARPOperation.Request, capturedevice.MacAddress, myipaddress, GatewayMAC, GatewayIP);
                                            EthernetPacket EtherPacketForGatewayProtection = new EthernetPacket(GatewayMAC, capturedevice.MacAddress, EthernetPacketType.Arp);
                                            EtherPacketForGatewayProtection.PayloadPacket = ArpPacketForGatewayProtection;
                                            capturedevice.SendPacket(EtherPacketForGatewayProtection);
                                        }
                                    }
                                }
                            }

                            else if (Size == 3)
                            {
                                if (!LoadingBarCalled)
                                {
                                    CallTheLoadingBar(view);
                                    view.MainForm.BeginInvoke(new Action(() => view.StatusLabel.Text = "Scanning..."));

                                }
                                for (int i = 1; i <= 255; i++)
                                {
                                    for (int j = 1; j <= 255; j++)
                                    {
                                        for (int k = 1; k <= 255; k++)
                                        {
                                            ARPPacket arprequestpacket = new ARPPacket(ARPOperation.Request, PhysicalAddress.Parse("00-00-00-00-00-00"), IPAddress.Parse(Root + i + '.' + j + '.' + k), capturedevice.MacAddress, myipaddress);//???
                                            EthernetPacket ethernetpacket = new EthernetPacket(capturedevice.MacAddress, PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"), EthernetPacketType.Arp);
                                            ethernetpacket.PayloadPacket = arprequestpacket;
                                            capturedevice.SendPacket(ethernetpacket);
                                            if (NetStalker.Properties.Settings.Default.SpoofProtection)
                                            {
                                                ARPPacket ArpPacketForGatewayProtection = new ARPPacket(ARPOperation.Request, capturedevice.MacAddress, myipaddress, GatewayMAC, GatewayIP);
                                                EthernetPacket EtherPacketForGatewayProtection = new EthernetPacket(GatewayMAC, capturedevice.MacAddress, EthernetPacketType.Arp);
                                                EtherPacketForGatewayProtection.PayloadPacket = ArpPacketForGatewayProtection;
                                                capturedevice.SendPacket(EtherPacketForGatewayProtection);
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                    catch (PcapException ex)
                    {

                    }
                    catch (Exception ex)
                    {
                    }
                }).Start();
                #endregion

                #region Assign OnPacketArrival event handler and start capturing
                capturedevice.OnPacketArrival += (object sender, CaptureEventArgs e) =>
                {
                    if (StopFlag) { return; }
                    Packet packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
                    if (packet == null) { return; }
                    ARPPacket arppacket = (ARPPacket)packet.Extract(typeof(ARPPacket));

                    if (!clientlist.ContainsKey(arppacket.SenderProtocolAddress) && arppacket.SenderProtocolAddress.ToString() != "0.0.0.0" && areCompatibleIPs(arppacket.SenderProtocolAddress, myipaddress, Size))
                    {
                        clientlist.Add(arppacket.SenderProtocolAddress, arppacket.SenderHardwareAddress);
                        view.ListView1.Invoke(new Action(() =>
                        {
                            string mac = GetMACString(arppacket.SenderHardwareAddress);
                            string machineName = "";
                            int id = clientlist.Count - 1;
                            string ip = arppacket.SenderProtocolAddress.ToString();
                            var obj = new Device();
                            new Thread(() =>
                            {
                                try
                                {

                                    ipp = ip;

                                    IPHostEntry hostEntry = Dns.GetHostEntry(ip);

                                    view.ListView1.BeginInvoke(new Action(() =>
                                    {
                                        obj.DeviceName = hostEntry.HostName;
                                        view.ListView1.UpdateObject(obj);
                                    }));

                                }
                                catch (Exception ex)
                                {

                                    view.ListView1.BeginInvoke(new Action(() =>
                                    {
                                        obj.DeviceName = ip;
                                        view.ListView1.UpdateObject(obj);
                                    }));

                                }
                            }).Start();

                            new Thread(() =>
                            {
                                var Name = VendorAPI.GetVendorInfo(mac);
                                if (Name != null)
                                {
                                    obj.ManName = Name.data.organization_name;
                                }
                                else
                                {
                                    obj.ManName = "";
                                }
                                view.ListView1.UpdateObject(obj);
                            }).Start();

                            obj.IP = arppacket.SenderProtocolAddress;
                            obj.MAC = PhysicalAddress.Parse(mac.Replace(":", ""));
                            obj.DeviceName = "Resolving";
                            obj.ManName = "Getting information...";
                            obj.DeviceStatus = "Online";
                            view.ListView1.AddObject(obj);

                        }));
                        view.MainForm.Invoke(new Action(() => view.StatusLabel.Text = clientlist.Count + " device(s) found"));

                    }
                };

                capturedevice.StartCapture();

                view.MainForm.Invoke(new Action(() => view.StatusLabel.Text = clientlist.Count + " device(s) found"));

                #endregion

            }
            catch (Exception ex)
            {
            }
        }



        /// <summary>
        /// Stops any ongoing capture and closes capturedevice if open
        /// </summary>
        public static void CloseAllCaptures(IView view = null)
        {
            try
            {
                capturedevice.StopCapture();
                capturedevice.OnPacketArrival += null;
                capturedevice.Close();
                StopFlag = true;
                if (view != null && LoadingBarCalled)
                {
                    StopTheLoadingBar(view);
                }


            }
            catch { }
        }

        public static void CloseAllCapturesForLimiter(IView view)
        {
            try
            {
                capturedevice.StopCapture();
                capturedevice.OnPacketArrival += null;
                StopFlag = true;
                StopTheLoadingBar(view);
            }
            catch { }
        }



        /// <summary>
        /// Converts a PhysicalAddress to colon delimited string like FF:FF:FF:FF:FF:FF
        /// </summary>
        /// <param name="physicaladdress"></param>
        /// <returns></returns>
        public static string GetMACString(PhysicalAddress physicaladdress)
        {
            try
            {
                string retval = "";
                for (int i = 0; i <= 5; i++)
                    retval += physicaladdress.GetAddressBytes()[i].ToString("X2") + ":";
                return retval.Substring(0, retval.Length - 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        /// <summary>
        /// Calculate the network size
        /// </summary>
        /// <param name="ipaddress"></param>
        /// <returns></returns>
        public static string GetRoot(IPAddress IP, int Mask)
        {
            var ip = IP.ToString();
            switch (Mask)
            {
                case 1:
                    {
                        return ip.Substring(0, ip.LastIndexOf('.') + 1);
                    }

                case 2:
                    {
                        return ip.Substring(0, ip.IndexOf('.') + 5);
                    }

                case 3:
                    {
                        return ip.Substring(0, ip.IndexOf('.') + 1);
                    }
            }

            return "";
        }

        public static void CallTheLoadingBar(IView view)
        {
            if (view.LoadingBar.InvokeRequired)
            {
                view.LoadingBar.BeginInvoke(new Action(() =>
                {
                    view.LoadingBar.Enabled = true;
                    view.LoadingBar.Show();
                    LoadingBarCalled = true;

                }));
            }
            else
            {
                view.LoadingBar.Enabled = true;
                view.LoadingBar.Show();
                LoadingBarCalled = true;

            }
        }

        public static void StopTheLoadingBar(IView view)
        {
            if (view.LoadingBar.InvokeRequired)
            {
                view.LoadingBar.BeginInvoke(new Action(() =>
                {
                    view.LoadingBar.Enabled = false;
                    view.LoadingBar.Visible = false;
                    view.LoadingBar.Hide();
                    LoadingBarCalled = false;


                }));
            }
            else
            {
                view.LoadingBar.Enabled = false;
                view.LoadingBar.Visible = false;
                view.LoadingBar.Hide();
                LoadingBarCalled = false;

            }

        }


        /// <summary>
        /// Converts say 192.168.1.4 to 192.168.1.
        /// </summary>
        /// <param name="ipaddress"></param>
        /// <returns></returns>
        public static string GetRootIp(IPAddress ipaddress)
        {
            string ipaddressstring = ipaddress.ToString();
            return ipaddressstring.Substring(0, ipaddressstring.LastIndexOf(".") + 1);
        }


        /// <summary>
        /// Converts say 192.168.1.4 to 192.168.1.
        /// </summary>
        /// <param name="ipaddress"></param>
        /// <returns></returns>
        public static string GetRootIp(string ipaddress)
        {

            return ipaddress.Substring(0, ipaddress.LastIndexOf(".") + 1);
        }

        /// <summary>
        /// Checks if both IPAddresses have the same root ip
        /// </summary>
        /// <param name="ip1"></param>
        /// <param name="ip2"></param>
        /// <returns></returns>
        public static bool areCompatibleIPs(IPAddress ip1, IPAddress ip2)
        {
            return (GetRootIp(ip1) == GetRootIp(ip2)) ? true : false;
        }


        public static bool areCompatibleIPs(IPAddress ip1, IPAddress ip2, int size)
        {
            return (GetRoot(ip1, size) == GetRoot(ip2, size)) ? true : false;
        }
    }
}

