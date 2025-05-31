using Microsoft.Win32;
using System;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.Edge
{
    public class BrowserSignin : FeatureBase
    {
        private const string keyName = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const string valueName = "BrowserSignin";
        private const int recommendedValue = 0;

        /// <summary>
        /// Provides detailed information about the registry key and value used to control Microsoft Edge browser sign-in.
        /// </summary>
        /// <returns>A string detailing the registry path, value name, and its recommended setting to disable sign-in.</returns>
        public override string GetFeatureDetails()
        {
            return $"{keyName} | Value: {valueName} | Recommended Value: {recommendedValue}";
        }

        /// <summary>
        /// Gets the unique identifier for the feature that disables Microsoft Edge browser sign-in and sync services.
        /// </summary>
        /// <returns>A string representing the unique ID: "Disable Browser sign in and sync services".</returns>
        public override string ID() => "Disable Browser sign in and sync services";

        /// <summary>
        /// Provides a brief description of the feature's purpose.
        /// </summary>
        /// <returns>A string explaining that this setting controls user sign-in to Microsoft Edge for services like sync and SSO.</returns>
        public override string Info() => "This setting controls whether a user can sign into Microsoft Edge with an account to use services such as sync and single sign on";

        /// <summary>
        /// Asynchronously checks if Microsoft Edge browser sign-in is currently disabled.
        /// It verifies if the 'BrowserSignin' registry value under Edge policies is set to 0.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result is <c>true</c> if browser sign-in is disabled (registry value is 0),
        /// <c>false</c> otherwise.
        /// </returns>
        public override Task<bool> CheckFeature()
        {
            return Task.FromResult(Utils.IntEquals(keyName, valueName, recommendedValue));
        }

        /// <summary>
        /// Asynchronously disables Microsoft Edge browser sign-in by setting the 'BrowserSignin' registry value to 0.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result is <c>true</c> if the registry value was successfully set, <c>false</c> if an error occurred.
        /// </returns>
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

        /// <summary>
        /// Enables Microsoft Edge browser sign-in by setting the 'BrowserSignin' registry value to 1.
        /// </summary>
        /// <returns><c>true</c> if the registry value was successfully set, <c>false</c> if an error occurred.</returns>
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