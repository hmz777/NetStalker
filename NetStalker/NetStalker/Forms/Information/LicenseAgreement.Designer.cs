namespace NetStalker
{
    partial class LicenseAgreement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenseAgreement));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AgreementBox = new System.Windows.Forms.TextBox();
            this.ButtonIcons = new System.Windows.Forms.ImageList(this.components);
            this.RejectButton = new System.Windows.Forms.Button();
            this.AcceptAGButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 439);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(555, 42);
            this.label1.TabIndex = 5;
            this.label1.Text = "Please take sometime to read the help section in order to use this\r\nsoftware prop" +
    "erly.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(407, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please read the Disclaimer before you proceed:";
            // 
            // AgreementBox
            // 
            this.AgreementBox.BackColor = System.Drawing.Color.White;
            this.AgreementBox.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgreementBox.Location = new System.Drawing.Point(12, 64);
            this.AgreementBox.Multiline = true;
            this.AgreementBox.Name = "AgreementBox";
            this.AgreementBox.ReadOnly = true;
            this.AgreementBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AgreementBox.Size = new System.Drawing.Size(644, 362);
            this.AgreementBox.TabIndex = 7;
            this.AgreementBox.TabStop = false;
            // 
            // ButtonIcons
            // 
            this.ButtonIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonIcons.ImageStream")));
            this.ButtonIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ButtonIcons.Images.SetKeyName(0, "color_cancel.PNG");
            this.ButtonIcons.Images.SetKeyName(1, "color_ok.PNG");
            // 
            // RejectButton
            // 
            this.RejectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RejectButton.BackColor = System.Drawing.Color.White;
            this.RejectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RejectButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.RejectButton.FlatAppearance.BorderSize = 0;
            this.RejectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RejectButton.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RejectButton.ImageKey = "color_cancel.PNG";
            this.RejectButton.ImageList = this.ButtonIcons;
            this.RejectButton.Location = new System.Drawing.Point(407, 552);
            this.RejectButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RejectButton.Name = "RejectButton";
            this.RejectButton.Size = new System.Drawing.Size(106, 57);
            this.RejectButton.TabIndex = 66;
            this.RejectButton.Text = "REJECT";
            this.RejectButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RejectButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.RejectButton.UseVisualStyleBackColor = false;
            this.RejectButton.Click += new System.EventHandler(this.Reject_Click);
            // 
            // AcceptAGButton
            // 
            this.AcceptAGButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AcceptAGButton.BackColor = System.Drawing.Color.White;
            this.AcceptAGButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AcceptAGButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.AcceptAGButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.AcceptAGButton.FlatAppearance.BorderSize = 0;
            this.AcceptAGButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AcceptAGButton.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AcceptAGButton.ImageKey = "color_ok.PNG";
            this.AcceptAGButton.ImageList = this.ButtonIcons;
            this.AcceptAGButton.Location = new System.Drawing.Point(550, 552);
            this.AcceptAGButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AcceptAGButton.Name = "AcceptAGButton";
            this.AcceptAGButton.Size = new System.Drawing.Size(106, 57);
            this.AcceptAGButton.TabIndex = 65;
            this.AcceptAGButton.Text = "ACCEPT";
            this.AcceptAGButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AcceptAGButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AcceptAGButton.UseVisualStyleBackColor = false;
            this.AcceptAGButton.Click += new System.EventHandler(this.Accept_Click);
            // 
            // LicenseAgreement
            // 
            this.AcceptButton = this.AcceptAGButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.RejectButton;
            this.ClientSize = new System.Drawing.Size(668, 622);
            this.ControlBox = false;
            this.Controls.Add(this.RejectButton);
            this.Controls.Add(this.AcceptAGButton);
            this.Controls.Add(this.AgreementBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LicenseAgreement";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Disclaimer";
            this.Load += new System.EventHandler(this.LicenseAgreement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AgreementBox;
        private System.Windows.Forms.ImageList ButtonIcons;
        private System.Windows.Forms.Button RejectButton;
        private System.Windows.Forms.Button AcceptAGButton;
    }
}