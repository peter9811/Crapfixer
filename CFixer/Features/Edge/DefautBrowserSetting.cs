using Microsoft.Win32;
using System;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.Edge
{
    public class DefautBrowserSetting : FeatureBase
    {
        private const string keyName = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const string valueName = "DefaultBrowserSettingEnabled";
        private const int recommendedValue = 0;

        public override string GetFeatureDetails()
        {
            return $"{keyName} | Value: {valueName} | Recommended Value: {recommendedValue}";
        }

        public override string ID() => "Disable Microsoft Edge as default browser";

        public override string Info() => "Force Edge to stop asking to change default browser";

        public override Task<bool> CheckFeature()
        {
            return Task.FromResult(Utils.IntEquals(keyName, valueName, recommendedValue));
        }

        public override async Task<bool> DoFeature()
        {
            try
            {
                await RegistryHelper.SetValue(keyName, valueName, 0, Microsoft.Win32.RegistryValueKind.DWord);

                return await RegistryHelper.SetValue(keyName, valueName, recommendedValue, RegistryValueKind.DWord);
            }
            catch (Exception ex)
            {
                Logger.Log("Code red in " + ex.Message, LogLevel.Error);
            }

            return false;
        }

        public override async Task<bool> UndoFeature()
        {
            try
            {
                await RegistryHelper.SetValue(keyName, valueName, 1, Microsoft.Win32.RegistryValueKind.DWord);

                return await RegistryHelper.SetValue(keyName, valueName, recommendedValue, RegistryValueKind.DWord);
            }
            catch (Exception ex)
            {
                Logger.Log("Code red in " + ex.Message, LogLevel.Error);
            }

            return false;
        }
    }
}