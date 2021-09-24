using NetStalker.MainLogic;
using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Threading.Timer;

namespace NetStalker
{
    public static class Scanner
    {
        #region Static Fields

        public static LibPcapLiveDevice capturedevice;
        public static bool BackgroundScanDisabled;
        private static bool GatewayCalled;
        public static bool LoadingBarCalled;
        public static Dictionary<IPAddress, PhysicalAddress> ClientList;
        public static Task ScannerTask;
        public static Timer DiscoveryTimer;
        public static IPAddress myipaddress = AppConfiguration.LocalIp;
        public static string Root = Tools.GetRoot(myipaddress, AppConfiguration.NetworkSize);

        #endregion

        /// <summary>
        /// Populates the list with devices connected on LAN
        /// </summary>
        /// <param name="view">UI controls</param>
        /// <param name="InterfaceFriendlyName"></param>
        public static void StartScan(IView view, string InterfaceFriendlyName)
        {
            #region initialization

            if (capturedevice != null)
            {
                GatewayCalled = false;
                BackgroundScanDisabled = true;
                capturedevice.StopCapture();
                capturedevice.Close();
                capturedevice = null;
            }
            else
            {
                ClientList = new Dictionary<IPAddress, PhysicalAddress>();
                Main.Devices = new ConcurrentDictionary<IPAddress, Device>();
            }

            #endregion

            //Get list of interfaces
            CaptureDeviceList capturedevicelist = CaptureDeviceList.Instance;
            //crucial for reflection on any network changes
            capturedevicelist.Refresh();
            capturedevice = (LibPcapLiveDevice)(from devicex in capturedevicelist where ((LibPcapLiveDevice)devicex).Interface.FriendlyName == InterfaceFriendlyName select devicex).ToList()[0];
            //open device in promiscuous mode with 1000ms timeout
            capturedevice.Open(DeviceModes.Promiscuous, 1000);
            //Arp filter
            capturedevice.Filter = "arp";

            IPAddress myipaddress = AppConfiguration.LocalIp;

            //Probe for active devices on the network
            if (DiscoveryTimer == null)
                StartDescoveryTimer();

            #region Retrieving ARP packets floating around and find out the sender's IP and MAC

            //Scan duration
            long scanduration = 10000;

            //Main scanning task
            ScannerTask = Task.Run(() =>
            {
                try
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    while (stopwatch.ElapsedMilliseconds <= scanduration)
                    {
                        if (capturedevice.GetNextPacket(out PacketCapture packetCapture) != GetPacketStatus.PacketRead)
                        {
                            continue;
                        }

                        ProcessPacket(packetCapture, view);

                        int percentageprogress = (int)((float)stopwatch.ElapsedMilliseconds / scanduration * 100);
                        view.MainForm.BeginInvoke(new Action(() => view.StatusLabel.Text = "Scanning " + percentageprogress + "%"));
                    }

                    stopwatch.Stop();
                    view.MainForm.BeginInvoke(new Action(() => view.StatusLabel.Text = ClientList.Count.ToString() + " device(s) found"));

                    //Initial scanning is over now we start the background scan.
                    Main.OperationIsInProgress = false;

                    //Start passive monitoring
                    BackgroundScanStart(view);
                }
                catch
                {
                    //Show an error in the UI in case something went wrong
                    try
                    {
                        view.MainForm.BeginInvoke(new Action(() =>
                        {
                            view.StatusLabel.Text = "Error occurred";
                            view.PictureBox.Image = Properties.Resources.color_error;
                        }));
                    }
                    catch { } //Swallow exception when the user closes the app during the scan operation
                }
            });

            #endregion
        }

