using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.UI
{
    internal class DisableBingSearch : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search";
        private const string valueName = "BingSearchEnabled";
        private const int recommendedValue = 0;

        public override string GetFeatureDetails() => $"{keyName} | Value: {valueName} | Recommended: {recommendedValue}";
        public override string ID() => "Disable Bing Search";
        public override string Info() => "This feature disables Bing integration in Windows Search.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, recommendedValue));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, recommendedValue, RegistryValueKind.DWord, "Bing Search disabled");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 1, RegistryValueKind.DWord, "Bing Search enabled");
    }
}
