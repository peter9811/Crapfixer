using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.System
{
    internal class SystemResponsiveness : FeatureBase
    {
        private const string keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile";
        private const string valueName = "SystemResponsiveness";
        private const int recommendedValue = 10;

        public override string GetFeatureDetails() => $"{keyName} | Value: {valueName} | Recommended: {recommendedValue}";
        public override string ID() => "Optimize System Responsiveness";
        public override string Info() => "Prioritizes CPU resources for foreground tasks.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, recommendedValue));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, recommendedValue, RegistryValueKind.DWord, "System Responsiveness optimized");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 20, RegistryValueKind.DWord, "System Responsiveness restored to default");
    }
}