        /// <summary>
        /// Actively monitor ARP packets for signs of new clients after the scanner is done. This method should be called from the StartScan method.
        /// </summary>
        /// <param name="view">UI controls</param>
        public static void BackgroundScanStart(IView view)
        {
            view.MainForm.BeginInvoke(new Action(() => view.StatusLabel.Text = "Starting background scan..."));
            BackgroundScanDisabled = false;

            IPAddress myipaddress = AppConfiguration.LocalIp;

            #region Assign OnPacketArrival event handler and start capturing

            capturedevice.OnPacketArrival += (object sender, PacketCapture e) =>
            {
                if (BackgroundScanDisabled) { return; }

                ProcessPacket(e, view);
            };

            //Start receiving packets
            capturedevice.StartCapture();

            //Update UI state
            view.MainForm.BeginInvoke(new Action(() =>
            {
                view.PictureBox.Image = Properties.Resources.color_ok;
                view.StatusLabel2.Text = "Ready";
                view.Tile.Enabled = true;
                view.Tile2.Enabled = true;
            }));

            if (!LoadingBarCalled)
            {
                CallTheLoadingBar(view);
                view.MainForm.BeginInvoke(new Action(() => view.StatusLabel.Text = "Scanning..."));
            }

            view.MainForm.BeginInvoke(new Action(() => view.StatusLabel.Text = ClientList.Count + " device(s) found"));

            #endregion
        }

        /// <summary>
        /// Start probing periodically for active devices depending on the size of the network. (Scanning in class A networks is disabled by default)
        /// </summary>
        public static void StartDescoveryTimer()
        {
            try
            {
                if (DiscoveryTimer == null)
                {
                    if (AppConfiguration.NetworkSize == 1)
                        DiscoveryTimer = new Timer(ProbingHandler, null, 0, 30000);
                    else if (AppConfiguration.NetworkSize == 2)
                        DiscoveryTimer = new Timer(ProbingHandler, null, 0, 60000);
                    else
                        DiscoveryTimer = new Timer(ProbingHandler, null, 0, 90000);
                }
                else
                {
                    if (AppConfiguration.NetworkSize == 1)
                        DiscoveryTimer.Change(7000, 30000);
                    else if (AppConfiguration.NetworkSize == 2)
                        DiscoveryTimer.Change(15000, 60000);
                    else
                        DiscoveryTimer.Change(30000, 90000);
                }
            }
            catch { }
        }

        /// <summary>
        /// Stop the discovery timer and dispose of it.
        /// </summary>
        public static void StopDiscoveryTimer()
        {
            if (DiscoveryTimer != null)
                DiscoveryTimer.Dispose();
        }

        /// <summary>
        /// The event handler for the probing timer
        /// </summary>
        /// <param name="stateInfo"></param>
        public async static void ProbingHandler(object stateInfo)
        {
            DiscoveryTimer.Change(Timeout.Infinite, Timeout.Infinite);

            await ProbeDevices();

            StartDescoveryTimer();
        }

