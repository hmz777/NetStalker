using BrightIdeasSoftware;
using NetStalker.Forms.Information;
using NetStalker.MainLogic;
using NetStalker.ToastNotifications;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace NetStalker
{
    public partial class Main : Form, IView
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
        /// <summary>
        /// A dictionary containing targets' user defined friendly names.
        /// </summary>
        public static Dictionary<string, string> DeviceFriendlyNames = new Dictionary<string, string>();
        /// <summary>
        /// A switch indicating that the user has checked the block all checkbox (used for deciding whether to block future discovered devices)
        /// </summary>
        public static bool BlockAll { get; set; }
        /// <summary>
        /// A switch indicating that the user has checked the redirect all checkbox  (used for deciding whether to redirect future discovered devices)
        /// </summary>
        public static bool RedirectAll { get; set; }
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

            //var materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);

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
            ListOverlay.Font = new Font("Century Gothic", 25);


            DeviceList.UseNotifyPropertyChanged = true;

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
                    if (!Device.Value.IsGateway && !Device.Value.IsLocalDevice && (DateTime.Now.Ticks - Device.Value.TimeSinceLastArp.Ticks) > 900000000L) //90 seconds
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
                    if (!Device.Value.IsGateway && !Device.Value.IsLocalDevice && (DateTime.Now.Ticks - Device.Value.TimeSinceLastArp.Ticks) > 1200000000L) //120 seconds
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
        private void ResetPacketCount()
        {
            foreach (var device in Devices)
            {
                device.Value.PacketsSentSinceLastReset = 0;
                device.Value.PacketsReceivedSinceLastReset = 0;
            }
        }
        /// <summary>
        /// Check if there is a device info file and read it.
        /// </summary>
        private void LoadSavedDeviceInfo()
        {
            var InfoFile = "DeviceInfo.json";

            if (File.Exists(InfoFile))
            {
                var json = File.ReadAllText(InfoFile);
                DeviceFriendlyNames = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            }
        }

        private void ToggleDarkMode()
        {
            ListOverlay.BackColor = Color.FromArgb(71, 71, 71);
            ListOverlay.TextColor = Color.FromArgb(204, 204, 204);
            DeviceList.BackColor = Color.FromArgb(51, 51, 51);
            DeviceList.HeaderFormatStyle = DarkHeaders;
            DeviceList.HotItemStyle = DarkHot;
            DeviceList.ForeColor = Color.FromArgb(204, 204, 204);
            DeviceList.SelectedBackColor = Color.FromArgb(88, 88, 88);
            DeviceList.SelectedForeColor = Color.FromArgb(204, 204, 204);
            DeviceList.UnfocusedSelectedBackColor = Color.FromArgb(204, 204, 204);
            DeviceList.UnfocusedSelectedForeColor = Color.FromArgb(88, 88, 88);
            LoadingIndicator.Image = Properties.Resources.spinW;
        }

        private void ToggleLightMode()
        {
            ListOverlay.BackColor = Color.FromArgb(204, 204, 204);
            ListOverlay.TextColor = Color.FromArgb(71, 71, 71);
            DeviceList.BackColor = Color.White;
            DeviceList.HeaderFormatStyle = LightHeaders;
            DeviceList.HotItemStyle = LightHot;
            DeviceList.ForeColor = Color.FromArgb(54, 54, 54);
            DeviceList.SelectedBackColor = Color.FromArgb(214, 214, 214);
            DeviceList.SelectedForeColor = Color.FromArgb(51, 51, 51);
            DeviceList.UnfocusedSelectedBackColor = Color.FromArgb(71, 71, 71);
            DeviceList.UnfocusedSelectedForeColor = Color.FromArgb(204, 204, 204);
            LoadingIndicator.Image = Properties.Resources.spinB;
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
        public Label StatusLabel
        {
            get
            {
                return DeviceCountLabel;
            }
        }
        public Label StatusLabel2
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
                return LoadingIndicator;
            }
        }
        public PictureBox PictureBox
        {
            get { return OpIndicator; }
        }
        public ToolTip TTip
        {
            get { return Tooltip; }
        }
        public Button Tile
        {
            get { return SnifferButton; }
        }
        public Button Tile2
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
            if (AppConfiguration.DarkMode)
            {
                ToggleDarkMode();
            }
            else
            {
                ToggleLightMode();
            }

            Controller.AttachOnExitEventHandler(this);
            ToastAPI.AttachHandler();
            LoadSavedDeviceInfo();
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
                    using (var message = new MessageBoxForm("Quit", Properties.Resources.AppQuit, MessageBoxIcon.Question, MessageBoxButtons.OKCancel))
                    {
                        if (message.ShowDialog() == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                        }
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
                ResizeDone = false;
                StatusLabel.Text = "Working";
                DeviceList.EmptyListMsg = "Scanning...";
                StatusLabel.Text = "Please wait...";
                OpIndicator.Image = Properties.Resources.color_error;

                AliveTimer.Enabled = true;

                Task.Run(() =>
                {
                    Controller.RefreshClients(this);
                });
            }
            else
            {
                using (var message = new MessageBoxForm("Info", Properties.Resources.ScanStillInProgress, MessageBoxIcon.Information, MessageBoxButtons.OK))
                {
                    message.ShowDialog();
                }
            }
        }

        /// <summary>
        /// The click event handler for the "Help" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpButton_Click(object sender, EventArgs e)
        {
            using (var message = new MessageBoxForm("Help", Properties.Resources.HelpText, MessageBoxIcon.Information, MessageBoxButtons.OK))
            {
                message.ShowDialog();
            }
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
                    throw new Exception(Properties.Resources.RefreshScanNotActive);

                RefreshButton.Enabled = false;

                await Scanner.ProbeDevices();

                RefreshButton.Enabled = true;
            }
            catch (Exception ex)
            {
                using (var message = new MessageBoxForm("Error", ex.Message, MessageBoxIcon.Error, MessageBoxButtons.OK))
                {
                    message.ShowDialog();
                }
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
                using (var message = new MessageBoxForm("Error", Properties.Resources.SelectDevice, MessageBoxIcon.Error, MessageBoxButtons.OK))
                {
                    message.ShowDialog();
                }
            }
            catch (CustomExceptions.OperationInProgressException)
            {
                using (var message = new MessageBoxForm("Error", Properties.Resources.SnifferLimiterStillActive, MessageBoxIcon.Error, MessageBoxButtons.OK))
                {
                    message.ShowDialog();
                }
            }
            catch (CustomExceptions.RedirectionNotActiveException)
            {
                using (var message = new MessageBoxForm("Error", Properties.Resources.MustRedirectFirst, MessageBoxIcon.Error, MessageBoxButtons.OK))
                {
                    message.ShowDialog();
                }
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
                using (var message = new MessageBoxForm("Error", Properties.Resources.LimiterDeviceNotReady, MessageBoxIcon.Error, MessageBoxButtons.OK))
                {
                    message.ShowDialog();
                }
            }
            catch (CustomExceptions.LocalHostTargeted)
            {
                using (var message = new MessageBoxForm("Error", Properties.Resources.NoGatewayOrOwnDevice, MessageBoxIcon.Error, MessageBoxButtons.OK))
                {
                    message.ShowDialog();
                }
            }
            catch (CustomExceptions.RedirectionNotActiveException)
            {
                using (var message = new MessageBoxForm("Error", Properties.Resources.LimiterDeviceNotReady, MessageBoxIcon.Error, MessageBoxButtons.OK))
                {
                    message.ShowDialog();
                }
            }
        }

        #endregion

        #region List Event Handlers

        private void DeviceList_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            if (e.Item == null)
            {
                DeviceList.ContextMenuStrip = null;

            }
            else
            {
                DeviceList.ContextMenuStrip = DeviceMenu;
            }

            e.Handled = true;
        }

        private void DeviceList_MouseDown(object sender, MouseEventArgs e)
        {
            var item = DeviceList.GetItemAt(e.X, e.Y);
            if (item == null)
            {
                DeviceList.ContextMenu = null;
                DeviceList.SelectedObjects.Clear();
            }
        }

        private async void DeviceList_ItemsAdding(object sender, ItemsAddingEventArgs e)
        {
            var objectsToAdd = e.ObjectsToAdd.Cast<Device>();

            if (objectsToAdd.Count() > 0)
            {
                Device device = objectsToAdd.First();

                if (BlockAll)
                {
                    if (!device.IsGateway && !device.IsLocalDevice && !device.Blocked)
                    {
                        var res = await SubItemCheckingHandler(CheckState.Unchecked, CheckState.Checked, 6, device);
                        DeviceList.CheckSubItem(device, olvColumn6);

                        if (res)
                        {
                            if (WindowState == FormWindowState.Minimized && Properties.Settings.Default.SuppressNotifications == 2)
                            {
                                ToastAPI.ShowPrompt(string.Format("{0}\nIP:{1}\nMAC:{2}\nDevice has been automatically blocked.",
                                    Properties.Resources.NewTargetNotificationPrompt,
                                    device.IP,
                                    device.MAC), NotificationPurpose.Message, device.IP.ToString(), device.MAC.ToString());
                            }
                        }
                    }
                }
                else if (RedirectAll)
                {
                    if (!device.IsGateway && !device.IsLocalDevice && !device.Redirected)
                    {
                        var res = await SubItemCheckingHandler(CheckState.Unchecked, CheckState.Checked, 5, device);
                        DeviceList.CheckSubItem(device, olvColumn5);

                        if (res)
                        {
                            if (WindowState == FormWindowState.Minimized && Properties.Settings.Default.SuppressNotifications == 2)
                            {
                                ToastAPI.ShowPrompt(string.Format("{0}\nIP:{1}\nMAC:{2}\nDevice has been automatically redirected.",
                                    Properties.Resources.NewTargetNotificationPrompt,
                                    device.IP,
                                    device.MAC), NotificationPurpose.Message, device.IP.ToString(), device.MAC.ToString());
                            }
                        }
                    }
                }
                else
                {
                    //If no previous action were taken
                    if (WindowState == FormWindowState.Minimized && Properties.Settings.Default.SuppressNotifications == 2)
                    {
                        ToastAPI.ShowPrompt(string.Format("{0}\nIP:{1}\nMAC:{2}",
                            Properties.Resources.NewTargetNotificationPrompt,
                            device.IP,
                            device.MAC), NotificationPurpose.TargetDiscovery, device.IP.ToString(), device.MAC.ToString());
                    }
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
                    using (var message = new MessageBoxForm("Error", Properties.Resources.NoLimiterWhileSniffer, MessageBoxIcon.Error, MessageBoxButtons.OK))
                    {
                        message.ShowDialog();
                    }

                    return false;
                }

                //Get the device in the selected row
                DeviceList.SelectObject(RowObject);
                Device device = RowObject as Device;

                if (device.IsGateway || device.IsLocalDevice)
                {
                    using (var message = new MessageBoxForm("Error", Properties.Resources.NoGatewayOrOwnDevice, MessageBoxIcon.Error, MessageBoxButtons.OK))
                    {
                        message.ShowDialog();
                    }

                    return false;
                }

                if (NewValue == CheckState.Checked && ColumnIndex == 6 && !device.Blocked && !device.Redirected)
                {
                    //Update device state in list
                    var listDevice = Devices.FirstOrDefault(D => D.Value.MAC == device.MAC);
                    if (listDevice.Equals(default(KeyValuePair<IPAddress, Device>)))
                        throw new CustomExceptions.DeviceNotInListException(Properties.Resources.DeviceNotFound);

                    listDevice.Value.Blocked = true;

                    //Update device state in UI
                    device.Blocked = true;
                    device.DeviceStatus = "Offline";
                    DeviceList.UpdateObject(device);
                    OpIndicator.Image = NetStalker.Properties.Resources.icons8_ok_red;

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
                        throw new CustomExceptions.DeviceNotInListException(Properties.Resources.DeviceNotFound);

                    listDevice.Value.Blocked = true;
                    listDevice.Value.Redirected = true;

                    //Update device state in UI
                    device.Blocked = true;
                    device.Redirected = true;
                    device.DownloadCap = 0;
                    device.UploadCap = 0;
                    DeviceList.UpdateObject(device);
                    OpIndicator.Image = NetStalker.Properties.Resources.icons8_ok_red;

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
                        throw new CustomExceptions.DeviceNotInListException(Properties.Resources.DeviceNotFound);

                    listDevice.Value.Blocked = false;

                    //Update device state in UI
                    device.Blocked = false;
                    device.DeviceStatus = "Online";
                    DeviceList.UpdateObject(device);

                    await Scanner.RestoreDevice(device);

                    //Checks if there are any devices left with active targeting
                    if (!Devices.Any(D => D.Value.Blocked == true))
                    {
                        OpIndicator.Image = NetStalker.Properties.Resources.color_ok;
                        Blocker_Redirector.BRMainSwitch = false;
                    }
                }
                else if (NewValue == CheckState.Unchecked && ColumnIndex == 5 && device.Redirected)
                {
                    //Update device state in list
                    var listDevice = Devices.FirstOrDefault(D => D.Value.MAC == device.MAC);
                    if (listDevice.Equals(default(KeyValuePair<IPAddress, Device>)))
                        throw new CustomExceptions.DeviceNotInListException(Properties.Resources.DeviceNotFound);

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
                        OpIndicator.Image = NetStalker.Properties.Resources.color_ok;
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
                using (var message = new MessageBoxForm("Error", Properties.Resources.DeviceNotFound, MessageBoxIcon.Error, MessageBoxButtons.OK))
                {
                    message.ShowDialog();
                }

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

            e.Graphics.DrawString(e.ToolTipText, new Font("Century Gothic", 9), new SolidBrush(Color.FromArgb(204, 204, 204)), e.Bounds.X + 8, e.Bounds.Y + 7); //Text with image location
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
                using (var message = new MessageBoxForm("Error", Properties.Resources.OpFailed, MessageBoxIcon.Error, MessageBoxButtons.OK))
                {
                    message.ShowDialog();
                }
            }
        }

        #endregion

        #region Device Menu Event Handlers

        private void SetName_Click(object sender, EventArgs e)
        {
            var selectedDevice = DeviceList.SelectedObject as Device;
            string deviceName;

            using (var set = new SetNameDialog(selectedDevice.DeviceName))
            {
                set.ShowDialog();

                if (!string.IsNullOrWhiteSpace(set.NameBox.Text))
                {
                    deviceName = set.NameBox.Text;
                    string MacString = selectedDevice.MAC.ToString();

                    if (!DeviceFriendlyNames.Any(d => d.Key == MacString))
                    {
                        DeviceFriendlyNames.Add(MacString, deviceName);
                    }
                    else
                    {
                        DeviceFriendlyNames[MacString] = deviceName;
                    }

                    var json = JsonSerializer.Serialize(DeviceFriendlyNames);

                    File.WriteAllText("DeviceInfo.json", json);

                    selectedDevice.DeviceName = deviceName;
                    DeviceList.UpdateObject(selectedDevice);
                }
            }
        }

        private void ClearName_Click(object sender, EventArgs e)
        {
            var selectedDevice = DeviceList.SelectedObject as Device;
            DeviceFriendlyNames.Remove(selectedDevice.MAC.ToString());

            var json = JsonSerializer.Serialize(DeviceFriendlyNames);

            File.WriteAllText("DeviceInfo.json", json);

            selectedDevice.DeviceName = selectedDevice.IP.ToString();
            DeviceList.UpdateObject(selectedDevice);
        }

        #endregion

        #region Block All/Redirect All Event Handlers

        private async void BlockAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!RedirectAll)
            {
                if (!BlockAllCheck.Checked)
                {
                    foreach (Device device in DeviceList.Objects.Cast<Device>().ToList())
                    {
                        if (!device.IsGateway && !device.IsLocalDevice && !device.Blocked)
                        {
                            _ = await SubItemCheckingHandler(CheckState.Unchecked, CheckState.Checked, 6, device);
                            DeviceList.CheckSubItem(device, olvColumn6);
                        }
                    }

                    BlockAllCheck.Checked = true;
                    BlockAll = true;
                }
                else
                {
                    foreach (Device device in DeviceList.Objects.Cast<Device>().ToList())
                    {
                        if (!device.IsGateway && !device.IsLocalDevice && device.Blocked)
                        {
                            _ = await SubItemCheckingHandler(CheckState.Checked, CheckState.Unchecked, 6, device);
                            DeviceList.UncheckSubItem(device, olvColumn6);
                        }
                    }

                    BlockAllCheck.Checked = false;
                    BlockAll = false;
                }
            }
        }

        private async void RedirectAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!BlockAll)
            {
                if (!RedirectAllCheck.Checked)
                {
                    foreach (Device device in DeviceList.Objects.Cast<Device>().ToList())
                    {
                        if (!device.IsGateway && !device.IsLocalDevice && !device.Redirected)
                        {
                            _ = await SubItemCheckingHandler(CheckState.Unchecked, CheckState.Checked, 5, device);
                            DeviceList.CheckSubItem(device, olvColumn5);
                        }
                    }

                    RedirectAllCheck.Checked = true;
                    RedirectAll = true;
                }
                else
                {
                    foreach (Device device in DeviceList.Objects.Cast<Device>().ToList())
                    {
                        if (!device.IsGateway && !device.IsLocalDevice && device.Redirected)
                        {
                            _ = await SubItemCheckingHandler(CheckState.Checked, CheckState.Unchecked, 5, device);
                            DeviceList.UncheckSubItem(device, olvColumn5);
                        }
                    }

                    RedirectAllCheck.Checked = false;
                    RedirectAll = false;
                }
            }
        }

        #endregion
    }
}
