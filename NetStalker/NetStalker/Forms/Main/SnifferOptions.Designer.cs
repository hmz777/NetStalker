namespace NetStalker
{
    partial class SnifferOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SnifferOptions));
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.SaveButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.PacketDirectionComboBox = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(12, 92);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(74, 19);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "Direction:";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.AutoSize = true;
            this.SaveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaveButton.Depth = 0;
            this.SaveButton.Icon = global::NetStalker.Properties.Resources.color_ok;
            this.SaveButton.Location = new System.Drawing.Point(283, 83);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.SaveButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Primary = false;
            this.SaveButton.Size = new System.Drawing.Size(83, 36);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // PacketDirectionComboBox
            // 
            this.PacketDirectionComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.PacketDirectionComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PacketDirectionComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.PacketDirectionComboBox.FormattingEnabled = true;
            this.PacketDirectionComboBox.ItemHeight = 23;
            this.PacketDirectionComboBox.Items.AddRange(new object[] {
            "Outbound",
            "Inbound/Outbound"});
            this.PacketDirectionComboBox.Location = new System.Drawing.Point(92, 87);
            this.PacketDirectionComboBox.Name = "PacketDirectionComboBox";
            this.PacketDirectionComboBox.PromptText = "Packet Direction";
            this.PacketDirectionComboBox.Size = new System.Drawing.Size(162, 29);
            this.PacketDirectionComboBox.Style = MetroFramework.MetroColorStyle.Teal;
            this.PacketDirectionComboBox.TabIndex = 47;
            this.PacketDirectionComboBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.PacketDirectionComboBox.UseCustomBackColor = true;
            this.PacketDirectionComboBox.UseCustomForeColor = true;
            this.PacketDirectionComboBox.UseSelectable = true;
            // 
            // SnifferOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 134);
            this.ControlBox = false;
            this.Controls.Add(this.PacketDirectionComboBox);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.SaveButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SnifferOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sniffer Options";
            this.Load += new System.EventHandler(this.SnifferOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton SaveButton;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MetroFramework.Controls.MetroComboBox PacketDirectionComboBox;
    }
}