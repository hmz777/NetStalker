using NetStalker.ToastNotifications;
using System;
using System.Threading;
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
            //Allow only one instance of NetStalker to be running at a time
            using (Mutex AppMutex = new Mutex(true, "NetStalker", out bool createdNew))
            {
                if (createdNew)
                {
                    ToastAPI.AttachHandler();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Main(args));
                }
            }
        }
    }
}
