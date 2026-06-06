using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.System
{
    internal class MenuShowDelay : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Control Panel\Desktop";
        private const string valueName = "MenuShowDelay";
        private const string recommendedValue = "0";

        public override string GetFeatureDetails() => $"{keyName} | Value: {valueName} | Recommended: {recommendedValue}";
        public override string ID() => "Reduce Menu Show Delay";
        public override string Info() => "Reduces the delay when menus appear.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.StringEquals(keyName, valueName, recommendedValue));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, recommendedValue, RegistryValueKind.String, "Menu Show Delay reduced");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, "400", RegistryValueKind.String, "Menu Show Delay restored to default");
    }
}
