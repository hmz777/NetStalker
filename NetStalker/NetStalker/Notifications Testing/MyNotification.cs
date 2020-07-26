using DesktopNotifications;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace NetStalker.TestingArea.ToastNotifications
{
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(INotificationActivationCallback))]
    [Guid("79A80A63-EFA4-4E1E-B749-E4D4DDCB5B49"), ComVisible(true)]
    public class MyNotification : NotificationActivator
    {
        public override void OnActivated(string invokedArgs, NotificationUserInput userInput, string appUserModelId)
        {
            if (invokedArgs.Length == 0)
            {
                SynchronizationContext.Current.Send(_ =>
                {
                    OpenWindowIfNeeded();
                }, null);

                return;
            }

            Dictionary<string, string> args = new Dictionary<string, string>();

            foreach (var arg in invokedArgs.Split('&', ';'))
            {
                var sep = arg.IndexOf('=');

                if (sep == -1)
                    args.Add(UrlDecode(arg), null); //Empty argument; we assign a key with a null value
                else
                    args.Add(UrlDecode(arg.Substring(0, sep)), UrlDecode(arg.Substring(sep + 1)));
            }

            //Ensure we have an open form before running the test
            SynchronizationContext.Current.Send(_ =>
            {
                OpenWindowIfNeeded();
            }, null);

            //Test
            var MainForm = Application.OpenForms["Main"] as Main;
            MainForm.BeginInvoke(new Action(() =>
            {
                MessageBox.Show("Hooray! it worked.");
            }));

        }

        private void OpenWindowIfNeeded()
        {
            if (Application.OpenForms.Count == 0)
            {
                new Main().Show();
            }

            Application.OpenForms["Main"].Activate();

            Application.OpenForms["Main"].WindowState = FormWindowState.Normal;
        }

        private static string UrlDecode(string str)
        {
            return Uri.UnescapeDataString(str.Replace('+', ' '));
        }
    }
}
