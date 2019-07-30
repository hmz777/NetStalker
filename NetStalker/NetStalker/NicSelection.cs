using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using CSArp;
using MaterialSkin;
using MaterialSkin.Controls;
using MetroFramework.Controls;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Net;

namespace NetStalker
{
    public partial class NicSelection : MaterialForm
    {
        private NetworkInterface selectedInterface;
        private string friendlyname;
        private static List<NetworkInterface> Nics = new List<NetworkInterface>();
        private Controller _controller;
        private MaterialSkinManager materialSkinManager;
        private Main m;

        public NicSelection()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey800, Primary.Grey700, Primary.Grey900, Accent.Teal700, TextShade.WHITE);
            _controller = new Controller();
            materialFlatButton1.Enabled = false;

        }

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

        private void NicSelection_Load(object sender, EventArgs e)
        {
            m = Application.OpenForms["Main"] as Main;
            if (Properties.Settings.Default.color == "Dark")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                m.textOverlay.BackColor = Color.FromArgb(71, 71, 71);
                m.textOverlay.TextColor = Color.FromArgb(204, 204, 204);
                m.textOverlay.BorderColor = Color.Teal;
                m.pictureBox2.Image = NetStalker.Properties.Resources._30G;

            }
            else
            {
                m.textOverlay.BorderColor = Color.Teal;
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                m.fastObjectListView1.HeaderFormatStyle = m.LightHeaders;
                m.fastObjectListView1.HotItemStyle = m.LightHot;
                m.textOverlay.BackColor = Color.FromArgb(204, 204, 204);
                m.textOverlay.TextColor = Color.FromArgb(71, 71, 71);
                m.fastObjectListView1.BackColor = Color.White;
                m.fastObjectListView1.ForeColor = Color.FromArgb(54, 54, 54);
                m.fastObjectListView1.SelectedBackColor = Color.FromArgb(214, 214, 214);
                m.fastObjectListView1.SelectedForeColor = Color.FromArgb(51, 51, 51);
                m.fastObjectListView1.UnfocusedSelectedBackColor = Color.FromArgb(71, 71, 71);
                m.fastObjectListView1.UnfocusedSelectedForeColor = Color.FromArgb(204, 204, 204);
                m.pictureBox2.Image = NetStalker.Properties.Resources._30W;
            }

            if (Properties.Settings.Default.minimize == "Tray")
            {
                m.Resize += m.Main_Resize;
                m.resizestate = "Tray";
            }
            else
            {
                m.Resize -= m.Main_Resize;
                m.resizestate = "Taskbar";
            }

            var root = Registry.CurrentUser;
            RegistryKey reg1 = root.OpenSubKey("Software", true).CreateSubKey("hSmNz");
            if (reg1 != null)
            {
                if (string.IsNullOrEmpty((string)reg1.GetValue("Des")) || (string)reg1.GetValue("Des") != "True")
                {
                    LicenseAgreement la = new LicenseAgreement();
                    if (la.ShowDialog() == DialogResult.Yes)
                    {
                        reg1.SetValue("Des", "True");
                    }
                    else
                    {
                        reg1.SetValue("Des", "False");
                        reg1.Close();
                        root.Close();
                        Application.Exit();
                    }

                }

                RegistryKey winpcapkey = null;
                if (Environment.Is64BitOperatingSystem)
                {
                    winpcapkey =
                       Registry.LocalMachine.OpenSubKey(
                           @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\WinPcapInst");
                }
                else
                {
                    winpcapkey =
                        Registry.LocalMachine.OpenSubKey(
                            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\WinPcapInst");
                }


                if (winpcapkey != null)
                {
                    string ver = (string)winpcapkey.GetValue("DisplayName");
                    if (!string.IsNullOrEmpty(ver))
                    {
                        materialLabel3.Text = ver;
                        winpcapkey.Close();
                    }
                }
                else
                {
                    try
                    {
                       
                        ErrorForm EF = new ErrorForm();
                        EF.ShowDialog();
                    }
                    catch (Exception exception)
                    {

                    }

                }



                if (!string.IsNullOrEmpty((string)reg1.GetValue("IsSNG")) && (string)reg1.GetValue("IsSNG") == "True")
                {
                    reg1.Close();
                    root.Close();
                    PasswordCheck pass = new PasswordCheck();
                    pass.ShowDialog();
                }


            }

            GetNics();
            foreach (var nic in Nics)
            {
                comboBox1.Items.Add(nic.Name);
            }

        }

        public static void NetDetails(string friendlyname, ref NetworkInterface selectedInterface)
        {
            foreach (var net in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (net.Name == friendlyname && net.NetworkInterfaceType != NetworkInterfaceType.Loopback && net.OperationalStatus == OperationalStatus.Up)
                {
                    selectedInterface = net;
                    break;
                }
            }

        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            friendlyname = comboBox1.SelectedItem.ToString();
            selectedInterface = Nics.FirstOrDefault(x => x.Name == friendlyname);

            materialLabel10.Text = selectedInterface.NetworkInterfaceType.ToString();


            foreach (var IP in selectedInterface.GetIPProperties().UnicastAddresses)
            {
                if (IP.Address.AddressFamily == AddressFamily.InterNetwork)
                {
                    materialLabel4.Text = IP.Address.ToString();
                    Properties.Settings.Default.NetMask = IP.IPv4Mask.ToString();
                    Properties.Settings.Default.NetSize = IP.IPv4Mask.ToString().Count(c => c == '0');
                    break;
                }
            }

            if (string.IsNullOrEmpty(materialLabel4.Text))
            {
                materialLabel4.Text = "";
            }

            if (!string.IsNullOrWhiteSpace(selectedInterface.GetPhysicalAddress().ToString()))
            {
                materialLabel5.Text = selectedInterface.GetPhysicalAddress().ToString().Insert(2, "-").Insert(5, "-").Insert(8, "-").Insert(11, "-").Insert(14, "-");
            }
            else
            {
                materialLabel5.Text = "";
            }

            foreach (var gateway in selectedInterface.GetIPProperties().GatewayAddresses)
            {
                if (gateway.Address.AddressFamily == AddressFamily.InterNetwork)
                {
                    materialLabel7.Text = gateway.Address.ToString();
                    materialFlatButton1.Enabled = true;
                    break;
                }
            }

            if (string.IsNullOrEmpty(materialLabel7.Text))
            {
                materialLabel7.Text = "No Gateway!";
                materialFlatButton1.Enabled = false;
            }

            if (selectedInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
            {
                string net = GetConnectedNetworks(selectedInterface);

                if (!string.IsNullOrWhiteSpace(net))
                {
                    materialLabel12.Text = net;
                }
            }
            else
            {
                materialLabel12.Text = "";
            }



        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.friendlyname = friendlyname;
            Properties.Settings.Default.Gateway =
                materialLabel7.Text;
            Properties.Settings.Default.localip =
                materialLabel4.Text;
            Properties.Settings.Default.gatewaymac = selectedInterface.GetPhysicalAddress().ToString();
            this.Close();

        }

        private void ComboBox1_DrawItem(object sender, DrawItemEventArgs e) //Test
        {

            if (e.Index != -1)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                e.Graphics.FillRectangle(Brushes.DimGray, e.Bounds);
                e.Graphics.DrawString(Nics[e.Index].Name, new Font("Roboto", 9), Brushes.LightGray,
                    new Point(Properties.Resources.icons8_network_card_16.Width * 2, e.Bounds.Y));
                e.Graphics.DrawImage(Properties.Resources.icons8_network_card_16, new Point(e.Bounds.X, e.Bounds.Y));

                if ((e.State & DrawItemState.Focus) == 0)
                {
                    e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                    e.Graphics.DrawString(Nics[e.Index].Name, new Font("Roboto", 9), Brushes.DimGray,
                        new Point(Properties.Resources.icons8_network_card_16.Width * 2, e.Bounds.Y));
                    e.Graphics.DrawImage(Properties.Resources.icons8_network_card_16, new Point(e.Bounds.X, e.Bounds.Y));
                }
            }


        }
    }
}
