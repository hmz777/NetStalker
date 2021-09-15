using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NetStalker
{
    public partial class ErrorForm : Form
    {
        public ErrorForm()
        {
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://nmap.org/download.html");
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Color == "Dark")
            {
                label1.ForeColor = Color.FromArgb(204, 204, 204);
            }
        }
    }
}
