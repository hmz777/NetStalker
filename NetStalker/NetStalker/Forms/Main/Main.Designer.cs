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
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle1 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle2 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle3 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle4 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle5 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle6 = new BrightIdeasSoftware.HeaderStateStyle();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.IconList = new System.Windows.Forms.ImageList(this.components);
            this.DarkHeaders = new BrightIdeasSoftware.HeaderFormatStyle();
            this.DarkHot = new BrightIdeasSoftware.HotItemStyle();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.DeviceCountLabel = new MaterialSkin.Controls.MaterialLabel();
            this.CurrentOperationStatusLabel = new MaterialSkin.Controls.MaterialLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OptionsButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ScanButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.SnifferButton = new MetroFramework.Controls.MetroTile();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LimiterButton = new MetroFramework.Controls.MetroTile();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMenu = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.RefreshButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.AboutButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.FormHelpButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.LightHot = new BrightIdeasSoftware.HotItemStyle();
            this.LightHeaders = new BrightIdeasSoftware.HeaderFormatStyle();
            this.Tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.TrayMenu.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.DeviceList);
            this.panel1.Location = new System.Drawing.Point(3, 64);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 375);
            this.panel1.TabIndex = 0;
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
            this.DeviceList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
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
            this.DeviceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceList.EmptyListMsg = "Device list is empty";
            this.DeviceList.EmptyListMsgFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.DeviceList.FullRowSelect = true;
            this.DeviceList.GroupImageList = this.IconList;
            this.DeviceList.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceList.HeaderFormatStyle = this.DarkHeaders;
            this.DeviceList.HideSelection = false;
            this.DeviceList.HotItemStyle = this.DarkHot;
            this.DeviceList.Location = new System.Drawing.Point(0, 0);
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
            this.DeviceList.Size = new System.Drawing.Size(1057, 375);
            this.DeviceList.SmallImageList = this.IconList;
            this.DeviceList.SpaceBetweenGroups = 1;
            this.DeviceList.TabIndex = 0;
            this.DeviceList.UnfocusedSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.DeviceList.UnfocusedSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.DeviceList.UseCompatibleStateImageBehavior = false;
            this.DeviceList.UseHotItem = true;
            this.DeviceList.UseNotifyPropertyChanged = true;
            this.DeviceList.UseSubItemCheckBoxes = true;
            this.DeviceList.View = System.Windows.Forms.View.Details;
            this.DeviceList.VirtualMode = true;
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
            this.olvColumn1.MaximumWidth = 145;
            this.olvColumn1.MinimumWidth = 145;
            this.olvColumn1.Text = "IP";
            this.olvColumn1.Width = 145;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "MAC";
            this.olvColumn2.Groupable = false;
            this.olvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.Hideable = false;
            this.olvColumn2.IsEditable = false;
            this.olvColumn2.MaximumWidth = 130;
            this.olvColumn2.MinimumWidth = 130;
            this.olvColumn2.Searchable = false;
            this.olvColumn2.Text = "MAC";
            this.olvColumn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.Width = 130;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "DeviceName";
            this.olvColumn3.Groupable = false;
            this.olvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn3.Hideable = false;
            this.olvColumn3.IsEditable = false;
            this.olvColumn3.MaximumWidth = 180;
            this.olvColumn3.MinimumWidth = 180;
            this.olvColumn3.Searchable = false;
            this.olvColumn3.Text = "DeviceName";
            this.olvColumn3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn3.Width = 180;
            // 
            // olvColumn9
            // 
            this.olvColumn9.AspectName = "ManName";
            this.olvColumn9.Groupable = false;
            this.olvColumn9.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn9.Hideable = false;
            this.olvColumn9.IsEditable = false;
            this.olvColumn9.MaximumWidth = 180;
            this.olvColumn9.MinimumWidth = 180;
            this.olvColumn9.Searchable = false;
            this.olvColumn9.Text = "Vendor";
            this.olvColumn9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn9.Width = 180;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "DeviceStatus";
            this.olvColumn4.Groupable = false;
            this.olvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn4.Hideable = false;
            this.olvColumn4.IsEditable = false;
            this.olvColumn4.MaximumWidth = 110;
            this.olvColumn4.MinimumWidth = 110;
            this.olvColumn4.Searchable = false;
            this.olvColumn4.Text = "DeviceStatus";
            this.olvColumn4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn4.Width = 110;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "Redirected";
            this.olvColumn5.CheckBoxes = true;
            this.olvColumn5.Groupable = false;
            this.olvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn5.Hideable = false;
            this.olvColumn5.MaximumWidth = 60;
            this.olvColumn5.MinimumWidth = 60;
            this.olvColumn5.Searchable = false;
            this.olvColumn5.Text = "Redirect";
            this.olvColumn5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "Blocked";
            this.olvColumn6.CheckBoxes = true;
            this.olvColumn6.Groupable = false;
            this.olvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn6.Hideable = false;
            this.olvColumn6.MaximumWidth = 50;
            this.olvColumn6.MinimumWidth = 50;
            this.olvColumn6.Searchable = false;
            this.olvColumn6.Text = "Block";
            this.olvColumn6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn6.Width = 50;
            // 
            // olvColumn8
            // 
            this.olvColumn8.AspectName = "DownloadSpeed";
            this.olvColumn8.Groupable = false;
            this.olvColumn8.Hideable = false;
            this.olvColumn8.IsEditable = false;
            this.olvColumn8.MaximumWidth = 102;
            this.olvColumn8.MinimumWidth = 102;
            this.olvColumn8.Searchable = false;
            this.olvColumn8.Text = "DownloadCap";
            this.olvColumn8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn8.Width = 102;
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "UploadSpeed";
            this.olvColumn7.Groupable = false;
            this.olvColumn7.Hideable = false;
            this.olvColumn7.IsEditable = false;
            this.olvColumn7.MaximumWidth = 100;
            this.olvColumn7.MinimumWidth = 100;
            this.olvColumn7.Searchable = false;
            this.olvColumn7.Text = "UploadCap";
            this.olvColumn7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn7.Width = 100;
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
            headerStateStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            headerStateStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            headerStateStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.DarkHeaders.Hot = headerStateStyle1;
            headerStateStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            headerStateStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            headerStateStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.DarkHeaders.Normal = headerStateStyle2;
            headerStateStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            headerStateStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            headerStateStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.DarkHeaders.Pressed = headerStateStyle3;
            // 
            // DarkHot
            // 
            this.DarkHot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            this.DarkHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DarkHot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(681, 17);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(68, 24);
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "Status:";
            // 
            // DeviceCountLabel
            // 
            this.DeviceCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeviceCountLabel.AutoSize = true;
            this.DeviceCountLabel.Depth = 0;
            this.DeviceCountLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.DeviceCountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DeviceCountLabel.Location = new System.Drawing.Point(743, 17);
            this.DeviceCountLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.DeviceCountLabel.Name = "DeviceCountLabel";
            this.DeviceCountLabel.Size = new System.Drawing.Size(41, 24);
            this.DeviceCountLabel.TabIndex = 5;
            this.DeviceCountLabel.Text = "Idle";
            // 
            // CurrentOperationStatusLabel
            // 
            this.CurrentOperationStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentOperationStatusLabel.AutoSize = true;
            this.CurrentOperationStatusLabel.Depth = 0;
            this.CurrentOperationStatusLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.CurrentOperationStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CurrentOperationStatusLabel.Location = new System.Drawing.Point(973, 17);
            this.CurrentOperationStatusLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.CurrentOperationStatusLabel.Name = "CurrentOperationStatusLabel";
            this.CurrentOperationStatusLabel.Size = new System.Drawing.Size(62, 24);
            this.CurrentOperationStatusLabel.TabIndex = 6;
            this.CurrentOperationStatusLabel.Text = "Ready";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(942, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 46);
            this.label1.TabIndex = 8;
            this.label1.Text = "|";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(650, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 46);
            this.label2.TabIndex = 9;
            this.label2.Text = "|";
            // 
            // OptionsButton
            // 
            this.OptionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OptionsButton.AutoSize = true;
            this.OptionsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OptionsButton.Depth = 0;
            this.OptionsButton.Icon = global::NetStalker.Properties.Resources.color_gear;
            this.OptionsButton.Location = new System.Drawing.Point(195, 9);
            this.OptionsButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.OptionsButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Primary = false;
            this.OptionsButton.Size = new System.Drawing.Size(123, 36);
            this.OptionsButton.TabIndex = 10;
            this.OptionsButton.Text = "Options";
            this.Tooltip.SetToolTip(this.OptionsButton, "Change NetStalker settings");
            this.OptionsButton.UseVisualStyleBackColor = true;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::NetStalker.Properties.Resources.color_ok;
            this.pictureBox1.Location = new System.Drawing.Point(1052, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // ScanButton
            // 
            this.ScanButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ScanButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ScanButton.Depth = 0;
            this.ScanButton.Icon = global::NetStalker.Properties.Resources.color_gps_receiving;
            this.ScanButton.Location = new System.Drawing.Point(10, 9);
            this.ScanButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ScanButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Primary = false;
            this.ScanButton.Size = new System.Drawing.Size(95, 36);
            this.ScanButton.TabIndex = 1;
            this.ScanButton.Text = "Scan";
            this.Tooltip.SetToolTip(this.ScanButton, "Initiate a new device scan");
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // SnifferButton
            // 
            this.SnifferButton.ActiveControl = null;
            this.SnifferButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.SnifferButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.SnifferButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.SnifferButton.Location = new System.Drawing.Point(0, 0);
            this.SnifferButton.Name = "SnifferButton";
            this.SnifferButton.Size = new System.Drawing.Size(29, 187);
            this.SnifferButton.TabIndex = 0;
            this.SnifferButton.Text = "S\r\nN\r\nI\r\nF\r\nF\r\nE\r\nR";
            this.SnifferButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SnifferButton.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.SnifferButton.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.Tooltip.SetToolTip(this.SnifferButton, "Start the Packet Sniffer");
            this.SnifferButton.UseCustomBackColor = true;
            this.SnifferButton.UseSelectable = true;
            this.SnifferButton.Click += new System.EventHandler(this.SnifferButton_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.LimiterButton);
            this.panel2.Controls.Add(this.SnifferButton);
            this.panel2.Location = new System.Drawing.Point(1063, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(29, 375);
            this.panel2.TabIndex = 1;
            // 
            // LimiterButton
            // 
            this.LimiterButton.ActiveControl = null;
            this.LimiterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.LimiterButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LimiterButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.LimiterButton.Location = new System.Drawing.Point(0, 188);
            this.LimiterButton.Name = "LimiterButton";
            this.LimiterButton.Size = new System.Drawing.Size(29, 187);
            this.LimiterButton.TabIndex = 0;
            this.LimiterButton.Text = "L\r\nI\r\nM\r\nI\r\nT\r\nE\r\nR";
            this.LimiterButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.LimiterButton.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.LimiterButton.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.Tooltip.SetToolTip(this.LimiterButton, "Start the Speed Limiter");
            this.LimiterButton.UseCustomBackColor = true;
            this.LimiterButton.UseSelectable = true;
            this.LimiterButton.Click += new System.EventHandler(this.LimiterButton_Click);
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
            this.TrayMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TrayMenu.Depth = 0;
            this.TrayMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.TrayMenu.MouseState = MaterialSkin.MouseState.HOVER;
            this.TrayMenu.Name = "materialContextMenuStrip1";
            this.TrayMenu.Size = new System.Drawing.Size(115, 52);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.RefreshButton);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.AboutButton);
            this.panel3.Controls.Add(this.FormHelpButton);
            this.panel3.Controls.Add(this.materialLabel4);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.CurrentOperationStatusLabel);
            this.panel3.Controls.Add(this.materialLabel1);
            this.panel3.Controls.Add(this.OptionsButton);
            this.panel3.Controls.Add(this.DeviceCountLabel);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.ScanButton);
            this.panel3.Location = new System.Drawing.Point(3, 442);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1086, 56);
            this.panel3.TabIndex = 0;
            // 
            // RefreshButton
            // 
            this.RefreshButton.AutoSize = true;
            this.RefreshButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RefreshButton.Depth = 0;
            this.RefreshButton.Icon = global::NetStalker.Properties.Resources.color_restart;
            this.RefreshButton.Location = new System.Drawing.Point(128, 9);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RefreshButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Primary = false;
            this.RefreshButton.Size = new System.Drawing.Size(44, 36);
            this.RefreshButton.TabIndex = 27;
            this.Tooltip.SetToolTip(this.RefreshButton, resources.GetString("RefreshButton.ToolTip"));
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Location = new System.Drawing.Point(609, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            this.Tooltip.SetToolTip(this.pictureBox2, "Background scanning is active");
            this.pictureBox2.Visible = false;
            // 
            // AboutButton
            // 
            this.AboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AboutButton.AutoSize = true;
            this.AboutButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AboutButton.Depth = 0;
            this.AboutButton.Icon = global::NetStalker.Properties.Resources.color_about;
            this.AboutButton.Location = new System.Drawing.Point(456, 9);
            this.AboutButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AboutButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Primary = false;
            this.AboutButton.Size = new System.Drawing.Size(106, 36);
            this.AboutButton.TabIndex = 25;
            this.AboutButton.Text = "About";
            this.Tooltip.SetToolTip(this.AboutButton, "About the developer");
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // FormHelpButton
            // 
            this.FormHelpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FormHelpButton.AutoSize = true;
            this.FormHelpButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FormHelpButton.Depth = 0;
            this.FormHelpButton.Icon = global::NetStalker.Properties.Resources.color_help;
            this.FormHelpButton.Location = new System.Drawing.Point(341, 9);
            this.FormHelpButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.FormHelpButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.FormHelpButton.Name = "FormHelpButton";
            this.FormHelpButton.Primary = false;
            this.FormHelpButton.Size = new System.Drawing.Size(92, 36);
            this.FormHelpButton.TabIndex = 24;
            this.FormHelpButton.Text = "Help";
            this.Tooltip.SetToolTip(this.FormHelpButton, "A simple guide on how to use this software properly");
            this.FormHelpButton.UseVisualStyleBackColor = true;
            this.FormHelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // materialLabel4
            // 
            this.materialLabel4.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(0, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(1086, 1);
            this.materialLabel4.TabIndex = 23;
            // 
            // LightHot
            // 
            this.LightHot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.LightHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LightHot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            // 
            // LightHeaders
            // 
            headerStateStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            headerStateStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            headerStateStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.LightHeaders.Hot = headerStateStyle4;
            headerStateStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            headerStateStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            headerStateStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.LightHeaders.Normal = headerStateStyle5;
            headerStateStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            headerStateStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LightHeaders.Pressed = headerStateStyle6;
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1092, 500);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetStalker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DeviceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.TrayMenu.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialFlatButton ScanButton;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel DeviceCountLabel;
        private MaterialSkin.Controls.MaterialLabel CurrentOperationStatusLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialFlatButton OptionsButton;
        private MetroFramework.Controls.MetroTile SnifferButton;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.NotifyIcon TrayIcon;
        private MetroFramework.Controls.MetroTile LimiterButton;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        public BrightIdeasSoftware.HotItemStyle DarkHot;
        public BrightIdeasSoftware.FastObjectListView DeviceList;
        public BrightIdeasSoftware.HeaderFormatStyle DarkHeaders;
        public System.Windows.Forms.ImageList IconList;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
        private BrightIdeasSoftware.OLVColumn olvColumn8;
        private MaterialSkin.Controls.MaterialFlatButton FormHelpButton;
        private MaterialSkin.Controls.MaterialFlatButton AboutButton;
        public BrightIdeasSoftware.HotItemStyle LightHot;
        public BrightIdeasSoftware.HeaderFormatStyle LightHeaders;
        public System.Windows.Forms.ToolTip Tooltip;
        private BrightIdeasSoftware.OLVColumn olvColumn9;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialContextMenuStrip TrayMenu;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private MaterialSkin.Controls.MaterialFlatButton RefreshButton;
    }
}

