namespace NetStalker
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle25 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle26 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle27 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle28 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle29 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle30 = new BrightIdeasSoftware.HeaderStateStyle();
            this.DeviceMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SetName = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearName = new System.Windows.Forms.ToolStripMenuItem();
            this.IconList = new System.Windows.Forms.ImageList(this.components);
            this.DarkHeaders = new BrightIdeasSoftware.HeaderFormatStyle();
            this.DarkHot = new BrightIdeasSoftware.HotItemStyle();
            this.ButtonIcons = new System.Windows.Forms.ImageList(this.components);
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sHOWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LightHot = new BrightIdeasSoftware.HotItemStyle();
            this.LightHeaders = new BrightIdeasSoftware.HeaderFormatStyle();
            this.Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.LoadingIndicator = new System.Windows.Forms.PictureBox();
            this.ScanButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.FormHelpButton = new System.Windows.Forms.Button();
            this.AboutButton = new System.Windows.Forms.Button();
            this.SnifferButton = new System.Windows.Forms.Button();
            this.LimiterButton = new System.Windows.Forms.Button();
            this.RedirectAllCheck = new System.Windows.Forms.CheckBox();
            this.BlockAllCheck = new System.Windows.Forms.CheckBox();
            this.DeviceList = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn9 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.Divider1 = new System.Windows.Forms.Label();
            this.CurrentOperationStatusLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DeviceCountLabel = new System.Windows.Forms.Label();
            this.OpIndicator = new System.Windows.Forms.PictureBox();
            this.Divider2 = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Separator = new System.Windows.Forms.Label();
            this.DeviceMenu.SuspendLayout();
            this.TrayMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceList)).BeginInit();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OpIndicator)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeviceMenu
            // 
            this.DeviceMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DeviceMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetName,
            this.ClearName});
            this.DeviceMenu.Name = "DeviceMenu";
            this.DeviceMenu.Size = new System.Drawing.Size(208, 52);
            // 
            // SetName
            // 
            this.SetName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetName.Name = "SetName";
            this.SetName.Size = new System.Drawing.Size(207, 24);
            this.SetName.Text = "Set Friendly Name";
            this.SetName.Click += new System.EventHandler(this.SetName_Click);
            // 
            // ClearName
            // 
            this.ClearName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearName.Name = "ClearName";
            this.ClearName.Size = new System.Drawing.Size(207, 24);
            this.ClearName.Text = "Clear Name";
            this.ClearName.Click += new System.EventHandler(this.ClearName_Click);
            // 
            // IconList
            // 
            this.IconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconList.ImageStream")));
            this.IconList.TransparentColor = System.Drawing.Color.Transparent;
            this.IconList.Images.SetKeyName(0, "router");
            this.IconList.Images.SetKeyName(1, "pc");
            // 
            // DarkHeaders
            // 
            headerStateStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            headerStateStyle25.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            headerStateStyle25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.DarkHeaders.Hot = headerStateStyle25;
            headerStateStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            headerStateStyle26.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            headerStateStyle26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.DarkHeaders.Normal = headerStateStyle26;
            headerStateStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            headerStateStyle27.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            headerStateStyle27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.DarkHeaders.Pressed = headerStateStyle27;
            // 
            // DarkHot
            // 
            this.DarkHot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            this.DarkHot.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DarkHot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            // 
            // ButtonIcons
            // 
            this.ButtonIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonIcons.ImageStream")));
            this.ButtonIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ButtonIcons.Images.SetKeyName(0, "color_about.PNG");
            this.ButtonIcons.Images.SetKeyName(1, "color_cancel.PNG");
            this.ButtonIcons.Images.SetKeyName(2, "color_clear-symbol.PNG");
            this.ButtonIcons.Images.SetKeyName(3, "color_define-location.PNG");
            this.ButtonIcons.Images.SetKeyName(4, "color_error.PNG");
            this.ButtonIcons.Images.SetKeyName(5, "color_external.PNG");
            this.ButtonIcons.Images.SetKeyName(6, "color_gear.PNG");
            this.ButtonIcons.Images.SetKeyName(7, "color_help.PNG");
            this.ButtonIcons.Images.SetKeyName(8, "color_info.PNG");
            this.ButtonIcons.Images.SetKeyName(9, "color_keyhole-shield.PNG");
            this.ButtonIcons.Images.SetKeyName(10, "color_network-card.PNG");
            this.ButtonIcons.Images.SetKeyName(11, "color_ok.PNG");
            this.ButtonIcons.Images.SetKeyName(12, "color_restart.PNG");
            this.ButtonIcons.Images.SetKeyName(13, "color_start.PNG");
            this.ButtonIcons.Images.SetKeyName(14, "color_stop-squared.PNG");
            this.ButtonIcons.Images.SetKeyName(15, "icons8-info-35.png");
            this.ButtonIcons.Images.SetKeyName(16, "icons8-ok-red.png");
            this.ButtonIcons.Images.SetKeyName(17, "spinB.gif");
            this.ButtonIcons.Images.SetKeyName(18, "spinW.gif");
            this.ButtonIcons.Images.SetKeyName(19, "icons8-speed-96.png");
            this.ButtonIcons.Images.SetKeyName(20, "icons8-target-100.png");
            this.ButtonIcons.Images.SetKeyName(21, "icons8-gps-signal-96.png");
            // 
            // TrayIcon
            // 
            this.TrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TrayIcon.BalloonTipText = "NetStalker is minimized";
            this.TrayIcon.BalloonTipTitle = "Info";
            this.TrayIcon.ContextMenuStrip = this.TrayMenu;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "NetStalker";
            // 
            // TrayMenu
            // 
            this.TrayMenu.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrayMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sHOWToolStripMenuItem,
            this.eXITToolStripMenuItem});
            this.TrayMenu.Name = "TrayMenu";
            this.TrayMenu.Size = new System.Drawing.Size(124, 52);
            // 
            // sHOWToolStripMenuItem
            // 
            this.sHOWToolStripMenuItem.Name = "sHOWToolStripMenuItem";
            this.sHOWToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.sHOWToolStripMenuItem.Text = "SHOW";
            this.sHOWToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // eXITToolStripMenuItem
            // 
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.eXITToolStripMenuItem.Text = "EXIT";
            this.eXITToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // LightHot
            // 
            this.LightHot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.LightHot.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LightHot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            // 
            // LightHeaders
            // 
            headerStateStyle28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            headerStateStyle28.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            headerStateStyle28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.LightHeaders.Hot = headerStateStyle28;
            headerStateStyle29.BackColor = System.Drawing.Color.WhiteSmoke;
            headerStateStyle29.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            headerStateStyle29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.LightHeaders.Normal = headerStateStyle29;
            headerStateStyle30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            headerStateStyle30.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LightHeaders.Pressed = headerStateStyle30;
            // 
            // Tooltip
            // 
            this.Tooltip.AutomaticDelay = 1000;
            this.Tooltip.AutoPopDelay = 10000;
            this.Tooltip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Tooltip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Tooltip.InitialDelay = 500;
            this.Tooltip.OwnerDraw = true;
            this.Tooltip.ReshowDelay = 200;
            this.Tooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Tooltip.ToolTipTitle = "Info";
            this.Tooltip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.ToolTip_Draw);
            this.Tooltip.Popup += new System.Windows.Forms.PopupEventHandler(this.ToolTip_Popup);
            // 
            // LoadingIndicator
            // 
            this.LoadingIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadingIndicator.Location = new System.Drawing.Point(898, 16);
            this.LoadingIndicator.Margin = new System.Windows.Forms.Padding(2);
            this.LoadingIndicator.Name = "LoadingIndicator";
            this.LoadingIndicator.Size = new System.Drawing.Size(30, 29);
            this.LoadingIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoadingIndicator.TabIndex = 26;
            this.LoadingIndicator.TabStop = false;
            this.Tooltip.SetToolTip(this.LoadingIndicator, "Background scanning is active");
            this.LoadingIndicator.Visible = false;
            // 
            // ScanButton
            // 
            this.ScanButton.BackColor = System.Drawing.Color.White;
            this.ScanButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ScanButton.FlatAppearance.BorderSize = 0;
            this.ScanButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScanButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScanButton.ImageKey = "icons8-gps-signal-96.png";
            this.ScanButton.ImageList = this.ButtonIcons;
            this.ScanButton.Location = new System.Drawing.Point(5, 5);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(104, 50);
            this.ScanButton.TabIndex = 2;
            this.ScanButton.Text = "SCAN";
            this.ScanButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ScanButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Tooltip.SetToolTip(this.ScanButton, "Initiate a new device scan");
            this.ScanButton.UseVisualStyleBackColor = false;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackColor = System.Drawing.Color.White;
            this.RefreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RefreshButton.FlatAppearance.BorderSize = 0;
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshButton.ImageKey = "color_restart.PNG";
            this.RefreshButton.ImageList = this.ButtonIcons;
            this.RefreshButton.Location = new System.Drawing.Point(109, 5);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(59, 50);
            this.RefreshButton.TabIndex = 29;
            this.RefreshButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RefreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Tooltip.SetToolTip(this.RefreshButton, resources.GetString("RefreshButton.ToolTip"));
            this.RefreshButton.UseVisualStyleBackColor = false;
            this.RefreshButton.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // OptionsButton
            // 
            this.OptionsButton.BackColor = System.Drawing.Color.White;
            this.OptionsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.OptionsButton.FlatAppearance.BorderSize = 0;
            this.OptionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OptionsButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsButton.ImageKey = "color_gear.PNG";
            this.OptionsButton.ImageList = this.ButtonIcons;
            this.OptionsButton.Location = new System.Drawing.Point(376, 5);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(104, 50);
            this.OptionsButton.TabIndex = 30;
            this.OptionsButton.Text = "OPTIONS";
            this.OptionsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OptionsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Tooltip.SetToolTip(this.OptionsButton, "Change NetStalker settings");
            this.OptionsButton.UseVisualStyleBackColor = false;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // FormHelpButton
            // 
            this.FormHelpButton.BackColor = System.Drawing.Color.White;
            this.FormHelpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FormHelpButton.FlatAppearance.BorderSize = 0;
            this.FormHelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FormHelpButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormHelpButton.ImageKey = "color_help.PNG";
            this.FormHelpButton.ImageList = this.ButtonIcons;
            this.FormHelpButton.Location = new System.Drawing.Point(480, 5);
            this.FormHelpButton.Name = "FormHelpButton";
            this.FormHelpButton.Size = new System.Drawing.Size(104, 50);
            this.FormHelpButton.TabIndex = 31;
            this.FormHelpButton.Text = "HELP";
            this.FormHelpButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FormHelpButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Tooltip.SetToolTip(this.FormHelpButton, "A simple guide on how to use this software properly\r\n");
            this.FormHelpButton.UseVisualStyleBackColor = false;
            this.FormHelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.BackColor = System.Drawing.Color.White;
            this.AboutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AboutButton.FlatAppearance.BorderSize = 0;
            this.AboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AboutButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutButton.ImageKey = "color_about.PNG";
            this.AboutButton.ImageList = this.ButtonIcons;
            this.AboutButton.Location = new System.Drawing.Point(584, 5);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(104, 50);
            this.AboutButton.TabIndex = 32;
            this.AboutButton.Text = "ABOUT";
            this.AboutButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AboutButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Tooltip.SetToolTip(this.AboutButton, "About the developer");
            this.AboutButton.UseVisualStyleBackColor = false;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // SnifferButton
            // 
            this.SnifferButton.BackColor = System.Drawing.Color.White;
            this.SnifferButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SnifferButton.FlatAppearance.BorderSize = 0;
            this.SnifferButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SnifferButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SnifferButton.ImageKey = "icons8-target-100.png";
            this.SnifferButton.ImageList = this.ButtonIcons;
            this.SnifferButton.Location = new System.Drawing.Point(272, 5);
            this.SnifferButton.Name = "SnifferButton";
            this.SnifferButton.Size = new System.Drawing.Size(104, 50);
            this.SnifferButton.TabIndex = 36;
            this.SnifferButton.Text = "SNIFFER";
            this.SnifferButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SnifferButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Tooltip.SetToolTip(this.SnifferButton, "Start the Packet Sniffer");
            this.SnifferButton.UseVisualStyleBackColor = false;
            this.SnifferButton.Click += new System.EventHandler(this.SnifferButton_Click);
            // 
            // LimiterButton
            // 
            this.LimiterButton.BackColor = System.Drawing.Color.White;
            this.LimiterButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LimiterButton.FlatAppearance.BorderSize = 0;
            this.LimiterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LimiterButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LimiterButton.ImageKey = "icons8-speed-96.png";
            this.LimiterButton.ImageList = this.ButtonIcons;
            this.LimiterButton.Location = new System.Drawing.Point(168, 5);
            this.LimiterButton.Name = "LimiterButton";
            this.LimiterButton.Size = new System.Drawing.Size(104, 50);
            this.LimiterButton.TabIndex = 37;
            this.LimiterButton.Text = "LIMITER";
            this.LimiterButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LimiterButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Tooltip.SetToolTip(this.LimiterButton, "Start the Speed Limiter\r\n");
            this.LimiterButton.UseVisualStyleBackColor = false;
            this.LimiterButton.Click += new System.EventHandler(this.LimiterButton_Click);
            // 
            // RedirectAllCheck
            // 
            this.RedirectAllCheck.AutoCheck = false;
            this.RedirectAllCheck.AutoSize = true;
            this.RedirectAllCheck.Location = new System.Drawing.Point(734, 32);
            this.RedirectAllCheck.Name = "RedirectAllCheck";
            this.RedirectAllCheck.Size = new System.Drawing.Size(119, 23);
            this.RedirectAllCheck.TabIndex = 40;
            this.RedirectAllCheck.Text = "REDIRECT ALL";
            this.Tooltip.SetToolTip(this.RedirectAllCheck, "Redirects all present devices \r\nincluding future detected devices.");
            this.RedirectAllCheck.UseVisualStyleBackColor = true;
            this.RedirectAllCheck.Click += new System.EventHandler(this.RedirectAllCheck_CheckedChanged);
            // 
            // BlockAllCheck
            // 
            this.BlockAllCheck.AutoCheck = false;
            this.BlockAllCheck.AutoSize = true;
            this.BlockAllCheck.Location = new System.Drawing.Point(734, 4);
            this.BlockAllCheck.Name = "BlockAllCheck";
            this.BlockAllCheck.Size = new System.Drawing.Size(101, 23);
            this.BlockAllCheck.TabIndex = 39;
            this.BlockAllCheck.Text = "BLOCK ALL";
            this.Tooltip.SetToolTip(this.BlockAllCheck, "Blocks all present devices \r\nincluding future detected devices.");
            this.BlockAllCheck.UseVisualStyleBackColor = true;
            this.BlockAllCheck.Click += new System.EventHandler(this.BlockAllCheck_CheckedChanged);
            // 
            // DeviceList
            // 
            this.DeviceList.AllColumns.Add(this.olvColumn1);
            this.DeviceList.AllColumns.Add(this.olvColumn2);
            this.DeviceList.AllColumns.Add(this.olvColumn3);
            this.DeviceList.AllColumns.Add(this.olvColumn9);
            this.DeviceList.AllColumns.Add(this.olvColumn4);
            this.DeviceList.AllColumns.Add(this.olvColumn5);
            this.DeviceList.AllColumns.Add(this.olvColumn6);
            this.DeviceList.AllColumns.Add(this.olvColumn8);
            this.DeviceList.AllColumns.Add(this.olvColumn7);
            this.DeviceList.BackColor = System.Drawing.Color.White;
            this.DeviceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DeviceList.CellEditUseWholeCell = false;
            this.DeviceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn9,
            this.olvColumn4,
            this.olvColumn5,
            this.olvColumn6,
            this.olvColumn8,
            this.olvColumn7});
            this.DeviceList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DeviceList.EmptyListMsg = "Device list is empty";
            this.DeviceList.EmptyListMsgFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceList.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.DeviceList.FullRowSelect = true;
            this.DeviceList.GroupImageList = this.IconList;
            this.DeviceList.HeaderFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceList.HeaderFormatStyle = this.DarkHeaders;
            this.DeviceList.HideSelection = false;
            this.DeviceList.Location = new System.Drawing.Point(2, 2);
            this.DeviceList.Margin = new System.Windows.Forms.Padding(2);
            this.DeviceList.MultiSelect = false;
            this.DeviceList.Name = "DeviceList";
            this.DeviceList.OverlayImage.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.DeviceList.RowHeight = 30;
            this.DeviceList.SelectAllOnControlA = false;
            this.DeviceList.SelectColumnsMenuStaysOpen = false;
            this.DeviceList.SelectColumnsOnRightClick = false;
            this.DeviceList.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.DeviceList.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.DeviceList.SelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.DeviceList.ShowFilterMenuOnRightClick = false;
            this.DeviceList.ShowGroups = false;
            this.DeviceList.ShowImagesOnSubItems = true;
            this.DeviceList.ShowSortIndicators = false;
            this.DeviceList.Size = new System.Drawing.Size(1312, 461);
            this.DeviceList.SmallImageList = this.IconList;
            this.DeviceList.SpaceBetweenGroups = 1;
            this.DeviceList.TabIndex = 0;
            this.DeviceList.UnfocusedSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.DeviceList.UnfocusedSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.DeviceList.UseCompatibleStateImageBehavior = false;
            this.DeviceList.UseHotItem = true;
            this.DeviceList.UseNotifyPropertyChanged = true;
            this.DeviceList.UseSubItemCheckBoxes = true;
            this.DeviceList.UseTranslucentSelection = true;
            this.DeviceList.View = System.Windows.Forms.View.Details;
            this.DeviceList.VirtualMode = true;
            this.DeviceList.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.DeviceList_CellRightClick);
            this.DeviceList.SubItemChecking += new System.EventHandler<BrightIdeasSoftware.SubItemCheckingEventArgs>(this.DeviceList_SubItemChecking);
            this.DeviceList.ItemsAdding += new System.EventHandler<BrightIdeasSoftware.ItemsAddingEventArgs>(this.DeviceList_ItemsAdding);
            this.DeviceList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DeviceList_MouseDown);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "IP";
            this.olvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.olvColumn1.Hideable = false;
            this.olvColumn1.ImageAspectName = "Image";
            this.olvColumn1.IsEditable = false;
            this.olvColumn1.MaximumWidth = 165;
            this.olvColumn1.MinimumWidth = 165;
            this.olvColumn1.Text = "IP";
            this.olvColumn1.Width = 165;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "MAC";
            this.olvColumn2.Groupable = false;
            this.olvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.Hideable = false;
            this.olvColumn2.IsEditable = false;
            this.olvColumn2.MaximumWidth = 145;
            this.olvColumn2.MinimumWidth = 145;
            this.olvColumn2.Searchable = false;
            this.olvColumn2.Text = "MAC";
            this.olvColumn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.Width = 145;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "DeviceName";
            this.olvColumn3.Groupable = false;
            this.olvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn3.Hideable = false;
            this.olvColumn3.IsEditable = false;
            this.olvColumn3.MaximumWidth = 250;
            this.olvColumn3.MinimumWidth = 250;
            this.olvColumn3.Searchable = false;
            this.olvColumn3.Text = "Device Name";
            this.olvColumn3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn3.Width = 250;
            // 
            // olvColumn9
            // 
            this.olvColumn9.AspectName = "ManName";
            this.olvColumn9.Groupable = false;
            this.olvColumn9.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn9.Hideable = false;
            this.olvColumn9.IsEditable = false;
            this.olvColumn9.MaximumWidth = 200;
            this.olvColumn9.MinimumWidth = 200;
            this.olvColumn9.Searchable = false;
            this.olvColumn9.Text = "Vendor";
            this.olvColumn9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn9.Width = 200;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "DeviceStatus";
            this.olvColumn4.Groupable = false;
            this.olvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn4.Hideable = false;
            this.olvColumn4.IsEditable = false;
            this.olvColumn4.MaximumWidth = 118;
            this.olvColumn4.MinimumWidth = 118;
            this.olvColumn4.Searchable = false;
            this.olvColumn4.Text = "Device Status";
            this.olvColumn4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn4.Width = 118;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "Redirected";
            this.olvColumn5.CheckBoxes = true;
            this.olvColumn5.Groupable = false;
            this.olvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn5.Hideable = false;
            this.olvColumn5.MaximumWidth = 80;
            this.olvColumn5.MinimumWidth = 80;
            this.olvColumn5.Searchable = false;
            this.olvColumn5.Text = "Redirect";
            this.olvColumn5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn5.Width = 80;
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "Blocked";
            this.olvColumn6.CheckBoxes = true;
            this.olvColumn6.Groupable = false;
            this.olvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn6.Hideable = false;
            this.olvColumn6.MaximumWidth = 75;
            this.olvColumn6.MinimumWidth = 75;
            this.olvColumn6.Searchable = false;
            this.olvColumn6.Text = "Block";
            this.olvColumn6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn6.Width = 75;
            // 
            // olvColumn8
            // 
            this.olvColumn8.AspectName = "DownloadSpeed";
            this.olvColumn8.Groupable = false;
            this.olvColumn8.Hideable = false;
            this.olvColumn8.IsEditable = false;
            this.olvColumn8.MaximumWidth = 140;
            this.olvColumn8.MinimumWidth = 140;
            this.olvColumn8.Searchable = false;
            this.olvColumn8.Text = "Download Cap";
            this.olvColumn8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn8.Width = 140;
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "UploadSpeed";
            this.olvColumn7.Groupable = false;
            this.olvColumn7.Hideable = false;
            this.olvColumn7.IsEditable = false;
            this.olvColumn7.MaximumWidth = 139;
            this.olvColumn7.MinimumWidth = 139;
            this.olvColumn7.Searchable = false;
            this.olvColumn7.Text = "Upload Cap";
            this.olvColumn7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn7.Width = 139;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BottomPanel.Controls.Add(this.RedirectAllCheck);
            this.BottomPanel.Controls.Add(this.BlockAllCheck);
            this.BottomPanel.Controls.Add(this.Divider1);
            this.BottomPanel.Controls.Add(this.LimiterButton);
            this.BottomPanel.Controls.Add(this.SnifferButton);
            this.BottomPanel.Controls.Add(this.CurrentOperationStatusLabel);
            this.BottomPanel.Controls.Add(this.label4);
            this.BottomPanel.Controls.Add(this.DeviceCountLabel);
            this.BottomPanel.Controls.Add(this.AboutButton);
            this.BottomPanel.Controls.Add(this.FormHelpButton);
            this.BottomPanel.Controls.Add(this.OptionsButton);
            this.BottomPanel.Controls.Add(this.RefreshButton);
            this.BottomPanel.Controls.Add(this.ScanButton);
            this.BottomPanel.Controls.Add(this.LoadingIndicator);
            this.BottomPanel.Controls.Add(this.OpIndicator);
            this.BottomPanel.Controls.Add(this.Divider2);
            this.BottomPanel.Location = new System.Drawing.Point(2, 469);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(2);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(1312, 59);
            this.BottomPanel.TabIndex = 0;
            // 
            // Divider1
            // 
            this.Divider1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Divider1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Divider1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Divider1.Location = new System.Drawing.Point(932, 9);
            this.Divider1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Divider1.Name = "Divider1";
            this.Divider1.Size = new System.Drawing.Size(24, 39);
            this.Divider1.TabIndex = 38;
            this.Divider1.Text = "|";
            this.Divider1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CurrentOperationStatusLabel
            // 
            this.CurrentOperationStatusLabel.AutoSize = true;
            this.CurrentOperationStatusLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentOperationStatusLabel.Location = new System.Drawing.Point(1205, 20);
            this.CurrentOperationStatusLabel.Name = "CurrentOperationStatusLabel";
            this.CurrentOperationStatusLabel.Size = new System.Drawing.Size(55, 20);
            this.CurrentOperationStatusLabel.TabIndex = 35;
            this.CurrentOperationStatusLabel.Text = "READY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(961, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "STATUS:";
            // 
            // DeviceCountLabel
            // 
            this.DeviceCountLabel.AutoSize = true;
            this.DeviceCountLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceCountLabel.Location = new System.Drawing.Point(1026, 20);
            this.DeviceCountLabel.Name = "DeviceCountLabel";
            this.DeviceCountLabel.Size = new System.Drawing.Size(40, 20);
            this.DeviceCountLabel.TabIndex = 33;
            this.DeviceCountLabel.Text = "IDLE";
            // 
            // OpIndicator
            // 
            this.OpIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OpIndicator.Image = global::NetStalker.Properties.Resources.color_ok;
            this.OpIndicator.Location = new System.Drawing.Point(1274, 15);
            this.OpIndicator.Margin = new System.Windows.Forms.Padding(2);
            this.OpIndicator.Name = "OpIndicator";
            this.OpIndicator.Size = new System.Drawing.Size(30, 30);
            this.OpIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OpIndicator.TabIndex = 7;
            this.OpIndicator.TabStop = false;
            // 
            // Divider2
            // 
            this.Divider2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Divider2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Divider2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Divider2.Location = new System.Drawing.Point(1186, 9);
            this.Divider2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Divider2.Name = "Divider2";
            this.Divider2.Size = new System.Drawing.Size(24, 39);
            this.Divider2.TabIndex = 8;
            this.Divider2.Text = "|";
            this.Divider2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.Controls.Add(this.DeviceList);
            this.MainPanel.Controls.Add(this.Separator);
            this.MainPanel.Controls.Add(this.BottomPanel);
            this.MainPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1314, 531);
            this.MainPanel.TabIndex = 2;
            // 
            // Separator
            // 
            this.Separator.BackColor = System.Drawing.Color.DimGray;
            this.Separator.Location = new System.Drawing.Point(3, 465);
            this.Separator.Name = "Separator";
            this.Separator.Size = new System.Drawing.Size(1309, 2);
            this.Separator.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1314, 531);
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetStalker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.DeviceMenu.ResumeLayout(false);
            this.TrayMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LoadingIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceList)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OpIndicator)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.NotifyIcon TrayIcon;
        public BrightIdeasSoftware.HotItemStyle DarkHot;
        public BrightIdeasSoftware.HeaderFormatStyle DarkHeaders;
        public System.Windows.Forms.ImageList IconList;
        public BrightIdeasSoftware.HotItemStyle LightHot;
        public BrightIdeasSoftware.HeaderFormatStyle LightHeaders;
        public System.Windows.Forms.ToolTip Tooltip;
        private System.Windows.Forms.ContextMenuStrip DeviceMenu;
        private System.Windows.Forms.ToolStripMenuItem SetName;
        private System.Windows.Forms.ToolStripMenuItem ClearName;
        public BrightIdeasSoftware.FastObjectListView DeviceList;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn9;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private BrightIdeasSoftware.OLVColumn olvColumn8;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button ScanButton;
        public System.Windows.Forms.PictureBox LoadingIndicator;
        public System.Windows.Forms.PictureBox OpIndicator;
        private System.Windows.Forms.Label Divider2;
        private System.Windows.Forms.FlowLayoutPanel MainPanel;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button OptionsButton;
        private System.Windows.Forms.Button FormHelpButton;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label DeviceCountLabel;
        private System.Windows.Forms.Label CurrentOperationStatusLabel;
        private System.Windows.Forms.Button SnifferButton;
        private System.Windows.Forms.Button LimiterButton;
        private System.Windows.Forms.ImageList ButtonIcons;
        private System.Windows.Forms.Label Divider1;
        private System.Windows.Forms.ContextMenuStrip TrayMenu;
        private System.Windows.Forms.ToolStripMenuItem sHOWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
        private System.Windows.Forms.Label Separator;
        private System.Windows.Forms.CheckBox RedirectAllCheck;
        private System.Windows.Forms.CheckBox BlockAllCheck;
    }
}

