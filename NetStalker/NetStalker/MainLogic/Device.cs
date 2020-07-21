using PacketDotNet;
using SharpPcap;
using SharpPcap.Npcap;
using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Threading;

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
        public bool Limited { get; set; }
    }
}
