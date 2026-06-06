using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace CrapFixer
{
    internal static class OSHelper
    {
        public static bool IsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        public static void RestartAsAdmin()
        {
            ProcessStartInfo proc = new ProcessStartInfo
            {
                UseShellExecute = true,
                WorkingDirectory = Environment.CurrentDirectory,
                FileName = Process.GetCurrentProcess().MainModule.FileName,
                Verb = "runas"
            };

            try
            {
                Process.Start(proc);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Logger.Log("Could not restart as administrator: " + ex.Message, LogLevel.Error);
            }
        }

        public static async Task CreateRestorePoint(string description)
        {
            try
            {
                Logger.Log("Creating System Restore Point...", LogLevel.Info);
                await Task.Run(() =>
                {
                    using (var process = new Process())
                    {
                        process.StartInfo.FileName = "powershell.exe";
                        process.StartInfo.Arguments = $"-Command \"Checkpoint-Computer -Description '{description}' -RestorePointType 'MODIFY_SETTINGS'\"";
                        process.StartInfo.CreateNoWindow = true;
                        process.StartInfo.UseShellExecute = false;
                        process.Start();
                        process.WaitForExit();
                    }
                });
                Logger.Log("System Restore Point creation request sent.", LogLevel.Info);
            }
            catch (Exception ex)
            {
                Logger.Log("Failed to create Restore Point: " + ex.Message, LogLevel.Warning);
            }
        }

        public static async Task<string> GetWindowsVersion()
        {
            return await Task.Run(() =>
            {
                try
                {
                    string caption = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "")?.ToString();
                    if (string.IsNullOrEmpty(caption)) caption = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "Caption", "")?.ToString();

                    string displayVersion = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "DisplayVersion", "")?.ToString();
                    string build = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuildNumber", "")?.ToString();
                    string ubr = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "UBR", "")?.ToString();

                    return $"Windows: {displayVersion} (Build {build}.{ubr})";
                }
                catch { return "Unknown Windows Version"; }
            });
        }
    }
}
