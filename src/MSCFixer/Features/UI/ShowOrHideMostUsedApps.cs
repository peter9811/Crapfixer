using Microsoft.Win32;
using System;
using Crapfixer;
using System.Threading.Tasks;

namespace Settings.Personalization
{
    internal class ShowOrHideMostUsedApps : FeatureBase
    {
        private const string keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer";
        private const string valueName = "ShowOrHideMostUsedApps";
        private const int recommendedValue = 0;

        public override string GetFeatureDetails()
        {
            return $"{keyName} | Value: {valueName} | Recommended Value: {recommendedValue}";
        }

        public override string ID()
        {
            return "Hide Most used apps in start menu";
        }

        public override string Info()
        {
            return "This feature will hide Most used apps in start menu";
        }

        public override bool CheckFeature()
        {
            return (
                   Utils.IntEquals(keyName, valueName, recommendedValue)
             );
        }

        public override Task<bool> DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, valueName, 0, RegistryValueKind.DWord);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Logger.Log("Code red in " + ex.Message, LogLevel.Error);
            }

            return Task.FromResult(false);
        }

        public override bool UndoFeature()
        {
            try
            {
                Registry.SetValue(keyName, valueName, 2, RegistryValueKind.DWord);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Code red in " + ex.Message, LogLevel.Error);
            }

            return false;
        }
    }
}