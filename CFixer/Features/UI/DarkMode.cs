using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.Personalization
{
    internal class AppDarkMode : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
        private const string valueName = "AppsUseLightTheme";
        private const int recommendedValue = 0;

        public override string GetFeatureDetails() => $"{keyName} | Value: {valueName} | Recommended: {recommendedValue}";
        public override string ID() => "Enable Dark Mode for Apps";
        public override string Info() => "Enables Dark Mode for apps in Windows.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, recommendedValue));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, 0, RegistryValueKind.DWord, "App Dark Mode enabled");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 1, RegistryValueKind.DWord, "App Dark Mode disabled");
    }

    internal class SystemDarkMode : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
        private const string valueName = "SystemUsesLightTheme";
        private const int recommendedValue = 0;

        public override string GetFeatureDetails() => $"{keyName} | Value: {valueName} | Recommended: {recommendedValue}";
        public override string ID() => "Enable Dark Mode for System";
        public override string Info() => "Enables Dark Mode for Windows system UI (taskbar, start menu).";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, recommendedValue));

        public override async Task<bool> DoFeature()
        {
            bool ok = await RegistryHelper.SetValue(keyName, valueName, 0, RegistryValueKind.DWord, "System Dark Mode enabled");
            if (ok) Utils.RestartExplorer();
            return ok;
        }

        public override async Task<bool> UndoFeature()
        {
            bool ok = await RegistryHelper.SetValue(keyName, valueName, 1, RegistryValueKind.DWord, "System Dark Mode disabled");
            if (ok) Utils.RestartExplorer();
            return ok;
        }
    }
}
