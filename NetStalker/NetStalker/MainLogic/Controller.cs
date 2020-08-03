using NetStalker.MainLogic;
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
                if (view.StatusLabel.Text.IndexOf("Scanning") == -1) //if a scan isn't active already
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
                if (Main.Devices == null)
                    return;

                //Turn off the BR
                Blocker_Redirector.BRMainSwitch = false;

                foreach (var device in Main.Devices)
                {
                    device.Value.Redirected = false;
                    device.Value.Blocked = false;
                    device.Value.Limited = false;
                }

                if (Blocker_Redirector.BRTask != null && Blocker_Redirector.BRTask.Status == System.Threading.Tasks.TaskStatus.Running)
                {
                    //Wait for the BR task to finish
                    Blocker_Redirector.BRTask.Wait();

                    //Dispose of the BR task
                    Blocker_Redirector.BRTask.Dispose();
                }

                //Terminate the scanner
                Scanner.CloseAllCaptures(view);

                //Clean all notifications
                //NotificationAPI.ClearNotifications();
            };
        }
    }
}
