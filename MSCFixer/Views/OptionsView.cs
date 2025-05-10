using System;
using System.Windows.Forms;
using Views;

namespace MSCFixer.Views
{
    public partial class OptionsView : UserControl
    {
        private NavigationManager subNavigation;

        public OptionsView(NavigationManager navigationManager)
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
    }
}