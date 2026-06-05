using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.Gaming
{
    internal class PowerThrottling : FeatureBase
    {
        private const string keyName = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power\PowerThrottling";
        private const string valueName = "PowerThrottlingOff";

        public override string GetFeatureDetails() => $"{keyName} | Recommended: 1";
        public override string ID() => "Disable Power Throttling";
        public override string Info() => "Disables power throttling for improved system performance.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, 1));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, 1, RegistryValueKind.DWord, "Power throttling disabled");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 0, RegistryValueKind.DWord, "Power throttling enabled");
    }
}
