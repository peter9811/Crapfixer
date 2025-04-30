using Microsoft.Win32;
using System;
using Crapfixer;
using System.Threading.Tasks;

namespace Settings.AI
{
    internal class RecallMachine : FeatureBase
    {
        private const string keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsAI";
        private const string valueName = "DisableAIDataAnalysis";
        private const int recommendedValue = 0;

        public override string GetFeatureDetails()
        {
            return $"{keyName} | Value: {valueName} | Recommended Value: {recommendedValue}";
        }

        public override string ID()
        {
            return "Don't Allow system-wide snapshots";
        }

        public override string Info()
        {
            return "This feature will disable system-wide snapshots.";
        }

        public override bool CheckFeature()
        {
            // Check if reg key exists
            object value = Registry.GetValue(keyName, valueName, null);
            if (value == null)
            {
                // Key does not exist, turn off feature
                return false;
            }

            // Key exists, check if value is desired value
            return (int)value != recommendedValue;
        }

        public override Task<bool> DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, valueName, 1, Microsoft.Win32.RegistryValueKind.DWord);
                Logger.Log("You've even disabled system-wide Snapshots for all users now.", LogLevel.Info);
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
                Registry.SetValue(keyName, valueName, recommendedValue, Microsoft.Win32.RegistryValueKind.DWord);
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