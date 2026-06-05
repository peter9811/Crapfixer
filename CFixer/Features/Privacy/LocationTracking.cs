using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.Privacy
{
    internal class LocationTracking : FeatureBase
    {
        private const string keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location";
        private const string valueName = "Value";

        public override string GetFeatureDetails() => $"{keyName} | Value: {valueName} | Recommended: Deny";
        public override string ID() => "Disable Location Tracking";
        public override string Info() => "Disables app access to your location.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.StringEquals(keyName, valueName, "Deny"));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, "Deny", RegistryValueKind.String, "Location tracking disabled");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, "Allow", RegistryValueKind.String, "Location tracking enabled");
    }
}
