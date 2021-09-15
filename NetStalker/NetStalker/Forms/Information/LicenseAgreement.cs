using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace NetStalker
{
    public partial class LicenseAgreement : Form
    {
        public LicenseAgreement()
        {
            InitializeComponent();
        }

        private void LicenseAgreement_Load(object sender, EventArgs e)
        {
            AgreementBox.Text = Properties.Resources.Agreement;

            if (Properties.Settings.Default.Color == "Dark")
            {
                label1.ForeColor = Color.FromArgb(204, 204, 204);
            }
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Reject_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
