using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.Gaming
{
    internal class GameDVR : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\GameDVR";

        public override string GetFeatureDetails() => $"{keyName} | AppCaptureEnabled";
        public override string ID() => "Disable Game DVR";
        public override string Info() => "Disables Game DVR background recording for better performance.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, "AppCaptureEnabled", 0));

        public override async Task<bool> DoFeature()
        {
            await RegistryHelper.SetValue(keyName, "AppCaptureEnabled", 0, RegistryValueKind.DWord);
            await RegistryHelper.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_Enabled", 0, RegistryValueKind.DWord);
            return true;
        }

        public override async Task<bool> UndoFeature()
        {
            await RegistryHelper.SetValue(keyName, "AppCaptureEnabled", 1, RegistryValueKind.DWord);
            await RegistryHelper.SetValue(@"HKEY_CURRENT_USER\System\GameConfigStore", "GameDVR_Enabled", 1, RegistryValueKind.DWord);
            return true;
        }
    }
}
