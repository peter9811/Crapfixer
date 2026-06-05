using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.Gaming
{
    internal class VisualFX : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects";
        private const string valueName = "VisualFXSetting";

        public override string GetFeatureDetails() => $"{keyName} | Recommended: 2 (Best performance)";
        public override string ID() => "Optimize Visual Effects";
        public override string Info() => "Adjusts visual effects for best performance.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, 2));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, 2, RegistryValueKind.DWord, "Visual effects optimized");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 0, RegistryValueKind.DWord, "Visual effects restored to default");
    }
}
