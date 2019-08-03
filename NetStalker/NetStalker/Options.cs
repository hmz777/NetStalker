using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;
using Timer = System.Timers.Timer;

namespace NetStalker
{
    public partial class Options : MaterialForm
    {
        private MaterialSkinManager materialSkinManager;
        private Main main;


        public Options()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            //materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey800, Primary.Grey700, Primary.Grey900, Accent.Teal700, TextShade.WHITE);
            materialFlatButton2.Enabled = false;
            main = Application.OpenForms["Main"] as Main;


        }

        private void Options_Load(object sender, EventArgs e)
        {
            if (materialSkinManager.Theme == MaterialSkinManager.Themes.LIGHT)
            {
                materialRadioButton1.Checked = true;
            }
            else if (materialSkinManager.Theme == MaterialSkinManager.Themes.DARK)
            {
                materialRadioButton2.Checked = true;
            }

            if (IsPassSet())
            {
                materialSingleLineTextField1.Enabled = false;
                materialSingleLineTextField2.Enabled = false;
                materialFlatButton3.Enabled = true;
                materialFlatButton2.Enabled = false;
            }
            else
            {
                materialSingleLineTextField2.Enabled = false;
                materialFlatButton3.Enabled = false;
            }

            main = Application.OpenForms["Main"] as Main;

            if (main.resizestate == "Tray")
            {
                materialRadioButton9.Checked = true;
            }
            else if (main.resizestate == "Taskbar")
            {
                materialRadioButton8.Checked = true;
            }

            if (Properties.Settings.Default.SpoofProtection)
            {
                materialCheckBox1.Checked = true;
            }

            if (Properties.Settings.Default.SuppressN == "True")
            {
                materialCheckBox2.Checked = true;
            }


        }

        private void materialSingleLineTextField1_TextChanged(object sender, EventArgs e)
        {

            if (materialSingleLineTextField1.Text.Length > 0)
            {
                materialLabel4.Text = "";
            }

            if (!string.IsNullOrWhiteSpace(materialSingleLineTextField1.Text) &&
                materialSingleLineTextField1.Text.Length >= 6)
            {
                if (materialSingleLineTextField2.Enabled &&
                    !string.IsNullOrWhiteSpace(materialSingleLineTextField2.Text))
                {
                    materialLabel5.ForeColor = Color.Red;
                    materialLabel5.Text = "Password mismatch!";
                    materialFlatButton2.Enabled = false;
                }
                else
                {
                    materialSingleLineTextField2.Enabled = true;
                    materialLabel5.Text = "";
                    materialFlatButton2.Enabled = false;
                }

            }
            else if (materialSingleLineTextField1.Text.Length < 6 && materialSingleLineTextField1.Text.Length >= 1)
            {
                materialLabel5.ForeColor = Color.Red;
                materialLabel5.Text = "At least 6 characters required!";
                materialSingleLineTextField2.Text = "";
                materialSingleLineTextField2.Enabled = false;
                materialFlatButton2.Enabled = false;
            }
            else
            {
                materialLabel5.ForeColor = Color.Red;
                materialLabel5.Text = "";
                materialSingleLineTextField2.Text = "";
                materialSingleLineTextField2.Enabled = false;
                materialFlatButton2.Enabled = false;
            }
        }

        public bool IsPassSet()
        {
            var root = Registry.CurrentUser;
            RegistryKey reg = root.OpenSubKey("Software").OpenSubKey("hSmNz");
            if (reg != null)
            {
                if ((string)reg.GetValue("IsSNG") == "True")
                {
                    reg.Close();
                    return true;
                }

            }

            reg.Close();
            return false;
        }

        private void Options_Click(object sender, EventArgs e)
        {
            materialLabel4.Focus();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            this.Close();
        }

        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;


