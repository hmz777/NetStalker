using Microsoft.Toolkit.Uwp.Notifications;
using NetStalker.MainLogic;
using NetStalker.ToastNotifications;
using System;
using System.Windows.Forms;

namespace NetStalker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main(string[] args)
        {
            DesktopNotificationManagerCompat.RegisterAumidAndComServer<MyNotification>(AppConfiguration.APP_ID);
            DesktopNotificationManagerCompat.RegisterActivator<MyNotification>();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main(args));
        }
    }
}
