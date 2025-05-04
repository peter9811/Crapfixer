using Microsoft.Win32;
using System.Windows.Forms;
using System;
using System.Diagnostics;

// This file is part of MSCFixer.
namespace Crapfixer
{
    internal class Utils
    {
        /// <summary>
        /// Checks if a registry value is equal to a specified integer.
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="valueName"></param>
        /// <param name="expectedValue"></param>
        /// <returns></returns>
        public static bool IntEquals(string keyName, string valueName, int expectedValue)
        {
            try
            {
                var value = Registry.GetValue(keyName, valueName, null);
                return (value != null && (int)value == expectedValue);
            }
            catch (Exception ex)

            {
                MessageBox.Show(keyName, ex.Message, MessageBoxButtons.OK);
                return false;
            }
        }

        /// <summary>
        /// Checks if a registry value is equal to a specified string.
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="valueName"></param>
        /// <param name="expectedValue"></param>
        /// <returns></returns>
        public static bool StringEquals(string keyName, string valueName, string expectedValue)
        {
            try
            {
                var value = Registry.GetValue(keyName, valueName, null);

                return (value != null && (string)value == expectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(keyName, ex.Message, MessageBoxButtons.OK);
                return false;
            }
        }

        /// <summary>
        /// Restarts Windows Explorer to apply UI changes.
        /// </summary>
        public static void RestartExplorer()
        {
            try
            {
                Logger.Log("Restarting Windows Explorer to apply UI changes...", LogLevel.Info);

                // Kill all explorer instances
                foreach (var process in Process.GetProcessesByName("explorer"))
                {
                    process.Kill();
                    process.WaitForExit();
                }

                // Restart explorer
                Process.Start("explorer.exe");

                Logger.Log("Explorer restarted successfully. Changes should now be visible.", LogLevel.Info);
            }
            catch (Exception ex)
            {
                Logger.Log("Failed to restart Explorer: " + ex.Message, LogLevel.Error);
            }
        }

    }
}