namespace CrapFixer
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Windows = new System.Windows.Forms.TabPage();
            this.treeFeatures = new System.Windows.Forms.TreeView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.analyzeMarkedFeatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewMarkedFeatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fixMarkedFeatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seperatorToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.restoreMarkedFeatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMarkedFeatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Apps = new System.Windows.Forms.TabPage();
            this.checkedListBoxApps = new System.Windows.Forms.CheckedListBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.comboLogActions = new System.Windows.Forms.ComboBox();
            this.rtbLogger = new System.Windows.Forms.RichTextBox();
            this.btnFix = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblOSInfo = new System.Windows.Forms.Label();
            this.lblVersionInfo = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pictureHeader = new System.Windows.Forms.PictureBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.linkUpdateCheck = new System.Windows.Forms.LinkLabel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.linkSelection = new System.Windows.Forms.LinkLabel();
            this.panelContainer.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.Windows.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.Apps.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainer.BackColor = System.Drawing.SystemColors.Control;
            this.panelContainer.Controls.Add(this.panelContent);
            this.panelContainer.Location = new System.Drawing.Point(99, 62);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(611, 382);
            this.panelContainer.TabIndex = 198;
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panelContent.Controls.Add(this.btnAnalyze);
            this.panelContent.Controls.Add(this.tabControl);
            this.panelContent.Controls.Add(this.groupBox);
            this.panelContent.Controls.Add(this.btnFix);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(611, 382);
            this.panelContent.TabIndex = 205;
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnalyze.AutoEllipsis = true;
            this.btnAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAnalyze.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalyze.Location = new System.Drawing.Point(280, 346);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(121, 29);
            this.btnAnalyze.TabIndex = 1;
            this.btnAnalyze.Text = "&Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = false;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl.Controls.Add(this.Windows);
            this.tabControl.Controls.Add(this.Apps);
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(20, 8);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.ShowToolTips = true;
            this.tabControl.Size = new System.Drawing.Size(270, 376);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 199;
            // 
            // Windows
            // 
            this.Windows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Windows.Controls.Add(this.treeFeatures);
            this.Windows.Location = new System.Drawing.Point(4, 32);
            this.Windows.Name = "Windows";
            this.Windows.Padding = new System.Windows.Forms.Padding(3);
            this.Windows.Size = new System.Drawing.Size(262, 340);
            this.Windows.TabIndex = 0;
            this.Windows.Text = "Windows";
            // 
            // treeFeatures
            // 
            this.treeFeatures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.treeFeatures.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeFeatures.CheckBoxes = true;
            this.treeFeatures.ContextMenuStrip = this.contextMenuStrip;
            this.treeFeatures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFeatures.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeFeatures.Indent = 20;
            this.treeFeatures.ItemHeight = 23;
            this.treeFeatures.Location = new System.Drawing.Point(3, 3);
            this.treeFeatures.Name = "treeFeatures";
            this.treeFeatures.ShowLines = false;
            this.treeFeatures.ShowNodeToolTips = true;
            this.treeFeatures.ShowPlusMinus = false;
            this.treeFeatures.ShowRootLines = false;
            this.treeFeatures.Size = new System.Drawing.Size(256, 334);
            this.treeFeatures.TabIndex = 196;
            this.treeFeatures.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeFeatures_AfterCheck);
            this.treeFeatures.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeFeatures_MouseDown);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analyzeMarkedFeatureToolStripMenuItem,
            this.previewMarkedFeatureToolStripMenuItem,
            this.fixMarkedFeatureToolStripMenuItem,
            this.seperatorToolStripMenuItem,
            this.restoreMarkedFeatureToolStripMenuItem,
            this.helpMarkedFeatureToolStripMenuItem});
            this.contextMenuStrip.Name = "contextManualMenu";
            this.contextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip.Size = new System.Drawing.Size(119, 120);
            // 
            // analyzeMarkedFeatureToolStripMenuItem
            // 
            this.analyzeMarkedFeatureToolStripMenuItem.Name = "analyzeMarkedFeatureToolStripMenuItem";
            this.analyzeMarkedFeatureToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.analyzeMarkedFeatureToolStripMenuItem.Text = "Analyze";
            this.analyzeMarkedFeatureToolStripMenuItem.Click += new System.EventHandler(this.analyzeMarkedFeatureToolStripMenuItem_Click);
            // 
            // previewMarkedFeatureToolStripMenuItem
            // 
            this.previewMarkedFeatureToolStripMenuItem.Name = "previewMarkedFeatureToolStripMenuItem";
            this.previewMarkedFeatureToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.previewMarkedFeatureToolStripMenuItem.Text = "Preview";
            this.previewMarkedFeatureToolStripMenuItem.Click += new System.EventHandler(this.previewMarkedFeatureToolStripMenuItem_Click);
            // 
            // fixMarkedFeatureToolStripMenuItem
            // 
            this.fixMarkedFeatureToolStripMenuItem.Name = "fixMarkedFeatureToolStripMenuItem";
            this.fixMarkedFeatureToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.fixMarkedFeatureToolStripMenuItem.Text = "Fix";
            this.fixMarkedFeatureToolStripMenuItem.Click += new System.EventHandler(this.fixMarkedFeatureToolStripMenuItem_Click);
            // 
            // seperatorToolStripMenuItem
            // 
            this.seperatorToolStripMenuItem.Name = "seperatorToolStripMenuItem";
            this.seperatorToolStripMenuItem.Size = new System.Drawing.Size(115, 6);
            // 
            // restoreMarkedFeatureToolStripMenuItem
            // 
            this.restoreMarkedFeatureToolStripMenuItem.Name = "restoreMarkedFeatureToolStripMenuItem";
            this.restoreMarkedFeatureToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.restoreMarkedFeatureToolStripMenuItem.Text = "Restore";
            this.restoreMarkedFeatureToolStripMenuItem.Click += new System.EventHandler(this.restoreMarkedFeatureToolStripMenuItem_Click);
            // 
            // helpMarkedFeatureToolStripMenuItem
            // 
            this.helpMarkedFeatureToolStripMenuItem.Name = "helpMarkedFeatureToolStripMenuItem";
            this.helpMarkedFeatureToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpMarkedFeatureToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.helpMarkedFeatureToolStripMenuItem.Text = "Help";
            this.helpMarkedFeatureToolStripMenuItem.Click += new System.EventHandler(this.helpMarkedFeatureToolStripMenuItem_Click);
            // 
            // Apps
            // 
            this.Apps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.Apps.Controls.Add(this.checkedListBoxApps);
            this.Apps.Location = new System.Drawing.Point(4, 32);
            this.Apps.Name = "Apps";
            this.Apps.Padding = new System.Windows.Forms.Padding(3);
            this.Apps.Size = new System.Drawing.Size(262, 340);
            this.Apps.TabIndex = 1;
            this.Apps.Text = "Apps";
            // 
            // checkedListBoxApps
            // 
            this.checkedListBoxApps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.checkedListBoxApps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxApps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxApps.Font = new System.Drawing.Font("Tahoma", 8F);
            this.checkedListBoxApps.FormattingEnabled = true;
            this.checkedListBoxApps.Items.AddRange(new object[] {
            "No analysis yet"});
            this.checkedListBoxApps.Location = new System.Drawing.Point(3, 3);
            this.checkedListBoxApps.Name = "checkedListBoxApps";
            this.checkedListBoxApps.Size = new System.Drawing.Size(256, 334);
            this.checkedListBoxApps.Sorted = true;
            this.checkedListBoxApps.TabIndex = 336;
            this.checkedListBoxApps.ThreeDCheckBoxes = true;
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.groupBox.Controls.Add(this.comboLogActions);
            this.groupBox.Controls.Add(this.rtbLogger);
            this.groupBox.Location = new System.Drawing.Point(280, 21);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(320, 317);
            this.groupBox.TabIndex = 200;
            this.groupBox.TabStop = false;
            // 
            // comboLogActions
            // 
            this.comboLogActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboLogActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLogActions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboLogActions.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.comboLogActions.FormattingEnabled = true;
            this.comboLogActions.Location = new System.Drawing.Point(7, 292);
            this.comboLogActions.Name = "comboLogActions";
            this.comboLogActions.Size = new System.Drawing.Size(305, 21);
            this.comboLogActions.TabIndex = 210;
            this.comboLogActions.Visible = false;
            // 
            // rtbLogger
            // 
            this.rtbLogger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLogger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.rtbLogger.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLogger.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLogger.Location = new System.Drawing.Point(7, 12);
            this.rtbLogger.Name = "rtbLogger";
            this.rtbLogger.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbLogger.Size = new System.Drawing.Size(305, 273);
            this.rtbLogger.TabIndex = 195;
            this.rtbLogger.Text = "";
            // 
            // btnFix
            // 
            this.btnFix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFix.AutoEllipsis = true;
            this.btnFix.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFix.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFix.Location = new System.Drawing.Point(480, 346);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(121, 29);
            this.btnFix.TabIndex = 2;
            this.btnFix.Text = "Run &Fixer";
            this.btnFix.UseVisualStyleBackColor = false;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.panelHeader.Controls.Add(this.lblOSInfo);
            this.panelHeader.Controls.Add(this.lblVersionInfo);
            this.panelHeader.Controls.Add(this.lblHeader);
            this.panelHeader.Controls.Add(this.pictureHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(710, 61);
            this.panelHeader.TabIndex = 204;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // lblOSInfo
            // 
            this.lblOSInfo.AutoSize = true;
            this.lblOSInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblOSInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblOSInfo.Location = new System.Drawing.Point(90, 37);
            this.lblOSInfo.Name = "lblOSInfo";
            this.lblOSInfo.Size = new System.Drawing.Size(116, 13);
            this.lblOSInfo.TabIndex = 200;
            this.lblOSInfo.Text = "Checking your system..";
            // 
            // lblVersionInfo
            // 
            this.lblVersionInfo.AutoSize = true;
            this.lblVersionInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.lblVersionInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblVersionInfo.Location = new System.Drawing.Point(198, 15);
            this.lblVersionInfo.Name = "lblVersionInfo";
            this.lblVersionInfo.Size = new System.Drawing.Size(13, 13);
            this.lblVersionInfo.TabIndex = 2;
            this.lblVersionInfo.Text = "v";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoEllipsis = true;
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(89, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(117, 25);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "CrapFixer";
            this.lblHeader.UseCompatibleTextRendering = true;
            // 
            // pictureHeader
            // 
            this.pictureHeader.Image = ((System.Drawing.Image)(resources.GetObject("pictureHeader.Image")));
            this.pictureHeader.Location = new System.Drawing.Point(30, 9);
            this.pictureHeader.Name = "pictureHeader";
            this.pictureHeader.Size = new System.Drawing.Size(44, 41);
            this.pictureHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureHeader.TabIndex = 0;
            this.pictureHeader.TabStop = false;
            // 
            // btnRestore
            // 
            this.btnRestore.AutoEllipsis = true;
            this.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestore.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Location = new System.Drawing.Point(0, 129);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(99, 69);
            this.btnRestore.TabIndex = 198;
            this.btnRestore.TabStop = false;
            this.btnRestore.Text = "&Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // linkUpdateCheck
            // 
            this.linkUpdateCheck.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkUpdateCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkUpdateCheck.AutoEllipsis = true;
            this.linkUpdateCheck.AutoSize = true;
            this.linkUpdateCheck.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkUpdateCheck.LinkColor = System.Drawing.Color.White;
            this.linkUpdateCheck.Location = new System.Drawing.Point(595, 447);
            this.linkUpdateCheck.Name = "linkUpdateCheck";
            this.linkUpdateCheck.Size = new System.Drawing.Size(95, 13);
            this.linkUpdateCheck.TabIndex = 203;
            this.linkUpdateCheck.TabStop = true;
            this.linkUpdateCheck.Text = "Check for updates";
            this.linkUpdateCheck.TextAlign = System.Drawing.ContentAlignment.TopCenter;  
            // 
            // btnSettings
            // 
            this.btnSettings.AutoEllipsis = true;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(0, 197);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(99, 69);
            this.btnSettings.TabIndex = 205;
            this.btnSettings.TabStop = false;
            this.btnSettings.Text = "&Options";
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            this.btnHome.AutoEllipsis = true;
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(235)))));
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(131)))), ((int)(((byte)(222)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Location = new System.Drawing.Point(0, 61);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(99, 69);
            this.btnHome.TabIndex = 206;
            this.btnHome.TabStop = false;
            this.btnHome.Text = "&Fixer";
            this.btnHome.UseVisualStyleBackColor = false;
            // 
            // linkSelection
            // 
            this.linkSelection.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkSelection.AutoEllipsis = true;
            this.linkSelection.AutoSize = true;
            this.linkSelection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkSelection.LinkColor = System.Drawing.Color.White;
            this.linkSelection.Location = new System.Drawing.Point(10, 447);
            this.linkSelection.Name = "linkSelection";
            this.linkSelection.Size = new System.Drawing.Size(49, 13);
            this.linkSelection.TabIndex = 207;
            this.linkSelection.TabStop = true;
            this.linkSelection.Text = "Select all";
            this.linkSelection.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkSelection.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelection_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(710, 466);
            this.Controls.Add(this.linkSelection);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.linkUpdateCheck);
            this.Controls.Add(this.panelContainer);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CrapFixer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.panelContainer.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.Windows.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.Apps.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fixMarkedFeatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analyzeMarkedFeatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreMarkedFeatureToolStripMenuItem;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage Windows;
        private System.Windows.Forms.TabPage Apps;
        private System.Windows.Forms.GroupBox groupBox;
        public System.Windows.Forms.RichTextBox rtbLogger;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureHeader;
        private System.Windows.Forms.Label lblVersionInfo;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.CheckedListBox checkedListBoxApps;
        private System.Windows.Forms.ToolStripSeparator seperatorToolStripMenuItem;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.LinkLabel linkUpdateCheck;
        private System.Windows.Forms.ToolStripMenuItem helpMarkedFeatureToolStripMenuItem;
        private System.Windows.Forms.TreeView treeFeatures;
        private System.Windows.Forms.Label lblOSInfo;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.LinkLabel linkSelection;
        private System.Windows.Forms.ToolStripMenuItem previewMarkedFeatureToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboLogActions;
    }
}

