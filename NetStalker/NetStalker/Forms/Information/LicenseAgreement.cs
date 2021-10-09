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
