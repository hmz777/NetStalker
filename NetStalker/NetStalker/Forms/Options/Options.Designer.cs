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
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HelpBubble)).BeginInit();
            this.SuspendLayout();
            // 
            // PasswordField
            // 
            this.PasswordField.Depth = 0;
            this.PasswordField.Hint = "Set Password";
            this.PasswordField.Location = new System.Drawing.Point(97, 128);
            this.PasswordField.MaxLength = 32767;
            this.PasswordField.MouseState = MaterialSkin.MouseState.HOVER;
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.PasswordChar = '*';
            this.PasswordField.SelectedText = "";
            this.PasswordField.SelectionLength = 0;
            this.PasswordField.SelectionStart = 0;
            this.PasswordField.Size = new System.Drawing.Size(224, 23);
            this.PasswordField.TabIndex = 8;
            this.PasswordField.TabStop = false;
            this.PasswordField.UseSystemPasswordChar = true;
            this.PasswordField.TextChanged += new System.EventHandler(this.PasswordField_TextChanged);
            // 
            // ConfirmPasswordField
            // 
            this.ConfirmPasswordField.Depth = 0;
            this.ConfirmPasswordField.Hint = "Confirm Password";
            this.ConfirmPasswordField.Location = new System.Drawing.Point(97, 157);
            this.ConfirmPasswordField.MaxLength = 32767;
            this.ConfirmPasswordField.MouseState = MaterialSkin.MouseState.HOVER;
            this.ConfirmPasswordField.Name = "ConfirmPasswordField";
            this.ConfirmPasswordField.PasswordChar = '*';
            this.ConfirmPasswordField.SelectedText = "";
            this.ConfirmPasswordField.SelectionLength = 0;
            this.ConfirmPasswordField.SelectionStart = 0;
            this.ConfirmPasswordField.Size = new System.Drawing.Size(224, 23);
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
            this.SetPasswordButton.Location = new System.Drawing.Point(248, 206);
            this.SetPasswordButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.SetPasswordButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.SetPasswordButton.Name = "SetPasswordButton";
            this.SetPasswordButton.Primary = false;
            this.SetPasswordButton.Size = new System.Drawing.Size(73, 36);
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
            this.SaveButton.Location = new System.Drawing.Point(588, 373);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.SaveButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Primary = false;
            this.SaveButton.Size = new System.Drawing.Size(83, 36);
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
            this.RemovePasswordButton.Location = new System.Drawing.Point(137, 206);
            this.RemovePasswordButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RemovePasswordButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.RemovePasswordButton.Name = "RemovePasswordButton";
            this.RemovePasswordButton.Primary = false;
            this.RemovePasswordButton.Size = new System.Drawing.Size(103, 36);
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
            this.materialLabel6.Location = new System.Drawing.Point(12, 102);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(310, 2);
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
            this.materialLabel3.Location = new System.Drawing.Point(362, 102);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(310, 2);
            this.materialLabel3.TabIndex = 22;
            // 
            // LightCheck
            // 
            this.LightCheck.AutoSize = true;
            this.LightCheck.Depth = 0;
            this.LightCheck.Font = new System.Drawing.Font("Roboto", 10F);
            this.LightCheck.Location = new System.Drawing.Point(4, 16);
            this.LightCheck.Margin = new System.Windows.Forms.Padding(0);
            this.LightCheck.MouseLocation = new System.Drawing.Point(-1, -1);
            this.LightCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.LightCheck.Name = "LightCheck";
            this.LightCheck.Ripple = true;
            this.LightCheck.Size = new System.Drawing.Size(60, 30);
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
            this.DarkCheck.Location = new System.Drawing.Point(88, 16);
            this.DarkCheck.Margin = new System.Windows.Forms.Padding(0);
            this.DarkCheck.MouseLocation = new System.Drawing.Point(-1, -1);
            this.DarkCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.DarkCheck.Name = "DarkCheck";
            this.DarkCheck.Ripple = true;
            this.DarkCheck.Size = new System.Drawing.Size(57, 30);
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
            this.materialLabel11.Location = new System.Drawing.Point(221, 77);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(101, 19);
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
            this.materialLabel2.Location = new System.Drawing.Point(573, 77);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(98, 19);
            this.materialLabel2.TabIndex = 32;
            this.materialLabel2.Text = "Choose Style";
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel10.Location = new System.Drawing.Point(16, 128);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(79, 19);
            this.materialLabel10.TabIndex = 34;
            this.materialLabel10.Text = "Password:";
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(16, 157);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(67, 19);
            this.materialLabel12.TabIndex = 35;
            this.materialLabel12.Text = "Confirm:";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(93, 183);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(0, 19);
            this.materialLabel5.TabIndex = 36;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Depth = 0;
            this.StatusLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.StatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StatusLabel.Location = new System.Drawing.Point(16, 381);
            this.StatusLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 19);
            this.StatusLabel.TabIndex = 37;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.DarkCheck);
            this.panel1.Controls.Add(this.LightCheck);
            this.panel1.Location = new System.Drawing.Point(362, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 60);
            this.panel1.TabIndex = 38;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(522, 183);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(150, 19);
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
            this.materialLabel9.Location = new System.Drawing.Point(362, 208);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(310, 2);
            this.materialLabel9.TabIndex = 40;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.TaskbarCheck);
            this.panel3.Controls.Add(this.TrayCheck);
            this.panel3.Location = new System.Drawing.Point(362, 213);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(309, 50);
            this.panel3.TabIndex = 42;
            // 
            // TaskbarCheck
            // 
            this.TaskbarCheck.AutoSize = true;
            this.TaskbarCheck.Depth = 0;
            this.TaskbarCheck.Font = new System.Drawing.Font("Roboto", 10F);
            this.TaskbarCheck.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TaskbarCheck.Location = new System.Drawing.Point(88, 15);
            this.TaskbarCheck.Margin = new System.Windows.Forms.Padding(0);
            this.TaskbarCheck.MouseLocation = new System.Drawing.Point(-1, -1);
            this.TaskbarCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.TaskbarCheck.Name = "TaskbarCheck";
            this.TaskbarCheck.Ripple = true;
            this.TaskbarCheck.Size = new System.Drawing.Size(79, 30);
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
            this.TrayCheck.Location = new System.Drawing.Point(4, 15);
            this.TrayCheck.Margin = new System.Windows.Forms.Padding(0);
            this.TrayCheck.MouseLocation = new System.Drawing.Point(-1, -1);
            this.TrayCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.TrayCheck.Name = "TrayCheck";
            this.TrayCheck.Ripple = true;
            this.TrayCheck.Size = new System.Drawing.Size(56, 30);
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
            this.materialLabel7.Location = new System.Drawing.Point(220, 258);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(101, 19);
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
            this.materialLabel8.Location = new System.Drawing.Point(12, 283);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(310, 2);
            this.materialLabel8.TabIndex = 43;
            // 
            // SpoofProtectionCheck
            // 
            this.SpoofProtectionCheck.AutoSize = true;
            this.SpoofProtectionCheck.Depth = 0;
            this.SpoofProtectionCheck.Font = new System.Drawing.Font("Roboto", 10F);
            this.SpoofProtectionCheck.Location = new System.Drawing.Point(20, 301);
            this.SpoofProtectionCheck.Margin = new System.Windows.Forms.Padding(0);
            this.SpoofProtectionCheck.MouseLocation = new System.Drawing.Point(-1, -1);
            this.SpoofProtectionCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.SpoofProtectionCheck.Name = "SpoofProtectionCheck";
            this.SpoofProtectionCheck.Ripple = true;
            this.SpoofProtectionCheck.Size = new System.Drawing.Size(134, 30);
            this.SpoofProtectionCheck.TabIndex = 45;
            this.SpoofProtectionCheck.Text = "Spoof Protection";
            this.SpoofProtectionCheck.UseVisualStyleBackColor = true;
            this.SpoofProtectionCheck.CheckedChanged += new System.EventHandler(this.SpoofProtectionCheck_CheckedChanged);
            // 
            // HelpBubble
            // 
            this.HelpBubble.Image = global::NetStalker.Properties.Resources.color_help;
            this.HelpBubble.Location = new System.Drawing.Point(199, 301);
            this.HelpBubble.Name = "HelpBubble";
            this.HelpBubble.Size = new System.Drawing.Size(30, 30);
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
            this.SuppressNotificationsCheck.Location = new System.Drawing.Point(20, 341);
            this.SuppressNotificationsCheck.Margin = new System.Windows.Forms.Padding(0);
            this.SuppressNotificationsCheck.MouseLocation = new System.Drawing.Point(-1, -1);
            this.SuppressNotificationsCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.SuppressNotificationsCheck.Name = "SuppressNotificationsCheck";
            this.SuppressNotificationsCheck.Ripple = true;
            this.SuppressNotificationsCheck.Size = new System.Drawing.Size(170, 30);
            this.SuppressNotificationsCheck.TabIndex = 47;
            this.SuppressNotificationsCheck.Text = "Suppress Notifications";
            this.SuppressNotificationsCheck.UseVisualStyleBackColor = true;
            this.SuppressNotificationsCheck.CheckedChanged += new System.EventHandler(this.SuppressNotificationsCheck_CheckedChanged);
            // 
            // Options
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 424);
            this.ControlBox = false;
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
    }
}