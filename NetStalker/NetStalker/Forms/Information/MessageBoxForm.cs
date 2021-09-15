using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetStalker.Forms.Information
{
    public partial class MessageBoxForm : Form
    {
        public MessageBoxForm(string Title, string Message, MessageBoxIcon Icon, MessageBoxButtons Buttons)
        {
            InitializeComponent();

            this.Text = Title;
            MessageControl.Text = Message;

            switch (Icon)
            {
                case MessageBoxIcon.None:
                    IconControl.Image = null;
                    break;
                case MessageBoxIcon icon when (icon == MessageBoxIcon.Hand
                || icon == MessageBoxIcon.Stop
                || icon == MessageBoxIcon.Error):
                    IconControl.Image = MessageIcons.Images[0];
                    break;
                case MessageBoxIcon.Question:
                    IconControl.Image = MessageIcons.Images[2];
                    break;
                case MessageBoxIcon icon when (icon == MessageBoxIcon.Exclamation ||
                icon == MessageBoxIcon.Warning):
                    IconControl.Image = MessageIcons.Images[1];
                    break;
                case MessageBoxIcon icon when (icon == MessageBoxIcon.Information ||
                icon == MessageBoxIcon.Asterisk):
                    IconControl.Image = MessageIcons.Images[3];
                    break;
                default:
                    IconControl.Image = MessageIcons.Images[4]; //Success
                    break;
            }

            if (Buttons == MessageBoxButtons.OKCancel)
            {
                CancelBtn.Visible = true;
            }
        }
    }
}
