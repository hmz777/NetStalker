using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using MaterialSkin;
using MaterialSkin.Controls;

namespace NetStalker
{
    public partial class LicenseAgreement : MaterialForm
    {
        public LicenseAgreement()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
        }

        private void LicenseAgreement_Load(object sender, EventArgs e)
        {
            materialLabel2.Select();
            using (var reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("NetStalker.Resources.D.txt")))
            {
                string line = reader.ReadToEnd();
                metroTextBox1.Text = line;
            }

            if (Properties.Settings.Default.Color == "Dark")
            {
                label1.ForeColor = Color.FromArgb(204, 204, 204);
            }
        }

        private void MaterialFlatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
