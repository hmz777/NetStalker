using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;

namespace NetStalker.MainLogic
{
    public class DeviceList
    {
        private static List<Device> Devices = new List<Device>();

        public static void AddDevice(Device device)
        {

        }

        public static void RemoveDevice(Device device)
        {

        }

        public static Device GetDevice(Func<Device, bool> expression)
        {
            return Devices.Where(expression).FirstOrDefault();
        }
    }
}
