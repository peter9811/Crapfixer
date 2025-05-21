namespace CFixer.Views
{
    partial class PluginsView
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPluginInstall = new System.Windows.Forms.Button();
            this.btnDescription = new System.Windows.Forms.Button();
            this.listBoxPlugins = new System.Windows.Forms.CheckedListBox();
            this.progressBarDownload = new System.Windows.Forms.ProgressBar();
            this.btnPluginOpen = new System.Windows.Forms.Button();
            this.btnPluginRemove = new System.Windows.Forms.Button();
            this.btnPluginSubmit = new System.Windows.Forms.Button();
            this.btnPluginUpdateAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPluginInstall
            // 
            this.btnPluginInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPluginInstall.Location = new System.Drawing.Point(488, 46);
            this.btnPluginInstall.Name = "btnPluginInstall";
            this.btnPluginInstall.Size = new System.Drawing.Size(121, 29);
            this.btnPluginInstall.TabIndex = 7;
            this.btnPluginInstall.Text = "Install";
            this.btnPluginInstall.UseVisualStyleBackColor = true;
            this.btnPluginInstall.Click += new System.EventHandler(this.btnPluginInstall_Click);
            // 
            // btnDescription
            // 
            this.btnDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDescription.AutoEllipsis = true;
            this.btnDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescription.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnDescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescription.Location = new System.Drawing.Point(15, 10);
            this.btnDescription.Name = "btnDescription";
            this.btnDescription.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnDescription.Size = new System.Drawing.Size(594, 25);
            this.btnDescription.TabIndex = 6;
            this.btnDescription.Text = "Plugins Gallery (App restart needed after install)";
            this.btnDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDescription.UseVisualStyleBackColor = true;
            // 
            // listBoxPlugins
            // 
            this.listBoxPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPlugins.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listBoxPlugins.FormattingEnabled = true;
            this.listBoxPlugins.Location = new System.Drawing.Point(15, 44);
            this.listBoxPlugins.Name = "listBoxPlugins";
            this.listBoxPlugins.Size = new System.Drawing.Size(457, 340);
            this.listBoxPlugins.TabIndex = 8;
            this.listBoxPlugins.SelectedIndexChanged += new System.EventHandler(this.listBoxPlugins_SelectedIndexChanged);
            // 
            // progressBarDownload
            // 
            this.progressBarDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarDownload.Location = new System.Drawing.Point(15, 380);
            this.progressBarDownload.Name = "progressBarDownload";
            this.progressBarDownload.Size = new System.Drawing.Size(457, 12);
            this.progressBarDownload.TabIndex = 9;
            this.progressBarDownload.Visible = false;
            // 
            // btnPluginOpen
            // 
            this.btnPluginOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPluginOpen.Location = new System.Drawing.Point(488, 116);
            this.btnPluginOpen.Name = "btnPluginOpen";
            this.btnPluginOpen.Size = new System.Drawing.Size(121, 29);
            this.btnPluginOpen.TabIndex = 10;
            this.btnPluginOpen.Text = "Open";
            this.btnPluginOpen.UseVisualStyleBackColor = true;
            this.btnPluginOpen.Click += new System.EventHandler(this.btnPluginOpen_Click);
            // 
            // btnPluginRemove
            // 
            this.btnPluginRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPluginRemove.Location = new System.Drawing.Point(488, 151);
            this.btnPluginRemove.Name = "btnPluginRemove";
            this.btnPluginRemove.Size = new System.Drawing.Size(121, 29);
            this.btnPluginRemove.TabIndex = 11;
            this.btnPluginRemove.Text = "Remove";
            this.btnPluginRemove.UseVisualStyleBackColor = true;
            this.btnPluginRemove.Click += new System.EventHandler(this.btnPluginRemove_Click);
            // 
            // btnPluginSubmit
            // 
            this.btnPluginSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPluginSubmit.Location = new System.Drawing.Point(488, 345);
            this.btnPluginSubmit.Name = "btnPluginSubmit";
            this.btnPluginSubmit.Size = new System.Drawing.Size(121, 29);
            this.btnPluginSubmit.TabIndex = 12;
            this.btnPluginSubmit.Text = "Submit Plugin";
            this.btnPluginSubmit.UseVisualStyleBackColor = true;
            this.btnPluginSubmit.Click += new System.EventHandler(this.btnPluginSubmit_Click);
            // 
            // btnPluginUpdateAll
            // 
            this.btnPluginUpdateAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPluginUpdateAll.Location = new System.Drawing.Point(488, 81);
            this.btnPluginUpdateAll.Name = "btnPluginUpdateAll";
            this.btnPluginUpdateAll.Size = new System.Drawing.Size(121, 29);
            this.btnPluginUpdateAll.TabIndex = 13;
            this.btnPluginUpdateAll.Text = "Update All";
            this.btnPluginUpdateAll.UseVisualStyleBackColor = true;
            this.btnPluginUpdateAll.Click += new System.EventHandler(this.btnPluginUpdateAll_Click);
            // 
            // PluginsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnPluginUpdateAll);
            this.Controls.Add(this.btnPluginSubmit);
            this.Controls.Add(this.btnPluginRemove);
            this.Controls.Add(this.btnPluginOpen);
            this.Controls.Add(this.progressBarDownload);
            this.Controls.Add(this.listBoxPlugins);
            this.Controls.Add(this.btnPluginInstall);
            this.Controls.Add(this.btnDescription);
            this.Name = "PluginsView";
            this.Size = new System.Drawing.Size(625, 395);
            this.Load += new System.EventHandler(this.PluginsView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPluginInstall;
        private System.Windows.Forms.Button btnDescription;
        private System.Windows.Forms.CheckedListBox listBoxPlugins;
        private System.Windows.Forms.ProgressBar progressBarDownload;
        private System.Windows.Forms.Button btnPluginOpen;
        private System.Windows.Forms.Button btnPluginRemove;
        private System.Windows.Forms.Button btnPluginSubmit;
        private System.Windows.Forms.Button btnPluginUpdateAll;
    }
}
