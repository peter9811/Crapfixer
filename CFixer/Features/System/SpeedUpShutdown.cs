using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.System
{
    internal class SpeedUpShutdown : FeatureBase
    {
        private const string keyName = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control";
        private const string valueName = "WaitToKillServiceTimeout";
        private const string recommendedValue = "1000";

        public override string GetFeatureDetails() => $"{keyName} | Value: {valueName} | Recommended: {recommendedValue} ms";
        public override string ID() => "Speed Up Shutdown Time";
        public override string Info() => "Reduces the time Windows waits for services to stop during shutdown.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.StringEquals(keyName, valueName, recommendedValue));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, recommendedValue, RegistryValueKind.String, "Shutdown time speeded up");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, "5000", RegistryValueKind.String, "Shutdown time restored to default");
    }
}
