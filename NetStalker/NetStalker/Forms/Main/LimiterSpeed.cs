using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;

namespace NetStalker
{
    public partial class LimiterSpeed : MaterialForm
    {
        #region Instance Fields

        private MaterialSkinManager materialSkinManager;
        private Device device;

        #endregion

        #region Constructor

        public LimiterSpeed(Device device)
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            this.device = device;

        }

        #endregion

        #region Form Handlers

        private void LimiterSpeed_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = device.UploadCap / 1024;
            numericUpDown2.Value = device.DownloadCap / 1024;
            if (device.Limited)
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

        #endregion

        #region Button Event Handlers

        private void SetButton_Click(object sender, EventArgs e)
        {
            var target = Main.Devices.FirstOrDefault(D => D.Value.MAC == device.MAC);

            if (target.Equals(default(KeyValuePair<IPAddress, Device>)))
                throw new CustomExceptions.DeviceNotInListException();

            //Update device limits in list
            target.Value.DownloadCap = (int)numericUpDown2.Value * 1024;
            target.Value.UploadCap = (int)numericUpDown1.Value * 1024;

            //Update device limits in UI
            device.DownloadCap = (int)numericUpDown2.Value * 1024;
            device.UploadCap = (int)numericUpDown1.Value * 1024;

            if (device.DownloadCap > 0 || device.UploadCap > 0)
            {
                target.Value.Limited = true;
                device.Limited = true;
            }

            Close();
        }

        #endregion
    }
}