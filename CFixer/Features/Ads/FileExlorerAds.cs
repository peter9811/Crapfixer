using Microsoft.Win32;
using System;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.Ads
{
    internal class FileExplorerAds : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
        private const string valueName = "ShowSyncProviderNotifications";
        private const int recommendedValue = 0;

        /// <summary>
        /// Provides detailed information about the registry key and value used to disable File Explorer ads.
        /// </summary>
        /// <returns>A string detailing the registry path, value name, and its recommended setting.</returns>
        public override string GetFeatureDetails()
        {
            return $"{keyName} | Value: {valueName} | Recommended Value: {recommendedValue}";
        }

        /// <summary>
        /// Gets the unique identifier for the feature that disables File Explorer ads.
        /// </summary>
        /// <returns>A string representing the unique ID: "Disable File Explorer Ads".</returns>
        public override string ID()
        {
            return "Disable File Explorer Ads";
        }

        /// <summary>
        /// Provides a brief description of the feature's purpose.
        /// </summary>
        /// <returns>A string explaining that this feature disables ads in File Explorer.</returns>
        public override string Info()
        {
            return "This feature will disable ads in File Explorer.";
        }

        /// <summary>
        /// Asynchronously checks if File Explorer ads are currently disabled.
        /// It verifies if the 'ShowSyncProviderNotifications' registry value is set to 0.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result is <c>true</c> if File Explorer ads are disabled (registry value is 0),
        /// <c>false</c> otherwise.
        /// </returns>
        public override Task<bool> CheckFeature()
        {
            return Task.FromResult(Utils.IntEquals(keyName, valueName, recommendedValue));
        }

        /// <summary>
        /// Asynchronously disables File Explorer ads by setting the 'ShowSyncProviderNotifications' registry value to 0.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result is <c>true</c> if the registry value was successfully set, <c>false</c> if an error occurred.
        /// </returns>
        public override Task<bool> DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, valueName, 0, RegistryValueKind.DWord);
                Logger.Log("File Explorer Ads disabled", LogLevel.Info);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Logger.Log("Code red in " + ex.Message, LogLevel.Error);
            }

            return Task.FromResult(false);
        }

        /// <summary>
        /// Enables File Explorer ads by setting the 'ShowSyncProviderNotifications' registry value back to 1.
        /// </summary>
        /// <returns><c>true</c> if the registry value was successfully set, <c>false</c> if an error occurred.</returns>
        public override bool UndoFeature()
        {
            try
            {
                Registry.SetValue(keyName, valueName, 1, RegistryValueKind.DWord);
                Logger.Log("File Explorer Ads enabled", LogLevel.Info);
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