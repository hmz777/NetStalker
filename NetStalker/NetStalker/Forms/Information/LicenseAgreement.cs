using NetStalker.MainLogic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NetStalker
{
    public partial class LicenseAgreement : Form
    {
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

        public LicenseAgreement()
        {
            InitializeComponent();
        }

        private void LicenseAgreement_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.DarkMode)
            {
                this.BackColor = Color.FromArgb(51, 51, 51);
                this.ForeColor = Color.White;

                foreach (Control control in Controls)
                {
                    control.BackColor = Color.FromArgb(51, 51, 51);
                    control.ForeColor = Color.White;
                }
            }

            AgreementBox.Text = Properties.Resources.Agreement;
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Reject_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
