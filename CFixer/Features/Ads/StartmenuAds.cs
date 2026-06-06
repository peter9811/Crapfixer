using Microsoft.Win32;
using System;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.Ads
{
    internal class StartmenuAds : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
        private const string valueName = "Start_IrisRecommendations";
        private const int recommendedValue = 0;

        public override string GetFeatureDetails()
        {
            return $"{keyName} | Value: {valueName} | Recommended Value: {recommendedValue}";
        }

        public override string ID()
        {
            return "Disable Start menu Ads";
        }

        public override string Info()
        {
            return "This feature will disable ads in the start menu.";
        }

        public override Task<bool> CheckFeature()
        {
            return Task.FromResult(
                   Utils.IntEquals(keyName, valueName, recommendedValue)
             );
        }

        public override async Task<bool> DoFeature()
        {
            try
            {
                await RegistryHelper.SetValue(keyName, valueName, 0, RegistryValueKind.DWord);
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
                await RegistryHelper.SetValue(keyName, valueName, 1, RegistryValueKind.DWord);
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