using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.Ads
{
    internal class TailoredExperiences : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Privacy";
        private const string valueName = "TailoredExperiencesWithDiagnosticDataEnabled";
        private const int recommendedValue = 0;

        public override string GetFeatureDetails() => $"{keyName} | Value: {valueName} | Recommended: {recommendedValue}";
        public override string ID() => "Disable Tailored Experiences";
        public override string Info() => "Disables personalized tips and recommendations based on diagnostic data.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, recommendedValue));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, 0, RegistryValueKind.DWord, "Tailored experiences disabled");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 1, RegistryValueKind.DWord, "Tailored experiences enabled");
    }
}
