using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BrightIdeasSoftware;
using MaterialSkin;
using MaterialSkin.Controls;
using MetroFramework;
using Microsoft.WindowsAPICodePack.Dialogs;
using PacketDotNet;
using SharpPcap;

namespace NetStalker
{
    public partial class Sniffer : MaterialForm
    {
        [DllImport("user32.dll")]
        internal static extern int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("user32.dll")]
        internal static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

        [DllImport("user32.dll")]
        internal static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        public enum ScrollbarDirection
        {
            Horizontal = 0,
            Vertical = 1,
        }

        private enum Messages
        {
            WM_HSCROLL = 0x0114,
            WM_VSCROLL = 0x0115
        }

        private ICaptureDevice capturedevice;
        private string Target;
        private string targetmac;
        List<AcceptedPacket> ListofAcceptedPackets = new List<AcceptedPacket>();

        private bool snifferStarted;
        private ContextMenu menu;
        private TextOverlay textOverlay;
        private bool viewerExtended;
        private bool ResizeDone;
        private string gatewayIP;
        private string gatewayMAC;
        private PhysicalAddress GatewayMAC;
        private PhysicalAddress TargetMAC;
        private bool IsLocalDeviceSniffing;
        private bool StopFlag;
        private bool CaptureDeviceConfigured;
        private IPAddress TargetIP;

        public Sniffer(string target, string mac, string gatewaymac, string gatewayip, Loading loading)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            gatewayIP = gatewayip;
            gatewayMAC = gatewaymac;
            GatewayMAC = PhysicalAddress.Parse(gatewaymac.Replace(":", ""));
            TargetMAC = PhysicalAddress.Parse(mac.Replace(":", ""));
            TargetIP = IPAddress.Parse(target);

            olvColumn7.AspectGetter = delegate (object rowObject)
            {
                try
                {
                    AcceptedPacket packet = rowObject as AcceptedPacket;
                    if ((packet != null && (string.IsNullOrEmpty(packet.Host) && packet.Source.ToString() == Target) || packet.Host == "Not found"))//null reference on sniffer close
                    {
                        return "Resolve";
                    }

                    return null;
                }
                catch (Exception)
                {

                }
                return null;
            };


