using NetStalker.MainLogic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NetStalker
{
    public partial class SnifferOptions : Form
    {
        #region Constructor

        public SnifferOptions()
        {
            InitializeComponent();
        }

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

        #region Form Event Handlers

        private void SnifferOptions_Load(object sender, EventArgs e)
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

            if (!string.IsNullOrEmpty(AppConfiguration.SnifferPacketDirection))
            {
                PacketDirectionComboBox.SelectedIndex = (AppConfiguration.SnifferPacketDirection == "Outbound") ? 0 : 1;
            }
            else
            {
                PacketDirectionComboBox.SelectedIndex = 0;
            }
        }

        #endregion

        #region Button Event Handlers

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PacketDirectionComboBox.Text))
            {
                Properties.Settings.Default.PacketDirection = PacketDirectionComboBox.Text;
                Properties.Settings.Default.Save();
            }

            this.Close();
        }

        #endregion
    }
}
