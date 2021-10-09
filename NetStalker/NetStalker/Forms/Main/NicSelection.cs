using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Net;
using NetStalker.MainLogic;
using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace NetStalker
{
    public partial class NicSelection : Form
    {
        #region Instance Fields

        private NetworkInterface SelectedInterface;
        private string FriendlyName;

        #endregion

        #region Static Fields

        private static List<NetworkInterface> Nics = new List<NetworkInterface>();

        #endregion

        #region Window Config

        /// <summary>
        /// Apply the Windows dark mode settings to the window.
        /// See <see href="https://stackoverflow.com/questions/57124243/winforms-dark-title-bar-on-windows-10">Stackoverflow</see>, <see href="https://docs.microsoft.com/en-us/windows/win32/api/dwmapi/ne-dwmapi-dwmwindowattribute">MS Docs</see> and <see href="https://docs.microsoft.com/en-us/windows/win32/com/structure-of-com-error-codes">MS Docs 2</see>
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleCreated(EventArgs e)
        {
            if (Properties.Settings.Default.DarkMode)
            {
                if (NativeMethods.DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0) //0 means S_OK 
                    NativeMethods.DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
            }
        }

        #endregion

        #region Constructor

        public NicSelection()
        {
            InitializeComponent();
            OkButton.Enabled = false;
            AdapterComboBox.Items.Add("Select an adapter");
            AdapterComboBox.SelectedIndex = 0;
        }

        #endregion

        #region Tools

        /// <summary>
        /// Populates the list of available network cards.
        /// </summary>
        public void GetNics()
        {
            foreach (var net in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (net.OperationalStatus == OperationalStatus.Up && net.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    Nics.Add(net);
                }
            }
        }

        /// <summary>
        /// Returns the name of the connected network.
        /// </summary>
        /// <param name="neti"></param>
        /// <returns></returns>
        public static string GetConnectedNetworks(NetworkInterface neti)
        {
            var connectedNet = NetworkListManager.GetNetworks(NetworkConnectivityLevels.Connected);

            foreach (var net in connectedNet)
            {
                foreach (var conn in net.Connections)
                {
                    if (conn.AdapterId == Guid.Parse(neti.Id))
                    {
                        return net.Name;
                    }
                }

            }
            return "";
        }

        /// <summary>
        /// Returns the details for the selected network interface.
        /// </summary>
        /// <param name="FriendlyName"></param>
        /// <param name="selectedInterface"></param>
        public static void NetDetails(string FriendlyName, ref NetworkInterface selectedInterface)
        {
            foreach (var net in Nics)
            {
                if (net.Name == FriendlyName && net.NetworkInterfaceType != NetworkInterfaceType.Loopback && net.OperationalStatus == OperationalStatus.Up)
                {
                    selectedInterface = net;
                    return;
                }
            }

        }

        #endregion

        #region Form Handlers

        private void NicSelection_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.DarkMode)
            {
                this.BackColor = Color.FromArgb(51, 51, 51);
                this.ForeColor = Color.White;

                foreach (Control control in Controls)
                {
                    if (control.GetType() == typeof(Button))
                    {
                        var btn = control as Button;
                        btn.FlatAppearance.BorderColor = Color.FromArgb(51, 51, 51);
                        btn.BackColor = Color.FromArgb(51, 51, 51);
                        btn.ForeColor = Color.White;
                    }
                    else
                    {
                        control.BackColor = Color.FromArgb(51, 51, 51);
                        control.ForeColor = Color.White;
                    }
                }
            }

            Main m = Application.OpenForms["Main"] as Main;

            //Open the registry, show the License Agreement dialog if it's not accepted,
            //then check for the Npcap driver and display an error dialog if it's not installed,
            //otherwise grab the driver version and show it.
            var Root = Registry.CurrentUser;
            RegistryKey Key = Root.OpenSubKey("Software", true).CreateSubKey("hSmNz");

            if (Key != null)
            {
                #region License agreement

                if (string.IsNullOrEmpty((string)Key.GetValue("Des")) || (string)Key.GetValue("Des") != "True")
                {
                    LicenseAgreement la = new LicenseAgreement();

                    if (la.ShowDialog() == DialogResult.Yes)
                    {
                        Key.SetValue("Des", "True");
                    }
                    else
                    {
                        Key.SetValue("Des", "False");
                        Key.Close();
                        Application.Exit();
                    }
                }

                #endregion

                #region Password check

                if (!string.IsNullOrEmpty((string)Key.GetValue("IsSNG")) && (string)Key.GetValue("IsSNG") == "True")
                {
                    Key.Close();

                    PasswordCheck pass = new PasswordCheck();
                    pass.ShowDialog();
                }

                #endregion

                #region Npcap driver check

                string ver = null;

                if (!Environment.Is64BitOperatingSystem)
                {
                    using (RegistryKey np = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Npcap", false))
                    {
                        //Get Npcap installation path
                        if (np != null)
                        {
                            var InstallationPath = np.GetValue(string.Empty) as string;

                            if (!string.IsNullOrEmpty(InstallationPath))
                            {
                                ver = FileVersionInfo.GetVersionInfo(Path.Combine(InstallationPath, "NPFInstall.exe")).FileVersion;

                                DriverValue.Text = ver;
                            }
                        }
                    }
                }
                else
                {
                    using (RegistryKey np = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Npcap", false))
                    {
                        //Get Npcap installation path
                        if (np != null)
                        {
                            var InstallationPath = np.GetValue(string.Empty) as string;

                            if (!string.IsNullOrEmpty(InstallationPath))
                            {
                                ver = FileVersionInfo.GetVersionInfo(Path.Combine(InstallationPath, "NPFInstall.exe")).FileVersion;

                                DriverValue.Text = ver;
                            }
                        }
                    }
                }

                if (string.IsNullOrEmpty(ver))
                {
                    var verError = new ErrorForm();
                    verError.ShowDialog();
                }

                #endregion
            }

            GetNics();

            //Populate the combo box with the available network interfaces
            foreach (var nic in Nics)
            {
                AdapterComboBox.Items.Add(nic.Name);
            }
        }

        #endregion

        #region Button Event Handlers

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            //Save the main app configuration values
            Properties.Settings.Default.FriendlyName = FriendlyName;
            Properties.Settings.Default.Gateway =
                GatewayValue.Text;
            Properties.Settings.Default.LocalIp =
                IPValue.Text;
            Properties.Settings.Default.LocalMac =
              SelectedInterface.GetPhysicalAddress().ToString();

            Properties.Settings.Default.AdapterName = (from devicex in CaptureDeviceList.Instance
                                                       where ((LibPcapLiveDevice)devicex).Interface.FriendlyName == FriendlyName
                                                       select devicex).ToList()[0].Name;

            Properties.Settings.Default.BroadcastAddress = Tools.GetBroadcastAddress(IPAddress.Parse(Properties.Settings.Default.LocalIp), Properties.Settings.Default.NetMask).ToString();

            Properties.Settings.Default.Save();

            Close();
        }

        #endregion

        #region AdapterComboBox Event Handlers

        private void AdapterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FriendlyName = AdapterComboBox.SelectedItem.ToString();
            SelectedInterface = Nics.FirstOrDefault(x => x.Name == FriendlyName);

            if (SelectedInterface != null)
            {
                NICValue.Text = SelectedInterface?.NetworkInterfaceType.ToString() ?? "Error";

                //Show local IP
                foreach (var IP in SelectedInterface.GetIPProperties().UnicastAddresses)
                {
                    if (IP.Address.AddressFamily == AddressFamily.InterNetwork) //Grab the IPV4 address of the selected NIC
                    {
                        IPValue.Text = IP?.Address?.ToString() ?? "";
                        Properties.Settings.Default.NetMask = IP.IPv4Mask.ToString();
                        Properties.Settings.Default.NetSize = IP.IPv4Mask.ToString().Count(c => c == '0');
                        break;
                    }
                }

                //Show local MAC
                MACValue.Text = SelectedInterface
                    .GetPhysicalAddress()?
                    .ToString().Insert(2, "-").Insert(5, "-").Insert(8, "-").Insert(11, "-").Insert(14, "-") ?? "";

                //Show gateway IP
                GatewayIPAddressInformationCollection addresses = null;

                if ((addresses = SelectedInterface.GetIPProperties().GatewayAddresses).Count == 0)
                {
                    GatewayValue.Text = "";
                    OkButton.Enabled = false;
                }
                else
                {
                    foreach (var gateway in addresses)
                    {
                        if (gateway.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            GatewayValue.Text = gateway?.Address?.ToString() ?? "";
                            OkButton.Enabled = true;
                            break;
                        }
                    }
                }

                //Show connected wireless network (if there is one)
                if (SelectedInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    SSIDValue.Text = GetConnectedNetworks(SelectedInterface) ?? "";
                }
                else
                {
                    SSIDValue.Text = "";
                }
            }
            else
            {
                NICValue.Text = "";
                IPValue.Text = "";
                MACValue.Text = "";
                GatewayValue.Text = "";
                SSIDValue.Text = "";
                OkButton.Enabled = false;
            }
        }

        #endregion
    }
}