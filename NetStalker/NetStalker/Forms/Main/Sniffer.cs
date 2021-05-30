using BrightIdeasSoftware;
using MaterialSkin;
using MaterialSkin.Controls;
using MetroFramework;
using Microsoft.WindowsAPICodePack.Dialogs;
using NetStalker.MainLogic;
using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetStalker
{
    public partial class Sniffer : MaterialForm
    {
        #region Instance Fields

        /// <summary>
        /// The capture device used for sniffing.
        /// </summary>
        private LibPcapLiveDevice CaptureDevice;
        /// <summary>
        /// This context menu will be added on user's right click and removed on empty clicks.
        /// </summary>
        private readonly ContextMenu PacketMenu;
        /// <summary>
        /// The overlay shown when the list is empty.
        /// </summary>
        private readonly TextOverlay ListOverlay;
        /// <summary>
        /// Indication if the packet viewer is extended.
        /// </summary>
        private bool ViewerExtended;
        /// <summary>
        /// Indication that a list resize has been done. This is used to adjust the visuals of the list when a scroll bar is shown.
        /// </summary>
        private bool ResizeDone;
        /// <summary>
        /// Indication that the capture device is configured.
        /// </summary>
        private bool CaptureDeviceConfigured;
        /// <summary>
        /// Indication to the state of the sniffer.
        /// </summary>
        private bool SnifferActive;
        /// <summary>
        /// The targeted device.
        /// </summary>
        private Device Device;
        /// <summary>
        /// The sniffer task.
        /// </summary>
        private Task SnifferTask;

        #endregion

        #region Constructor

        public Sniffer(Device device)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            this.Device = device;

            #region List Configuration

            //Set empty list overlay
            ListOverlay = this.PacketListView.EmptyListMsgOverlay as TextOverlay;

            //A context menu to be added to list items on every right click and removed on empty clicks
            PacketMenu = new ContextMenu(new MenuItem[] { new MenuItem("Show Packet", ShowPacket), });

            //This delegate decides if the list item has a resolve button
            olvColumn7.AspectGetter = delegate (object rowObject)
            {
                try
                {
                    AcceptedPacket packet = rowObject as AcceptedPacket;

                    if (packet == null)
                        return null;

                    if (string.IsNullOrEmpty(packet.Host) && packet.Source.Equals(device.IP) || packet.Host == "Not found")
                        return "Resolve";

                }
                catch { }

                return null;
            };

            //Select row icon based on the packet type (Request or Response)
            olvColumn1.ImageGetter = delegate (object rowObject)
            {
                AcceptedPacket Packet = rowObject as AcceptedPacket;
                if (Packet == null)
                    return default;

                try
                {
                    if (Packet.Source.Equals(device.IP))
                    {
                        return "request";
                    }
                    else
                    {
                        return "response";
                    }
                }
                catch
                {
                    return "";
                }

            };

            #endregion
        }

        #endregion

        #region Tools

        /// <summary>
        /// The event handler for showing the selected packet properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowPacket(object sender, EventArgs e)
        {
            var packet = PacketListView.SelectedObject as AcceptedPacket;

            //TCP packet sent or received over HTTP
            if (packet.TCPPacket != null && packet.Type == "HTTP")
            {
                metroTextBox1.Clear();

                //Packet header data
                if (packet.TCPPacket.HeaderData != null)
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

                //Separator
                metroTextBox1.Text += Environment.NewLine + "==================================================" + Environment.NewLine;

                //Packet payload data
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

                //TCP packet properties
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
                metroTextBox1.Text += $"TCP Packet Header Length: {packet.TCPPacket.HeaderData.Length}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Payload Length: {packet.TCPPacket.PayloadData.Length}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Source Port: {packet.TCPPacket.SourcePort}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Destination Port: {packet.TCPPacket.DestinationPort}" + Environment.NewLine;

            }
            //TCP packet sent or received over HTTPS
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
                metroTextBox1.Text += $"TCP Packet Header Length: {packet.TCPPacket.HeaderData.Length}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Payload Length: {packet.TCPPacket.PayloadData.Length}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Source Port: {packet.TCPPacket.SourcePort}" + Environment.NewLine;
                metroTextBox1.Text += $"TCP Packet Destination Port: {packet.TCPPacket.DestinationPort}" + Environment.NewLine;
                metroTextBox1.Text += Environment.NewLine;
                metroTextBox1.Text += Environment.NewLine;

            }
            //UDP packet
            else if (packet.UDPPacket != null)
            {
                //UDP packet properties
                metroTextBox1.Clear();
                metroTextBox1.Text += "-----------------UDP-PacketProperties-----------------" + Environment.NewLine;
                metroTextBox1.Text += $"Packet Length: {packet.Packet.Bytes.Length}" + Environment.NewLine;
                metroTextBox1.Text += $"Packet TimeStamp: {packet.Time}" + Environment.NewLine;
                metroTextBox1.Text += $"IPV4 Packet Identification: {packet.ID}" + Environment.NewLine;
                metroTextBox1.Text += $"IPV4 Protocol: {packet.Protocol}" + Environment.NewLine;
                metroTextBox1.Text += $"IPV4 Source IP: {packet.Source}" + Environment.NewLine;
                metroTextBox1.Text += $"IPV4 Destination IP: {packet.Destination}" + Environment.NewLine;
                metroTextBox1.Text += $"UDP Packet Header Length: {packet.UDPPacket.HeaderData.Length}" + Environment.NewLine;
                metroTextBox1.Text += $"UDP Packet Payload Length: {packet.UDPPacket.PayloadData.Length}" + Environment.NewLine;
                metroTextBox1.Text += $"UDP Packet Source Port: {packet.UDPPacket.SourcePort}" + Environment.NewLine;
                metroTextBox1.Text += $"UDP Packet Destination Port: {packet.UDPPacket.DestinationPort}" + Environment.NewLine;
                metroTextBox1.Text += Environment.NewLine;
                metroTextBox1.Text += Environment.NewLine;

            }
        }

        /// <summary>
        /// Perform the initialization of the capture device.
        /// </summary>
        public void ConfigureCaptureDevice()
        {
            if (!CaptureDeviceConfigured)
            {
                metroTextBox2.BeginInvoke(new Action(() =>
                {
                    metroTextBox2.Text += "Preparing network adapter..." + Environment.NewLine;
                }));

                CaptureDeviceList capturedevicelist = CaptureDeviceList.Instance;
                capturedevicelist.Refresh();

                CaptureDevice = (LibPcapLiveDevice)CaptureDeviceList.New()[AppConfiguration.AdapterName];
                CaptureDeviceConfigured = true;

                metroTextBox2.BeginInvoke(new Action(() =>
                {
                    metroTextBox2.Text += "Ready" + Environment.NewLine;
                }));
            }
        }

        /// <summary>
        /// The main sniffer job.
        /// </summary>
        private void StartSniffer()
        {
            RawCapture rawCapture;
            do
            {
                if (CaptureDevice.GetNextPacket(out PacketCapture packetCapture) == GetPacketStatus.PacketRead)
                {
                    rawCapture = packetCapture.GetPacket();

                    EthernetPacket Packet = PacketDotNet.Packet.ParsePacket(rawCapture.LinkLayerType, rawCapture.Data) as EthernetPacket;
                    if (Packet == null) { return; }

                    AcceptedPacket acPacket = new AcceptedPacket();
                    acPacket.Packet = Packet;

                    if (Packet.SourceHardwareAddress.Equals(Device.MAC))
                    {
                        if (acPacket.TCPPacket != null)
                        {
                            PacketListView.BeginInvoke(new Action(() =>
                            {
                                PacketListView.AddObject(acPacket);

                                if (PacketListView.Items.Count > 15 && !ResizeDone)
                                {
                                    olvColumn8.MaximumWidth = 65;
                                    olvColumn8.MinimumWidth = 65;
                                    olvColumn8.Width = 65;
                                    ResizeDone = true;
                                }

                            }));
                        }
                    }
                    else if (Packet.SourceHardwareAddress.Equals(AppConfiguration.GatewayMac))
                    {
                        if (AppConfiguration.SnifferPacketDirection == "Inbound/Outbound") //Catch inbound packets
                        {
                            IPv4Packet IPV4 = Packet.Extract<IPv4Packet>();

                            if (IPV4.DestinationAddress.Equals(Device.IP))
                            {
                                if (acPacket.TCPPacket != null)
                                {
                                    PacketListView.BeginInvoke(new Action(() =>
                                    {
                                        PacketListView.AddObject(acPacket);

                                        if (PacketListView.Items.Count > 15 && !ResizeDone)
                                        {
                                            olvColumn8.MaximumWidth = 65;
                                            olvColumn8.MinimumWidth = 65;
                                            olvColumn8.Width = 65;
                                            ResizeDone = true;
                                        }
                                    }));
                                }
                            }
                        }
                    }
                }

            } while (SnifferActive);
        }

        #endregion

        #region Form Handlers

        /// <summary>
        /// Do the initial setup of the sniffer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sniffer_Load(object sender, EventArgs e)
        {
            metroTextBox2.Text += "Targeting: " + Device.IP.ToString() + Environment.NewLine;

            #region Visual Garbage

            metroTextBox1.UseCustomBackColor = true;
            metroTextBox1.UseCustomForeColor = true;
            metroTextBox1.Style = MetroColorStyle.Default;
            metroTextBox2.UseCustomForeColor = true;
            metroTextBox2.UseCustomBackColor = true;
            metroTextBox2.Style = MetroColorStyle.Default;

            if (Properties.Settings.Default.Color == "Light")
            {
                metroTextBox1.BackColor = Color.WhiteSmoke;
                metroTextBox2.BackColor = Color.WhiteSmoke;
                metroTextBox1.ForeColor = Color.Black;
                metroTextBox2.ForeColor = Color.Black;
                ListOverlay.BackColor = Color.FromArgb(204, 204, 204);
                ListOverlay.TextColor = Color.FromArgb(71, 71, 71);
                PacketListView.BackColor = Color.WhiteSmoke;
                PacketListView.HeaderFormatStyle = LightHeaders;
                PacketListView.HotItemStyle = LightHot;
                PacketListView.ForeColor = Color.FromArgb(54, 54, 54);
                PacketListView.SelectedBackColor = Color.FromArgb(214, 214, 214);
                PacketListView.SelectedForeColor = Color.FromArgb(51, 51, 51);
                PacketListView.UnfocusedSelectedBackColor = Color.FromArgb(71, 71, 71);
                PacketListView.UnfocusedSelectedForeColor = Color.FromArgb(204, 204, 204);
                ListOverlay.BorderColor = Color.Teal;
                metroToolTip1.Theme = MetroThemeStyle.Light;


            }
            else if (Properties.Settings.Default.Color == "Dark")
            {
                ListOverlay.BackColor = Color.FromArgb(71, 71, 71);
                ListOverlay.TextColor = Color.FromArgb(204, 204, 204);
                ListOverlay.BorderColor = Color.Teal;
                metroToolTip1.Theme = MetroThemeStyle.Dark;

            }
            else
            {
                metroTextBox1.BackColor = Color.WhiteSmoke;
                metroTextBox2.BackColor = Color.WhiteSmoke;
                metroTextBox1.ForeColor = Color.Black;
                metroTextBox2.ForeColor = Color.Black;
                ListOverlay.BackColor = Color.FromArgb(204, 204, 204);
                ListOverlay.TextColor = Color.FromArgb(71, 71, 71);
                PacketListView.BackColor = Color.WhiteSmoke;
                PacketListView.HeaderFormatStyle = LightHeaders;
                PacketListView.HotItemStyle = LightHot;
                PacketListView.ForeColor = Color.FromArgb(54, 54, 54);
                PacketListView.SelectedBackColor = Color.FromArgb(214, 214, 214);
                PacketListView.SelectedForeColor = Color.FromArgb(51, 51, 51);
                PacketListView.UnfocusedSelectedBackColor = Color.FromArgb(71, 71, 71);
                PacketListView.UnfocusedSelectedForeColor = Color.FromArgb(204, 204, 204);
                ListOverlay.BorderColor = Color.Teal;
                metroToolTip1.Theme = MetroThemeStyle.Light;
            }

            ListOverlay.Font = new Font("Roboto", 25);

            #endregion

            //Prepare capture device
            _ = Task.Run(ConfigureCaptureDevice);

            //Focus the sniffer form
            Activate();
        }

        private void Sniffer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CaptureDevice != null)
            {
                if (SnifferActive)
                {
                    if (MetroMessageBox.Show(this, "The sniffer is still working, continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        SnifferActive = false;

                        if (PacketMenu != null)
                            PacketMenu.Dispose();

                        if (SnifferTask != null)
                        {
                            if (SnifferTask.Status == TaskStatus.Running)
                                SnifferTask.Wait();

                            SnifferTask.Dispose();
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }

                CaptureDevice.Close();
                CaptureDevice.Dispose();
            }
        }

        #endregion

        #region Button Event Handlers

        /// <summary>
        /// The event handler for the Start button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (SnifferActive)
                MetroMessageBox.Show(this, "Sniffer already started!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            else if (CaptureDeviceConfigured)
            {
                PacketListView.EmptyListMsg = "Working...";

                try
                {
                    SnifferActive = true;

                    CaptureDevice.Open(DeviceModes.Promiscuous, 1000);

                    CaptureDevice.Filter = $"(tcp port 80 and (((ip[2:2] - ((ip[0]&0xf)<<2)) - ((tcp[12]&0xf0)>>2)) != 0) and (ether src {Device.MAC.ToString().ToLower()} or (dst net {Device.IP}))) or (tcp port 443 and (((ip[2:2] - ((ip[0]&0xf)<<2)) - ((tcp[12]&0xf0)>>2)) != 0) and (ether src {Device.MAC.ToString().ToLower()} or (dst net {Device.IP})))";

                    //Start the sniffer
                    SnifferTask = Task.Run(StartSniffer);

                }
                catch (Exception exception)
                {
                    MetroMessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                metroTextBox2.Text += "Started..." + Environment.NewLine;
            }
            else
                metroTextBox2.Text += "Device is not ready yet!" + Environment.NewLine;
        }

        /// <summary>
        /// The event handler for the Stop button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopButton_Click(object sender, EventArgs e)
        {
            if (CaptureDevice != null)
            {
                if (SnifferActive)
                {
                    SnifferActive = false;

                    if (SnifferTask != null)
                    {
                        if (SnifferTask.Status == TaskStatus.Running)
                        {
                            metroTextBox2.Text += "Stopping capture, please wait..." + Environment.NewLine;
                            SnifferTask.Wait();
                        }

                        SnifferTask.Dispose();
                    }

                    CaptureDevice.Close();

                    PacketListView.EmptyListMsg = "Stopped";
                    metroTextBox2.Text += "Stopped" + Environment.NewLine;
                }
            }
        }

        /// <summary>
        /// Event handler for the Clear button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (PacketListView.GetItemCount() > 0)
            {
                PacketListView.ClearObjects();
                olvColumn8.MaximumWidth = 82;
                olvColumn8.MinimumWidth = 82;
                olvColumn8.Width = 82;
                ResizeDone = false;

            }

            PacketListView.EmptyListMsg = "Packet list is empty";
        }

        /// <summary>
        /// Help button event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpButton_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this,
                "1- In order to begin capturing packets click on START.\n2- You can clear the list from items by pressing CLEAR.\n3- You can save the captured packets in a form of a log file by stopping the ongoing operation, pressing EXPORT and choosing a location for the file to be saved.\n4- In order to open a chosen packet do a right click on the selected packet and click \"Show Packet\" and it will be displayed in the packet viewer on the bottom left of the window.\n5- To resolve the destination ip in HTTPS Packets just click the Resolve button for the requested row.\n6- Hint: its useful to resolve the destination IPs before exporting the content of the list in order to include more information in the log file.",
                "Help", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 290);

        }

        /// <summary>
        /// The event handler of the Export button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (SnifferActive)
            {
                MetroMessageBox.Show(this, "The Creation of a log file requires stopping any on going sniffing operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (PacketListView.Items.Count == 0)
            {
                MetroMessageBox.Show(this, "The list is empty you have to start a sniffing operation first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CommonFileDialog cfd = new CommonOpenFileDialog()
                {
                    IsFolderPicker = true,
                    Multiselect = false,
                    Title = "Choose a folder to save the log file in"
                };
                var filename = DateTime.Now.ToString("MM-dd-yyyy_hh-mm-ss-tt");
                AcceptedPacket packet;

                if (cfd.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    foreach (var item in PacketListView.Objects)
                    {
                        packet = item as AcceptedPacket;
                        File.AppendAllText(Path.Combine(cfd.FileName, filename + ".log"), $"Source: {packet.Source} // Destination: {packet.Destination} // Host: {packet.Host} // Type: {packet.Type} // Date: {packet.Time.ToString("dd/MM/yyyy h:mm:ss tt")}\n");
                    }

                    MetroMessageBox.Show(this, "Log saved successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                cfd.Dispose();
            }
        }

        /// <summary>
        /// The event handler for the Clear packet button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearViewerButton_Click(object sender, EventArgs e)
        {
            metroTextBox1.Clear();
        }

        /// <summary>
        /// The event handler for the Save packet button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
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

                cfd.Dispose();
            }
            else
            {
                MetroMessageBox.Show(this, "Open a packet first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// The event handler for the Extend viewer button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpandButton_Click(object sender, EventArgs e)
        {
            if (ViewerExtended)
            {
                panel3.Parent = panel4;
                panel3.Dock = DockStyle.Left;
                panel3.SendToBack();
                ViewerExtended = false;
            }
            else
            {
                panel3.Parent = this;
                panel3.Dock = DockStyle.Fill;
                panel3.BringToFront();
                ViewerExtended = true;
            }
        }

        /// <summary>
        /// The event handler for the Change font button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontButton_Click(object sender, EventArgs e)
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

        /// <summary>
        /// The event handler for the sniffer options button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionsButton_Click(object sender, EventArgs e)
        {
            var snifferOptions = new SnifferOptions();
            snifferOptions.ShowDialog();
            snifferOptions.Dispose();
        }

        #endregion

        #region List Handlers

        /// <summary>
        /// MouseDown event handler to add a context menu on non empty user clicks and remove the context menu on empty clicks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PacketListView_MouseDown(object sender, MouseEventArgs e)
        {
            var item = PacketListView.GetItemAt(e.X, e.Y);
            if (item != null)
                PacketListView.ContextMenu = PacketMenu;
            else
            {
                PacketListView.ContextMenu = null;
                PacketListView.SelectedObjects.Clear();
            }
        }

        /// <summary>
        /// The event handler for the resolve button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PacketListView_ButtonClick(object sender, CellClickEventArgs e)
        {
            Task.Run(() =>
            {
                var pack = e.Model as AcceptedPacket;
                try
                {
                    IPHostEntry ip = Dns.GetHostEntry(pack.Destination);

                    PacketListView.BeginInvoke(new Action(() =>
                    {
                        if (PacketListView.GetItemCount() > 0)
                        {
                            pack.Host = ip.HostName;
                            PacketListView.UpdateObject(pack);
                            PacketListView.RefreshObject(e.Model);
                        }
                    }));

                }
                catch (SocketException)
                {
                    PacketListView.BeginInvoke(new Action(() =>
                    {
                        if (PacketListView.GetItemCount() > 0)
                        {
                            pack.Host = "Not found";
                            PacketListView.UpdateObject(pack);
                            PacketListView.RefreshObject(e.Model);
                        }
                    }));
                }
            });
        }

        #endregion
    }
}
