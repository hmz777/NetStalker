using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace NetStalker
{
    public partial class AboutForm : MaterialForm
    {
        public AboutForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
        }

        private void MaterialFlatButton1_Click(object sender, EventArgs e)
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

        private void MaterialLabel7_Click(object sender, EventArgs e)
        {
            Process.Start(materialLabel7.Text);
        }

        private void MaterialLabel5_Click(object sender, EventArgs e)
        {
            Process.Start(materialLabel5.Text);
        }

        private void MaterialLabel3_Click(object sender, EventArgs e)
        {
            Process.Start($"Mailto:{materialLabel3.Text}");
        }
    }
}
