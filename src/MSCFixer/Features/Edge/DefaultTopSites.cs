using Microsoft.Win32;
using System;
using Crapfixer;
using System.Threading.Tasks;

namespace Settings.Edge
{
    public class DefaultTopSites : FeatureBase
    {
        private const string keyName = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const string valueName = "NewTabPageHideDefaultTopSites";
        private const int recommendedValue = 0;

        public override string GetFeatureDetails()
        {
            return $"{keyName} | Value: {valueName} | Recommended Value: {recommendedValue}";
        }

        public override string ID() => "Don't Show Sponsored links in new tab page";

        public override string Info() => "Hide default top sites from the new tab page in Microsoft Edge";

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, valueName, recommendedValue);
        }

        public override Task<bool> DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, valueName, 0, Microsoft.Win32.RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, valueName, 1, Microsoft.Win32.RegistryValueKind.DWord);

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