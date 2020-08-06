using NetStalker.MainLogic;
using System;
using System.Net;
using System.Net.NetworkInformation;

namespace NetStalker
{
    public class Device
    {
        public Device()
        {
            TimeSinceLastArp = DateTime.Now;
        }

        public DateTime TimeSinceLastArp { get; set; }
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
                if (IP.Equals(AppConfiguration.LocalIp))
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
                if (IP.Equals(AppConfiguration.GatewayIp))
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
        public bool Limited { get; set; }
    }
}
