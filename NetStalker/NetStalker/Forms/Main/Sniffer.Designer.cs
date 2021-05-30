namespace NetStalker
{
    partial class Sniffer
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
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle1 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle2 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle3 = new BrightIdeasSoftware.HeaderStateStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sniffer));
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle4 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle5 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle6 = new BrightIdeasSoftware.HeaderStateStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PacketListView = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DarkHeaders = new BrightIdeasSoftware.HeaderFormatStyle();
            this.DarkHot = new BrightIdeasSoftware.HotItemStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.OptionsButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.FormHelpButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.ExportButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.ClearButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.StartButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.StopButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.FontButton = new MetroFramework.Controls.MetroButton();
            this.ClearViewerButton = new MetroFramework.Controls.MetroButton();
            this.SaveButton = new MetroFramework.Controls.MetroButton();
            this.ExpandButton = new MetroFramework.Controls.MetroButton();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.LightHot = new BrightIdeasSoftware.HotItemStyle();
            this.LightHeaders = new BrightIdeasSoftware.HeaderFormatStyle();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PacketListView)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.PacketListView);
            this.panel1.Location = new System.Drawing.Point(1, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 328);
            this.panel1.TabIndex = 1;
            // 
            // PacketListView
            // 
            this.PacketListView.AllColumns.Add(this.olvColumn1);
            this.PacketListView.AllColumns.Add(this.olvColumn2);
            this.PacketListView.AllColumns.Add(this.olvColumn3);
            this.PacketListView.AllColumns.Add(this.olvColumn7);
            this.PacketListView.AllColumns.Add(this.olvColumn4);
            this.PacketListView.AllColumns.Add(this.olvColumn6);
            this.PacketListView.AllColumns.Add(this.olvColumn8);
            this.PacketListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PacketListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.PacketListView.CellEditUseWholeCell = false;
            this.PacketListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn7,
            this.olvColumn4,
            this.olvColumn6,
            this.olvColumn8});
            this.PacketListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.PacketListView.EmptyListMsg = "Packet list is empty";
            this.PacketListView.EmptyListMsgFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PacketListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PacketListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.PacketListView.FullRowSelect = true;
            this.PacketListView.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PacketListView.HeaderFormatStyle = this.DarkHeaders;
            this.PacketListView.HideSelection = false;
            this.PacketListView.HotItemStyle = this.DarkHot;
            this.PacketListView.Location = new System.Drawing.Point(0, 0);
            this.PacketListView.MultiSelect = false;
            this.PacketListView.Name = "PacketListView";
            this.PacketListView.SelectAllOnControlA = false;
            this.PacketListView.SelectColumnsMenuStaysOpen = false;
            this.PacketListView.SelectColumnsOnRightClick = false;
            this.PacketListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.PacketListView.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.PacketListView.SelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.PacketListView.ShowFilterMenuOnRightClick = false;
            this.PacketListView.ShowGroups = false;
            this.PacketListView.ShowSortIndicators = false;
            this.PacketListView.Size = new System.Drawing.Size(748, 328);
            this.PacketListView.SmallImageList = this.imageList1;
            this.PacketListView.TabIndex = 0;
            this.PacketListView.UnfocusedSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.PacketListView.UnfocusedSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.PacketListView.UseCompatibleStateImageBehavior = false;
            this.PacketListView.UseHotItem = true;
            this.PacketListView.View = System.Windows.Forms.View.Details;
            this.PacketListView.VirtualMode = true;
            this.PacketListView.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.PacketListView_ButtonClick);
            this.PacketListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PacketListView_MouseDown);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Source";
            this.olvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.olvColumn1.IsEditable = false;
            this.olvColumn1.MaximumWidth = 135;
            this.olvColumn1.MinimumWidth = 135;
            this.olvColumn1.Text = "Source";
            this.olvColumn1.Width = 135;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Destination";
            this.olvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.IsEditable = false;
            this.olvColumn2.MaximumWidth = 125;
            this.olvColumn2.MinimumWidth = 125;
            this.olvColumn2.Text = "Destination";
            this.olvColumn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.Width = 125;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Host";
            this.olvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.olvColumn3.IsEditable = false;
            this.olvColumn3.MaximumWidth = 245;
            this.olvColumn3.MinimumWidth = 245;
            this.olvColumn3.Text = "Host";
            this.olvColumn3.Width = 245;
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "Resolve";
            this.olvColumn7.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.olvColumn7.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn7.IsButton = true;
            this.olvColumn7.IsEditable = false;
            this.olvColumn7.MaximumWidth = 80;
            this.olvColumn7.MinimumWidth = 80;
            this.olvColumn7.Text = "Resolve";
            this.olvColumn7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn7.Width = 80;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "Type";
            this.olvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn4.IsEditable = false;
            this.olvColumn4.MaximumWidth = 77;
            this.olvColumn4.MinimumWidth = 77;
            this.olvColumn4.Text = "Type";
            this.olvColumn4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn4.Width = 77;
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "ID";
            this.olvColumn6.IsEditable = false;
            this.olvColumn6.MaximumWidth = 0;
            this.olvColumn6.MinimumWidth = 0;
            this.olvColumn6.Text = "ID";
            this.olvColumn6.Width = 0;
            // 
            // olvColumn8
            // 
            this.olvColumn8.AspectName = "Protocol";
            this.olvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn8.IsEditable = false;
            this.olvColumn8.MaximumWidth = 82;
            this.olvColumn8.MinimumWidth = 82;
            this.olvColumn8.Text = "Protocol";
            this.olvColumn8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn8.Width = 82;
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "response");
            this.imageList1.Images.SetKeyName(1, "request");
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "ID";
            this.olvColumn5.DisplayIndex = 4;
            this.olvColumn5.IsVisible = false;
            this.olvColumn5.Text = "ID";
            this.olvColumn5.Width = 1;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.OptionsButton);
            this.panel2.Controls.Add(this.materialLabel2);
            this.panel2.Controls.Add(this.materialLabel1);
            this.panel2.Controls.Add(this.FormHelpButton);
            this.panel2.Controls.Add(this.ExportButton);
            this.panel2.Controls.Add(this.ClearButton);
            this.panel2.Controls.Add(this.materialLabel3);
            this.panel2.Controls.Add(this.StartButton);
            this.panel2.Controls.Add(this.StopButton);
            this.panel2.Location = new System.Drawing.Point(755, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(119, 328);
            this.panel2.TabIndex = 1;
            // 
            // OptionsButton
            // 
            this.OptionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsButton.AutoSize = true;
            this.OptionsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OptionsButton.Depth = 0;
            this.OptionsButton.Icon = global::NetStalker.Properties.Resources.color_gear;
            this.OptionsButton.Location = new System.Drawing.Point(6, 175);
            this.OptionsButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.OptionsButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Primary = false;
            this.OptionsButton.Size = new System.Drawing.Size(107, 36);
            this.OptionsButton.TabIndex = 42;
            this.OptionsButton.Text = "Options";
            this.OptionsButton.UseVisualStyleBackColor = true;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.BackColor = System.Drawing.Color.Black;
            this.materialLabel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(1, 327);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(118, 1);
            this.materialLabel2.TabIndex = 41;
            // 
            // materialLabel1
            // 
            this.materialLabel1.BackColor = System.Drawing.Color.Black;
            this.materialLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(1, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(118, 1);
            this.materialLabel1.TabIndex = 40;
            // 
            // FormHelpButton
            // 
            this.FormHelpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FormHelpButton.AutoSize = true;
            this.FormHelpButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FormHelpButton.Depth = 0;
            this.FormHelpButton.Icon = global::NetStalker.Properties.Resources.color_help;
            this.FormHelpButton.Location = new System.Drawing.Point(18, 227);
            this.FormHelpButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.FormHelpButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.FormHelpButton.Name = "FormHelpButton";
            this.FormHelpButton.Primary = false;
            this.FormHelpButton.Size = new System.Drawing.Size(83, 36);
            this.FormHelpButton.TabIndex = 39;
            this.FormHelpButton.Text = "Help";
            this.FormHelpButton.UseVisualStyleBackColor = true;
            this.FormHelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportButton.AutoSize = true;
            this.ExportButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExportButton.Depth = 0;
            this.ExportButton.Icon = global::NetStalker.Properties.Resources.color_external;
            this.ExportButton.Location = new System.Drawing.Point(9, 123);
            this.ExportButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ExportButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Primary = false;
            this.ExportButton.Size = new System.Drawing.Size(101, 36);
            this.ExportButton.TabIndex = 2;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.AutoSize = true;
            this.ClearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClearButton.Depth = 0;
            this.ClearButton.Icon = global::NetStalker.Properties.Resources.color_clear_symbol;
            this.ClearButton.Location = new System.Drawing.Point(14, 71);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ClearButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Primary = false;
            this.ClearButton.Size = new System.Drawing.Size(91, 36);
            this.ClearButton.TabIndex = 38;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.BackColor = System.Drawing.Color.Black;
            this.materialLabel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(0, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(1, 328);
            this.materialLabel3.TabIndex = 23;
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.AutoSize = true;
            this.StartButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StartButton.Depth = 0;
            this.StartButton.Icon = global::NetStalker.Properties.Resources.color_start;
            this.StartButton.Location = new System.Drawing.Point(13, 19);
            this.StartButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.StartButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.StartButton.Name = "StartButton";
            this.StartButton.Primary = false;
            this.StartButton.Size = new System.Drawing.Size(92, 36);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StopButton.AutoSize = true;
            this.StopButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StopButton.Depth = 0;
            this.StopButton.Icon = global::NetStalker.Properties.Resources.color_stop_squared;
            this.StopButton.Location = new System.Drawing.Point(17, 279);
            this.StopButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.StopButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.StopButton.Name = "StopButton";
            this.StopButton.Primary = false;
            this.StopButton.Size = new System.Drawing.Size(84, 36);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.metroTextBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(648, 103);
            this.panel3.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.FontButton);
            this.panel6.Controls.Add(this.ClearViewerButton);
            this.panel6.Controls.Add(this.SaveButton);
            this.panel6.Controls.Add(this.ExpandButton);
            this.panel6.Location = new System.Drawing.Point(622, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(26, 103);
            this.panel6.TabIndex = 1;
            // 
            // FontButton
            // 
            this.FontButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FontButton.BackgroundImage")));
            this.FontButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FontButton.Location = new System.Drawing.Point(3, 53);
            this.FontButton.Name = "FontButton";
            this.FontButton.Size = new System.Drawing.Size(20, 20);
            this.FontButton.TabIndex = 43;
            this.metroToolTip1.SetToolTip(this.FontButton, "Change font size");
            this.FontButton.UseSelectable = true;
            this.FontButton.Click += new System.EventHandler(this.FontButton_Click);
            // 
            // ClearViewerButton
            // 
            this.ClearViewerButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ClearViewerButton.BackgroundImage")));
            this.ClearViewerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClearViewerButton.Location = new System.Drawing.Point(3, 78);
            this.ClearViewerButton.Name = "ClearViewerButton";
            this.ClearViewerButton.Size = new System.Drawing.Size(20, 20);
            this.ClearViewerButton.TabIndex = 1;
            this.metroToolTip1.SetToolTip(this.ClearViewerButton, "Clear the packet viewer");
            this.ClearViewerButton.UseSelectable = true;
            this.ClearViewerButton.Click += new System.EventHandler(this.ClearViewerButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveButton.BackgroundImage")));
            this.SaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveButton.Location = new System.Drawing.Point(3, 28);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(20, 20);
            this.SaveButton.TabIndex = 41;
            this.metroToolTip1.SetToolTip(this.SaveButton, "Save packet");
            this.SaveButton.UseSelectable = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ExpandButton
            // 
            this.ExpandButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ExpandButton.BackgroundImage")));
            this.ExpandButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ExpandButton.Location = new System.Drawing.Point(3, 3);
            this.ExpandButton.Name = "ExpandButton";
            this.ExpandButton.Size = new System.Drawing.Size(20, 20);
            this.ExpandButton.TabIndex = 42;
            this.metroToolTip1.SetToolTip(this.ExpandButton, "Extend the packet viewer");
            this.ExpandButton.UseSelectable = true;
            this.ExpandButton.Click += new System.EventHandler(this.ExpandButton_Click);
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.AutoSize = true;
            this.metroTextBox1.CustomButton.BackColor = System.Drawing.Color.DarkRed;
            this.metroTextBox1.CustomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.metroTextBox1.CustomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTextBox1.CustomButton.ForeColor = System.Drawing.Color.White;
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(514, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(101, 101);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Text = "Button";
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.UseVisualStyleBackColor = false;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(0, 0);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Multiline = true;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.PromptText = "Packet Viewer";
            this.metroTextBox1.ReadOnly = true;
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(616, 103);
            this.metroTextBox1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroTextBox1.TabIndex = 40;
            this.metroTextBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMark = "Packet Viewer";
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Location = new System.Drawing.Point(1, 398);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(873, 103);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.metroTextBox2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(654, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(219, 103);
            this.panel5.TabIndex = 3;
            // 
            // metroTextBox2
            // 
            this.metroTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            // 
            // 
            // 
            this.metroTextBox2.CustomButton.Image = null;
            this.metroTextBox2.CustomButton.Location = new System.Drawing.Point(117, 1);
            this.metroTextBox2.CustomButton.Name = "";
            this.metroTextBox2.CustomButton.Size = new System.Drawing.Size(101, 101);
            this.metroTextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox2.CustomButton.TabIndex = 1;
            this.metroTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox2.CustomButton.UseSelectable = true;
            this.metroTextBox2.CustomButton.Visible = false;
            this.metroTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.metroTextBox2.Lines = new string[0];
            this.metroTextBox2.Location = new System.Drawing.Point(0, 0);
            this.metroTextBox2.MaxLength = 32767;
            this.metroTextBox2.Multiline = true;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.PasswordChar = '\0';
            this.metroTextBox2.PromptText = "Status";
            this.metroTextBox2.ReadOnly = true;
            this.metroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.metroTextBox2.SelectedText = "";
            this.metroTextBox2.SelectionLength = 0;
            this.metroTextBox2.SelectionStart = 0;
            this.metroTextBox2.ShortcutsEnabled = true;
            this.metroTextBox2.ShowClearButton = true;
            this.metroTextBox2.Size = new System.Drawing.Size(219, 103);
            this.metroTextBox2.Style = MetroFramework.MetroColorStyle.Black;
            this.metroTextBox2.TabIndex = 41;
            this.metroTextBox2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox2.UseSelectable = true;
            this.metroTextBox2.WaterMark = "Status";
            this.metroTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Dark;
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
            // Sniffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 504);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Sniffer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Packet Sniffer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Sniffer_FormClosing);
            this.Load += new System.EventHandler(this.Sniffer_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PacketListView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialFlatButton ExportButton;
        private MaterialSkin.Controls.MaterialFlatButton StopButton;
        private MaterialSkin.Controls.MaterialFlatButton StartButton;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.Panel panel3;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MaterialSkin.Controls.MaterialFlatButton ClearButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private MetroFramework.Controls.MetroTextBox metroTextBox2;
        private BrightIdeasSoftware.HeaderFormatStyle DarkHeaders;
        public BrightIdeasSoftware.HotItemStyle DarkHot;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.FastObjectListView PacketListView;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private MaterialSkin.Controls.MaterialFlatButton FormHelpButton;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
        private MetroFramework.Controls.MetroButton ClearViewerButton;
        private MetroFramework.Controls.MetroButton SaveButton;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroButton ExpandButton;
        private System.Windows.Forms.Panel panel6;
        private MetroFramework.Controls.MetroButton FontButton;
        private System.Windows.Forms.ImageList imageList1;
        private MaterialSkin.Controls.MaterialFlatButton OptionsButton;
        private BrightIdeasSoftware.OLVColumn olvColumn8;
        public BrightIdeasSoftware.HotItemStyle LightHot;
        public BrightIdeasSoftware.HeaderFormatStyle LightHeaders;
    }
}