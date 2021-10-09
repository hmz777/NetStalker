using NetStalker.MainLogic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace NetStalker
{
    public partial class LimiterSpeed : Form
    {
        #region Instance Fields

        private Device device;

        #endregion

        #region Window Config

        /// <summary>
        /// Apply the Windows dark mode settings to the window.
        /// See <see href="https://stackoverflow.com/questions/57124243/winforms-dark-title-bar-on-windows-10">Stackoverflow</see>, <see href="https://docs.microsoft.com/en-us/windows/win32/api/dwmapi/ne-dwmapi-dwmwindowattribute">MS Docs</see> and <see href="https://docs.microsoft.com/en-us/windows/win32/com/structure-of-com-error-codes">MS Docs 2</see>
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleCreated(EventArgs e)
        {
            if (Properties.Settings.Default.DarkMode)
            {
                if (NativeMethods.DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0) //0 means S_OK 
                    NativeMethods.DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
            }
        }

        #endregion

        #region Constructor

        public LimiterSpeed(Device device)
        {
            InitializeComponent();
            this.device = device;
        }

        #endregion

        #region Form Handlers

        private void LimiterSpeed_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.DarkMode)
            {
                this.BackColor = Color.FromArgb(51, 51, 51);
                this.ForeColor = Color.White;

                foreach (Control control in Controls)
                {
                    if (control.GetType() == typeof(Button))
                    {
                        var btn = control as Button;
                        btn.FlatAppearance.BorderColor = Color.FromArgb(51, 51, 51);
                        btn.BackColor = Color.FromArgb(51, 51, 51);
                        btn.ForeColor = Color.White;
                    }
                    else
                    {
                        control.BackColor = Color.FromArgb(51, 51, 51);
                        control.ForeColor = Color.White;
                    }
                }
            }

            numericUpDown1.Value = device.UploadCap / 1024;
            numericUpDown2.Value = device.DownloadCap / 1024;

            if (device.Limited)
            {
                StatusLabel.ForeColor = Color.Green;
                StatusLabel.Text = "Active";
            }
            else
            {
                StatusLabel.ForeColor = Color.Red;
                StatusLabel.Text = "Inactive";
            }
        }

        #endregion

        #region Button Event Handlers

        private void SetButton_Click(object sender, EventArgs e)
        {
            var target = Main.Devices.FirstOrDefault(D => D.Value.MAC == device.MAC);

            if (target.Equals(default(KeyValuePair<IPAddress, Device>)))
                throw new CustomExceptions.DeviceNotInListException();

            //Update device limits in list
            target.Value.DownloadCap = (int)numericUpDown2.Value * 1024;
            target.Value.UploadCap = (int)numericUpDown1.Value * 1024;

            //Update device limits in UI
            device.DownloadCap = (int)numericUpDown2.Value * 1024;
            device.UploadCap = (int)numericUpDown1.Value * 1024;

            if (device.DownloadCap > 0 || device.UploadCap > 0)
            {
                target.Value.Limited = true;
                device.Limited = true;
            }

            Close();
        }

        #endregion
    }
}