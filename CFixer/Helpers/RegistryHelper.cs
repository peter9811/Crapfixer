using Microsoft.Win32;
using System;
using System.Threading.Tasks;

namespace CrapFixer
{
    internal static class RegistryHelper
    {
        public static async Task<bool> SetValue(string keyName, string valueName, object value, RegistryValueKind kind, string successMessage = null)
        {
            return await Task.Run(() =>
            {
                try
                {
                    Registry.SetValue(keyName, valueName, value, kind);
                    if (!string.IsNullOrEmpty(successMessage))
                    {
                        Logger.Log(successMessage, LogLevel.Info);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Logger.Log($"Registry write failed for {keyName}\\{valueName}: {ex.Message}", LogLevel.Error);
                    return false;
                }
            });
        }

        public static async Task<bool> DeleteValue(string keyName, string valueName, string successMessage = null)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (var root = GetRootKey(keyName, out string subKey))
                    {
                        if (root == null) return false;

                        if (string.IsNullOrEmpty(valueName))
                        {
                            // If valueName is empty, we assume the user wants to delete the entire subkey (leaf)
                            root.DeleteSubKeyTree(subKey, false);
                        }
                        else
                        {
                            using (var key = root.OpenSubKey(subKey, true))
                            {
                                if (key != null && key.GetValue(valueName) != null)
                                {
                                    key.DeleteValue(valueName);
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(successMessage))
                        {
                            Logger.Log(successMessage, LogLevel.Info);
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Logger.Log($"Registry delete failed for {keyName}\\{valueName}: {ex.Message}", LogLevel.Error);
                    return false;
                }
            });
        }

        private static RegistryKey GetRootKey(string keyName, out string subKey)
        {
            if (keyName.StartsWith("HKEY_CURRENT_USER", StringComparison.OrdinalIgnoreCase))
            {
                subKey = keyName.Substring("HKEY_CURRENT_USER".Length).TrimStart('\\');
                return Registry.CurrentUser;
            }
            if (keyName.StartsWith("HKEY_LOCAL_MACHINE", StringComparison.OrdinalIgnoreCase))
            {
                subKey = keyName.Substring("HKEY_LOCAL_MACHINE".Length).TrimStart('\\');
                return Registry.LocalMachine;
            }
            subKey = null;
            return null;
        }
    }
}
