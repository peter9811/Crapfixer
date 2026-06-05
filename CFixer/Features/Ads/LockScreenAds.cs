using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.Ads
{
    internal class LockScreenAds : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";

        public override string GetFeatureDetails() => $"{keyName} | SubscribedContent-338387Enabled";
        public override string ID() => "Disable Lock Screen Ads";
        public override string Info() => "Disables ads and suggestions on the lock screen.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, "SubscribedContent-338387Enabled", 0));

        public override async Task<bool> DoFeature()
        {
            await RegistryHelper.SetValue(keyName, "SubscribedContent-338387Enabled", 0, RegistryValueKind.DWord);
            await RegistryHelper.SetValue(keyName, "RotatingLockScreenEnabled", 0, RegistryValueKind.DWord);
            return true;
        }

        public override async Task<bool> UndoFeature()
        {
            await RegistryHelper.SetValue(keyName, "SubscribedContent-338387Enabled", 1, RegistryValueKind.DWord);
            await RegistryHelper.SetValue(keyName, "RotatingLockScreenEnabled", 1, RegistryValueKind.DWord);
            return true;
        }
    }
}
