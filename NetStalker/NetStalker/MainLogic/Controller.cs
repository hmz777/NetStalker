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
            if (!string.IsNullOrEmpty(NetStalker.Properties.Settings.Default.friendlyname)) //if a network interface has been selected
            {
                if (view.StatusLabel.Text.IndexOf("Scanning") == -1) //if a scan isn't active already
                {
                    try
                    {
                        Scanner.StartScan(view, NetStalker.Properties.Settings.Default.friendlyname);
                    }
                    catch
                    {

                    }

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
                try
                {
                    //Turn off the BR
                    Blocker_Redirector.BRMainSwitch = false;

                    foreach (var device in Main.Devices)
                    {
                        device.Redirected = false;
                        device.Blocked = false;
                        device.Limited = false;
                    }

                    if (Blocker_Redirector.BRTask != null && Blocker_Redirector.BRTask.Status == System.Threading.Tasks.TaskStatus.Running)
                    {
                        //Wait for the BR task to finish
                        Blocker_Redirector.BRTask.Wait();

                        //Dispose of the BR task
                        Blocker_Redirector.BRTask.Dispose();
                    }

                    //Close the capture device
                    Scanner.CloseAllCaptures(view);

                    //Clean all notifications
                    //NotificationAPI.ClearNotifications();
                }
                catch
                {

                }
            };
        }
    }
}
