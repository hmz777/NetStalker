using BrightIdeasSoftware;
using Microsoft.WindowsAPICodePack.Dialogs;
using NetStalker.Forms.Information;
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
    public partial class Sniffer : Form
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

        public Sniffer(Device device)
        {
            InitializeComponent();

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
                PacketBox.Clear();

                //Packet header data
                if (packet.TCPPacket.HeaderData != null)
                {
                    PacketBox.Text += "-----------------HTTPHeader-----------------" + Environment.NewLine;
                    PacketBox.Text += Environment.NewLine + "UTF8:" + Environment.NewLine;
                    PacketBox.Text += Encoding.UTF8.GetString(packet.TCPPacket.PayloadData) + Environment.NewLine;
                    PacketBox.Text += Environment.NewLine;
                    PacketBox.Text += Environment.NewLine;
                    PacketBox.Text += Environment.NewLine + "ASCII:" + Environment.NewLine;
                    PacketBox.Text += Encoding.ASCII.GetString(packet.TCPPacket.PayloadData) + Environment.NewLine;
                    PacketBox.Text += Environment.NewLine;
                    PacketBox.Text += Environment.NewLine;
                }

                //Separator
                PacketBox.Text += Environment.NewLine + "==================================================" + Environment.NewLine;

                //Packet payload data
                if (packet.TCPPacket.PayloadData != null)
                {
                    PacketBox.Text += "-----------------TCPPayload-----------------" + Environment.NewLine;
                    PacketBox.Text += Environment.NewLine + "UTF8:" + Environment.NewLine;
                    PacketBox.Text += Encoding.UTF8.GetString(packet.TCPPacket.PayloadData) + Environment.NewLine;
                    PacketBox.Text += Environment.NewLine + "ASCII:" + Environment.NewLine;
                    PacketBox.Text += Encoding.ASCII.GetString(packet.TCPPacket.PayloadData) + Environment.NewLine;
                    PacketBox.Text += Environment.NewLine;
                    PacketBox.Text += Environment.NewLine;
                }

                //TCP packet properties
                PacketBox.Text += Environment.NewLine + "==================================================" + Environment.NewLine;
                PacketBox.Text += "-----------------TCP-PacketProperties-----------------" + Environment.NewLine;
                PacketBox.Text += $"Packet Length: {packet.Packet.Bytes.Length}" + Environment.NewLine;
                PacketBox.Text += $"Packet TimeStamp: {packet.Time}" + Environment.NewLine;
                PacketBox.Text += $"IPV4 Packet Identification: {packet.ID}" + Environment.NewLine;
                PacketBox.Text += $"IPV4 Protocol: {packet.Protocol}" + Environment.NewLine;
                PacketBox.Text += $"IPV4 Source IP: {packet.Source}" + Environment.NewLine;
                PacketBox.Text += $"IPV4 Destination IP: {packet.Destination}" + Environment.NewLine;
                PacketBox.Text += $"TCP Packet Window Size: {packet.TCPPacket.WindowSize}" + Environment.NewLine;
                PacketBox.Text += $"TCP Packet Acknowledgment Number: {packet.TCPPacket.AcknowledgmentNumber}" + Environment.NewLine;
                PacketBox.Text += $"TCP Packet Sequence Number: {packet.TCPPacket.SequenceNumber}" + Environment.NewLine;
                PacketBox.Text += $"TCP Packet Header Length: {packet.TCPPacket.HeaderData.Length}" + Environment.NewLine;
                PacketBox.Text += $"TCP Packet Payload Length: {packet.TCPPacket.PayloadData.Length}" + Environment.NewLine;
                PacketBox.Text += $"TCP Packet Source Port: {packet.TCPPacket.SourcePort}" + Environment.NewLine;
                PacketBox.Text += $"TCP Packet Destination Port: {packet.TCPPacket.DestinationPort}" + Environment.NewLine;

            }
            //TCP packet sent or received over HTTPS
            else if (packet.TCPPacket != null && packet.Type == "HTTPS")
            {
                PacketBox.Clear();
                PacketBox.Text += "-----------------TCP-PacketProperties-----------------" + Environment.NewLine;
                PacketBox.Text += $"Packet Length: {packet.Packet.Bytes.Length}" + Environment.NewLine;
                PacketBox.Text += $"Packet TimeStamp: {packet.Time}" + Environment.NewLine;
                PacketBox.Text += $"IPV4 Packet Identification: {packet.ID}" + Environment.NewLine;
                PacketBox.Text += $"IPV4 Protocol: {packet.Protocol}" + Environment.NewLine;
                PacketBox.Text += $"IPV4 Source IP: {packet.Source}" + Environment.NewLine;
                PacketBox.Text += $"IPV4 Destination IP: {packet.Destination}" + Environment.NewLine;
                PacketBox.Text += $"TCP Packet Window Size: {packet.TCPPacket.WindowSize}" + Environment.NewLine;
                PacketBox.Text += $"TCP Packet Acknowledgment Number: {packet.TCPPacket.AcknowledgmentNumber}" + Environment.NewLine;
                PacketBox.Text += $"TCP Packet Sequence Number: {packet.TCPPacket.SequenceNumber}" + Environment.NewLine;
                PacketBox.Text += $"TCP Packet Header Length: {packet.TCPPacket.HeaderData.Length}" + Environment.NewLine;
                PacketBox.Text += $"TCP Packet Payload Length: {packet.TCPPacket.PayloadData.Length}" + Environment.NewLine;
                PacketBox.Text += $"TCP Packet Source Port: {packet.TCPPacket.SourcePort}" + Environment.NewLine;
                PacketBox.Text += $"TCP Packet Destination Port: {packet.TCPPacket.DestinationPort}" + Environment.NewLine;
                PacketBox.Text += Environment.NewLine;
                PacketBox.Text += Environment.NewLine;

            }
            //UDP packet
            else if (packet.UDPPacket != null)
            {
                //UDP packet properties
                PacketBox.Clear();
                PacketBox.Text += "-----------------UDP-PacketProperties-----------------" + Environment.NewLine;
                PacketBox.Text += $"Packet Length: {packet.Packet.Bytes.Length}" + Environment.NewLine;
                PacketBox.Text += $"Packet TimeStamp: {packet.Time}" + Environment.NewLine;
                PacketBox.Text += $"IPV4 Packet Identification: {packet.ID}" + Environment.NewLine;
                PacketBox.Text += $"IPV4 Protocol: {packet.Protocol}" + Environment.NewLine;
                PacketBox.Text += $"IPV4 Source IP: {packet.Source}" + Environment.NewLine;
                PacketBox.Text += $"IPV4 Destination IP: {packet.Destination}" + Environment.NewLine;
                PacketBox.Text += $"UDP Packet Header Length: {packet.UDPPacket.HeaderData.Length}" + Environment.NewLine;
                PacketBox.Text += $"UDP Packet Payload Length: {packet.UDPPacket.PayloadData.Length}" + Environment.NewLine;
                PacketBox.Text += $"UDP Packet Source Port: {packet.UDPPacket.SourcePort}" + Environment.NewLine;
                PacketBox.Text += $"UDP Packet Destination Port: {packet.UDPPacket.DestinationPort}" + Environment.NewLine;
                PacketBox.Text += Environment.NewLine;
                PacketBox.Text += Environment.NewLine;

            }
        }

        /// <summary>
        /// Perform the initialization of the capture device.
        /// </summary>
        public void ConfigureCaptureDevice()
        {
            if (!CaptureDeviceConfigured)
            {
                StatusBox.BeginInvoke(new Action(() =>
                {
                    StatusBox.Text += "Preparing network adapter..." + Environment.NewLine;
                }));

                CaptureDeviceList capturedevicelist = CaptureDeviceList.Instance;
                capturedevicelist.Refresh();

                CaptureDevice = (LibPcapLiveDevice)CaptureDeviceList.New()[AppConfiguration.AdapterName];
                CaptureDeviceConfigured = true;

                StatusBox.BeginInvoke(new Action(() =>
                {
                    StatusBox.Text += "Ready" + Environment.NewLine;
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
            if (Properties.Settings.Default.DarkMode)
            {
                this.BackColor = Color.FromArgb(51, 51, 51);
                this.ForeColor = Color.White;

                foreach (Control control in Controls)
                {
                    if (control.GetType() == typeof(Panel))
                    {
                        foreach (Control innerControl in control.Controls)
                        {
                            innerControl.BackColor = Color.FromArgb(51, 51, 51);
                            innerControl.ForeColor = Color.White;
                        }
                    }
                    else
                    {
                        control.BackColor = Color.FromArgb(51, 51, 51);
                        control.ForeColor = Color.White;
                    }
                }
            }

            StatusBox.Text += "Targeting: " + Device.IP.ToString() + Environment.NewLine;

            ListOverlay.Font = new Font("Century Gothic", 25);

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
                    using (var message = new MessageBoxForm("Warning", "The sniffer is still working, continue?", MessageBoxIcon.Warning, MessageBoxButtons.OKCancel))
                    {
                        if (message.ShowDialog() == DialogResult.OK)
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
            {
                using (var message = new MessageBoxForm("Error", "Sniffer already started!", MessageBoxIcon.Error, MessageBoxButtons.OK))
                {
                    message.ShowDialog();
                }
            }
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
                    using (var message = new MessageBoxForm("Error", exception.Message, MessageBoxIcon.Error, MessageBoxButtons.OK))
                    {
                        message.ShowDialog();
                    }
                }

                StatusBox.Text += "Started..." + Environment.NewLine;
            }
            else
                StatusBox.Text += "Device is not ready yet!" + Environment.NewLine;
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
                            StatusBox.Text += "Stopping capture, please wait..." + Environment.NewLine;
                            SnifferTask.Wait();
                        }

                        SnifferTask.Dispose();
                    }

                    CaptureDevice.Close();

                    PacketListView.EmptyListMsg = "Stopped";
                    StatusBox.Text += "Stopped" + Environment.NewLine;
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
            using (var message = new MessageBoxForm("Help", Properties.Resources.SnifferHelp, MessageBoxIcon.Information, MessageBoxButtons.OK))
            {
                message.ShowDialog();
            }
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
                using (var message = new MessageBoxForm("Error", "The Creation of a log file requires stopping any on going sniffing operation!", MessageBoxIcon.Error, MessageBoxButtons.OK))
                {
                    message.ShowDialog();
                }
            }
            else if (PacketListView.Items.Count == 0)
            {
                using (var message = new MessageBoxForm("Error", "The list is empty you have to start a sniffing operation first!", MessageBoxIcon.Error, MessageBoxButtons.OK))
                {
                    message.ShowDialog();
                }
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

                    using (var message = new MessageBoxForm("Info", "Log saved successfully!", MessageBoxIcon.Information, MessageBoxButtons.OK))
                    {
                        message.ShowDialog();
                    }
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
            PacketBox.Clear();
        }

        /// <summary>
        /// The event handler for the Save packet button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (PacketBox.Text.Length > 0)
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
                    File.AppendAllText(Path.Combine(cfd.FileName, filename + "-Packet.log"), PacketBox.Text);

                    using (var message = new MessageBoxForm("Info", "Packet saved successfully!", MessageBoxIcon.Information, MessageBoxButtons.OK))
                    {
                        message.ShowDialog();
                    }
                }

                cfd.Dispose();
            }
            else
            {
                using (var message = new MessageBoxForm("Error", "Open a packet first!", MessageBoxIcon.Error, MessageBoxButtons.OK))
                {
                    message.ShowDialog();
                }
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
                PacketBox.Parent = BottomPanel;
                PacketBox.Dock = DockStyle.Left;
                PacketBox.SendToBack();
                ViewerExtended = false;
            }
            else
            {
                PacketBox.Parent = this;
                PacketBox.Dock = DockStyle.Fill;
                PacketBox.BringToFront();
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
            int fontSize = 10; //Default font size

            if (PacketBox.Font.Size >= 20)
            {
                fontSize = 10;
            }
            else if (PacketBox.Font.Size >= 15)
            {
                fontSize = 20;
            }
            else if (PacketBox.Font.Size >= 10)
            {
                fontSize = 15;
            }

            PacketBox.Font = new Font("Century Gothic", fontSize);
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
