namespace NetStalker
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.PasswordField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.ConfirmPasswordField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.SetPasswordButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.SaveButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.RemovePasswordButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.LightCheck = new MaterialSkin.Controls.MaterialRadioButton();
            this.DarkCheck = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.StatusLabel = new MaterialSkin.Controls.MaterialLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TaskbarCheck = new MaterialSkin.Controls.MaterialRadioButton();
            this.TrayCheck = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.SpoofProtectionCheck = new MaterialSkin.Controls.MaterialCheckBox();
            this.HelpBubble = new System.Windows.Forms.PictureBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuppressNotificationsCheck = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.TokenField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel14 = new MaterialSkin.Controls.MaterialLabel();
            this.MacVendorsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.materialLabel15 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel16 = new MaterialSkin.Controls.MaterialLabel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HelpBubble)).BeginInit();
            this.SuspendLayout();
            // 
            // PasswordField
            // 
            this.PasswordField.Depth = 0;
            this.PasswordField.Hint = "Set Password";
            this.PasswordField.Location = new System.Drawing.Point(129, 156);
            this.PasswordField.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PasswordField.MaxLength = 32767;
            this.PasswordField.MouseState = MaterialSkin.MouseState.HOVER;
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.PasswordChar = '*';
            this.PasswordField.SelectedText = "";
            this.PasswordField.SelectionLength = 0;
            this.PasswordField.SelectionStart = 0;
            this.PasswordField.Size = new System.Drawing.Size(299, 28);
            this.PasswordField.TabIndex = 8;
            this.PasswordField.TabStop = false;
            this.PasswordField.UseSystemPasswordChar = true;
            this.PasswordField.TextChanged += new System.EventHandler(this.PasswordField_TextChanged);
            // 
            // ConfirmPasswordField
            // 
            this.ConfirmPasswordField.Depth = 0;
            this.ConfirmPasswordField.Hint = "Confirm Password";
            this.ConfirmPasswordField.Location = new System.Drawing.Point(129, 191);
            this.ConfirmPasswordField.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConfirmPasswordField.MaxLength = 32767;
            this.ConfirmPasswordField.MouseState = MaterialSkin.MouseState.HOVER;
            this.ConfirmPasswordField.Name = "ConfirmPasswordField";
            this.ConfirmPasswordField.PasswordChar = '*';
            this.ConfirmPasswordField.SelectedText = "";
            this.ConfirmPasswordField.SelectionLength = 0;
            this.ConfirmPasswordField.SelectionStart = 0;
            this.ConfirmPasswordField.Size = new System.Drawing.Size(299, 28);
            this.ConfirmPasswordField.TabIndex = 9;
            this.ConfirmPasswordField.TabStop = false;
            this.ConfirmPasswordField.UseSystemPasswordChar = true;
            this.ConfirmPasswordField.TextChanged += new System.EventHandler(this.ConfirmPasswordField_TextChanged);
            // 
            // SetPasswordButton
            // 
            this.SetPasswordButton.AutoSize = true;
            this.SetPasswordButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SetPasswordButton.Depth = 0;
            this.SetPasswordButton.Icon = global::NetStalker.Properties.Resources.color_keyhole_shield;
            this.SetPasswordButton.Location = new System.Drawing.Point(331, 254);
            this.SetPasswordButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.SetPasswordButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.SetPasswordButton.Name = "SetPasswordButton";
            this.SetPasswordButton.Primary = false;
            this.SetPasswordButton.Size = new System.Drawing.Size(81, 36);
            this.SetPasswordButton.TabIndex = 18;
            this.SetPasswordButton.Text = "Set";
            this.SetPasswordButton.UseVisualStyleBackColor = true;
            this.SetPasswordButton.Click += new System.EventHandler(this.SetPasswordButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.AutoSize = true;
            this.SaveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaveButton.Depth = 0;
            this.SaveButton.Icon = global::NetStalker.Properties.Resources.color_ok;
            this.SaveButton.Location = new System.Drawing.Point(815, 525);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.SaveButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Primary = false;
            this.SaveButton.Size = new System.Drawing.Size(93, 36);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // RemovePasswordButton
            // 
            this.RemovePasswordButton.AutoSize = true;
            this.RemovePasswordButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RemovePasswordButton.Depth = 0;
            this.RemovePasswordButton.Icon = global::NetStalker.Properties.Resources.color_clear_symbol;
            this.RemovePasswordButton.Location = new System.Drawing.Point(183, 254);
            this.RemovePasswordButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.RemovePasswordButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.RemovePasswordButton.Name = "RemovePasswordButton";
            this.RemovePasswordButton.Primary = false;
            this.RemovePasswordButton.Size = new System.Drawing.Size(118, 36);
            this.RemovePasswordButton.TabIndex = 19;
            this.RemovePasswordButton.Text = "Remove";
            this.RemovePasswordButton.UseVisualStyleBackColor = true;
            this.RemovePasswordButton.Click += new System.EventHandler(this.RemovePasswordButton_Click);
            // 
            // materialLabel6
            // 
            this.materialLabel6.BackColor = System.Drawing.Color.White;
            this.materialLabel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(16, 126);
            this.materialLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(413, 2);
            this.materialLabel6.TabIndex = 20;
            // 
            // materialLabel3
            // 
            this.materialLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel3.BackColor = System.Drawing.Color.White;
            this.materialLabel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(483, 126);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(413, 2);
            this.materialLabel3.TabIndex = 22;
            // 
            // LightCheck
            // 
            this.LightCheck.AutoSize = true;
            this.LightCheck.Depth = 0;
            this.LightCheck.Font = new System.Drawing.Font("Roboto", 10F);
            this.LightCheck.Location = new System.Drawing.Point(5, 20);
            this.LightCheck.Margin = new System.Windows.Forms.Padding(0);
            this.LightCheck.MouseLocation = new System.Drawing.Point(-1, -1);
            this.LightCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.LightCheck.Name = "LightCheck";
            this.LightCheck.Ripple = true;
            this.LightCheck.Size = new System.Drawing.Size(69, 30);
            this.LightCheck.TabIndex = 23;
            this.LightCheck.TabStop = true;
            this.LightCheck.Text = "Light";
            this.LightCheck.UseVisualStyleBackColor = true;
            this.LightCheck.Click += new System.EventHandler(this.LightCheck_Click);
            // 
            // DarkCheck
            // 
            this.DarkCheck.AutoSize = true;
            this.DarkCheck.Depth = 0;
            this.DarkCheck.Font = new System.Drawing.Font("Roboto", 10F);
            this.DarkCheck.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DarkCheck.Location = new System.Drawing.Point(117, 20);
            this.DarkCheck.Margin = new System.Windows.Forms.Padding(0);
            this.DarkCheck.MouseLocation = new System.Drawing.Point(-1, -1);
            this.DarkCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.DarkCheck.Name = "DarkCheck";
            this.DarkCheck.Ripple = true;
            this.DarkCheck.Size = new System.Drawing.Size(66, 30);
            this.DarkCheck.TabIndex = 24;
            this.DarkCheck.TabStop = true;
            this.DarkCheck.Text = "Dark";
            this.DarkCheck.UseVisualStyleBackColor = true;
            this.DarkCheck.Click += new System.EventHandler(this.DarkCheck_Click);
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(295, 95);
            this.materialLabel11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(126, 24);
            this.materialLabel11.TabIndex = 31;
            this.materialLabel11.Text = "Set Password";
            // 
            // materialLabel2
            // 
            this.materialLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(764, 95);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(120, 24);
            this.materialLabel2.TabIndex = 32;
            this.materialLabel2.Text = "Choose Style";
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel10.Location = new System.Drawing.Point(21, 158);
            this.materialLabel10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(99, 24);
            this.materialLabel10.TabIndex = 34;
            this.materialLabel10.Text = "Password:";
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(21, 193);
            this.materialLabel12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(83, 24);
            this.materialLabel12.TabIndex = 35;
            this.materialLabel12.Text = "Confirm:";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(124, 225);
            this.materialLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(0, 24);
            this.materialLabel5.TabIndex = 36;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Depth = 0;
            this.StatusLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.StatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StatusLabel.Location = new System.Drawing.Point(21, 527);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StatusLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 24);
            this.StatusLabel.TabIndex = 37;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.DarkCheck);
            this.panel1.Controls.Add(this.LightCheck);
            this.panel1.Location = new System.Drawing.Point(483, 132);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 74);
            this.panel1.TabIndex = 38;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(696, 225);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(183, 24);
            this.materialLabel1.TabIndex = 41;
            this.materialLabel1.Text = "Minimize Application";
            // 
            // materialLabel9
            // 
            this.materialLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel9.BackColor = System.Drawing.Color.White;
            this.materialLabel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(483, 256);
            this.materialLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(413, 2);
            this.materialLabel9.TabIndex = 40;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.TaskbarCheck);
            this.panel3.Controls.Add(this.TrayCheck);
            this.panel3.Location = new System.Drawing.Point(483, 262);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(412, 62);
            this.panel3.TabIndex = 42;
            // 
            // TaskbarCheck
            // 
            this.TaskbarCheck.AutoSize = true;
            this.TaskbarCheck.Depth = 0;
            this.TaskbarCheck.Font = new System.Drawing.Font("Roboto", 10F);
            this.TaskbarCheck.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TaskbarCheck.Location = new System.Drawing.Point(117, 18);
            this.TaskbarCheck.Margin = new System.Windows.Forms.Padding(0);
            this.TaskbarCheck.MouseLocation = new System.Drawing.Point(-1, -1);
            this.TaskbarCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.TaskbarCheck.Name = "TaskbarCheck";
            this.TaskbarCheck.Ripple = true;
            this.TaskbarCheck.Size = new System.Drawing.Size(93, 30);
            this.TaskbarCheck.TabIndex = 24;
            this.TaskbarCheck.TabStop = true;
            this.TaskbarCheck.Text = "Taskbar";
            this.TaskbarCheck.UseVisualStyleBackColor = true;
            this.TaskbarCheck.Click += new System.EventHandler(this.TaskbarCheck_Click);
            // 
            // TrayCheck
            // 
            this.TrayCheck.AutoSize = true;
            this.TrayCheck.Depth = 0;
            this.TrayCheck.Font = new System.Drawing.Font("Roboto", 10F);
            this.TrayCheck.Location = new System.Drawing.Point(5, 18);
            this.TrayCheck.Margin = new System.Windows.Forms.Padding(0);
            this.TrayCheck.MouseLocation = new System.Drawing.Point(-1, -1);
            this.TrayCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.TrayCheck.Name = "TrayCheck";
            this.TrayCheck.Ripple = true;
            this.TrayCheck.Size = new System.Drawing.Size(64, 30);
            this.TrayCheck.TabIndex = 23;
            this.TrayCheck.TabStop = true;
            this.TrayCheck.Text = "Tray";
            this.TrayCheck.UseVisualStyleBackColor = true;
            this.TrayCheck.Click += new System.EventHandler(this.TrayCheck_Click);
            // 
            // materialLabel7
            // 
            this.materialLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(293, 318);
            this.materialLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(126, 24);
            this.materialLabel7.TabIndex = 44;
            this.materialLabel7.Text = "Other Options";
            // 
            // materialLabel8
            // 
            this.materialLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel8.BackColor = System.Drawing.Color.White;
            this.materialLabel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(16, 348);
            this.materialLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(413, 2);
            this.materialLabel8.TabIndex = 43;
            // 
            // SpoofProtectionCheck
            // 
            this.SpoofProtectionCheck.AutoSize = true;
            this.SpoofProtectionCheck.Depth = 0;
            this.SpoofProtectionCheck.Font = new System.Drawing.Font("Roboto", 10F);
            this.SpoofProtectionCheck.Location = new System.Drawing.Point(27, 370);
            this.SpoofProtectionCheck.Margin = new System.Windows.Forms.Padding(0);
            this.SpoofProtectionCheck.MouseLocation = new System.Drawing.Point(-1, -1);
            this.SpoofProtectionCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.SpoofProtectionCheck.Name = "SpoofProtectionCheck";
            this.SpoofProtectionCheck.Ripple = true;
            this.SpoofProtectionCheck.Size = new System.Drawing.Size(161, 30);
            this.SpoofProtectionCheck.TabIndex = 45;
            this.SpoofProtectionCheck.Text = "Spoof Protection";
            this.SpoofProtectionCheck.UseVisualStyleBackColor = true;
            this.SpoofProtectionCheck.CheckedChanged += new System.EventHandler(this.SpoofProtectionCheck_CheckedChanged);
            // 
            // HelpBubble
            // 
            this.HelpBubble.Image = global::NetStalker.Properties.Resources.color_help;
            this.HelpBubble.Location = new System.Drawing.Point(265, 370);
            this.HelpBubble.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HelpBubble.Name = "HelpBubble";
            this.HelpBubble.Size = new System.Drawing.Size(40, 37);
            this.HelpBubble.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HelpBubble.TabIndex = 46;
            this.HelpBubble.TabStop = false;
            this.HelpBubble.MouseEnter += new System.EventHandler(this.HelpBubble_MouseEnter);
            // 
            // ToolTip
            // 
            this.ToolTip.AutomaticDelay = 1000;
            this.ToolTip.AutoPopDelay = 10000;
            this.ToolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ToolTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.ToolTip.InitialDelay = 400;
            this.ToolTip.OwnerDraw = true;
            this.ToolTip.ReshowDelay = 200;
            this.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ToolTip.ToolTipTitle = "Info";
            this.ToolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.ToolTip_Draw);
            this.ToolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.ToolTip_Popup);
            // 
            // SuppressNotificationsCheck
            // 
            this.SuppressNotificationsCheck.AutoSize = true;
            this.SuppressNotificationsCheck.Depth = 0;
            this.SuppressNotificationsCheck.Font = new System.Drawing.Font("Roboto", 10F);
            this.SuppressNotificationsCheck.Location = new System.Drawing.Point(27, 420);
            this.SuppressNotificationsCheck.Margin = new System.Windows.Forms.Padding(0);
            this.SuppressNotificationsCheck.MouseLocation = new System.Drawing.Point(-1, -1);
            this.SuppressNotificationsCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.SuppressNotificationsCheck.Name = "SuppressNotificationsCheck";
            this.SuppressNotificationsCheck.Ripple = true;
            this.SuppressNotificationsCheck.Size = new System.Drawing.Size(207, 30);
            this.SuppressNotificationsCheck.TabIndex = 47;
            this.SuppressNotificationsCheck.Text = "Suppress Notifications";
            this.SuppressNotificationsCheck.UseVisualStyleBackColor = true;
            this.SuppressNotificationsCheck.CheckedChanged += new System.EventHandler(this.SuppressNotificationsCheck_CheckedChanged);
            // 
            // materialLabel4
            // 
            this.materialLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(719, 339);
            this.materialLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(160, 24);
            this.materialLabel4.TabIndex = 49;
            this.materialLabel4.Text = "MAC Vendors API";
            // 
            // materialLabel13
            // 
            this.materialLabel13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel13.BackColor = System.Drawing.Color.White;
            this.materialLabel13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel13.Location = new System.Drawing.Point(483, 370);
            this.materialLabel13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(413, 2);
            this.materialLabel13.TabIndex = 48;
            // 
            // TokenField
            // 
            this.TokenField.Depth = 0;
            this.TokenField.Hint = "Token";
            this.TokenField.Location = new System.Drawing.Point(587, 425);
            this.TokenField.MaxLength = 32767;
            this.TokenField.MouseState = MaterialSkin.MouseState.HOVER;
            this.TokenField.Name = "TokenField";
            this.TokenField.PasswordChar = '\0';
            this.TokenField.SelectedText = "";
            this.TokenField.SelectionLength = 0;
            this.TokenField.SelectionStart = 0;
            this.TokenField.Size = new System.Drawing.Size(309, 28);
            this.TokenField.TabIndex = 50;
            this.TokenField.TabStop = false;
            this.TokenField.UseSystemPasswordChar = false;
            // 
            // materialLabel14
            // 
            this.materialLabel14.AutoSize = true;
            this.materialLabel14.Depth = 0;
            this.materialLabel14.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel14.Location = new System.Drawing.Point(479, 427);
            this.materialLabel14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel14.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel14.Name = "materialLabel14";
            this.materialLabel14.Size = new System.Drawing.Size(101, 24);
            this.materialLabel14.TabIndex = 51;
            this.materialLabel14.Text = "API Token:";
            // 
            // MacVendorsLinkLabel
            // 
            this.MacVendorsLinkLabel.AutoSize = true;
            this.MacVendorsLinkLabel.Location = new System.Drawing.Point(715, 462);
            this.MacVendorsLinkLabel.Name = "MacVendorsLinkLabel";
            this.MacVendorsLinkLabel.Size = new System.Drawing.Size(181, 17);
            this.MacVendorsLinkLabel.TabIndex = 52;
            this.MacVendorsLinkLabel.TabStop = true;
            this.MacVendorsLinkLabel.Text = "https://macvendors.com/api";
            this.MacVendorsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // materialLabel15
            // 
            this.materialLabel15.AutoSize = true;
            this.materialLabel15.Depth = 0;
            this.materialLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.materialLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel15.Location = new System.Drawing.Point(480, 377);
            this.materialLabel15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel15.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel15.Name = "materialLabel15";
            this.materialLabel15.Size = new System.Drawing.Size(405, 34);
            this.materialLabel15.TabIndex = 55;
            this.materialLabel15.Text = "If you can\'t see the device\'s manufacturer, acquire a new token\r\nfrom the link be" +
    "low and enter it in the API Token field.";
            // 
            // materialLabel16
            // 
            this.materialLabel16.AutoSize = true;
            this.materialLabel16.Depth = 0;
            this.materialLabel16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.materialLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel16.Location = new System.Drawing.Point(586, 462);
            this.materialLabel16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel16.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel16.Name = "materialLabel16";
            this.materialLabel16.Size = new System.Drawing.Size(122, 17);
            this.materialLabel16.TabIndex = 56;
            this.materialLabel16.Text = "Get your token at:";
            // 
            // Options
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 580);
            this.ControlBox = false;
            this.Controls.Add(this.materialLabel16);
            this.Controls.Add(this.materialLabel15);
            this.Controls.Add(this.MacVendorsLinkLabel);
            this.Controls.Add(this.materialLabel14);
            this.Controls.Add(this.TokenField);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel13);
            this.Controls.Add(this.SuppressNotificationsCheck);
            this.Controls.Add(this.HelpBubble);
            this.Controls.Add(this.SpoofProtectionCheck);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.materialLabel8);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialLabel9);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel12);
            this.Controls.Add(this.materialLabel10);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel11);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.RemovePasswordButton);
            this.Controls.Add(this.SetPasswordButton);
            this.Controls.Add(this.ConfirmPasswordField);
            this.Controls.Add(this.PasswordField);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.Click += new System.EventHandler(this.Options_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HelpBubble)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton SaveButton;
        private MaterialSkin.Controls.MaterialSingleLineTextField PasswordField;
        private MaterialSkin.Controls.MaterialSingleLineTextField ConfirmPasswordField;
        private MaterialSkin.Controls.MaterialFlatButton SetPasswordButton;
        private MaterialSkin.Controls.MaterialFlatButton RemovePasswordButton;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialRadioButton LightCheck;
        private MaterialSkin.Controls.MaterialRadioButton DarkCheck;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel StatusLabel;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialRadioButton TaskbarCheck;
        private MaterialSkin.Controls.MaterialRadioButton TrayCheck;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialCheckBox SpoofProtectionCheck;
        private System.Windows.Forms.PictureBox HelpBubble;
        public System.Windows.Forms.ToolTip ToolTip;
        private MaterialSkin.Controls.MaterialCheckBox SuppressNotificationsCheck;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private MaterialSkin.Controls.MaterialSingleLineTextField TokenField;
        private MaterialSkin.Controls.MaterialLabel materialLabel14;
        private System.Windows.Forms.LinkLabel MacVendorsLinkLabel;
        private MaterialSkin.Controls.MaterialLabel materialLabel15;
        private MaterialSkin.Controls.MaterialLabel materialLabel16;
    }
}