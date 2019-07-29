using System;
using System.Drawing;
using MaterialSkin;
using MaterialSkin.Controls;

namespace NetStalker
{
    public partial class LimiterSpeed : MaterialForm
    {
        private MaterialSkinManager materialSkinManager;
        private Device device;


        public LimiterSpeed(Device device)
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            this.device = device;

        }
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            device.DownloadCap = (int)numericUpDown2.Value * 1024;
            device.UploadCap = (int)numericUpDown1.Value * 1024;
            this.Close();
        }

        private void LimiterSpeed_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = device.UploadCap / 1024;
            numericUpDown2.Value = device.DownloadCap / 1024;
            if (device.LimiterStarted)
            {
                materialLabel2.ForeColor = Color.Green;
                materialLabel2.Text = "Active";
            }
            else
            {
                materialLabel2.ForeColor = Color.Red;
                materialLabel2.Text = "Inactive";
            }
        }


    }
}
