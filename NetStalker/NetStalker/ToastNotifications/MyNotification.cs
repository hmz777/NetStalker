using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DesktopNotifications;

namespace SelfishNetReWrite.ToastNotifications
{
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(INotificationActivationCallback))]
    [Guid("79A80A63-EFA4-4E1E-B749-E4D4DDCB5B49"), ComVisible(true)]
    public class MyNotification : NotificationActivator
    {
        public override void OnActivated(string arguments, NotificationUserInput userInput, string appUserModelId)
        {

        }
    }
}
