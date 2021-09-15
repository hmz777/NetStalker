using Microsoft.Win32;
using NetStalker.MainLogic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NetStalker
{
    public partial class PasswordCheck : Form
    {
        #region Instance Fields

        string key = "h777m777z777@netstalker.app";

        #endregion

        #region Constructor

        public PasswordCheck()
        {
            InitializeComponent();
        }

        #endregion

        #region Button Event Handlers

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PasswordField.Text))
            {
                var Root = Registry.CurrentUser;
                RegistryKey Key = Root.OpenSubKey("Software").OpenSubKey("hSmNz");
                if (Key != null)
                {
                    if ((string)Key.GetValue("IsSNG") == "True" && !string.IsNullOrWhiteSpace((string)Key.GetValue("SNG")))
                    {
                        if (PasswordField.Text == Tools.DecryptText((string)Key.GetValue("SNG"), key))
                        {
                            this.Close();
                        }
                        else
                        {
                            StatusLabel.ForeColor = Color.Red;
                            StatusLabel.Text = "Wrong Password!";
                        }
                    }

                    Key.Close();
                }
            }
            else
            {
                StatusLabel.ForeColor = Color.Red;
                StatusLabel.Text = "Password is needed to continue!";
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PasswordCheck_Click(object sender, EventArgs e)
        {
            StatusLabel.Focus();
        }

        #endregion
    }
}