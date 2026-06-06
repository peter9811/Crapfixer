using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.System
{
    internal class NetworkThrottling : FeatureBase
    {
        private const string keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile";
        private const string valueName = "NetworkThrottlingIndex";

        public override string GetFeatureDetails() => $"{keyName} | Value: {valueName} | Recommended: 0xffffffff";
        public override string ID() => "Disable Network Throttling";
        public override string Info() => "Disables network throttling for improved gaming performance.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, -1));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, -1, RegistryValueKind.DWord, "Network Throttling disabled");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 10, RegistryValueKind.DWord, "Network Throttling enabled (default)");
    }
}
