namespace NetStalker
{
    partial class PasswordCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordCheck));
            this.PasswordField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.QuitButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.OkButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.StatusLabel = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // PasswordField
            // 
            this.PasswordField.Depth = 0;
            this.PasswordField.Hint = "Password";
            this.PasswordField.Location = new System.Drawing.Point(12, 105);
            this.PasswordField.MaxLength = 32767;
            this.PasswordField.MouseState = MaterialSkin.MouseState.HOVER;
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.PasswordChar = '*';
            this.PasswordField.SelectedText = "";
            this.PasswordField.SelectionLength = 0;
            this.PasswordField.SelectionStart = 0;
            this.PasswordField.Size = new System.Drawing.Size(281, 23);
            this.PasswordField.TabIndex = 13;
            this.PasswordField.TabStop = false;
            this.PasswordField.UseSystemPasswordChar = true;
            // 
            // QuitButton
            // 
            this.QuitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.QuitButton.AutoSize = true;
            this.QuitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.QuitButton.Depth = 0;
            this.QuitButton.Icon = global::NetStalker.Properties.Resources.color_cancel;
            this.QuitButton.Location = new System.Drawing.Point(135, 176);
            this.QuitButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.QuitButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Primary = false;
            this.QuitButton.Size = new System.Drawing.Size(80, 36);
            this.QuitButton.TabIndex = 16;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.AutoSize = true;
            this.OkButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OkButton.Depth = 0;
            this.OkButton.Icon = global::NetStalker.Properties.Resources.color_ok;
            this.OkButton.Location = new System.Drawing.Point(223, 176);
            this.OkButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.OkButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.OkButton.Name = "OkButton";
            this.OkButton.Primary = false;
            this.OkButton.Size = new System.Drawing.Size(67, 36);
            this.OkButton.TabIndex = 15;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(8, 83);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(114, 19);
            this.materialLabel2.TabIndex = 41;
            this.materialLabel2.Text = "Enter Password";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Depth = 0;
            this.StatusLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.StatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StatusLabel.Location = new System.Drawing.Point(8, 131);
            this.StatusLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 19);
            this.StatusLabel.TabIndex = 42;
            // 
            // PasswordCheck
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 227);
            this.ControlBox = false;
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.PasswordField);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordCheck";
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Password Check";
            this.Click += new System.EventHandler(this.PasswordCheck_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialSingleLineTextField PasswordField;
        private MaterialSkin.Controls.MaterialFlatButton QuitButton;
        private MaterialSkin.Controls.MaterialFlatButton OkButton;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel StatusLabel;
    }
}