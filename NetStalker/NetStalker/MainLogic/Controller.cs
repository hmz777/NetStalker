using NetStalker.MainLogic;
using NetStalker.ToastNotifications;
using System;
using System.Windows.Forms;

namespace NetStalker
{
    public static class Controller
    {
        /// <summary>
        /// Populate the LAN clients
        /// </summary>
        public static void RefreshClients(IView view)
        {
            if (!string.IsNullOrEmpty(NetStalker.Properties.Settings.Default.FriendlyName)) //if a network interface has been selected
            {
                if (view.DeviceCountIndicator.Text.IndexOf("Scanning") == -1) //if a scan isn't active already
                {
                    Scanner.StartScan(view, AppConfiguration.FriendlyName);
                }
            }
        }

        /// <summary>
        /// Attach the OnExit event handler, to do some clean up before exiting
        /// </summary>
        public static void AttachOnExitEventHandler(IView view)
        {
            Application.ApplicationExit += (object sender, EventArgs e) =>
            {
                //Terminate the Blocker/Redirector
                Blocker_Redirector.CLoseBR();

                //Terminate the scanner
                Scanner.CloseAllCaptures(view);

                //Clean all notifications
                ToastAPI.ClearNotificationHistory();

                //Toast notifications service cleanup
                ToastAPI.DestroyAPI();
            };
        }
    }
}
