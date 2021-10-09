
namespace NetStalker.Forms.Information
{
    partial class MessageBoxForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageBoxForm));
            this.IconControl = new System.Windows.Forms.PictureBox();
            this.MessageControl = new System.Windows.Forms.Label();
            this.OKBtn = new System.Windows.Forms.Button();
            this.MessageIcons = new System.Windows.Forms.ImageList(this.components);
            this.CancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IconControl)).BeginInit();
            this.SuspendLayout();
            // 
            // IconControl
            // 
            this.IconControl.Location = new System.Drawing.Point(22, 23);
            this.IconControl.Name = "IconControl";
            this.IconControl.Size = new System.Drawing.Size(60, 64);
            this.IconControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.IconControl.TabIndex = 0;
            this.IconControl.TabStop = false;
            // 
            // MessageControl
            // 
            this.MessageControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageControl.AutoSize = true;
            this.MessageControl.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageControl.Location = new System.Drawing.Point(115, 45);
            this.MessageControl.MaximumSize = new System.Drawing.Size(562, 0);
            this.MessageControl.Name = "MessageControl";
            this.MessageControl.Size = new System.Drawing.Size(71, 21);
            this.MessageControl.TabIndex = 1;
            this.MessageControl.Text = "Dummy";
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.OKBtn.FlatAppearance.BorderSize = 0;
            this.OKBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKBtn.ImageIndex = 4;
            this.OKBtn.ImageList = this.MessageIcons;
            this.OKBtn.Location = new System.Drawing.Point(598, 126);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(92, 48);
            this.OKBtn.TabIndex = 2;
            this.OKBtn.Text = "OK";
            this.OKBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OKBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OKBtn.UseVisualStyleBackColor = true;
            // 
            // MessageIcons
            // 
            this.MessageIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MessageIcons.ImageStream")));
            this.MessageIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.MessageIcons.Images.SetKeyName(0, "color_cancel.PNG");
            this.MessageIcons.Images.SetKeyName(1, "color_error.PNG");
            this.MessageIcons.Images.SetKeyName(2, "color_help.PNG");
            this.MessageIcons.Images.SetKeyName(3, "color_info.PNG");
            this.MessageIcons.Images.SetKeyName(4, "color_ok.PNG");
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.FlatAppearance.BorderSize = 0;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.ImageIndex = 0;
            this.CancelBtn.ImageList = this.MessageIcons;
            this.CancelBtn.Location = new System.Drawing.Point(453, 126);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(108, 48);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "CANCEL";
            this.CancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CancelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Visible = false;
            // 
            // MessageBoxForm
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(702, 186);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.MessageControl);
            this.Controls.Add(this.IconControl);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageBoxForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MessageBoxForm";
            this.Load += new System.EventHandler(this.MessageBoxForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IconControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox IconControl;
        private System.Windows.Forms.Label MessageControl;
        private System.Windows.Forms.Button OKBtn;
        public System.Windows.Forms.ImageList MessageIcons;
        private System.Windows.Forms.Button CancelBtn;
    }
}