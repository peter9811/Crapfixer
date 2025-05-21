using System;
using System.Windows.Forms;
using Views;

namespace CFixer.Views
{
    public partial class OptionsView : UserControl
    {
        private NavigationManager subNavigation;

        public OptionsView()
        {
            InitializeComponent();
            subNavigation = new NavigationManager(panelSubContent);
            subNavigation.SwitchView(new AboutView()); // Startsite
        }

        private void btnAboutMenu_Click(object sender, EventArgs e)
        {
            subNavigation.SwitchView(new AboutView());
        }

        private void btnSettingsMenu_Click(object sender, EventArgs e)
        {
            subNavigation.SwitchView(new SettingsView());
        }

        private void btnPluginsMenu_Click(object sender, EventArgs e)
        {
            subNavigation.SwitchView(new PluginsView());
        }
    }
}