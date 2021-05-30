using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Windows.Forms;

namespace NetStalker.ToastNotifications
{
    /// <summary>
    /// A small API to simplify the interaction with the Microsoft.Toolkit.Uwp.Notifications library.
    /// </summary>
    public class ToastAPI
    {
        /// <summary>
        /// Returns if the notification event handler has been attached to <see cref="ToastNotificationManagerCompat.OnActivated"/>.
        /// </summary>
        static bool APIReady;

        /// <summary>
        /// Show a toast notification by providing the Content, Purpose, and optionally Device IP and MAC (for device blocking handling scenarios).
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="Purpose"></param>
        /// <param name="DeviceId"></param>
        public static void ShowPrompt(string Content, NotificationPurpose Purpose, string DeviceIP = "", string DeviceMAC = "")
        {
            var Toast = new ToastContentBuilder()
                .AddArgument("Action", Purpose)
                .AddArgument("DeviceIP", DeviceIP)
                .AddArgument("DeviceMAC", DeviceMAC)
                .AddText("NetStalker", AdaptiveTextStyle.Header)
                .AddText(Content);

            switch (Purpose)
            {
                case NotificationPurpose.NotificationsSuppression:
                    {
                        Toast.AddButton(new ToastButton()
                                .SetContent("Yes")
                                .AddArgument("Choice", NotificationChoice.Yes))
                             .AddButton(new ToastButton()
                                .SetContent("No")
                                .AddArgument("Choice", NotificationChoice.No));

                        break;
                    }
                case NotificationPurpose.TargetDiscovery:
                    {
                        Toast.AddButton(new ToastButton()
                                 .SetContent("Show")
                                 .AddArgument("Choice", NotificationChoice.Show))
                             .AddButton(new ToastButton()
                                 .SetContent("Block")
                                 .AddArgument("Choice", NotificationChoice.Block))
                             .AddButton(new ToastButtonDismiss())
                                 .AddButton(new ToastButton()
                                 .SetContent("Suppress Notifications")
                                 .AddArgument("Choice", NotificationChoice.Suppress));

                        break;
                    }
                default:
                    {
                        Toast = null;
                        return;
                    }
            }

            Toast.Show();
        }

        private async static void Notifications_OnActivated(ToastNotificationActivatedEventArgsCompat e)
        {
            ToastArguments args = ToastArguments.Parse(e.Argument);
            var MainForm = Application.OpenForms["Main"] as Main;

            if (ToastNotificationManagerCompat.WasCurrentProcessToastActivated())
            {
                MainForm.BeginInvoke(new Action(() =>
                {
                    MetroFramework.MetroMessageBox.Show(MainForm,
                        "Process has been activated by toast notification trigger.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }));

                return;
            }

            if (!Enum.TryParse<NotificationChoice>(args["Choice"], out NotificationChoice NotificationChoice))
            {
                return; //No choice to select then no action required e.g. body tapped
            }

            switch (Enum.Parse(typeof(NotificationPurpose), args["Action"]))
            {
                case NotificationPurpose.NotificationsSuppression:
                    {
                        switch (NotificationChoice)
                        {
                            case NotificationChoice.Yes:
                                Properties.Settings.Default.SuppressNotifications = 2;
                                break;
                            case NotificationChoice.No:
                                Properties.Settings.Default.SuppressNotifications = 1;
                                break;
                            default: return;
                        }

                        Properties.Settings.Default.Save();

                        break;
                    }
                case NotificationPurpose.TargetDiscovery:
                    {
                        switch (NotificationChoice)
                        {
                            case NotificationChoice.Show:
                                {
                                    if (MainForm.InvokeRequired)
                                    {
                                        MainForm.BeginInvoke(new Action(() =>
                                        {
                                            MainForm.Show();
                                            MainForm.WindowState = FormWindowState.Normal;

                                            if (MainForm.TrayIcon.Visible)
                                            {
                                                MainForm.TrayIcon.Visible = false;
                                            }
                                        }));
                                    }
                                    else
                                    {
                                        MainForm.Show();
                                        MainForm.WindowState = FormWindowState.Normal;

                                        if (MainForm.TrayIcon.Visible)
                                        {
                                            MainForm.TrayIcon.Visible = false;
                                        }
                                    }

                                    break;
                                }
                            case NotificationChoice.Block:
                                {
                                    if (!string.IsNullOrEmpty(args["DeviceIP"]) && !string.IsNullOrEmpty(args["DeviceMAC"]))
                                    {
                                        if (MainForm.InvokeRequired)
                                        {
                                            MainForm.BeginInvoke(new Action(async () =>
                                           {
                                               await MainForm.BlockDevice(args["DeviceIP"], args["DeviceMAC"]);
                                           }));
                                        }
                                        else
                                        {
                                            await MainForm.BlockDevice(args["DeviceIP"], args["DeviceMAC"]);
                                        }
                                    }

                                    break;
                                }
                            case NotificationChoice.Suppress:
                                {
                                    Properties.Settings.Default.SuppressNotifications = 1;
                                    Properties.Settings.Default.Save();
                                    break;
                                }
                            default: return;
                        }

                        break;
                    }

                default: return;
            }
        }

        public static void AttachHandler()
        {
            if (!APIReady)
            {
                ToastNotificationManagerCompat.OnActivated += Notifications_OnActivated;

                APIReady = true;
            }
        }

        public static void ClearNotificationHistory()
        {
            ToastNotificationManagerCompat.History.Clear();
        }

        public static void DestroyAPI()
        {
            ToastNotificationManagerCompat.Uninstall();
        }
    }
}