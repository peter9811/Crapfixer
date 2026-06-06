using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.UI
{
    internal class SearchboxTaskbarMode : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search";
        private const string valueName = "SearchboxTaskbarMode";
        private const int recommendedValue = 0;

        public override string GetFeatureDetails() => $"{keyName} | Value: {valueName} | Recommended: {recommendedValue} (Hidden)";
        public override string ID() => "Hide Search Box on Taskbar";
        public override string Info() => "Hides the search box from the taskbar to save space.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, recommendedValue));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, recommendedValue, RegistryValueKind.DWord, "Search box hidden");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 2, RegistryValueKind.DWord, "Search box shown (default)");
    }
}
