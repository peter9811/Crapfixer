using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.UI
{
    internal class LockScreen : FeatureBase
    {
        private const string keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Personalization";
        private const string valueName = "NoLockScreen";
        private const int recommendedValue = 1;

        public override string GetFeatureDetails() => $"{keyName} | Value: {valueName} | Recommended: {recommendedValue}";
        public override string ID() => "Disable Lock Screen";
        public override string Info() => "Disables the lock screen and takes you directly to the login screen.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, recommendedValue));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, recommendedValue, RegistryValueKind.DWord, "Lock screen disabled");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 0, RegistryValueKind.DWord, "Lock screen enabled");
    }
}
