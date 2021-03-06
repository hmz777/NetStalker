﻿using MaterialSkin;
using MaterialSkin.Controls;
using NetStalker.MainLogic;
using System;

namespace NetStalker
{
    public partial class SnifferOptions : MaterialForm
    {
        #region Constructor

        public SnifferOptions()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
        }

        #endregion

        #region Form Event Handlers

        private void SnifferOptions_Load(object sender, EventArgs e)
        {
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
