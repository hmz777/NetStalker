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
using NetStalker.MainLogic;

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
                        if (materialSingleLineTextField1.Text == Tools.DecryptText((string)reg.GetValue("SNG"), key))
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
