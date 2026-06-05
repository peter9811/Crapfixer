using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.Edge
{
    public class ImportOnEachLaunch : FeatureBase
    {
        private const string keyName = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const string valueName = "ImportOnEachLaunch";

        public override string GetFeatureDetails() => $"{keyName} | Recommended: 0";
        public override string ID() => "Disable Edge Data Import";
        public override string Info() => "Prevents Edge from importing data on each launch.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, 0));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, 0, RegistryValueKind.DWord, "Edge data import disabled");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 1, RegistryValueKind.DWord, "Edge data import enabled");
    }
}
