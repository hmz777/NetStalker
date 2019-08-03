using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DesktopNotifications;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using CSArp;


namespace NetStalker.ToastNotifications
{
    public class NotificationAPI
    {
        public ToastNotification toast;
        private Main main = Application.OpenForms["Main"] as Main;
        private Device Device;

        public NotificationAPI(Device device = null)
        {
            this.Device = device;
        }
        public void CreateNotification()
        {
            // Construct the visuals of the toast (using Notifications library)

            //AddPic(Properties.Resources.logo);

            ToastContent toastContent = new ToastContent()
            {
                // Arguments when the user taps body of toast
                Launch = "bodyTapped",

                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {

                            new AdaptiveText()
                            {
                                Text = $"A new device detected!\nMAC: {Device.MAC}\nIP: {Device.IP}"
                            },

                        }
                    }
                },
                Actions = new ToastActionsCustom()
                {
                    Buttons = { new ToastButton("Show", "Show"), new ToastButton("Block", "Block"), new ToastButtonDismiss("Dismiss"), new ToastButton("Suppress", "Suppress") },

                },
                Header = new ToastHeader("header", "NetStalker", "header")
            };

            // Create the XML document (BE SURE TO REFERENCE WINDOWS.DATA.XML.DOM)
            var doc = new XmlDocument();
            doc.LoadXml(toastContent.GetContent());

            // And create the toast notification
            toast = new ToastNotification(doc);
        }

        public void ShowToast()
        {
            DesktopNotificationManagerCompat.CreateToastNotifier().Show(toast);
        }

        public void AttachHandlers()
        {
            toast.Activated += ToastOnActivated;
        }

        private void AddPic(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "logo.png", xByte);

        }

        private void DelPic()
        {
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + "logo.png");
        }

        public void CreateAndShowMessage(string message)
        {
            ToastContent toastContent = new ToastContent()
            {
                Launch = "bodyTapped",

                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = message
                            },

                        }
                    }
                },
                Header = new ToastHeader("header", "NetStalker", "header")
            };

            var doc = new XmlDocument();
            doc.LoadXml(toastContent.GetContent());

            var messageNotification = new ToastNotification(doc);

            DesktopNotificationManagerCompat.CreateToastNotifier().Show(messageNotification);
        }


        public void CreateAndShowPrompt(string message)
        {
            ToastContent toastContent = new ToastContent()
            {
                Launch = "bodyTapped",

                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = message
                            },

                        }
                    }
                },
                Actions = new ToastActionsCustom()
                {
                    Buttons = { new ToastButton("Yes", "Yes"), new ToastButton("No", "No") }
                },
                Header = new ToastHeader("header", "NetStalker", "header")
            };

            var doc = new XmlDocument();
            doc.LoadXml(toastContent.GetContent());

            var promptNotification = new ToastNotification(doc);
            promptNotification.Activated += PromptNotificationOnActivated;

            DesktopNotificationManagerCompat.CreateToastNotifier().Show(promptNotification);
        }

        private void PromptNotificationOnActivated(ToastNotification sender, object args)
        {
            ToastActivatedEventArgs strArgs = args as ToastActivatedEventArgs;

            switch (strArgs.Arguments)
            {
                case "Yes":
                    Properties.Settings.Default.SuppressN = "False";
                    Properties.Settings.Default.Save();
                    break;
                case "No":
                    Properties.Settings.Default.SuppressN = "True";
                    Properties.Settings.Default.Save();
                    break;
            }

        }

        private void ToastOnActivated(ToastNotification sender, object invokedArgs)
        {
            // Tapping on the top-level header launches with empty args
            ToastActivatedEventArgs strArgs = invokedArgs as ToastActivatedEventArgs;

            switch (strArgs.Arguments)
            {
                // Open the image
                case "Block":
                    {
                        try
                        {
                            if (Device.IsGateway || Device.IsLocalDevice)
                            {
                                throw new Controller.GatewayTargeted();
                            }

                            if (main.InvokeRequired)
                            {
                                main.BeginInvoke(new Action(() =>
                                {
                                    if (!Device.BlockerActive && !Device.RedirectorActive)
                                    {
                                        Device.GatewayMAC = main.GetGatewayMAC();
                                        Device.GatewayIP = main.GetGatewayIP();
                                        Device.LocalIP = main.GetLocalIP();
                                        Device.Blocked = true;
                                        Device.BlockerActive = true;
                                        Device.DeviceStatus = "Offline";
                                        Device.BlockOrRedirect();
                                        main.fastObjectListView1.UpdateObject(Device);
                                        main.pictureBox1.Image = NetStalker.Properties.Resources.icons8_ok_96;
                                    }

                                }));

                            }
                        }
                        catch (Exception e)
                        {
                            //Show a message that this is the gateway/local device
                            if (Device.IsGateway)
                            {
                                CreateAndShowMessage("Gateway can not be blocked!");
                            }
                            else if (Device.IsLocalDevice)
                            {
                                CreateAndShowMessage("The Local Device can not be blocked!");
                            }

                        }

                        break;
                    }
                case "Show":
                    {
                        if (main.InvokeRequired)
                        {
                            main.BeginInvoke(new Action(() =>
                            {
                                main.Show();
                                main.WindowState = FormWindowState.Normal;
                                if (main.notifyIcon1.Visible)
                                {
                                    main.notifyIcon1.Visible = false;
                                }
                            }));
                        }
                        else
                        {
                            main.Show();
                            main.WindowState = FormWindowState.Normal;
                            if (main.notifyIcon1.Visible)
                            {
                                main.notifyIcon1.Visible = false;
                            }

                        }

                        break;
                    }
                case "Suppress":
                    {
                        Properties.Settings.Default.SuppressN = "True";
                        Properties.Settings.Default.Save();
                        break;
                    }

            }
        }

        public static void RemoveNotification(string tag)
        {
            // Remove the toast with tag 
            DesktopNotificationManagerCompat.History.Remove(tag);
        }

        public static void ClearNotifications()
        {
            // Clear all toasts
            DesktopNotificationManagerCompat.History.Clear();
        }

    }


}

