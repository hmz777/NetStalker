using NetStalker.MainLogic;
using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Packet = PacketDotNet.Packet;

namespace NetStalker
{
    class AcceptedPacket
    {
        private PacketDotNet.Packet packet;
        private string host = "";
        DateTime time = DateTime.Now;

        public Packet Packet
        {
            get { return packet; }
            set { packet = value; }
        }

        public IPv4Packet IPV4Packet
        {
            get
            {
                return packet.Extract<IPv4Packet>();
            }
        }

        public TcpPacket TCPPacket
        {
            get
            {
                return IPV4Packet.Extract<TcpPacket>();
            }
        }

        public UdpPacket UDPPacket
        {
            get
            {
                return IPV4Packet.Extract<UdpPacket>();
            }
        }

        public DateTime Time
        {
            get { return time; }
        }

        public IPAddress Source
        {
            get { return IPV4Packet.SourceAddress; }
        }

        public IPAddress Destination
        {
            get { return IPV4Packet.DestinationAddress; }

        }

        public string Type
        {
            get
            {

                if (IsRequest)
                {
                    if (TCPPacket != null)
                    {
                        if (TCPPacket.DestinationPort == 443)
                        {
                            return "HTTPS";
                        }
                        else if (TCPPacket.DestinationPort == 80)
                        {
                            return "HTTP";
                        }
                        else if (TCPPacket.DestinationPort == 21 || TCPPacket.DestinationPort == 20)
                        {
                            return "FTP";
                        }
                        else if (TCPPacket.DestinationPort == 23)
                        {
                            return "TELNET";
                        }
                        else if (TCPPacket.DestinationPort == 25)
                        {
                            return "SMTP";
                        }
                        else if (TCPPacket.DestinationPort == 53)
                        {
                            return "DNS";
                        }
                        else if (TCPPacket.DestinationPort == 137 || TCPPacket.DestinationPort == 138 || TCPPacket.DestinationPort == 139)
                        {
                            return "NetBIOS";
                        }
                        else if (TCPPacket.DestinationPort == 110)
                        {
                            return "POP";
                        }
                        else if (TCPPacket.DestinationPort == 143)
                        {
                            return "IMAP";
                        }
                        else if (TCPPacket.DestinationPort == 161 || TCPPacket.DestinationPort == 162)
                        {
                            return "SNMP";
                        }
                        else if (TCPPacket.DestinationPort == 989 || TCPPacket.DestinationPort == 990)
                        {
                            return "FTPS";
                        }
                    }
                    else if (UDPPacket != null)
                    {
                        if (UDPPacket.DestinationPort == 63)
                        {
                            return "DNS";
                        }
                        else if (UDPPacket.DestinationPort == 67 || UDPPacket.DestinationPort == 68)
                        {
                            return "DHCP";
                        }
                        if (UDPPacket.DestinationPort == 69)
                        {
                            return "TFTP";
                        }
                        if (UDPPacket.DestinationPort == 123)
                        {
                            return "NTP";
                        }
                        else if (UDPPacket.DestinationPort == 161 || UDPPacket.DestinationPort == 162)
                        {
                            return "SNMP";
                        }
                        else if (UDPPacket.DestinationPort == 137 || UDPPacket.DestinationPort == 138 || UDPPacket.DestinationPort == 139)
                        {
                            return "NetBIOS";
                        }
                    }
                }
                else if (IsResponse)
                {
                    if (TCPPacket != null)
                    {
                        if (TCPPacket.SourcePort == 443)
                        {
                            return "HTTPS";
                        }
                        else if (TCPPacket.SourcePort == 80)
                        {
                            return "HTTP";
                        }
                        else if (TCPPacket.SourcePort == 21 || TCPPacket.SourcePort == 20)
                        {
                            return "FTP";
                        }
                        else if (TCPPacket.SourcePort == 23)
                        {
                            return "TELNET";
                        }
                        else if (TCPPacket.SourcePort == 25)
                        {
                            return "SMTP";
                        }
                        else if (TCPPacket.SourcePort == 53)
                        {
                            return "DNS";
                        }
                        else if (TCPPacket.SourcePort == 137 || TCPPacket.SourcePort == 138 || TCPPacket.SourcePort == 139)
                        {
                            return "NetBIOS";
                        }
                        else if (TCPPacket.SourcePort == 110)
                        {
                            return "POP";
                        }
                        else if (TCPPacket.SourcePort == 143)
                        {
                            return "IMAP";
                        }
                        else if (TCPPacket.SourcePort == 161 || TCPPacket.SourcePort == 162)
                        {
                            return "SNMP";
                        }
                        else if (TCPPacket.SourcePort == 989 || TCPPacket.SourcePort == 990)
                        {
                            return "FTPS";
                        }
                    }
                    else if (UDPPacket != null)
                    {
                        if (UDPPacket.SourcePort == 63)
                        {
                            return "DNS";
                        }
                        else if (UDPPacket.SourcePort == 67 || UDPPacket.SourcePort == 68)
                        {
                            return "DHCP";
                        }
                        if (UDPPacket.SourcePort == 69)
                        {
                            return "TFTP";
                        }
                        if (UDPPacket.SourcePort == 123)
                        {
                            return "NTP";
                        }
                        else if (UDPPacket.SourcePort == 161 || UDPPacket.SourcePort == 162)
                        {
                            return "SNMP";
                        }
                        else if (UDPPacket.SourcePort == 137 || UDPPacket.SourcePort == 138 || UDPPacket.SourcePort == 139)
                        {
                            return "NetBIOS";
                        }
                    }
                }



                return "N/A";


            }
        }

        public bool IsRequest
        {
            get
            {
                return Tools.AreCompatibleIPs(Source,
                    IPAddress.Parse(AppConfiguration.GatewayIp.ToString()), AppConfiguration.NetworkSize);
            }
        }

        public bool IsResponse
        {
            get { return !IsRequest; }
        }

        public string Host
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(host) && Type.Equals("HTTP") && HTTPData.Count > 0)
                    {
                        return HTTPData[0];
                    }
                }
                catch (Exception)
                {

                }

                return host;
            }

            set { host = value; }
        }

        public ushort ID
        {
            get
            {
                return IPV4Packet.Id;
            }
        }

        public string Protocol
        {
            get
            {
                return IPV4Packet.Protocol.ToString();
            }
        }

        public List<string> HTTPData
        {
            get
            {
                if (TCPPacket.PayloadData != null)
                {
                    return Encoding.UTF8.GetString(TCPPacket.PayloadData).Split('\n').ToList();
                }

                return default;
            }
        }
    }
}
