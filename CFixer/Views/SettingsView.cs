using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CFixer.Views
{
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            LoadSettings();
        }

        /// <summary>
        /// Collects and saves all relevant checkbox settings to the INI file.
        /// </summary>
        public void SaveSettings()
        {
            var settings = new Dictionary<string, bool>
    {
        { nameof(checkSaveToINI), checkSaveToINI.Checked },
    };

            IniStateManager.SaveViewSettings("SETTINGS", settings);
        }

        /// <summary>
        /// Loads checkbox settings from the INI file and applies them to the view.
        /// </summary>
        public void LoadSettings()
        {
            var settings = IniStateManager.LoadViewSettings("SETTINGS");
            checkSaveToINI.Checked = settings.GetValueOrDefault(nameof(checkSaveToINI), false);
        }

        private void SettingsView_Leave(object sender, EventArgs e)
        {
            SaveSettings();
        }
    }
}