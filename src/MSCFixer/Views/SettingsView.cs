using Crapfixer;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Views
{
    public partial class SettingsView : UserControl

    {
        private NavigationManager navigationManager;

        public SettingsView(NavigationManager navigationManager)
        {
            InitializeComponent();
            this.navigationManager = navigationManager;
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Update version label
            this.lblVersionInfo.Text = $"v{Program.GetCurrentVersionTostring()} ";
        }

        private void linkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/builtbybel/Crapfixer/releases");
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Hi! I'm building Crapfixer solo. Want to support me and help launch Version 1.0?",
                "Support Crapfixer ❤️",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = "https://paypal.com/donate?hosted_button_id=MY7HX4QLYR4KG",
                    UseShellExecute = true
                });
            }
        }
    }
}