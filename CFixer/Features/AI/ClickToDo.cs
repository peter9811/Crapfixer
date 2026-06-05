using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.AI
{
    internal class ClickToDo : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
        private const string valueName = "EnableClickToDo";
        private const int recommendedValue = 0;

        public override string GetFeatureDetails() => $"{keyName} | Value: {valueName} | Recommended: {recommendedValue}";
        public override string ID() => "Disable Click to Do";
        public override string Info() => "Disables the 'Click to Do' AI feature in Windows 11.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, recommendedValue));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, recommendedValue, RegistryValueKind.DWord, "Click to Do disabled");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 1, RegistryValueKind.DWord, "Click to Do enabled");
    }
}
