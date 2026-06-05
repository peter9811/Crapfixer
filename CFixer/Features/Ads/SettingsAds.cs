using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.Ads
{
    internal class SettingsAds : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";

        public override string GetFeatureDetails() => $"{keyName} | SubscribedContent-338393Enabled, etc.";
        public override string ID() => "Disable Ads in Settings";
        public override string Info() => "Disables suggested content (ads) in the Settings app.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, "SubscribedContent-338393Enabled", 0));

        public override async Task<bool> DoFeature()
        {
            await RegistryHelper.SetValue(keyName, "SubscribedContent-338393Enabled", 0, RegistryValueKind.DWord);
            await RegistryHelper.SetValue(keyName, "SubscribedContent-353694Enabled", 0, RegistryValueKind.DWord);
            await RegistryHelper.SetValue(keyName, "SubscribedContent-353696Enabled", 0, RegistryValueKind.DWord);
            return true;
        }

        public override async Task<bool> UndoFeature()
        {
            await RegistryHelper.SetValue(keyName, "SubscribedContent-338393Enabled", 1, RegistryValueKind.DWord);
            await RegistryHelper.SetValue(keyName, "SubscribedContent-353694Enabled", 1, RegistryValueKind.DWord);
            await RegistryHelper.SetValue(keyName, "SubscribedContent-353696Enabled", 1, RegistryValueKind.DWord);
            return true;
        }
    }
}
