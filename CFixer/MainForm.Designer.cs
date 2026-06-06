using System.Drawing;
using System.Windows.Forms;

namespace CrapFixer
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.btnSaveLog = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Windows = new System.Windows.Forms.TabPage();
            this.treeFeatures = new System.Windows.Forms.TreeView();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.analyzeMarkedFeatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fixMarkedFeatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreMarkedFeatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seperatorToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.helpMarkedFeatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Apps = new System.Windows.Forms.TabPage();
            this.checkedListBoxApps = new System.Windows.Forms.CheckedListBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.rtbLogger = new System.Windows.Forms.RichTextBox();
            this.btnFix = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnGitHub = new System.Windows.Forms.Button();
            this.linkUpdateCheck = new System.Windows.Forms.LinkLabel();
            this.lblVersionInfo = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pictureHeader = new System.Windows.Forms.PictureBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.linkSelection = new System.Windows.Forms.LinkLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelContainer.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.Windows.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.Apps.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHeader)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.White;
            this.panelContainer.Controls.Add(this.panelContent);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 77);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(613, 353);
            this.panelContainer.TabIndex = 206;
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.btnSaveLog);
            this.panelContent.Controls.Add(this.progressBar);
            this.panelContent.Controls.Add(this.btnAnalyze);
            this.panelContent.Controls.Add(this.tabControl);
            this.panelContent.Controls.Add(this.groupBox);
            this.panelContent.Controls.Add(this.btnFix);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(613, 353);
            this.panelContent.TabIndex = 205;
            // 
            // btnSaveLog
            //
            this.btnSaveLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveLog.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSaveLog.Location = new System.Drawing.Point(522, 285);
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(77, 23);
            this.btnSaveLog.TabIndex = 207;
            this.btnSaveLog.Text = "Save Log";
            this.btnSaveLog.UseVisualStyleBackColor = true;
            this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
            //
            // progressBar
            //
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar.Location = new System.Drawing.Point(12, 343);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(250, 5);
            this.progressBar.TabIndex = 206;
            this.progressBar.Visible = false;
            //
            // btnAnalyze
            // 
            this.btnAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnalyze.AutoEllipsis = true;
            this.btnAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAnalyze.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalyze.Location = new System.Drawing.Point(268, 317);
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
            this.tabControl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(12, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(250, 301);
            this.tabControl.TabIndex = 204;
            // 
            // Windows
            // 
            this.Windows.Controls.Add(this.treeFeatures);
            this.Windows.Controls.Add(this.panelSearch);
            this.Windows.Location = new System.Drawing.Point(4, 22);
            this.Windows.Name = "Windows";
            this.Windows.Padding = new System.Windows.Forms.Padding(3);
            this.Windows.Size = new System.Drawing.Size(242, 275);
            this.Windows.TabIndex = 0;
            this.Windows.Text = "Settings";
            this.Windows.UseVisualStyleBackColor = true;
            // 
            // treeFeatures
            // 
            this.treeFeatures.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeFeatures.CheckBoxes = true;
            this.treeFeatures.ContextMenuStrip = this.contextMenuStrip;
            this.treeFeatures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFeatures.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeFeatures.Location = new System.Drawing.Point(3, 29);
            this.treeFeatures.Name = "treeFeatures";
            this.treeFeatures.ShowLines = false;
            this.treeFeatures.ShowPlusMinus = false;
            this.treeFeatures.ShowRootLines = false;
            this.treeFeatures.Size = new System.Drawing.Size(236, 243);
            this.treeFeatures.TabIndex = 205;
            this.treeFeatures.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeFeatures_AfterCheck);
            this.treeFeatures.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeFeatures_MouseDown);
            // 
            // panelSearch
            //
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(3, 3);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(236, 26);
            this.panelSearch.TabIndex = 206;
            //
            // txtSearch
            //
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(236, 21);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Search settings...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            //
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analyzeMarkedFeatureToolStripMenuItem,
            this.fixMarkedFeatureToolStripMenuItem,
            this.restoreMarkedFeatureToolStripMenuItem,
            this.seperatorToolStripMenuItem,
            this.helpMarkedFeatureToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(117, 98);
            // 
            // analyzeMarkedFeatureToolStripMenuItem
            // 
            this.analyzeMarkedFeatureToolStripMenuItem.Name = "analyzeMarkedFeatureToolStripMenuItem";
            this.analyzeMarkedFeatureToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.analyzeMarkedFeatureToolStripMenuItem.Text = "Analyze";
            this.analyzeMarkedFeatureToolStripMenuItem.Click += new System.EventHandler(this.analyzeMarkedFeatureToolStripMenuItem_Click);
            // 
            // fixMarkedFeatureToolStripMenuItem
            // 
            this.fixMarkedFeatureToolStripMenuItem.Name = "fixMarkedFeatureToolStripMenuItem";
            this.fixMarkedFeatureToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.fixMarkedFeatureToolStripMenuItem.Text = "Fix";
            this.fixMarkedFeatureToolStripMenuItem.Click += new System.EventHandler(this.fixMarkedFeatureToolStripMenuItem_Click);
            // 
            // restoreMarkedFeatureToolStripMenuItem
            // 
            this.restoreMarkedFeatureToolStripMenuItem.Name = "restoreMarkedFeatureToolStripMenuItem";
            this.restoreMarkedFeatureToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.restoreMarkedFeatureToolStripMenuItem.Text = "Restore";
            this.restoreMarkedFeatureToolStripMenuItem.Click += new System.EventHandler(this.restoreMarkedFeatureToolStripMenuItem_Click);
            // 
            // seperatorToolStripMenuItem
            // 
            this.seperatorToolStripMenuItem.Name = "seperatorToolStripMenuItem";
            this.seperatorToolStripMenuItem.Size = new System.Drawing.Size(113, 6);
            // 
            // helpMarkedFeatureToolStripMenuItem
            // 
            this.helpMarkedFeatureToolStripMenuItem.Name = "helpMarkedFeatureToolStripMenuItem";
            this.helpMarkedFeatureToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.helpMarkedFeatureToolStripMenuItem.Text = "Help";
            this.helpMarkedFeatureToolStripMenuItem.Click += new System.EventHandler(this.helpMarkedFeatureToolStripMenuItem_Click);
            // 
            // Apps
            // 
            this.Apps.Controls.Add(this.checkedListBoxApps);
            this.Apps.Location = new System.Drawing.Point(4, 22);
            this.Apps.Name = "Apps";
            this.Apps.Padding = new System.Windows.Forms.Padding(3);
            this.Apps.Size = new System.Drawing.Size(242, 275);
            this.Apps.TabIndex = 1;
            this.Apps.Text = "Apps";
            this.Apps.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxApps
            // 
            this.checkedListBoxApps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxApps.CheckOnClick = true;
            this.checkedListBoxApps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxApps.FormattingEnabled = true;
            this.checkedListBoxApps.Location = new System.Drawing.Point(3, 3);
            this.checkedListBoxApps.Name = "checkedListBoxApps";
            this.checkedListBoxApps.Size = new System.Drawing.Size(236, 269);
            this.checkedListBoxApps.TabIndex = 0;
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.rtbLogger);
            this.groupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox.Location = new System.Drawing.Point(268, 10);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(331, 301);
            this.groupBox.TabIndex = 203;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Log";
            // 
            // rtbLogger
            // 
            this.rtbLogger.BackColor = System.Drawing.Color.White;
            this.rtbLogger.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLogger.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLogger.Location = new System.Drawing.Point(3, 17);
            this.rtbLogger.Name = "rtbLogger";
            this.rtbLogger.ReadOnly = true;
            this.rtbLogger.Size = new System.Drawing.Size(325, 281);
            this.rtbLogger.TabIndex = 202;
            this.rtbLogger.Text = "";
            // 
            // btnFix
            // 
            this.btnFix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFix.AutoEllipsis = true;
            this.btnFix.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFix.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFix.Location = new System.Drawing.Point(395, 317);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(121, 29);
            this.btnFix.TabIndex = 2;
            this.btnFix.Text = "&Run Fixer";
            this.btnFix.UseVisualStyleBackColor = false;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.panelHeader.Controls.Add(this.btnGitHub);
            this.panelHeader.Controls.Add(this.linkUpdateCheck);
            this.panelHeader.Controls.Add(this.lblVersionInfo);
            this.panelHeader.Controls.Add(this.lblHeader);
            this.panelHeader.Controls.Add(this.pictureHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(613, 77);
            this.panelHeader.TabIndex = 207;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // btnGitHub
            // 
            this.btnGitHub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGitHub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnGitHub.FlatAppearance.BorderSize = 0;
            this.btnGitHub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGitHub.Image = ((System.Drawing.Image)(resources.GetObject("btnGitHub.Image")));
            this.btnGitHub.Location = new System.Drawing.Point(565, 12);
            this.btnGitHub.Name = "btnGitHub";
            this.btnGitHub.Size = new System.Drawing.Size(36, 36);
            this.btnGitHub.TabIndex = 205;
            this.btnGitHub.UseVisualStyleBackColor = false;
            this.btnGitHub.Click += new System.EventHandler(this.btnGitHub_Click);
            // 
            // linkUpdateCheck
            // 
            this.linkUpdateCheck.ActiveLinkColor = System.Drawing.Color.Gainsboro;
            this.linkUpdateCheck.AutoSize = true;
            this.linkUpdateCheck.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkUpdateCheck.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkUpdateCheck.LinkColor = System.Drawing.Color.White;
            this.linkUpdateCheck.Location = new System.Drawing.Point(62, 51);
            this.linkUpdateCheck.Name = "linkUpdateCheck";
            this.linkUpdateCheck.Size = new System.Drawing.Size(95, 13);
            this.linkUpdateCheck.TabIndex = 204;
            this.linkUpdateCheck.TabStop = true;
            this.linkUpdateCheck.Text = "Check for updates";
            this.linkUpdateCheck.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUpdateCheck_LinkClicked);
            // 
            // lblVersionInfo
            // 
            this.lblVersionInfo.AutoSize = true;
            this.lblVersionInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersionInfo.ForeColor = System.Drawing.Color.White;
            this.lblVersionInfo.Location = new System.Drawing.Point(62, 38);
            this.lblVersionInfo.Name = "lblVersionInfo";
            this.lblVersionInfo.Size = new System.Drawing.Size(42, 13);
            this.lblVersionInfo.TabIndex = 203;
            this.lblVersionInfo.Text = "Version";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(61, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(103, 23);
            this.lblHeader.TabIndex = 202;
            this.lblHeader.Text = "CrapFixer";
            // 
            // pictureHeader
            // 
            this.pictureHeader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureHeader.Image = ((System.Drawing.Image)(resources.GetObject("pictureHeader.Image")));
            this.pictureHeader.Location = new System.Drawing.Point(12, 15);
            this.pictureHeader.Name = "pictureHeader";
            this.pictureHeader.Size = new System.Drawing.Size(43, 44);
            this.pictureHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureHeader.TabIndex = 201;
            this.pictureHeader.TabStop = false;
            this.pictureHeader.Click += new System.EventHandler(this.PictureHeader_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRestore.AutoEllipsis = true;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRestore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.Location = new System.Drawing.Point(522, 317);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(77, 29);
            this.btnRestore.TabIndex = 207;
            this.btnRestore.Text = "&Restore";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // linkSelection
            // 
            this.linkSelection.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.linkSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkSelection.AutoSize = true;
            this.linkSelection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkSelection.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkSelection.LinkColor = System.Drawing.Color.DimGray;
            this.linkSelection.Location = new System.Drawing.Point(12, 317);
            this.linkSelection.Name = "linkSelection";
            this.linkSelection.Size = new System.Drawing.Size(51, 13);
            this.linkSelection.TabIndex = 208;
            this.linkSelection.TabStop = true;
            this.linkSelection.Text = "Select all";
            this.linkSelection.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelection_LinkClicked);
            // 
            // statusStrip
            //
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 430);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(613, 22);
            this.statusStrip.TabIndex = 209;
            this.statusStrip.Text = "statusStrip";
            //
            // statusLabel
            //
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Ready";
            //
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 452);
            this.Controls.Add(this.linkSelection);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject(".Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CrapFixer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelContainer.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.Windows.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.Apps.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHeader)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage Windows;
        private System.Windows.Forms.TreeView treeFeatures;
        private System.Windows.Forms.TabPage Apps;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.RichTextBox rtbLogger;
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
        private System.Windows.Forms.Button btnGitHub;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem analyzeMarkedFeatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fixMarkedFeatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreMarkedFeatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMarkedFeatureToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkSelection;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnSaveLog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}
