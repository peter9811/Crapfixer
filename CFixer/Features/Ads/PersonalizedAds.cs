using Microsoft.Win32;
using System;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.Ads
{
    public class PersonalizedAds : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo";
        private const string valueName = "Enabled";
        private const int recommendedValue = 0;

        public override string ID() => "Disable Personalized Ads";

        public override string Info() => "This feature will disable personalized ads.";

        public override string GetFeatureDetails()
        {
            return $"{keyName} | Value: {valueName} | Recommended Value: {recommendedValue}";
        }

        public override Task<bool> CheckFeature()
        {
            return Task.FromResult(Utils.IntEquals(keyName, valueName, 0));
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