using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetStalker
{
    public partial class SetNameDialog : Form
    {
        private readonly string name;

        public SetNameDialog(string Name)
        {
            InitializeComponent();

            name = Name;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameBox.Text))
            {
                MessageBox.Show(this, Properties.Resources.FriendlyNameEmpty, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (NameBox.Text.Length > 20)
            {
                MessageBox.Show(this, Properties.Resources.FriendlyNameCharLimit, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Close();
            }
        }

        private void SetNameDialog_Load(object sender, EventArgs e)
        {
            NameBox.Text = name;
        }
    }
}
