using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace NetStalker
{
    public partial class ErrorForm : MaterialForm
    {
        public ErrorForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
        }

        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.winpcap.org/install/bin/WinPcap_4_1_3.exe");
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.color == "Dark")
            {
                label1.ForeColor = Color.FromArgb(204, 204, 204);
            }
        }
    }
}
