using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.Personalization
{
    internal class Transparency : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
        private const string valueName = "EnableTransparency";
        private const int recommendedValue = 0;

        public override string GetFeatureDetails() => $"{keyName} | Value: {valueName} | Suggestion: {recommendedValue}";
        public override string ID() => "Disable Transparency Effects";
        public override string Info() => "This feature disables transparency effects for Start menu, taskbar, and other surfaces.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, recommendedValue));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, recommendedValue, RegistryValueKind.DWord, "Transparency disabled");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 1, RegistryValueKind.DWord, "Transparency enabled");
    }
}
