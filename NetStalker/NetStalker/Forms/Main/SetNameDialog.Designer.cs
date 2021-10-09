
namespace NetStalker
{
    partial class SetNameDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetNameDialog));
            this.NameBox = new System.Windows.Forms.TextBox();
            this.ButtonIcons = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(78, 46);
            this.NameBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(326, 26);
            this.NameBox.TabIndex = 0;
            // 
            // ButtonIcons
            // 
            this.ButtonIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonIcons.ImageStream")));
            this.ButtonIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ButtonIcons.Images.SetKeyName(0, "color_cancel.PNG");
            this.ButtonIcons.Images.SetKeyName(1, "color_ok.PNG");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 65;
            this.label1.Text = "Name";
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.Color.White;
            this.OkButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OkButton.FlatAppearance.BorderSize = 0;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkButton.ImageKey = "color_ok.PNG";
            this.OkButton.ImageList = this.ButtonIcons;
            this.OkButton.Location = new System.Drawing.Point(435, 35);
            this.OkButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(94, 51);
            this.OkButton.TabIndex = 66;
            this.OkButton.TabStop = false;
            this.OkButton.Text = "SET";
            this.OkButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // SetNameDialog
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(554, 112);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameBox);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetNameDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Friendly Name";
            this.Load += new System.EventHandler(this.SetNameDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList ButtonIcons;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Button OkButton;
    }
}