            byte[] saltBytes = new byte[] { 19, 9, 94, 1, 94, 9, 19, 2 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        public string EncryptText(string input, string password)
        {
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }

        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            byte[] saltBytes = new byte[] { 19, 9, 94, 1, 94, 9, 19, 2 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        public string DecryptText(string input, string password)
        {
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            string result = Encoding.UTF8.GetString(bytesDecrypted);

            return result;
        }

        private void materialSingleLineTextField2_TextChanged(object sender, EventArgs e)
        {


            if (materialSingleLineTextField2.Text.Length >= 6 &&
                materialSingleLineTextField1.Text == materialSingleLineTextField2.Text)
            {
                materialLabel5.ForeColor = Color.Green;
                materialLabel5.Text = "Sounds Good!";
                materialFlatButton2.Enabled = true;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(materialSingleLineTextField2.Text))
                {
                    materialLabel5.ForeColor = Color.Red;
                    materialLabel5.Text = "Password mismatch!";
                    materialFlatButton2.Enabled = false;
                }

            }

        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(materialSingleLineTextField1.Text) &&
                !string.IsNullOrWhiteSpace(materialSingleLineTextField2.Text) &&
                materialSingleLineTextField1.Text == materialSingleLineTextField2.Text)
            {
                string strText = materialSingleLineTextField1.Text;
                string key = "h777m777z777@netstalker.app";
                string encText = EncryptText(strText, key);

                var root = Registry.CurrentUser;
                RegistryKey reg = root.OpenSubKey("Software", true).CreateSubKey("hSmNz");
                reg.Close();
                RegistryKey reg1 = root.OpenSubKey("Software").OpenSubKey("hSmNz", true);
                reg1.SetValue("SNG", encText);
                reg1.SetValue("IsSNG", true);
                reg1.Close();
                materialFlatButton3.Enabled = true;
                materialLabel4.ForeColor = Color.Green;
                materialLabel4.Text = "Password has been set!";
                materialFlatButton2.Enabled = false;
                materialSingleLineTextField1.Text = "";
                materialSingleLineTextField2.Text = "";
                materialLabel5.Text = "";
                materialSingleLineTextField1.Enabled = false;
                materialSingleLineTextField2.Enabled = false;
                Timer t1 = new Timer(3500);
                t1.Start();
                t1.Elapsed += (o, args) =>
                {
                    materialLabel4.Invoke(new Action(() => { materialLabel4.Text = ""; }));
                    t1.Stop();
                };



            }
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            var root = Registry.CurrentUser;
            RegistryKey reg1 = root.OpenSubKey("Software").OpenSubKey("hSmNz", true);
            reg1.DeleteValue("SNG");
            reg1.SetValue("IsSNG", false);
            reg1.Close();
            materialFlatButton2.Enabled = true;
            materialFlatButton3.Enabled = false;
            materialLabel4.ForeColor = Color.Green;
            materialLabel4.Text = "Password has been removed!";
            materialSingleLineTextField1.Enabled = true;
            Timer t1 = new Timer(3500);
            t1.Start();
            t1.Elapsed += (o, args) =>
            {
                materialLabel4.Invoke(new Action(() => { materialLabel4.Text = ""; }));

                t1.Stop();
            };
        }

