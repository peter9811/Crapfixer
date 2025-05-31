using Microsoft.Win32;
using System;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.AI
{
    internal class AskCopilot : FeatureBase
    {
        private const string keyPath = @"Software\Microsoft\Windows\CurrentVersion\Shell Extensions\Blocked";
        private const string fullKeyPath = @"HKEY_CURRENT_USER\" + keyPath;
        private const string valueName = "{CB3B0003-8088-4EDE-8769-8B354AB2FF8C}";
        private const string displayValue = "Ask Copilot";

        /// <summary>
        /// Provides detailed information about the registry key and value used to block the "Ask Copilot" context menu entry.
        /// </summary>
        /// <returns>A string detailing the registry path, value name, and its purpose.</returns>
        public override string GetFeatureDetails()
        {
            return $"{fullKeyPath} | Value: {valueName} = \"{displayValue}\" | Blocks Copilot context menu entry.";
        }

        /// <summary>
        /// Gets the unique identifier for the feature that removes the "Ask Copilot" context menu entry.
        /// </summary>
        /// <returns>A string representing the unique ID: "Remove Ask Copilot from context menu".</returns>
        public override string ID()
        {
            return "Remove Ask Copilot from context menu";
        }

        /// <summary>
        /// Provides a brief description of the feature's purpose.
        /// </summary>
        /// <returns>A string explaining that this feature blocks the "Ask Copilot" entry in the Windows 11 context menu.</returns>
        public override string Info()
        {
            return "Blocks the 'Ask Copilot' entry in the Windows 11 context menu by disabling its Shell Extension.";
        }

        /// <summary>
        /// Asynchronously checks if the "Ask Copilot" context menu entry is currently blocked.
        /// It verifies the presence and value of a specific registry entry.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result is <c>true</c> if the context menu entry is blocked (registry value exists and is correct),
        /// <c>false</c> otherwise.
        /// </returns>
        public override Task<bool> CheckFeature()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
            {
                if (key == null) return Task.FromResult(false);
                object value = key.GetValue(valueName);
                return Task.FromResult(value != null && value.ToString() == displayValue);
            }
        }

        /// <summary>
        /// Asynchronously blocks the "Ask Copilot" context menu entry by creating a specific registry value.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result is <c>true</c> if the registry value was successfully set, <c>false</c> if an error occurred.
        /// </returns>
        public override Task<bool> DoFeature()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    key.SetValue(valueName, displayValue, RegistryValueKind.String);
                }

                Logger.Log("'Ask Copilot' context menu entry has been blocked.", LogLevel.Info);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Logger.Log("Error blocking Copilot context menu: " + ex.Message, LogLevel.Error);
                return Task.FromResult(false);
            }
        }

        /// <summary>
        /// Restores the "Ask Copilot" context menu entry by deleting the specific registry value that blocks it.
        /// </summary>
        /// <returns><c>true</c> if the registry value was successfully deleted or did not exist, <c>false</c> if an error occurred.</returns>
        public override bool UndoFeature()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath, writable: true))
                {
                    key?.DeleteValue(valueName, false);
                }

                Logger.Log("'Ask Copilot' context menu entry has been restored.", LogLevel.Info);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Error restoring Copilot context menu: " + ex.Message, LogLevel.Error);
                return false;
            }
        }
    }
}
