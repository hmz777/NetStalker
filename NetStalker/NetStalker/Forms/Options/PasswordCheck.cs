using Microsoft.Win32;
using NetStalker.MainLogic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NetStalker
{
    public partial class PasswordCheck : Form
    {
        #region Instance Fields

        string key = "h777m777z777@netstalker.app";

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

        public PasswordCheck()
        {
            InitializeComponent();
        }

        #endregion

        #region Button Event Handlers

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PasswordField.Text))
            {
                var Root = Registry.CurrentUser;
                RegistryKey Key = Root.OpenSubKey("Software").OpenSubKey("hSmNz");
                if (Key != null)
                {
                    if ((string)Key.GetValue("IsSNG") == "True" && !string.IsNullOrWhiteSpace((string)Key.GetValue("SNG")))
                    {
                        if (PasswordField.Text == Tools.DecryptText((string)Key.GetValue("SNG"), key))
                        {
                            this.Close();
                        }
                        else
                        {
                            StatusLabel.ForeColor = Color.Red;
                            StatusLabel.Text = "Wrong Password!";
                        }
                    }

                    Key.Close();
                }
            }
            else
            {
                StatusLabel.ForeColor = Color.Red;
                StatusLabel.Text = "Password is needed to continue!";
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PasswordCheck_Click(object sender, EventArgs e)
        {
            StatusLabel.Focus();
        }

        #endregion

        private void PasswordCheck_Load(object sender, EventArgs e)
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
        }
    }
}