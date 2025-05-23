﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Management.Deployment;

namespace Crapfixer
{
    public class AppAnalysisResult
    {
        public string AppName { get; set; }
        public string FullName { get; set; }
    }

    public class AppManagerService
    {
        private Dictionary<string, string> _appDirectory = new Dictionary<string, string>();

        // Loads all apps and stores them in the directory (name -> fullName)
        private async Task LoadAppsAsync()
        {
            _appDirectory.Clear();

            var pm = new PackageManager();
            var packages = await Task.Run(() =>
                pm.FindPackagesForUserWithPackageTypes(string.Empty, PackageTypes.Main));

            foreach (var p in packages)
            {
                string name = p.Id.Name;
                string fullName = p.Id.FullName;

                if (!_appDirectory.ContainsKey(name))
                {
                    _appDirectory[name] = fullName;
                }
            }
            Logger.Log($"(Checked against {_appDirectory.Count} apps from the system)");
        }

        /// <summary>
        /// Analyzes the apps based on predefined apps (from resources) and logs the results in MainForm.
        /// </summary>
        /// <param name="predefinedApps"></param>
        /// <returns></returns>
        public async Task<List<AppAnalysisResult>> AnalyzeAndLogAppsAsync(string[] predefinedApps)
        {
            var apps = await AnalyzeAppsAsync(predefinedApps);

            if (apps.Count > 0)
            {
                Logger.Log("Bloatware apps detected:", LogLevel.Info);
                foreach (var app in apps)
                {
                    Logger.Log($"❌ {app.AppName} [{app.FullName}]", LogLevel.Warning);
                }
            }
            else
            {
                Logger.Log("✅ No Microsoft Store bloatware apps found.", LogLevel.Info);
            }

            return apps;
        }


        /// <summary>
        /// Analyzes the apps based on predefined apps (from resources) and returns matching apps.
        /// </summary>
        /// <param name="predefinedApps"></param>
        /// <returns></returns>
        public async Task<List<AppAnalysisResult>> AnalyzeAppsAsync(string[] predefinedApps)
        {
            Logger.Log("\n🧩 APPS ANALYSIS", LogLevel.Info);
            Logger.Log(new string('=', 50), LogLevel.Info);

            await LoadAppsAsync(); // Load all apps before analysis

            var result = new List<AppAnalysisResult>();

            // Check each app's name against predefined patterns
            foreach (var app in _appDirectory)
            {
                foreach (string pattern in predefinedApps)
                {
                    if (app.Key.ToLower().Contains(pattern.ToLower()))
                    {
                        result.Add(new AppAnalysisResult
                        {
                            AppName = app.Key,
                            FullName = app.Value // Store the full name
                        });
                        break;
                    }
                }
            }

            return result;
        }

        // Uninstall an app by its full name
        public async Task<bool> UninstallApp(string fullName)
        {
            try
            {
                var pm = new PackageManager();
                var operation = pm.RemovePackageAsync(fullName);

                var resetEvent = new ManualResetEvent(false);
                operation.Completed = (o, s) => resetEvent.Set();
                await Task.Run(() => resetEvent.WaitOne());

                if (operation.Status == AsyncStatus.Completed)
                {
                    Logger.Log($"Successfully uninstalled app: {fullName}");
                    return true;
                }
                else
                {
                    Logger.Log($"Failed to uninstall appe: {fullName}", LogLevel.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Error during uninstalling app {fullName}: {ex.Message}", LogLevel.Warning);
                return false;
            }
        }

        /// <summary>
        /// Uninstalls the selected apps and logs the results.
        /// </summary>
        /// <param name="selectedApps"></param>
        /// <returns></returns>
        public async Task<List<string>> UninstallSelectedAppsAsync(List<string> selectedApps)
        {
            List<string> removedApps = new List<string>();

            foreach (var fullName in selectedApps)
            {
                Logger.Log($"🗑️ Removing app: {fullName}...");

                // Uninstall the app using its full name
                var success = await UninstallApp(fullName);
                if (success)
                {
                    removedApps.Add(fullName);
                }
            }

            // Log results for apps that were successfully removed
            foreach (var app in removedApps)
            {
                Logger.Log($"🗑️ Removed Store App: {app}");
            }

            // Log failed attempts
            var failedApps = selectedApps.Except(removedApps).ToList();
            foreach (var app in failedApps)
            {
                Logger.Log($"⚠️ Failed to remove Store App: {app}", LogLevel.Warning);
            }

            Logger.Log("App cleanup complete.");

            return removedApps; // Return removed apps to update the UI
        }

        /// <summary>
        /// Loads an external bloatware list from the CFEnhancer text file (comma-separated).
        /// Falls back to an empty array if the file doesn't exist or fails to load.
        /// </summary>
        public string[] LoadExternalBloatwareList(string fileName = "CFEnhancer.txt")
        {
            try
            {
                string exeDir = AppDomain.CurrentDomain.BaseDirectory;
                string fullPath = Path.Combine(exeDir, fileName);

                if (!File.Exists(fullPath))
                {
                    Logger.Log($"⚠️ The bloatware radar stays basic for now 🧠. Get the enhanced detection list from the GitHub releases (Assets).", LogLevel.Warning);
                    return Array.Empty<string>();
                }

                var content = File.ReadAllText(fullPath);
                return content.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(s => s.Trim())
                              .ToArray();
            }
            catch (Exception ex)
            {
                Logger.Log($"Error reading external bloatware file: {ex.Message}", LogLevel.Warning);
                return Array.Empty<string>();
            }
        }


        /// <summary>
        /// OPTIONALLY!Returns all installed apps in the system. 
        /// </summary>
        /// <returns></returns>
        public async Task<List<AppAnalysisResult>> GetAllInstalledAppsAsync()
        {
            await LoadAppsAsync();

            return _appDirectory.Select(kvp => new AppAnalysisResult
            {
                AppName = kvp.Key,
                FullName = kvp.Value
            }).ToList();
        }
    }
}