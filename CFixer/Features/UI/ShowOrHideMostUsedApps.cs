using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.UI
{
    internal class ShowOrHideMostUsedApps : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
        private const string valueName = "Start_TrackProgs";
        private const int recommendedValue = 0;

        public override string GetFeatureDetails() => $"{keyName} | Value: {valueName} | Recommended: {recommendedValue}";
        public override string ID() => "Hide Most Used Apps";
        public override string Info() => "Hides the 'Most used' apps section from the Start menu.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, recommendedValue));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, recommendedValue, RegistryValueKind.DWord, "Most used apps hidden");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 1, RegistryValueKind.DWord, "Most used apps shown");
    }
}
