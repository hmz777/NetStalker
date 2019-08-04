using System;
using System.Threading;
using CSArp;
using PacketDotNet;
using SharpPcap;
using Timer = System.Windows.Forms.Timer;

namespace NetStalker
{
    public class LimiterClass
    {
        private ICaptureDevice capturedevice;
        private string TargetMAC;
        private string GatewayMAC;
        public Device device;


        public LimiterClass(Device device)
        {
            this.device = device;
            capturedevice = CaptureDeviceList.New()[Properties.Settings.Default.AdapterName];
            TargetMAC = GetClientList.GetMACString(device.MAC);
            GatewayMAC = GetClientList.GetMACString(device.GatewayMAC);

        }

        public void StartLimiter()
        {
            try
            {
                if (capturedevice != null)
                {
                    capturedevice.Open(DeviceMode.Normal, 1); //test difference in performance between the two modes
                    capturedevice.Filter = $"(ip and ether src {TargetMAC.ToLower()}) or (ip and ether src {GatewayMAC.ToLower()} and dst net {device.IP})"; //dotted macs

                    new Thread(Limiter).Start();

                }
            }
            catch (Exception)
            {

            }
        }

        public void Limiter()
        {


            RawCapture rawCapture;
            do
            {
                if ((rawCapture = capturedevice.GetNextPacket()) != null)
                {
                    EthernetPacket Packet;
                    try
                    {
                        Packet = PacketDotNet.Packet.ParsePacket(rawCapture.LinkLayerType, rawCapture.Data) as EthernetPacket;
                        if (Packet == null) { return; }
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    if (Packet.SourceHwAddress.Equals(device.MAC))
                    {

                        if (device.UploadCap == 0 || device.UploadCap > device.PacketsSentSinceLastReset)
                        {
                            Packet.SourceHwAddress = capturedevice.MacAddress;
                            Packet.DestinationHwAddress = device.GatewayMAC;
                            capturedevice.SendPacket(Packet);
                            device.PacketsSentSinceLastReset += Packet.Bytes.Length;
                        }

                    }
                    else if (Packet.SourceHwAddress.Equals(device.GatewayMAC))
                    {
                        IPv4Packet IPV4 = Packet.Extract(typeof(IPv4Packet)) as IPv4Packet;

                        if (IPV4.DestinationAddress.Equals(device.IP))
                        {
                            if (device.DownloadCap == 0 || device.DownloadCap > device.PacketsReceivedSinceLastReset)
                            {
                                Packet.SourceHwAddress = capturedevice.MacAddress;
                                Packet.DestinationHwAddress = device.MAC;
                                capturedevice.SendPacket(Packet);
                                device.PacketsReceivedSinceLastReset += Packet.Bytes.Length;
                            }
                        }
                    }
                }

            } while (device.LimiterStarted && device.Redirected);

            device.LimiterStarted = false;


        }


    }
}
