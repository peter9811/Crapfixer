using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.System
{
    internal class TaskbarEndTask : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
        private const string valueName = "TaskbarEndTask";
        private const int recommendedValue = 1;

        public override string GetFeatureDetails() => $"{keyName} | Value: {valueName} | Recommended: {recommendedValue}";
        public override string ID() => "Enable Taskbar End Task";
        public override string Info() => "Adds an 'End Task' option to the taskbar right-click menu.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, recommendedValue));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, recommendedValue, RegistryValueKind.DWord, "Taskbar End Task enabled");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 0, RegistryValueKind.DWord, "Taskbar End Task disabled");
    }
}