        /// <summary>
        /// Probe for active devices on the network
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public async static Task ProbeDevices()
        {
            await Task.Run(() =>
            {
                if (AppConfiguration.NetworkSize == 1)
                {
                    for (int ipindex = 1; ipindex <= 255; ipindex++)
                    {
                        if (capturedevice == null || capturedevice.Opened == false)
                            break;

                        ArpPacket arprequestpacket = new ArpPacket(ArpOperation.Request, PhysicalAddress.Parse("00-00-00-00-00-00"), IPAddress.Parse(Root + ipindex), capturedevice.MacAddress, myipaddress);
                        EthernetPacket ethernetpacket = new EthernetPacket(capturedevice.MacAddress, PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"), EthernetType.Arp);
                        ethernetpacket.PayloadPacket = arprequestpacket;
                        capturedevice.SendPacket(ethernetpacket);
                    }
                }
                else if (AppConfiguration.NetworkSize == 2)
                {
                    for (int i = 1; i <= 255; i++)
                    {
                        if (capturedevice == null || capturedevice.Opened == false)
                            break;

                        for (int j = 1; j <= 255; j++)
                        {
                            if (capturedevice == null || capturedevice.Opened == false)
                                break;

                            ArpPacket arprequestpacket = new ArpPacket(ArpOperation.Request, PhysicalAddress.Parse("00-00-00-00-00-00"), IPAddress.Parse(Root + i + '.' + j), capturedevice.MacAddress, myipaddress);
                            EthernetPacket ethernetpacket = new EthernetPacket(capturedevice.MacAddress, PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"), EthernetType.Arp);
                            ethernetpacket.PayloadPacket = arprequestpacket;
                            capturedevice.SendPacket(ethernetpacket);
                            if (!GatewayCalled)
                            {
                                ArpPacket ArpForGateway = new ArpPacket(ArpOperation.Request, PhysicalAddress.Parse("00-00-00-00-00-00"), AppConfiguration.GatewayIp, capturedevice.MacAddress, myipaddress);//???
                                EthernetPacket EtherForGateway = new EthernetPacket(capturedevice.MacAddress, PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"), EthernetType.Arp);
                                EtherForGateway.PayloadPacket = ArpForGateway;
                                capturedevice.SendPacket(EtherForGateway);
                                GatewayCalled = true;
                            }
                        }
                    }
                }
                else if (AppConfiguration.NetworkSize == 3)
                {
                    for (int i = 1; i <= 255; i++)
                    {
                        if (capturedevice == null || capturedevice.Opened == false)
                            break;

                        for (int j = 1; j <= 255; j++)
                        {
                            if (capturedevice == null || capturedevice.Opened == false)
                                break;

                            for (int k = 1; k <= 255; k++)
                            {
                                if (capturedevice == null || capturedevice.Opened == false)
                                    break;

                                ArpPacket arprequestpacket = new ArpPacket(ArpOperation.Request,
                                    PhysicalAddress.Parse("00-00-00-00-00-00"),
                                    IPAddress.Parse(Root + i + '.' + j + '.' + k), capturedevice.MacAddress,
                                    myipaddress);
                                EthernetPacket ethernetpacket = new EthernetPacket(capturedevice.MacAddress,
                                    PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"), EthernetType.Arp);
                                ethernetpacket.PayloadPacket = arprequestpacket;
                                capturedevice.SendPacket(ethernetpacket);
                                if (!GatewayCalled)
                                {
                                    ArpPacket ArpForGateway = new ArpPacket(ArpOperation.Request, PhysicalAddress.Parse("00-00-00-00-00-00"), AppConfiguration.GatewayIp, capturedevice.MacAddress, myipaddress);//???
                                    EthernetPacket EtherForGateway = new EthernetPacket(capturedevice.MacAddress, PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"), EthernetType.Arp);//???
                                    EtherForGateway.PayloadPacket = ArpForGateway;
                                    capturedevice.SendPacket(EtherForGateway);
                                    GatewayCalled = true;
                                }
                            }
                        }
                    }
                }
            });
        }

        /// <summary>
        /// Reconnects device and gateway again disabling the spoofing effect on the selected device.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public async static Task RestoreDevice(Device device)
        {
            await Task.Run(() =>
            {
                ArpPacket gatewayPacket = new ArpPacket(ArpOperation.Response, AppConfiguration.BroadcastMac, AppConfiguration.GatewayIp, device.MAC, device.IP);
                EthernetPacket gatewayEtherPacket = new EthernetPacket(device.MAC, AppConfiguration.BroadcastMac, EthernetType.Arp)
                {
                    PayloadPacket = gatewayPacket
                };

                ArpPacket devicePacket = new ArpPacket(ArpOperation.Response, AppConfiguration.BroadcastMac, device.IP, AppConfiguration.GatewayMac, AppConfiguration.GatewayIp);
                EthernetPacket deviceEtherPacket = new EthernetPacket(AppConfiguration.GatewayMac, AppConfiguration.BroadcastMac, EthernetType.Arp)
                {
                    PayloadPacket = devicePacket
                };

                for (int i = 0; i < 20; i++)
                {
                    capturedevice.SendPacket(gatewayEtherPacket);
                    capturedevice.SendPacket(deviceEtherPacket);
                }

            });
        }

        /// <summary>
        /// Stop any ongoing capture, close the capturedevice if open and dispose of all tasks and timers and their resources.
        /// </summary>
        public static void CloseAllCaptures(IView view = null)
        {
            BackgroundScanDisabled = true;

            if (ScannerTask != null)
            {
                if (ScannerTask.Status == TaskStatus.Running)
                    ScannerTask.Wait();

                ScannerTask.Dispose();
            }

            StopDiscoveryTimer();

            if (capturedevice != null)
            {
                capturedevice.StopCapture();
                capturedevice.Close();
                capturedevice.Dispose();
            }

            if (view != null && LoadingBarCalled)
                StopTheLoadingBar(view);
        }

        /// <summary>
        /// Show the indication that there is an ongoing scan.
        /// </summary>
        /// <param name="view"></param>
        public static void CallTheLoadingBar(IView view)
        {
            try
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
            catch
            {
            }
        }

        /// <summary>
        /// Hide the scan indication
        /// </summary>
        /// <param name="view"></param>
        public static void StopTheLoadingBar(IView view)
        {
            try
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
            catch
            {
            }
        }

        /// <summary>
        /// Try to get the device name, either from the user defined info or by resolving.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public async static Task<string> GetHostName(Device device)
        {
            //Check if there is a user defined name for this device
            if (Main.DeviceFriendlyNames.TryGetValue(device.MAC.ToString(), out string val))
            {
                return val;
            }
            else
            {
                //No name was found, we try to resolve device
                IPHostEntry hostEntry = await Dns.GetHostEntryAsync(device.IP);
                return hostEntry?.HostName ?? device.IP.ToString();
            }
        }

        /// <summary>
        /// Get the manufacturer of the device using the vendor API
        /// </summary>
        /// <param name="MAC"></param>
        /// <returns></returns>
        public async static Task<string> GetVendorInfo(string MAC)
        {
            var Name = await VendorAPI.GetVendorInfo(MAC);

            if (Name is null)
            {
                return string.Empty;
            }
            else
            {
                return Name.data.organization_name;
            }
        }

        /// <summary>
        /// Process the current packet
        /// </summary>
        /// <param name="packetCapture"></param>
        /// <param name="view"></param>
        public static void ProcessPacket(PacketCapture packetCapture, IView view)
        {
            RawCapture rawcapture = packetCapture.GetPacket();
            Packet packet = Packet.ParsePacket(rawcapture.LinkLayerType, rawcapture.Data);
            ArpPacket ArpPacket = packet.Extract<ArpPacket>();
            if (!ClientList.ContainsKey(ArpPacket.SenderProtocolAddress) && ArpPacket.SenderProtocolAddress.ToString() != "0.0.0.0" && Tools.AreCompatibleIPs(ArpPacket.SenderProtocolAddress, myipaddress, AppConfiguration.NetworkSize))
            {
                ClientList.Add(ArpPacket.SenderProtocolAddress, ArpPacket.SenderHardwareAddress);

                string mac = Tools.GetMACString(ArpPacket.SenderHardwareAddress);
                string ip = ArpPacket.SenderProtocolAddress.ToString();
                var device = new Device
                {
                    IP = ArpPacket.SenderProtocolAddress,
                    MAC = PhysicalAddress.Parse(mac.Replace(":", "")),
                    DeviceName = "Resolving...",
                    ManName = "Getting information...",
                    DeviceStatus = "Online",
                    TimeSinceLastArp = DateTime.Now
                };

                //Add device to UI list
                view.ListView1.BeginInvoke(new Action(() => { view.ListView1.AddObject(device); }));

                //Add device to main device list
                _ = Main.Devices.TryAdd(ArpPacket.SenderProtocolAddress, device);

                //Get hostname and mac vendor for the current device
                _ = Task.Run(async () =>
                {
                    try
                    {
                        var host = await GetHostName(device);
                        device.DeviceName = host;
                    }
                    catch
                    {
                        device.DeviceName = ip;
                    }

                    var vendor = await GetVendorInfo(mac);
                    device.ManName = vendor;

                    view.ListView1.BeginInvoke(new Action(() => { view.ListView1.UpdateObject(device); }));
                });
            }
            else if (ClientList.ContainsKey(ArpPacket.SenderProtocolAddress))
            {
                if (Main.Devices.TryGetValue(ArpPacket.SenderProtocolAddress, out Device device))
                {
                    device.TimeSinceLastArp = DateTime.Now;

                }
            }
        }
    }
}