using BrightIdeasSoftware;
using MaterialSkin;
using MaterialSkin.Controls;
using MetroFramework;
using MetroFramework.Controls;
using NetStalker.MainLogic;
using NetStalker.ToastNotifications;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace NetStalker
{
    public partial class Main : MaterialForm, IView
    {
        #region Static Fields

        /// <summary>
        /// Inication that an operation is in progress.
        /// </summary>
        public static bool OperationIsInProgress;
        /// <summary>
        /// The list of targets of type <see cref="Device"/>
        /// </summary>
        public static ConcurrentDictionary<IPAddress, Device> Devices;

        #endregion

        #region Instance Fields

        /// <summary>
        /// The list overlay that represents the status of the list when its empty.
        /// </summary>
        public TextOverlay ListOverlay;
        /// <summary>
        /// The timer that is responsible for updating the speed values in the UI.
        /// </summary>
        private readonly Timer ValuesTimer;
        /// <summary>
        /// The timer that is responsible for detecting device timeouts in order to disconnect from it and delete it from the list of targets.
        /// </summary>
        private readonly Timer AliveTimer;
        /// <summary>
        /// A flag to indicate if a list resize should be done. (This is used when the list is cleared or a scroll bar is shown).
        /// </summary>
        private bool ResizeDone;
        /// <summary>
        /// An indication that the app is being closed from the tray icon's context menu.
        /// </summary>
        public bool TrayExitFlag = false;

        #endregion

        #region Constructor

        public Main(string[] args = null)
        {
            InitializeComponent();

            #region MaterialSkin Configuration

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            #endregion

            #region Object ListView Initial Configuration

            this.olvColumn1.ImageGetter = delegate (object rowObject) //Set the images from the image list (with setting small image list in properties)
            {
                Device s = (Device)rowObject;
                if (s.IsGateway)
                    return "router"; //Image name in the image list
                else
                    return "pc"; //Image name in the image list
            };
            this.olvColumn1.GroupKeyGetter = delegate (object rowObject) //Give every model object a key so items with the same key are grouped together
            {
                var Device = rowObject as Device;

                if (Device.IsGateway)
                {
                    return "Gateway";
                }
                else if (Device.IsLocalDevice)
                {
                    return "Own Device";
                }
                else
                {
                    return "Devices";
                }
            };
            this.olvColumn1.GroupKeyToTitleConverter = delegate (object key) { return key.ToString(); }; //Convert the key to a title for the groups
            DeviceList.ShowGroups = true;

            this.olvColumn5.AspectGetter = delegate (object rowObject)
            {
                return (rowObject as Device).Redirected;
            };

            this.olvColumn5.AspectPutter = delegate (object rowObject, object newValue)
            {
                (rowObject as Device).Redirected = (bool)newValue;
            };

            this.olvColumn6.AspectGetter = delegate (object rowObject)
            {
                return (rowObject as Device).Blocked;
            };

            this.olvColumn6.AspectPutter = delegate (object rowObject, object newValue)
            {
                (rowObject as Device).Blocked = (bool)newValue;
            };

            ListOverlay = this.DeviceList.EmptyListMsgOverlay as TextOverlay;
            ListOverlay.Font = new Font("Roboto", 25);

            #endregion

            #region Update Timers

            //Speed Timer
            ValuesTimer = new Timer
            {
                Interval = 1000
            };
            ValuesTimer.Tick += ValuesTimerOnTick;

            //Timeout Timer
            AliveTimer = new Timer
            {
                Interval = 5000
            };
            AliveTimer.Tick += AliveTimerOnTick;

            #endregion

            //if (DeviceDpi >= 120)
            //{
            //    PerformDPIChanges();
            //}
        }

        #endregion

        #region Timers Handlers

        //Timeout handler: it removes devices once they exceed the timeoout period
        private void AliveTimerOnTick(object sender, EventArgs e)
        {
            //255.255.255.0
            if (Properties.Settings.Default.NetSize == 1)
            {
                foreach (var Device in Devices)
                {
                    if (!Device.Value.IsGateway && !Device.Value.IsLocalDevice && (DateTime.Now.Ticks - Device.Value.TimeSinceLastArp.Ticks) > 600000000L) //60 seconds
                    {
                        if (Devices.TryRemove(Device.Key, out Device Target))
                        {
                            Scanner.ClientList.Remove(Target.IP);

                            Target.Blocked = false;
                            Target.Redirected = false;
                            Target.Limited = false;
                            DeviceList.RemoveObject(Target);
                        }
                    }
                }
            }
            //255.255.0.0
            else if (Properties.Settings.Default.NetSize == 2)
            {
                foreach (var Device in Devices)
                {
                    if (!Device.Value.IsGateway && !Device.Value.IsLocalDevice && (DateTime.Now.Ticks - Device.Value.TimeSinceLastArp.Ticks) > 900000000L) //1.5 minutes
                    {
                        if (Devices.TryRemove(Device.Key, out Device Target))
                        {
                            Scanner.ClientList.Remove(Target.IP);

                            Target.Blocked = false;
                            Target.Redirected = false;
                            Target.Limited = false;
                            DeviceList.RemoveObject(Target);
                        }
                    }
                }
            }
            //255.0.0.0
            else if (Properties.Settings.Default.NetSize == 3)
            {
                foreach (var Device in Devices)
                {
                    if (!Device.Value.IsGateway && !Device.Value.IsLocalDevice && (DateTime.Now.Ticks - Device.Value.TimeSinceLastArp.Ticks) > 6000000000L) //10 minutes, extremely large networks this option could theoretically work, but not worth it.
                    {
                        if (Devices.TryRemove(Device.Key, out Device Target))
                        {
                            Scanner.ClientList.Remove(Target.IP);

                            Target.Blocked = false;
                            Target.Redirected = false;
                            Target.Limited = false;
                            DeviceList.RemoveObject(Target);
                        }
                    }
                }
            }
        }

        //Speed update handler: it updates the speed of targeted devices in the UI
        private void ValuesTimerOnTick(object sender, EventArgs e)
        {
            foreach (var Device in Devices)
            {
                if (Device.Value.Redirected)
                {
                    string D = ((float)Device.Value.PacketsReceivedSinceLastReset * 0.0009765625f / (float)(this.ValuesTimer.Interval / 1000)).ToString();
                    string U = ((float)Device.Value.PacketsSentSinceLastReset * 0.0009765625f / (float)(this.ValuesTimer.Interval / 1000)).ToString();

                    //0.0009765625f = 1/1024 Conversion from Bytes to KBytes

                    if (D.Length - D.IndexOf(".") > 1) //remove the number after the period
                    {
                        int num = -2 - D.IndexOf("."); //exclude the first number and the period
                        string str3 = D;
                        D = str3.Remove(str3.IndexOf(".") + 1, D.Length + num); //remove all the numbers to the right of the period but the first number
                    }
                    if (U.Length - U.IndexOf(".") > 1) //same here for the upload
                    {
                        int num = -2 - U.IndexOf(".");
                        string str3 = U;
                        U = str3.Remove(str3.IndexOf(".") + 1, U.Length + num);
                    }

                    Device.Value.DownloadSpeed = D + " KB/s";
                    Device.Value.UploadSpeed = U + " KB/s";
                    DeviceList.UpdateObject(Device.Value);
                }
            }

            ResetPacketCount();
        }

        #endregion

        #region Tools

        /// <summary>
        /// Reset recieved and sent packets for all devices in order for the value counter to compute the next value
        /// </summary>
        public void ResetPacketCount()
        {
            foreach (var device in Devices)
            {
                device.Value.PacketsSentSinceLastReset = 0;
                device.Value.PacketsReceivedSinceLastReset = 0;
            }
        }

        public void PerformDPIChanges()
        {
          //React to DPI changes...
        }

        #endregion

        #region IView Members

        public FastObjectListView ListView1
        {
            get
            {
                return DeviceList;
            }
        }
        public MaterialLabel StatusLabel
        {
            get
            {
                return DeviceCountLabel;
            }
        }
        public MaterialLabel StatusLabel2
        {
            get
            {
                return CurrentOperationStatusLabel;
            }
        }
        public Form MainForm
        {
            get
            {
                return this;
            }
        }
        public PictureBox LoadingBar
        {
            get
            {
                return pictureBox2;
            }
        }
        public PictureBox PictureBox
        {
            get { return pictureBox1; }
        }
        public ToolTip TTip
        {
            get { return Tooltip; }
        }
        public MetroTile Tile
        {
            get { return SnifferButton; }
        }
        public MetroTile Tile2
        {
            get { return LimiterButton; }
        }

        #endregion

        #region From Event Handlers

        private void Main_Shown(object sender, EventArgs e)
        {
            NicSelection nicform = new NicSelection();
            nicform.ShowDialog();
            nicform.Dispose();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Controller.AttachOnExitEventHandler(this);
            ToastAPI.AttachHandler();
        }

        public void Main_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                if (Properties.Settings.Default.Minimize == "Tray")
                {
                    Hide();
                    TrayIcon.Visible = true;
                    TrayIcon.ShowBalloonTip(2);
                }

                if (Properties.Settings.Default.SuppressNotifications == 0)
                {
                    ToastAPI.ShowPrompt(Properties.Resources.NotificationsPrompt, NotificationPurpose.NotificationsSuppression);
                }
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            var nic = Application.OpenForms["NicSelection"] as NicSelection;

            if (nic == null)
            {
                if (AliveTimer.Enabled && ValuesTimer.Enabled)
                {
                    AliveTimer.Enabled = false;
                    AliveTimer.Dispose();

                    ValuesTimer.Enabled = false;
                    ValuesTimer.Dispose();
                }

                if (e.CloseReason == CloseReason.UserClosing && !TrayExitFlag)
                {
                    if (MetroMessageBox.Show(this, "Quit the application ?", "Quit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        #endregion

        #region Button Event Handlers
        /// <summary>
        /// The click event handler for the "New Scan" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanButton_Click(object sender, EventArgs e)
        {
            if (!OperationIsInProgress)
            {
                ScanButton.Enabled = false;
                SnifferButton.Enabled = false;
                LimiterButton.Enabled = false;
                OperationIsInProgress = true;
                olvColumn7.MaximumWidth = 100;
                olvColumn7.MinimumWidth = 100;
                olvColumn7.Width = 100;
                ResizeDone = false;
                StatusLabel.Text = "Working";
                DeviceList.EmptyListMsg = "Scanning...";
                StatusLabel.Text = "Please wait...";
                pictureBox1.Image = Properties.Resources.color_error;

                AliveTimer.Enabled = true;

                Task.Run(() =>
                {
                    Controller.RefreshClients(this);
                });
            }
            else
            {
                MetroMessageBox.Show(this, "A scan is still in progress, please wait until its finished.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// The click event handler for the "Help" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpButton_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, Properties.Resources.HelpText, "Help", MessageBoxButtons.OK,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 375);
        }

        /// <summary>
        /// The click event handler for the "About button"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.ShowDialog();
        }

        /// <summary>
        /// The click event handler for the "Options" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionsButton_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.ShowDialog();
        }

        /// <summary>
        /// The click event handler for the "Refresh" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (Scanner.ScannerTask == null || OperationIsInProgress)
                    throw new Exception("In order to do a refresh, the scanner must be active and no other operations are in progress.");

                RefreshButton.Enabled = false;

                await Scanner.ProbeDevices();

                RefreshButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// The click event handler for the "Sniffer" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SnifferButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeviceList.SelectedObjects.Count == 0)
                {
                    throw new ArgumentNullException();
                }

                var selectedDevice = DeviceList.SelectedObject as Device;

                //Device should be redirected and not a gateway or a local device
                if (!selectedDevice.Redirected && !(selectedDevice.IsGateway || selectedDevice.IsLocalDevice))
                {
                    throw new CustomExceptions.RedirectionNotActiveException();
                }

                //For the berkeley packet filter to work, mac addresses should have ':' separating each hex number
                Sniffer sniff = new Sniffer(selectedDevice);
                sniff.ShowDialog(this);

                DeviceList.SelectedObjects.Clear();

                sniff.Dispose();

                DeviceList.UpdateObject(selectedDevice);
            }
            catch (ArgumentNullException)
            {
                MetroMessageBox.Show(this, "Select a device first!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (CustomExceptions.OperationInProgressException)
            {
                MetroMessageBox.Show(this, "The Packet Sniffer can't be used while the limiter is active!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (CustomExceptions.RedirectionNotActiveException)
            {
                MetroMessageBox.Show(this, "Redirection must be active for this device!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// The click event handler for the "Limiter" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LimiterButton_Click(object sender, EventArgs e)
        {
            try
            {
                //No selected device
                if (DeviceList.SelectedObjects.Count == 0)
                {
                    throw new ArgumentNullException();
                }

                var device = DeviceList.SelectedObject as Device;

                //Check if the selected device is a gateway or own device
                if (device.IsGateway || device.IsLocalDevice)
                    throw new CustomExceptions.LocalHostTargeted();


                //Check if device is redirected before applying a speed limit
                if (!device.Redirected)
                    throw new CustomExceptions.RedirectionNotActiveException();


                LimiterSpeed ls = new LimiterSpeed(device);
                if (ls.ShowDialog() == DialogResult.OK)
                {
                    if (device.Limited)
                    {
                        DeviceList.UpdateObject(device);
                    }

                    ls.Dispose();
                }
            }
            catch (ArgumentNullException)
            {
                MetroMessageBox.Show(this, "Choose a device first and activate redirection for it!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (CustomExceptions.LocalHostTargeted)
            {
                MetroMessageBox.Show(this, "This operation can not target the gateway or your own ip address!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (CustomExceptions.RedirectionNotActiveException)
            {
                MetroMessageBox.Show(this, "Redirection must be active for this device!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        #endregion

        #region List Event Handlers

        private void DeviceList_MouseDown(object sender, MouseEventArgs e)
        {
            var item = DeviceList.GetItemAt(e.X, e.Y);
            if (item == null)
            {
                DeviceList.ContextMenu = null;
                DeviceList.SelectedObjects.Clear();
            }
        }

        private void DeviceList_ItemsAdding(object sender, ItemsAddingEventArgs e)
        {
            if (DeviceList.Items.Count >= 8 && !ResizeDone)
            {
                olvColumn7.MaximumWidth = 83;
                olvColumn7.MinimumWidth = 83;
                olvColumn7.Width = 83;
                ResizeDone = true;
            }

            //Notifications are not suppressed
            if (WindowState == FormWindowState.Minimized && Properties.Settings.Default.SuppressNotifications == 2)
            {
                var Ad = e.ObjectsToAdd.Cast<Device>().ToList();
                if (Ad.Count > 0)
                {
                    Device Device = Ad[0];

                    ToastAPI.ShowPrompt(string.Format("{0}\nIP:{1}\nMAC:{2}",
                        Properties.Resources.NewTargetNotificationPrompt,
                        Device.IP,
                        Device.MAC), NotificationPurpose.TargetDiscovery, Device.IP.ToString(), Device.MAC.ToString());
                }
            }
        }

        private async void DeviceList_SubItemChecking(object sender, SubItemCheckingEventArgs e)
        {
            if (!await SubItemCheckingHandler(e.CurrentValue, e.NewValue, e.Column.Index, e.RowObject))
            {
                e.Canceled = true;
                e.NewValue = e.CurrentValue;
            }
        }

        public async Task<bool> SubItemCheckingHandler(CheckState CurrentValue, CheckState NewValue, int ColumnIndex, object RowObject)
        {
            try
            {
                //Don't allow blocking / redirection while the sniffer is active or any other operation.
                if (OperationIsInProgress)
                {
                    MetroMessageBox.Show(this, "The Speed Limiter can't be used while the sniffer is active!", "Error", MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);

                    return false;
                }

                //Get the device in the selected row
                DeviceList.SelectObject(RowObject);
                Device device = RowObject as Device;

                if (device.IsGateway || device.IsLocalDevice)
                {
                    MetroMessageBox.Show(this, "This operation can not target the gateway or your own ip address!", "Error", MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);

                    return false;
                }

                if (NewValue == CheckState.Checked && ColumnIndex == 6 && !device.Blocked && !device.Redirected)
                {
                    //Update device state in list
                    var listDevice = Devices.FirstOrDefault(D => D.Value.MAC == device.MAC);
                    if (listDevice.Equals(default(KeyValuePair<IPAddress, Device>)))
                        throw new CustomExceptions.DeviceNotInListException("Device was not found in the list of targeted devices.");

                    listDevice.Value.Blocked = true;

                    //Update device state in UI
                    device.Blocked = true;
                    device.DeviceStatus = "Offline";
                    DeviceList.UpdateObject(device);
                    pictureBox1.Image = NetStalker.Properties.Resources.icons8_ok_red;

                    //Activate the BR if it's not already active
                    if (!Blocker_Redirector.BRMainSwitch)
                    {
                        if (Blocker_Redirector.BRTask != null && Blocker_Redirector.BRTask.Status == TaskStatus.Running)
                            Blocker_Redirector.BRTask.Wait();

                        Blocker_Redirector.BRMainSwitch = true;
                        Blocker_Redirector.BlockAndRedirect();
                    }
                }
                else if (NewValue == CheckState.Checked && ColumnIndex == 5 && !device.Blocked && !device.Redirected)
                {
                    //Update device state in list
                    var listDevice = Devices.FirstOrDefault(D => D.Value.MAC == device.MAC);
                    if (listDevice.Equals(default(KeyValuePair<IPAddress, Device>)))
                        throw new CustomExceptions.DeviceNotInListException("Device was not found in the list of targeted devices.");

                    listDevice.Value.Blocked = true;
                    listDevice.Value.Redirected = true;

                    //Update device state in UI
                    device.Blocked = true;
                    device.Redirected = true;
                    device.DownloadCap = 0;
                    device.UploadCap = 0;
                    DeviceList.UpdateObject(device);
                    pictureBox1.Image = NetStalker.Properties.Resources.icons8_ok_red;

                    //Activate the BR if it's not already active
                    if (!Blocker_Redirector.BRMainSwitch)
                    {
                        if (Blocker_Redirector.BRTask != null && Blocker_Redirector.BRTask.Status == TaskStatus.Running)
                            Blocker_Redirector.BRTask.Wait();

                        Blocker_Redirector.BRMainSwitch = true;
                        Blocker_Redirector.BlockAndRedirect();
                    }

                    //Start value counter if it's not already started
                    if (!ValuesTimer.Enabled)
                    {
                        ValuesTimer.Enabled = true;
                    }
                }
                else if (NewValue == CheckState.Unchecked && ColumnIndex == 6 && device.Blocked && !device.Redirected)
                {
                    //Update device state in list
                    var listDevice = Devices.FirstOrDefault(D => D.Value.MAC == device.MAC);
                    if (listDevice.Equals(default(KeyValuePair<IPAddress, Device>)))
                        throw new CustomExceptions.DeviceNotInListException("Device was not found in the list of targeted devices.");

                    listDevice.Value.Blocked = false;

                    //Update device state in UI
                    device.Blocked = false;
                    device.DeviceStatus = "Online";
                    DeviceList.UpdateObject(device);

                    await Scanner.RestoreDevice(device);

                    //Checks if there are any devices left with active targeting
                    if (!Devices.Any(D => D.Value.Blocked == true))
                    {
                        pictureBox1.Image = NetStalker.Properties.Resources.color_ok;
                        Blocker_Redirector.BRMainSwitch = false;
                    }
                }
                else if (NewValue == CheckState.Unchecked && ColumnIndex == 5 && device.Redirected)
                {
                    //Update device state in list
                    var listDevice = Devices.FirstOrDefault(D => D.Value.MAC == device.MAC);
                    if (listDevice.Equals(default(KeyValuePair<IPAddress, Device>)))
                        throw new CustomExceptions.DeviceNotInListException("Device was not found in the list of targeted devices.");

                    listDevice.Value.Blocked = false;
                    listDevice.Value.Redirected = false;
                    listDevice.Value.Limited = false;
                    listDevice.Value.DownloadCap = 0;
                    listDevice.Value.UploadCap = 0;

                    device.Blocked = false;
                    device.Redirected = false;
                    device.Limited = false;
                    device.DownloadCap = 0;
                    device.UploadCap = 0;
                    device.DownloadSpeed = "";
                    device.UploadSpeed = "";
                    DeviceList.UpdateObject(device);

                    await Scanner.RestoreDevice(device);

                    //Checks if there are any devices left with the Redirected switch
                    if (!Devices.Any(D => D.Value.Redirected == true))
                    {
                        pictureBox1.Image = NetStalker.Properties.Resources.color_ok;
                        Blocker_Redirector.BRMainSwitch = false;
                        ValuesTimer.Enabled = false;
                        ValuesTimer.Stop();
                    }
                }
                else
                {
                    //The user action didn't hit any of our conditions so we cancel it and reset the value
                    return false;
                }

            }
            catch (CustomExceptions.DeviceNotInListException)
            {
                MetroMessageBox.Show(this, "The selected device was not found in the list or targets", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        #endregion

        #region Tooltip Event Handlers

        private void ToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(51, 51, 51)), e.Bounds);//Background color

            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(204, 204, 204), 1), new Rectangle(e.Bounds.X, e.Bounds.Y,
                e.Bounds.Width - 1, e.Bounds.Height - 1));//The white bounds

            e.Graphics.DrawString(e.ToolTipText, new Font("Roboto", 9), new SolidBrush(Color.FromArgb(204, 204, 204)), e.Bounds.X + 8, e.Bounds.Y + 7); //Text with image location
        }

        private void ToolTip_Popup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = new Size(e.ToolTipSize.Width - 7, e.ToolTipSize.Height - 5);
        }

        #endregion

        #region Notify Icon Event Handlers

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            TrayIcon.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Toast Actions

        public async Task BlockDevice(string IpAddress, string MacAddress)
        {
            try
            {
                var ListDevice = DeviceList.Objects.Cast<Device>().FirstOrDefault(d => d.MAC.Equals(PhysicalAddress.Parse(MacAddress)));

                if (ListDevice != null && !(ListDevice.IsGateway || ListDevice.IsLocalDevice) && !(ListDevice.Blocked || ListDevice.Redirected))
                {
                    //6 is the index of the blocking column
                    if (await SubItemCheckingHandler(CheckState.Unchecked, CheckState.Checked, 6, ListDevice))
                    {
                        DeviceList.CheckSubItem(ListDevice, olvColumn6);
                    }
                }
            }
            catch
            {
                MetroMessageBox.Show(this, "Operation failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
