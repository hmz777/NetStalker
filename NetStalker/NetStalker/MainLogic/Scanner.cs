using MetroFramework;
using NetStalker.MainLogic;
using PacketDotNet;
using SharpPcap;
using SharpPcap.Npcap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace NetStalker
{
    public static class Scanner
    {
        #region Vars

        private static ICaptureDevice capturedevice;
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
                try
                {
                    capturedevice.StopCapture(); //stop previous capture
                    capturedevice.Close(); //close previous instances
                    BackgroundScanDisabled = true;
                    GatewayCalled = false;
                    Main.CheckboxActive = false;
                    StopTheLoadingBar(view);

                }
                catch
                {
                }
            }

            ClientList = new Dictionary<IPAddress, PhysicalAddress>();
            Main.Devices.Clear();

            #endregion

            //Get list of interfaces
            CaptureDeviceList capturedevicelist = CaptureDeviceList.Instance;
            //crucial for reflection on any network changes
            capturedevicelist.Refresh();
            capturedevice = (from devicex in capturedevicelist where ((NpcapDevice)devicex).Interface.FriendlyName == InterfaceFriendlyName select devicex).ToList()[0];
            //open device in promiscuous mode with 1000ms timeout
            capturedevice.Open(DeviceMode.Promiscuous, 1000);
            //Arp filter
            capturedevice.Filter = "arp";

            IPAddress myipaddress = AppConfiguration.LocalIp;

            //Probe for active devices on the network
            if (DiscoveryTimer == null)
                StartDescoveryTimer();

            #region Retrieving ARP packets floating around and find out the sender's IP and MAC

            //Scan duration
            long scanduration = 8000;
            RawCapture rawcapture = null;

            //Main scanning task
            ScannerTask = Task.Run(() =>
             {
                 try
                 {
                     Stopwatch stopwatch = new Stopwatch();
                     stopwatch.Start();
                     while ((rawcapture = capturedevice.GetNextPacket()) != null && stopwatch.ElapsedMilliseconds <= scanduration)
                     {
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
                                 DeviceName = "Resolving",
                                 ManName = "Getting information...",
                                 DeviceStatus = "Online"
                             };

                             //Add device to UI list
                             view.ListView1.BeginInvoke(new Action(() => { view.ListView1.AddObject(device); }));

                             //Add device to main device list
                             Main.Devices.Add(device);

                             //Get hostname and mac vendor for the current device
                             _ = Task.Run(async () =>
                              {
                                  try
                                  {
                                      #region Get Hostname

                                      IPHostEntry hostEntry = await Dns.GetHostEntryAsync(ip);
                                      device.DeviceName = hostEntry?.HostName ?? ip;

                                      #endregion

                                      #region Get MacVendor

                                      var Name = VendorAPI.GetVendorInfo(mac);
                                      device.ManName = (Name is null) ? "" : Name.data.organization_name;

                                      #endregion

                                      view.ListView1.BeginInvoke(new Action(() => { view.ListView1.UpdateObject(device); }));
                                  }
                                  catch (Exception ex)
                                  {
                                      if (ex is SocketException)
                                      {
                                          var Name = VendorAPI.GetVendorInfo(mac);
                                          device.ManName = (Name is null) ? "" : Name.data.organization_name;

                                          view.ListView1.BeginInvoke(new Action(() =>
                                          {
                                              device.DeviceName = ip;
                                              view.ListView1.UpdateObject(device);
                                          }));
                                      }
                                  }
                              });
                         }

                         int percentageprogress = (int)((float)stopwatch.ElapsedMilliseconds / scanduration * 100);

                         view.MainForm.BeginInvoke(new Action(() => view.StatusLabel.Text = "Scanning " + percentageprogress + "%"));
                     }

                     stopwatch.Stop();
                     Main.operationinprogress = false;
                     view.MainForm.Invoke(new Action(() => view.StatusLabel.Text = ClientList.Count.ToString() + " device(s) found"));

                     //start passive monitoring
                     BackgroundScanStart(view);
                 }
                 catch
                 {
                     //Show an error in the UI in case something went wrong
                     view.MainForm.Invoke(new Action(() => view.StatusLabel.Text = "Error occurred"));
                 }
             });

            #endregion
        }

        /// <summary>
        /// Actively monitor ARP packets for signs of new clients after the scanner is done. This method sould be called from the StartScan method.
        /// </summary>
        /// <param name="view">UI controls</param>
        public static void BackgroundScanStart(IView view)
        {
            try
            {
                view.MainForm.BeginInvoke(new Action(() => view.StatusLabel.Text = "Starting background scan..."));
                BackgroundScanDisabled = false;

                IPAddress myipaddress = AppConfiguration.LocalIp;

                #region Assign OnPacketArrival event handler and start capturing

                capturedevice.OnPacketArrival += (object sender, CaptureEventArgs e) =>
                {
                    try
                    {
                        if (BackgroundScanDisabled) { return; }

                        Packet packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
                        if (packet == null) { return; }

                        ArpPacket ArpPacket = packet.Extract<ArpPacket>();

                        if (!ClientList.ContainsKey(ArpPacket.SenderProtocolAddress) && ArpPacket.SenderProtocolAddress.ToString() != "0.0.0.0" && Tools.AreCompatibleIPs(ArpPacket.SenderProtocolAddress, myipaddress, AppConfiguration.NetworkSize))
                        {
                            ClientList.Add(ArpPacket.SenderProtocolAddress, ArpPacket.SenderHardwareAddress);
                            view.ListView1.Invoke(new Action(() =>
                            {
                                string mac = Tools.GetMACString(ArpPacket.SenderHardwareAddress);
                                string ip = ArpPacket.SenderProtocolAddress.ToString();
                                var device = new Device
                                {
                                    IP = ArpPacket.SenderProtocolAddress,
                                    MAC = PhysicalAddress.Parse(mac.Replace(":", "")),
                                    DeviceName = "Resolving",
                                    ManName = "Getting information...",
                                    DeviceStatus = "Online"
                                };

                                //Add device to list
                                view.ListView1.BeginInvoke(new Action(() => { view.ListView1.AddObject(device); }));

                                //Add device to main device list
                                Main.Devices.Add(device);

                                //Get hostname and mac vendor for the current device
                                _ = Task.Run(async () =>
                                {
                                    try
                                    {
                                        #region Get Hostname

                                        IPHostEntry hostEntry = await Dns.GetHostEntryAsync(ip);
                                        device.DeviceName = hostEntry?.HostName ?? ip;

                                        #endregion

                                        #region Get MacVendor

                                        var Name = VendorAPI.GetVendorInfo(mac);
                                        device.ManName = (Name is null) ? "" : Name.data.organization_name;

                                        #endregion

                                        view.ListView1.BeginInvoke(new Action(() => { view.ListView1.UpdateObject(device); }));
                                    }
                                    catch (Exception ex)
                                    {
                                        if (ex is SocketException)
                                        {
                                            var Name = VendorAPI.GetVendorInfo(mac);
                                            device.ManName = (Name is null) ? "" : Name.data.organization_name;

                                            view.ListView1.BeginInvoke(new Action(() =>
                                            {
                                                device.DeviceName = ip;
                                                view.ListView1.UpdateObject(device);
                                            }));
                                        }
                                    }
                                });

                            }));

                            view.MainForm.Invoke(new Action(() => view.StatusLabel.Text = ClientList.Count + " device(s) found"));

                        }
                        else if (ClientList.ContainsKey(ArpPacket.SenderProtocolAddress))
                        {
                            foreach (Device Device in Main.Devices)
                            {
                                if (Device.IP.Equals(ArpPacket.SenderProtocolAddress))
                                {
                                    Device.TimeSinceLastArp = DateTime.Now;
                                    break;
                                }
                            }
                        }
                    }
                    catch
                    {

                    }

                };

                //Start recieving packets
                capturedevice.StartCapture();

                //Update UI state
                view.MainForm.BeginInvoke(new Action(() =>
                {
                    view.PictureBox.Image = NetStalker.Properties.Resources.icons8_ok_96px;
                    view.StatusLabel2.Text = "Ready";
                    view.Tile.Enabled = true;
                    view.Tile2.Enabled = true;
                }));

                if (!LoadingBarCalled)
                {
                    CallTheLoadingBar(view);
                    Main.CheckboxActive = true;
                    view.MainForm.BeginInvoke(new Action(() => view.StatusLabel.Text = "Scanning..."));
                }

                view.MainForm.Invoke(new Action(() => view.StatusLabel.Text = ClientList.Count + " device(s) found"));

                #endregion
            }
            catch
            {
            }
        }

        /// <summary>
        /// Start probing periodically for active devices depending on the size of the network. (Scanning in class A networks is disabled by default)
        /// </summary>
        public static void StartDescoveryTimer()
        {
            if (DiscoveryTimer == null)
            {
                if (AppConfiguration.NetworkSize == 1)
                    DiscoveryTimer = new Timer(ProbeDevices, null, 0, 30000);
                else if (AppConfiguration.NetworkSize == 2)
                    DiscoveryTimer = new Timer(ProbeDevices, null, 0, 60000);
            }
            else
            {
                if (AppConfiguration.NetworkSize == 1)
                    DiscoveryTimer.Change(10000, 30000);
                else if (AppConfiguration.NetworkSize == 2)
                    DiscoveryTimer.Change(30000, 60000);
            }
        }

        /// <summary>
        /// Stop the discovery timer.
        /// </summary>
        public static void StopDiscoveryTimer()
        {
            if (DiscoveryTimer != null)
                DiscoveryTimer.Dispose();
        }

        /// <summary>
        /// Probe for active devices on the network
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public async static void ProbeDevices(object stateInfo)
        {
            DiscoveryTimer.Change(Timeout.Infinite, Timeout.Infinite);

            await Task.Run(() =>
            {
                try
                {
                    if (AppConfiguration.NetworkSize == 1)
                    {
                        for (int ipindex = 1; ipindex <= 255; ipindex++)
                        {
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
                            for (int j = 1; j <= 255; j++)
                            {
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
                            for (int j = 1; j <= 255; j++)
                            {
                                for (int k = 1; k <= 255; k++)
                                {
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
                }
                catch
                {

                }
            });

            StartDescoveryTimer();
        }

        /// <summary>
        /// Stops any ongoing capture and closes capturedevice if open.
        /// </summary>
        public static void CloseAllCaptures(IView view = null)
        {
            try
            {
                BackgroundScanDisabled = true;

                if (capturedevice != null)
                {
                    capturedevice.StopCapture();
                    capturedevice.OnPacketArrival += null;
                    capturedevice.Close();
                }

                if (view != null && LoadingBarCalled)
                    StopTheLoadingBar(view);

            }
            catch { }
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
    }
}

