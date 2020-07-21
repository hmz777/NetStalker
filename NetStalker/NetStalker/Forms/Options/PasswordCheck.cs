using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MetroFramework;
using Microsoft.Win32;

namespace NetStalker
{
    public partial class PasswordCheck : MaterialForm
    {
        private MaterialSkinManager materialSkinManager;
        string key = "h777m777z777@netstalker.app";

        public PasswordCheck()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(materialSingleLineTextField1.Text))
            {
                var root = Registry.CurrentUser;
                RegistryKey reg = root.OpenSubKey("Software").OpenSubKey("hSmNz");
                if (reg != null)
                {
                    if ((string)reg.GetValue("IsSNG") == "True" && !string.IsNullOrWhiteSpace((string)reg.GetValue("SNG")))
                    {
                        if (materialSingleLineTextField1.Text == DecryptText((string)reg.GetValue("SNG"), key))
                        {
                            reg.Close();
                            this.Close();
                        }
                        else
                        {
                            materialLabel1.ForeColor = Color.Red;
                            materialLabel1.Text = "Wrong Password!";
                            reg.Close();
                        }
                    }
                    else
                    {
                        reg.Close();
                    }

                }
            }
            else
            {
                materialLabel1.ForeColor = Color.Red;
                materialLabel1.Text = "Password is needed to continue!";

            }
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

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PasswordCheck_Click(object sender, EventArgs e)
        {
            materialLabel1.Focus();
        }
    }
}
