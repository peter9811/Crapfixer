using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.UI
{
    internal class StartLayout : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
        private const string valueName = "Start_Layout";
        private const int recommendedValue = 1;

        public override string GetFeatureDetails() => $"{keyName} | Value: {valueName} | Recommended: {recommendedValue} (More pins)";
        public override string ID() => "Show More Pins in Start";
        public override string Info() => "Changes the Start menu layout to show more pinned apps and fewer recommendations.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, recommendedValue));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, recommendedValue, RegistryValueKind.DWord, "Start layout changed to more pins");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 0, RegistryValueKind.DWord, "Start layout restored to default");
    }
}
