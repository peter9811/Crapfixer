using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using CrapFixer;

namespace Settings.Issues
{
    internal class BasicCleanup : FeatureBase
    {
        private readonly string tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp");
        private const int cleanupSetNumber = 1;

        public override string ID() => "Basic Disk Cleanup";
        public override string Info() => "Deletes temporary files and runs the Windows Disk Cleanup utility.";
        public override string GetFeatureDetails()
        {
            try { return $"Temp folder: {tempPath} | Size: {GetDirectorySize(tempPath)} MB"; }
            catch { return "Temp folder not accessible"; }
        }

        public override Task<bool> CheckFeature()
        {
            try { return Task.FromResult(GetDirectorySize(tempPath) <= 50); }
            catch { return Task.FromResult(false); }
        }

        public override async Task<bool> DoFeature()
        {
            try
            {
                await CleanTempFolderAsync();
                await RunDiskCleanup();
                Logger.Log("Basic Cleanup completed successfully.", LogLevel.Info);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log($"Cleanup error: {ex.Message}", LogLevel.Warning);
                return false;
            }
        }

        public override Task<bool> UndoFeature()
        {
            Logger.Log("Cleanup cannot be undone.", LogLevel.Warning);
            return Task.FromResult(false);
        }

        private async Task CleanTempFolderAsync()
        {
            if (!Directory.Exists(tempPath)) return;

            var files = await Task.Run(() => Directory.GetFiles(tempPath, "*", SearchOption.AllDirectories));
            var dirs = await Task.Run(() => Directory.GetDirectories(tempPath, "*", SearchOption.AllDirectories));

            foreach (var file in files)
            {
                try { await Task.Run(() => File.Delete(file)); } catch { }
            }

            foreach (var dir in dirs)
            {
                try { await Task.Run(() => Directory.Delete(dir, true)); } catch { }
            }
        }

        private long GetDirectorySize(string directory)
        {
            try
            {
                if (!Directory.Exists(directory)) return 0;
                var directoryInfo = new DirectoryInfo(directory);
                return directoryInfo.GetFiles("*", SearchOption.AllDirectories).Sum(file => file.Length) / (1024 * 1024);
            }
            catch { return 0; }
        }

        private async Task RunDiskCleanup()
        {
            try
            {
                var startInfo1 = new ProcessStartInfo("cmd", $"/c cleanmgr.exe /sageset:{cleanupSetNumber}") { CreateNoWindow = true, UseShellExecute = false };
                var startInfo2 = new ProcessStartInfo("cmd", $"/c cleanmgr.exe /sagerun:{cleanupSetNumber} /verylowdisk") { CreateNoWindow = true, UseShellExecute = false };

                using (var p1 = Process.Start(startInfo1)) { if (p1 != null) await Task.Run(() => p1.WaitForExit()); }
                using (var p2 = Process.Start(startInfo2)) { if (p2 != null) await Task.Run(() => p2.WaitForExit()); }
            }
            catch { }
        }
    }
}
