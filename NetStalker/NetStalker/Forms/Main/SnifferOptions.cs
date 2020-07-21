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
            }

            Properties.Settings.Default.Save();
            this.Close();


        }

        private void SnifferOptions_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Properties.Settings.Default.PacketDirection))
            {
                comboBox2.Text = Properties.Settings.Default.PacketDirection;
            }
            else
            {
                comboBox2.Text = "Outbound";
            }
        }
    }
}