            textOverlay = this.materialListView1.EmptyListMsgOverlay as TextOverlay;
            menu = new ContextMenu(new MenuItem[] { new MenuItem("Show Packet", ShowPacket), });
            Target = target;
            targetmac = mac;
            olvColumn1.ImageGetter = delegate (object rowObject)
            {
                var Packet = rowObject as AcceptedPacket;
                try
                {
                    if (Packet.Source.ToString() == Target)
                    {
                        return "request";
                    }
                    else
                    {
                        return "response";
                    }
                }
                catch (Exception)
                {
                    return "";
                }

            };
        }

        private void ShowPacket(object sender, EventArgs e)
        {
            var packet = materialListView1.SelectedObject as AcceptedPacket;


            if (packet.TCPPacket != null && packet.Type == "HTTP")
            {
                metroTextBox1.Clear();

                if (packet.TCPPacket.Header != null)
                {
                    metroTextBox1.Text += "-----------------HTTPHeader-----------------" + Environment.NewLine;
                    metroTextBox1.Text += Environment.NewLine + "UTF8:" + Environment.NewLine;
                    metroTextBox1.Text += Encoding.UTF8.GetString(packet.TCPPacket.PayloadData) + Environment.NewLine;
                    metroTextBox1.Text += Environment.NewLine;
                    metroTextBox1.Text += Environment.NewLine;
                    metroTextBox1.Text += Environment.NewLine + "ASCII:" + Environment.NewLine;
                    metroTextBox1.Text += Encoding.ASCII.GetString(packet.TCPPacket.PayloadData) + Environment.NewLine;
                    metroTextBox1.Text += Environment.NewLine;
                    metroTextBox1.Text += Environment.NewLine;
                }

                metroTextBox1.Text += Environment.NewLine + "==================================================" + Environment.NewLine;

                if (packet.TCPPacket.PayloadData != null)
                {
                    metroTextBox1.Text += "-----------------TCPPayload-----------------" + Environment.NewLine;
                    metroTextBox1.Text += Environment.NewLine + "UTF8:" + Environment.NewLine;
                    metroTextBox1.Text += Encoding.UTF8.GetString(packet.TCPPacket.PayloadData) + Environment.NewLine;
                    metroTextBox1.Text += Environment.NewLine + "ASCII:" + Environment.NewLine;
                    metroTextBox1.Text += Encoding.ASCII.GetString(packet.TCPPacket.PayloadData) + Environment.NewLine;
                    metroTextBox1.Text += Environment.NewLine;
                    metroTextBox1.Text += Environment.NewLine;
                }

                metroTextBox1.Text += Environment.NewLine + "==================================================" + Environment.NewLine;
                metroTextBox1.Text += "-----------------TCP-PacketProperties-----------------" + Environment.NewLine;
                metroTextBox1.Text += $"Packet Length: {packet.Packet.Bytes.Length}" + Environment.NewLine;
                metroTextBox1.Text += $"Packet TimeStamp: {packet.Time}" + Environment.NewLine;
                metroTextBox1.Text += $"IPV4 Packet Identification: {packet.ID}" + Environment.NewLine;
                metroTextBox1.Text += $"IPV4 Protocol: {packet.Protocol}" + Environment.NewLine;
                metroTextBox1.Text += $"IPV4 Source IP: {packet.Source}" + Environment.NewLine;
                metroTextBox1.Text += $"IPV4 Destination IP: {packet.Destination}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Window Size: {packet.TCPPacket.WindowSize}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Acknowledgment Number: {packet.TCPPacket.AcknowledgmentNumber}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Sequence Number: {packet.TCPPacket.SequenceNumber}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Header Length: {packet.TCPPacket.Header.Length}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Payload Length: {packet.TCPPacket.PayloadData.Length}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Source Port: {packet.TCPPacket.SourcePort}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Destination Port: {packet.TCPPacket.DestinationPort}" + Environment.NewLine;

            }
            else if (packet.TCPPacket != null && packet.Type == "HTTPS")
            {
                metroTextBox1.Clear();
                metroTextBox1.Text += "-----------------TCP-PacketProperties-----------------" + Environment.NewLine;
                metroTextBox1.Text += $"Packet Length: {packet.Packet.Bytes.Length}" + Environment.NewLine;
                metroTextBox1.Text += $"Packet TimeStamp: {packet.Time}" + Environment.NewLine;
                metroTextBox1.Text += $"IPV4 Packet Identification: {packet.ID}" + Environment.NewLine;
                metroTextBox1.Text += $"IPV4 Protocol: {packet.Protocol}" + Environment.NewLine;
                metroTextBox1.Text += $"IPV4 Source IP: {packet.Source}" + Environment.NewLine;
                metroTextBox1.Text += $"IPV4 Destination IP: {packet.Destination}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Window Size: {packet.TCPPacket.WindowSize}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Acknowledgment Number: {packet.TCPPacket.AcknowledgmentNumber}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Sequence Number: {packet.TCPPacket.SequenceNumber}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Header Length: {packet.TCPPacket.Header.Length}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Payload Length: {packet.TCPPacket.PayloadData.Length}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Source Port: {packet.TCPPacket.SourcePort}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Destination Port: {packet.TCPPacket.DestinationPort}" + Environment.NewLine;
                metroTextBox1.Text += Environment.NewLine;
                metroTextBox1.Text += Environment.NewLine;



            }
            else if (packet.UDPPacket != null)
            {
                metroTextBox1.Clear();
                metroTextBox1.Text += "-----------------UDP-PacketProperties-----------------" + Environment.NewLine;
                metroTextBox1.Text += $"Packet Length: {packet.Packet.Bytes.Length}" + Environment.NewLine;
                metroTextBox1.Text += $"Packet TimeStamp: {packet.Time}" + Environment.NewLine;
                metroTextBox1.Text += $"IPV4 Packet Identification: {packet.ID}" + Environment.NewLine;
                metroTextBox1.Text += $"IPV4 Protocol: {packet.Protocol}" + Environment.NewLine;
                metroTextBox1.Text += $"IPV4 Source IP: {packet.Source}" + Environment.NewLine;
                metroTextBox1.Text += $"IPV4 Destination IP: {packet.Destination}" + Environment.NewLine;
                metroTextBox1.Text += $"UDP Packet Header Length: {packet.UDPPacket.Header.Length}" + Environment.NewLine;
                metroTextBox1.Text += $"UDP Packet Payload Length: {packet.UDPPacket.PayloadData.Length}" + Environment.NewLine;
                metroTextBox1.Text += $"UDP Packet Source Port: {packet.UDPPacket.SourcePort}" + Environment.NewLine;
                metroTextBox1.Text += $"UDP Packet Destination Port: {packet.UDPPacket.DestinationPort}" + Environment.NewLine;
                metroTextBox1.Text += Environment.NewLine;
                metroTextBox1.Text += Environment.NewLine;

            }

        }

        public static int GetScrollPosition(IntPtr hWnd, ScrollbarDirection direction)
        {
            return GetScrollPos(hWnd, (int)direction);
        }

        public static void GetScrollPosition(IntPtr hWnd, out int horizontalPosition, out int verticalPosition)
        {
            horizontalPosition = GetScrollPos(hWnd, (int)ScrollbarDirection.Horizontal);
            verticalPosition = GetScrollPos(hWnd, (int)ScrollbarDirection.Vertical);
        }

        public static void SetScrollPosition(IntPtr hwnd, int hozizontalPosition, int verticalPosition)
        {
            SetScrollPosition(hwnd, ScrollbarDirection.Horizontal, hozizontalPosition);
            SetScrollPosition(hwnd, ScrollbarDirection.Vertical, verticalPosition);
        }

        public static void SetScrollPosition(IntPtr hwnd, ScrollbarDirection direction, int position)
        {
            //move the scroll bar
            SetScrollPos(hwnd, (int)direction, position, true);

            //convert the position to the windows message equivalent
            IntPtr msgPosition = new IntPtr((position << 16) + 4);
            Messages msg = (direction == ScrollbarDirection.Horizontal) ? Messages.WM_HSCROLL : Messages.WM_VSCROLL;
            SendMessage(hwnd, (int)msg, msgPosition, IntPtr.Zero);
        }

        private void Sniffer_Load(object sender, EventArgs e)
        {


            metroTextBox2.Text += "Targeting: " + Target + Environment.NewLine;
            if (Target == Properties.Settings.Default.localip)
            {
                IsLocalDeviceSniffing = true;
            }

            metroTextBox1.UseCustomBackColor = true;
            metroTextBox1.UseCustomForeColor = true;
            metroTextBox1.Style = MetroColorStyle.Custom;
            metroTextBox2.UseCustomForeColor = true;
            metroTextBox2.UseCustomBackColor = true;
            metroTextBox2.Style = MetroColorStyle.Custom;

            if (Properties.Settings.Default.color == "Light")
            {
                metroTextBox1.BackColor = Color.WhiteSmoke;
                metroTextBox2.BackColor = Color.WhiteSmoke;
                metroTextBox1.ForeColor = Color.Black;
                metroTextBox2.ForeColor = Color.Black;
                textOverlay.BackColor = Color.FromArgb(204, 204, 204);
                textOverlay.TextColor = Color.FromArgb(71, 71, 71);
                materialListView1.BackColor = Color.WhiteSmoke;
                materialListView1.HeaderFormatStyle = LightHeaders;
                materialListView1.HotItemStyle = LightHot;
                materialListView1.ForeColor = Color.FromArgb(54, 54, 54);
                materialListView1.SelectedBackColor = Color.FromArgb(214, 214, 214);
                materialListView1.SelectedForeColor = Color.FromArgb(51, 51, 51);
                materialListView1.UnfocusedSelectedBackColor = Color.FromArgb(71, 71, 71);
                materialListView1.UnfocusedSelectedForeColor = Color.FromArgb(204, 204, 204);
                textOverlay.BorderColor = Color.Teal;
                metroToolTip1.Theme = MetroThemeStyle.Light;


            }
            else if (Properties.Settings.Default.color == "Dark")
            {
                textOverlay.BackColor = Color.FromArgb(71, 71, 71);
                textOverlay.TextColor = Color.FromArgb(204, 204, 204);
                textOverlay.BorderColor = Color.Teal;
                metroToolTip1.Theme = MetroThemeStyle.Dark;

            }
            else
            {
                metroTextBox1.BackColor = Color.WhiteSmoke;
                metroTextBox2.BackColor = Color.WhiteSmoke;
                metroTextBox1.ForeColor = Color.Black;
                metroTextBox2.ForeColor = Color.Black;
                textOverlay.BackColor = Color.FromArgb(204, 204, 204);
                textOverlay.TextColor = Color.FromArgb(71, 71, 71);
                materialListView1.BackColor = Color.WhiteSmoke;
                materialListView1.HeaderFormatStyle = LightHeaders;
                materialListView1.HotItemStyle = LightHot;
                materialListView1.ForeColor = Color.FromArgb(54, 54, 54);
                materialListView1.SelectedBackColor = Color.FromArgb(214, 214, 214);
                materialListView1.SelectedForeColor = Color.FromArgb(51, 51, 51);
                materialListView1.UnfocusedSelectedBackColor = Color.FromArgb(71, 71, 71);
                materialListView1.UnfocusedSelectedForeColor = Color.FromArgb(204, 204, 204);
                textOverlay.BorderColor = Color.Teal;
                metroToolTip1.Theme = MetroThemeStyle.Light;
            }

            textOverlay.Font = new Font("Roboto", 25);

            new Thread(() => { GetReady(); }).Start();

            var main = Application.OpenForms["Main"] as Main;
            main.loading.BeginInvoke(new Action(() => { main.loading.Close(); }));

            this.Activate();

        }

        public void GetReady()
        {
            if (!CaptureDeviceConfigured)
            {
                metroTextBox2.BeginInvoke(new Action(() =>
                {
                    metroTextBox2.Text += "Preparing network adapter..." + Environment.NewLine;
                }));

                CaptureDeviceList capturedevicelist = CaptureDeviceList.Instance;
                capturedevicelist.Refresh();
                capturedevice = CaptureDeviceList.New()[NetStalker.Properties.Settings.Default.AdapterName];
                CaptureDeviceConfigured = true;

                metroTextBox2.BeginInvoke(new Action(() =>
                {
                    metroTextBox2.Text += "Ready" + Environment.NewLine;
                }));

            }
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {

            if (snifferStarted)
            {
                MetroMessageBox.Show(this, "Operation already started!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (CaptureDeviceConfigured)
            {
                materialListView1.EmptyListMsg = "Working...";

                try
                {
                    snifferStarted = true;
                    if (capturedevice != null)
                    {
                        capturedevice.Open(DeviceMode.Promiscuous, 1000);

                        if (!IsLocalDeviceSniffing)
                        {
                            capturedevice.Filter = $"(tcp port 80 and (((ip[2:2] - ((ip[0]&0xf)<<2)) - ((tcp[12]&0xf0)>>2)) != 0) and (ether src {targetmac.ToLower()} or (dst net {Target}))) or (tcp port 443 and (((ip[2:2] - ((ip[0]&0xf)<<2)) - ((tcp[12]&0xf0)>>2)) != 0) and (ether src {targetmac.ToLower()} or (dst net {Target})))";
                        }
                        else
                        {
                            capturedevice.Filter = $"(tcp port 80 and (((ip[2:2] - ((ip[0]&0xf)<<2)) - ((tcp[12]&0xf0)>>2)) != 0) and (ether src {targetmac.ToLower()} or (dst net {Target}))) or (tcp port 443 and (((ip[2:2] - ((ip[0]&0xf)<<2)) - ((tcp[12]&0xf0)>>2)) != 0) and (ether src {targetmac.ToLower()} or (dst net {Target})))";

                        }

                        if (!IsLocalDeviceSniffing)
                        {
                            new Thread(() => { StartSniffer(); }).Start();
                        }
                        else
                        {
                            capturedevice.OnPacketArrival += CapturedeviceOnOnPacketArrival;
                            capturedevice.StartCapture();
                        }
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "No Capture Device is selected!", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception exception)
                {
                    MetroMessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                metroTextBox2.Text += "Started..." + Environment.NewLine;

            }
            else
            {
                metroTextBox2.Text += "Device is not ready yet!" + Environment.NewLine;
            }
        }

        private void CapturedeviceOnOnPacketArrival(object sender, CaptureEventArgs e)
        {
            new Thread(() =>
            {
                try
                {
                    if (StopFlag)
                    {
                        return;
                    }

                    EthernetPacket Packet = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data) as EthernetPacket;
                    if (Packet == null) { return; }

                    AcceptedPacket acPacket = new AcceptedPacket();
                    acPacket.Packet = Packet;

                    if (Packet.SourceHwAddress.Equals(TargetMAC))
                    {
                        if (acPacket.TCPPacket != null)
                        {
                            materialListView1.BeginInvoke(new Action(() =>
                            {
                                materialListView1.AddObject(acPacket);

                                if (materialListView1.Items.Count > 15 && !ResizeDone)
                                {
                                    olvColumn8.MaximumWidth = 65;
                                    olvColumn8.MinimumWidth = 65;
                                    olvColumn8.Width = 65;
                                    ResizeDone = true;
                                }

                                ListofAcceptedPackets.Add(acPacket);

                            }));

                        }
                    }

                    else if (Packet.SourceHwAddress.Equals(GatewayMAC))
                    {
                        if (Properties.Settings.Default.PacketDirection == "Inbound")
                        {
                            IPv4Packet IPV4 = Packet.Extract(typeof(IPv4Packet)) as IPv4Packet;

                            if (IPV4.DestinationAddress.Equals(TargetIP))
                            {
                                if (acPacket.TCPPacket != null)
                                {
                                    materialListView1.BeginInvoke(new Action(() =>
                                    {
                                        materialListView1.AddObject(acPacket);

                                        if (materialListView1.Items.Count > 15 && !ResizeDone)
                                        {
                                            olvColumn8.MaximumWidth = 65;
                                            olvColumn8.MinimumWidth = 65;
                                            olvColumn8.Width = 65;
                                            ResizeDone = true;
                                        }

                                        ListofAcceptedPackets.Add(acPacket);


                                    }));
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }


            }).Start();
        }

        private void StartSniffer()
        {

            try
            {
                RawCapture rawCapture;
                do
                {
                    if ((rawCapture = capturedevice.GetNextPacket()) != null)
                    {
                        EthernetPacket Packet = PacketDotNet.Packet.ParsePacket(rawCapture.LinkLayerType, rawCapture.Data) as EthernetPacket;
                        if (Packet == null) { return; }

                        AcceptedPacket acPacket = new AcceptedPacket();
                        acPacket.Packet = Packet;

                        if (Packet.SourceHwAddress.Equals(TargetMAC))
                        {

                            if (acPacket.TCPPacket != null)
                            {

                                materialListView1.BeginInvoke(new Action(() =>
                                {
                                    materialListView1.AddObject(acPacket);

                                    if (materialListView1.Items.Count > 15 && !ResizeDone)
                                    {
                                        olvColumn8.MaximumWidth = 65;
                                        olvColumn8.MinimumWidth = 65;
                                        olvColumn8.Width = 65;
                                        ResizeDone = true;
                                    }

                                    ListofAcceptedPackets.Add(acPacket);

                                }));

                            }
                        }

                        else if (Packet.SourceHwAddress.Equals(GatewayMAC))
                        {



                            if (Properties.Settings.Default.PacketDirection == "Inbound")
                            {

                                IPv4Packet IPV4 = Packet.Extract(typeof(IPv4Packet)) as IPv4Packet;

                                if (IPV4.DestinationAddress.Equals(TargetIP))
                                {
                                    if (acPacket.TCPPacket != null)
                                    {
                                        materialListView1.BeginInvoke(new Action(() =>
                                        {
                                            materialListView1.AddObject(acPacket);

                                            if (materialListView1.Items.Count > 15 && !ResizeDone)
                                            {
                                                olvColumn8.MaximumWidth = 65;
                                                olvColumn8.MinimumWidth = 65;
                                                olvColumn8.Width = 65;
                                                ResizeDone = true;
                                            }

                                            ListofAcceptedPackets.Add(acPacket);


                                        }));
                                    }
                                }
                            }
                        }
                    }

                } while (snifferStarted);
            }
            catch (Exception)
            {

            }


        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (capturedevice != null && snifferStarted)
                {
                    if (IsLocalDeviceSniffing)
                    {
                        capturedevice.StopCapture();
                        snifferStarted = false;
                        StopFlag = true;
                        materialListView1.EmptyListMsg = "Stopped";
                        metroTextBox2.Text += "Stopped" + Environment.NewLine;
                    }
                    else
                    {
                        snifferStarted = false;
                        materialListView1.EmptyListMsg = "Stopped";
                        metroTextBox2.Text += "Stopped" + Environment.NewLine;

                    }

                }
            }
            catch (Exception)
            {

            }

        }

        private void Sniffer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (snifferStarted && capturedevice != null)
            {
                if (MetroMessageBox.Show(this, "The sniffer is still working, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (IsLocalDeviceSniffing)
                    {
                        capturedevice.StopCapture();
                        snifferStarted = false;
                        StopFlag = true;

                        if (menu != null)
                        {
                            menu.Dispose();
                        }
                    }
                    else
                    {
                        snifferStarted = false;
                        StopFlag = true;

                        if (menu != null)
                        {
                            menu.Dispose();
                        }
                    }

                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void materialFlatButton4_Click_1(object sender, EventArgs e)
        {
            if (materialListView1.GetItemCount() > 0)
            {
                materialListView1.ClearObjects();
                ListofAcceptedPackets.Clear();
                olvColumn8.MaximumWidth = 82;
                olvColumn8.MinimumWidth = 82;
                olvColumn8.Width = 82;
                ResizeDone = false;

            }

            materialListView1.EmptyListMsg = "Packet list is empty";

        }

        private void materialListView1_MouseDown_1(object sender, MouseEventArgs e)
        {
            var item = materialListView1.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                materialListView1.ContextMenu = menu;
            }
            else
            {
                materialListView1.ContextMenu = null;
                materialListView1.SelectedObjects.Clear();
            }
        }

        private void materialFlatButton5_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this,
                "1- In order to begin capturing packets click on START.\n2- You can clear the list from items by pressing CLEAR.\n3- You can save the captured packets in a form of a log file by stopping the ongoing operation, pressing EXPORT and choosing a location for the file to be saved.\n4- In order to open a chosen packet do a right click on the selected packet and click \"Show Packet\" and it will be displayed in the packet viewer on the bottom left of the window.\n5- To resolve the destination ip in HTTPS Packets just click the Resolve button for the requested row.\n6- Hint: its useful to resolve the destination IPs before exporting the content of the list in order to include more information in the log file.",
                "Help", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 290);

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if (snifferStarted)
            {
                MetroMessageBox.Show(this, "The Creation of a log file requires stopping any on going sniffing operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (materialListView1.Items.Count == 0)
            {
                MetroMessageBox.Show(this, "The list is empty you have to start a sniffing operation first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var objects = materialListView1.Objects as List<AcceptedPacket>;
                CommonFileDialog cfd = new CommonOpenFileDialog()
                {
                    IsFolderPicker = true,
                    Multiselect = false,
                    Title = "Choose a folder to save the log file in",


                };
                var filename = DateTime.Now.ToString("MM-dd-yyyy_hh-mm-ss-tt");
                AcceptedPacket packet;
                if (cfd.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    foreach (var item in materialListView1.Objects)
                    {
                        packet = item as AcceptedPacket;
                        File.AppendAllText(Path.Combine(cfd.FileName, filename + ".log"), $"Source: {packet.Source} // Destination: {packet.Destination} // Host: {packet.Host} // Type: {packet.Type} // Date: {packet.Time.ToString("dd/MM/yyyy h:mm:ss tt")}\n");
                    }

                    MetroMessageBox.Show(this, "Log saved successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void materialListView1_ButtonClick(object sender, CellClickEventArgs e)
        {

            new Thread(() =>
            {
                var pack = e.Model as AcceptedPacket;
                try
                {
                    IPHostEntry ip = Dns.GetHostEntry(pack.Destination);

                    materialListView1.BeginInvoke(new Action(() =>
                    {
                        try
                        {
                            pack.Host = ip.HostName;
                            materialListView1.UpdateObject(pack);
                            materialListView1.RefreshObject(e.Model);
                        }
                        catch (SocketException)
                        {
                            pack.Host = "Not found";
                            materialListView1.UpdateObject(pack);
                            materialListView1.RefreshObject(e.Model);
                        }

                    }));

                }
                catch (SocketException)
                {
                    pack.Host = "Not found";
                    materialListView1.UpdateObject(pack);
                    materialListView1.RefreshObject(e.Model);
                }

            }).Start();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            metroTextBox1.Clear();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text.Length > 0)
            {
                CommonFileDialog cfd = new CommonOpenFileDialog()
                {
                    IsFolderPicker = true,
                    Multiselect = false,
                    Title = "Choose a folder to save the packet file in",


                };
                var filename = DateTime.Now.ToString("MM-dd-yyyy_hh-mm-ss-tt");
                if (cfd.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    File.AppendAllText(Path.Combine(cfd.FileName, filename + "-Packet.log"), metroTextBox1.Text);
                    MetroMessageBox.Show(this, "Packet saved successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MetroMessageBox.Show(this, "Open a packet first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (viewerExtended)
            {

                panel3.Parent = panel4;
                panel3.Dock = DockStyle.Left;
                panel3.SendToBack();
                viewerExtended = false;

            }
            else
            {

                panel3.Parent = this;
                panel3.Dock = DockStyle.Fill;
                panel3.BringToFront();
                viewerExtended = true;
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.FontSize == MetroTextBoxSize.Tall)
            {
                metroTextBox1.FontSize = MetroTextBoxSize.Small;
            }
            else if (metroTextBox1.FontSize == MetroTextBoxSize.Medium)
            {
                metroTextBox1.FontSize = MetroTextBoxSize.Tall;
            }
            else if (metroTextBox1.FontSize == MetroTextBoxSize.Small)
            {
                metroTextBox1.FontSize = MetroTextBoxSize.Medium;
            }

        }

        private void MaterialFlatButton6_Click(object sender, EventArgs e)
        {
            var snifferOptions = new SnifferOptions();
            snifferOptions.ShowDialog();
        }

    }
}
