using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.System
{
    internal class VerboseStatus : FeatureBase
    {
        private const string keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";
        private const string valueName = "VerboseStatus";
        private const int recommendedValue = 1;

        public override string GetFeatureDetails() => $"{keyName} | Value: {valueName} | Recommended: {recommendedValue}";
        public override string ID() => "Verbose Status Messages";
        public override string Info() => "Enables verbose status messages during startup and shutdown.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, recommendedValue));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, recommendedValue, RegistryValueKind.DWord, "Verbose Status enabled");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 0, RegistryValueKind.DWord, "Verbose Status disabled");
    }
}
