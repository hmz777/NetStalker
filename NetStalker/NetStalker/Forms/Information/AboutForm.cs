using NetStalker.MainLogic;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace NetStalker
{
    public partial class AboutForm : Form
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

        public AboutForm()
        {
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.DarkMode)
            {
                this.BackColor = Color.FromArgb(51, 51, 51);
                this.ForeColor = Color.White;

                foreach (Control control in Controls)
                {
                    control.BackColor = Color.FromArgb(51, 51, 51);
                    control.ForeColor = Color.White;

                    if (control.GetType() == typeof(LinkLabel))
                    {
                        var lnk = control as LinkLabel;
                        lnk.TabStop = false;
                    }
                    if (control.GetType() == typeof(GroupBox))
                    {
                        foreach (Control gbC in control.Controls)
                        {
                            gbC.TabStop = false;
                        }
                    }
                }
            }

            VerLabel.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            BuildLabel.Text = File.GetCreationTimeUtc(Assembly.GetExecutingAssembly().Location).ToString("dd/MM/yyyy");
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel3.Text);
        }

        private void LinkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel4.Text);
        }

        private void Email_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"Mailto:{EmailLabel.Text}");
        }

        private void Site_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(SiteLabel.Text);
        }

        private void Git_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(GitLabel.Text);
        }
    }
}
