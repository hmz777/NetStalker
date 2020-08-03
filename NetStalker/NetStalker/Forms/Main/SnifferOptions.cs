using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using NetStalker.MainLogic;

namespace NetStalker
{
    public partial class SnifferOptions : MaterialForm
    {
        public SnifferOptions()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
        }

        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox2.Text))
            {
                Properties.Settings.Default.PacketDirection = comboBox2.Text;
                Properties.Settings.Default.Save();
            }

            this.Close();
        }

        private void SnifferOptions_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AppConfiguration.SnifferPacketDirection))
            {
                comboBox2.SelectedIndex = (AppConfiguration.SnifferPacketDirection == "Outbound") ? 0 : 1;
            }
            else
            {
                comboBox2.SelectedIndex = 0;
            }
        }
    }
}
