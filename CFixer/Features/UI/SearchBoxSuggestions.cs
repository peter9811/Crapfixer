using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.UI
{
    internal class DisableSearchBoxSuggestions : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\Explorer";
        private const string valueName = "DisableSearchBoxSuggestions";
        private const int recommendedValue = 1;

        public override string GetFeatureDetails() => $"{keyName} | Value: {valueName} | Recommended: {recommendedValue}";
        public override string ID() => "Disable Search Box Suggestions";
        public override string Info() => "Disables web search suggestions in the taskbar search box.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, recommendedValue));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, recommendedValue, RegistryValueKind.DWord, "Search box suggestions disabled");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 0, RegistryValueKind.DWord, "Search box suggestions enabled");
    }
}
