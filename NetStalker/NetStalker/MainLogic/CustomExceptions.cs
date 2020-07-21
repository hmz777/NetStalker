using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStalker
{
    public class CustomExceptions
    {
        public class NoScanStartedException : Exception
        {
            public NoScanStartedException() : base() { }

            public NoScanStartedException(string message) : base(message) { }
        }

        public class NoDeviceSelectedException : Exception
        {
            public NoDeviceSelectedException() : base() { }

            public NoDeviceSelectedException(string message) : base(message) { }
        }

        public class ArpStateFalse : Exception
        {
            public ArpStateFalse() : base() { }

            public ArpStateFalse(string message) : base(message) { }
        }

        public class OperationInProgressException : Exception
        {
            public OperationInProgressException() : base() { }

            public OperationInProgressException(string message) : base(message) { }
        }

        public class RedirectionNotActiveException : Exception
        {
            public RedirectionNotActiveException() : base() { }

            public RedirectionNotActiveException(string message) : base(message) { }
        }

        public class LimiterActiveException : Exception
        {
            public LimiterActiveException() : base() { }

            public LimiterActiveException(string message) : base(message) { }
        }

        public class DeviceNotInListException : Exception
        {
            public DeviceNotInListException() : base() { }

            public DeviceNotInListException(string message) : base(message) { }
        }

        public class LocalHostTargeted : Exception
        {
            public LocalHostTargeted() : base() { }

            public LocalHostTargeted(string message) : base(message) { }
        }

        public class GatewayTargeted : Exception
        {
            public GatewayTargeted() : base() { }

            public GatewayTargeted(string message) : base(message) { }
        }
    }
}
