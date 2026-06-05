using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.Edge
{
    public class FirstRunExperience : FeatureBase
    {
        private const string keyName = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const string valueName = "HideFirstRunExperience";

        public override string GetFeatureDetails() => $"{keyName} | Recommended: 1";
        public override string ID() => "Disable Edge First Run Experience";
        public override string Info() => "Hides the first-run experience in Microsoft Edge.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, 1));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, 1, RegistryValueKind.DWord, "Edge First Run Experience disabled");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 0, RegistryValueKind.DWord, "Edge First Run Experience enabled");
    }
}
