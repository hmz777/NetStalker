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
            if (Properties.Settings.Default.Color == "Dark")
            {
                groupBox1.ForeColor = Color.White;
            }
            else
            {
                groupBox1.ForeColor = Color.Black;
            }

            VerLabel.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            BuildLabel.Text = File.GetCreationTimeUtc(Assembly.GetExecutingAssembly().Location).ToString();
        }

        private void LinkLabel1_Click(object sender, EventArgs e)
        {
            Process.Start(linkLabel1.Text);
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel2.Text);
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel3.Text);
        }

        private void LinkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel4.Text);
        }

        private void Email_Click(object sender, EventArgs e)
        {
            Process.Start($"Mailto:{EmailLabel.Text}");
        }

        private void Site_Click(object sender, EventArgs e)
        {
            Process.Start(SiteLabel.Text);
        }

        private void Git_Click(object sender, EventArgs e)
        {
            Process.Start(GitLabel.Text);
        }
    }
}
