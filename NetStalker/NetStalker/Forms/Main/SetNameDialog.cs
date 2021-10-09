using NetStalker.MainLogic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NetStalker
{
    public partial class SetNameDialog : Form
    {
        private readonly string name;

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

        public SetNameDialog(string Name)
        {
            InitializeComponent();

            name = Name;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameBox.Text))
            {
                MessageBox.Show(this, Properties.Resources.FriendlyNameEmpty, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (NameBox.Text.Length > 20)
            {
                MessageBox.Show(this, Properties.Resources.FriendlyNameCharLimit, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Close();
            }
        }

        private void SetNameDialog_Load(object sender, EventArgs e)
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

            NameBox.Text = name;
        }
    }
}
