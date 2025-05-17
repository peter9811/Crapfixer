namespace MSCFixer.Views
{
    partial class OptionsView
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
            this.panelSettings = new System.Windows.Forms.Panel();
            this.panelSubContent = new System.Windows.Forms.Panel();
            this.btnAboutMenu = new System.Windows.Forms.Button();
            this.btnSettingsMenu = new System.Windows.Forms.Button();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSettings
            // 
            this.panelSettings.BackColor = System.Drawing.Color.White;
            this.panelSettings.Controls.Add(this.panelSubContent);
            this.panelSettings.Controls.Add(this.btnAboutMenu);
            this.panelSettings.Controls.Add(this.btnSettingsMenu);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSettings.Location = new System.Drawing.Point(0, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(625, 395);
            this.panelSettings.TabIndex = 243;
            // 
            // panelSubContent
            // 
            this.panelSubContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSubContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSubContent.Location = new System.Drawing.Point(135, 14);
            this.panelSubContent.Name = "panelSubContent";
            this.panelSubContent.Size = new System.Drawing.Size(474, 363);
            this.panelSubContent.TabIndex = 246;
            // 
            // btnAboutMenu
            // 
            this.btnAboutMenu.BackColor = System.Drawing.Color.White;
            this.btnAboutMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnAboutMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAboutMenu.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnAboutMenu.Location = new System.Drawing.Point(14, 53);
            this.btnAboutMenu.Name = "btnAboutMenu";
            this.btnAboutMenu.Size = new System.Drawing.Size(107, 34);
            this.btnAboutMenu.TabIndex = 242;
            this.btnAboutMenu.Text = "About";
            this.btnAboutMenu.UseVisualStyleBackColor = false;
            this.btnAboutMenu.Click += new System.EventHandler(this.btnAboutMenu_Click);
            // 
            // btnSettingsMenu
            // 
            this.btnSettingsMenu.BackColor = System.Drawing.Color.White;
            this.btnSettingsMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnSettingsMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettingsMenu.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnSettingsMenu.Location = new System.Drawing.Point(14, 13);
            this.btnSettingsMenu.Name = "btnSettingsMenu";
            this.btnSettingsMenu.Size = new System.Drawing.Size(107, 34);
            this.btnSettingsMenu.TabIndex = 241;
            this.btnSettingsMenu.Text = "Settings";
            this.btnSettingsMenu.UseVisualStyleBackColor = false;
            this.btnSettingsMenu.Click += new System.EventHandler(this.btnSettingsMenu_Click);
            // 
            // OptionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelSettings);
            this.Name = "OptionsView";
            this.Size = new System.Drawing.Size(625, 395);
            this.panelSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Button btnSettingsMenu;
        private System.Windows.Forms.Button btnAboutMenu;
        private System.Windows.Forms.Panel panelSubContent;
    }
}