        private void materialRadioButton1_Click(object sender, EventArgs e)
        {
            if (materialLabel5.ForeColor == Color.Red)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                materialLabel5.ForeColor = Color.Red;
                materialLabel4.ForeColor = Color.Green;
                materialLabel4.Text = "";
                Properties.Settings.Default.color = "Light";
            }
            else if (materialLabel5.ForeColor == Color.Green)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                materialLabel5.ForeColor = Color.Green;
                materialLabel4.ForeColor = Color.Green;
                materialLabel4.Text = "";
                Properties.Settings.Default.color = "Light";
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                materialLabel4.ForeColor = Color.Green;
                materialLabel4.Text = "";
                Properties.Settings.Default.color = "Light";
            }

            main.textOverlay.BackColor = Color.FromArgb(204, 204, 204);
            main.textOverlay.TextColor = Color.FromArgb(71, 71, 71);
            main.fastObjectListView1.BackColor = Color.White;
            main.fastObjectListView1.HeaderFormatStyle = main.LightHeaders;
            main.fastObjectListView1.HotItemStyle = main.LightHot;
            main.fastObjectListView1.ForeColor = Color.FromArgb(54, 54, 54);
            main.fastObjectListView1.SelectedBackColor = Color.FromArgb(214, 214, 214);
            main.fastObjectListView1.SelectedForeColor = Color.FromArgb(51, 51, 51);
            main.fastObjectListView1.UnfocusedSelectedBackColor = Color.FromArgb(71, 71, 71);
            main.fastObjectListView1.UnfocusedSelectedForeColor = Color.FromArgb(204, 204, 204);
            main.pictureBox2.Image = NetStalker.Properties.Resources._30W;

        }

        private void materialRadioButton2_Click(object sender, EventArgs e)
        {
            if (materialLabel5.ForeColor == Color.Red)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                materialLabel5.ForeColor = Color.Red;
                materialLabel4.ForeColor = Color.Green;
                materialLabel4.Text = "";
                Properties.Settings.Default.color = "Dark";
            }
            else if (materialLabel5.ForeColor == Color.Green)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                materialLabel5.ForeColor = Color.Green;
                Properties.Settings.Default.color = "Dark";
                materialLabel4.ForeColor = Color.Green;
                materialLabel4.Text = "";
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                Properties.Settings.Default.color = "Dark";
                materialLabel4.ForeColor = Color.Green;
                materialLabel4.Text = "";
            }

            main.textOverlay.BackColor = Color.FromArgb(71, 71, 71);
            main.textOverlay.TextColor = Color.FromArgb(204, 204, 204);
            main.fastObjectListView1.BackColor = Color.FromArgb(51, 51, 51);
            main.fastObjectListView1.HeaderFormatStyle = main.DarkHeaders;
            main.fastObjectListView1.HotItemStyle = main.DarkHot;
            main.fastObjectListView1.ForeColor = Color.FromArgb(204, 204, 204);
            main.fastObjectListView1.SelectedBackColor = Color.FromArgb(88, 88, 88);
            main.fastObjectListView1.SelectedForeColor = Color.FromArgb(204, 204, 204);
            main.fastObjectListView1.UnfocusedSelectedBackColor = Color.FromArgb(204, 204, 204);
            main.fastObjectListView1.UnfocusedSelectedForeColor = Color.FromArgb(88, 88, 88);
            main.pictureBox2.Image = NetStalker.Properties.Resources._30G;
        }

        private void materialRadioButton9_Click(object sender, EventArgs e)
        {
            materialRadioButton8.Enabled = false;
            main.Resize += main.Main_Resize;
            Properties.Settings.Default.minimize = "Tray";
            main.resizestate = "Tray";
            materialLabel4.Text = "";
            materialRadioButton8.Enabled = true;

        }

        private void materialRadioButton8_Click(object sender, EventArgs e)
        {
            materialRadioButton9.Enabled = false;
            main.Resize -= main.Main_Resize;
            Properties.Settings.Default.minimize = "Taskbar";
            main.resizestate = "Taskbar";
            materialLabel4.Text = "";
            materialRadioButton9.Enabled = true;
        }

        private void MaterialCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialCheckBox1.Checked)
            {
                Properties.Settings.Default.SpoofProtection = true;
            }
            else
            {
                Properties.Settings.Default.SpoofProtection = false;
            }
        }

        private void PictureBox1_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox1, string.Format(
                "Spoof Protection occurs whenever a blocking or a redirection operation is active.{0}It protects you pc from being blocked or redirected by the same tool{0}or any other spoofing software.", Environment.NewLine));

        }

        private void ToolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {

            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(51, 51, 51)), e.Bounds);//background color e.bounds

            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(204, 204, 204), 1), new Rectangle(e.Bounds.X, e.Bounds.Y,
                e.Bounds.Width - 1, e.Bounds.Height - 1));//the white bounds

            e.Graphics.DrawString(e.ToolTipText, new Font("Roboto", 9), new SolidBrush(Color.FromArgb(204, 204, 204)),
                new Point(Properties.Resources.icons8_info_30px.Width + 16,
                    e.Bounds.Y + 8)); //text with image location

            e.Graphics.DrawImage(Properties.Resources.icons8_info_30px, //image
                new Point(e.Bounds.X + Properties.Resources.icons8_info_30px.Width / 3, e.Bounds.Y + 10));
        }

        private void ToolTip1_Popup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = new Size(e.ToolTipSize.Width + 30, e.ToolTipSize.Height);
        }

        private void MaterialCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (materialCheckBox2.Checked)
            {
                Properties.Settings.Default.SuppressN = "True";
            }
            else
            {
                Properties.Settings.Default.SuppressN = "False";
            }
        }
    }
}
