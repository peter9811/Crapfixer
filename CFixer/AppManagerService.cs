using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.Management.Deployment;
using Windows.Foundation;

namespace CrapFixer
{
    public class AppAnalysisResult
    {
        public string AppName { get; set; }
        public string FullName { get; set; }
    }

    public class AppManagerService
    {
        private Dictionary<string, string> _appDirectory = new Dictionary<string, string>();

        public async Task LoadAppsAsync()
        {
            _appDirectory.Clear();
            await Task.Run(() =>
            {
                var pm = new PackageManager();
                var packages = pm.FindPackagesForUser("");
                foreach (var package in packages)
                {
                    try
                    {
                        string name = package.Id.Name;
                        string fullName = package.Id.FullName;
                        if (!_appDirectory.ContainsKey(name))
                            _appDirectory.Add(name, fullName);
                    }
                    catch { }
                }
            });
        }

        public async Task<List<AppAnalysisResult>> AnalyzeAndLogAppsAsync(string[] bloatwarePatterns, string[] whitelistPatterns, bool scanAll)
        {
            await LoadAppsAsync();
            var result = new List<AppAnalysisResult>();
            foreach (var app in _appDirectory)
            {
                string appName = app.Key.ToLower();
                if (whitelistPatterns.Any(w => appName.Contains(w))) continue;

                if (scanAll || bloatwarePatterns.Any(p => appName.Contains(p)))
                {
                    result.Add(new AppAnalysisResult { AppName = app.Key, FullName = app.Value });
                }
            }
            return result;
        }

        public async Task<bool> UninstallApp(string fullName)
        {
            try
            {
                var pm = new PackageManager();
                var operation = pm.RemovePackageAsync(fullName);
                var tcs = new TaskCompletionSource<bool>();
                operation.Completed = (o, s) =>
                {
                    if (s == AsyncStatus.Completed) tcs.TrySetResult(true);
                    else tcs.TrySetResult(false);
                };
                return await tcs.Task;
            }
            catch (Exception ex)
            {
                Logger.Log($"Error uninstalling {fullName}: {ex.Message}", LogLevel.Warning);
                return false;
            }
        }

        public async Task<List<string>> UninstallSelectedAppsAsync(List<string> selectedApps)
        {
            List<string> removedApps = new List<string>();
            foreach (var fullName in selectedApps)
            {
                Logger.Log($"🗑️ Removing app: {fullName}...");
                if (await UninstallApp(fullName))
                {
                    removedApps.Add(fullName);
                    Logger.Log($"🗑️ Removed Store App: {fullName}");
                }
                else
                {
                    Logger.Log($"⚠️ Failed to remove Store App: {fullName}", LogLevel.Warning);
                }
            }
            return removedApps;
        }

        public (string[] bloatwarePatterns, string[] whitelistPatterns, bool scanAll) LoadExternalBloatwarePatterns(string fileName = "CFEnhancer.txt")
        {
            try
            {
                string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins", fileName);
                if (!System.IO.File.Exists(fullPath)) return (Array.Empty<string>(), Array.Empty<string>(), false);

                var lines = System.IO.File.ReadAllLines(fullPath);
                var bloatware = new List<string>();
                var whitelist = new List<string>();
                bool scanAll = false;

                foreach (var line in lines)
                {
                    var entry = line.Split('#')[0].Trim();
                    if (string.IsNullOrWhiteSpace(entry)) continue;
                    if (entry == "*" || entry == "*.*") { scanAll = true; continue; }
                    if (entry.StartsWith("!")) whitelist.Add(entry.Substring(1).Trim().ToLower());
                    else bloatware.Add(entry.ToLower());
                }
                return (bloatware.ToArray(), whitelist.ToArray(), scanAll);
            }
            catch { return (Array.Empty<string>(), Array.Empty<string>(), false); }
        }
    }
}
