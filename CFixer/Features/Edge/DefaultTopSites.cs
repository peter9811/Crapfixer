using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.Edge
{
    public class DefaultTopSites : FeatureBase
    {
        private const string keyName = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const string valueName = "NewTabPageHideDefaultTopSites";

        public override string GetFeatureDetails() => $"{keyName} | Recommended: 1";
        public override string ID() => "Hide Default Top Sites in Edge";
        public override string Info() => "Hides default top sites on the new tab page in Microsoft Edge.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, 1));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, 1, RegistryValueKind.DWord, "Edge default top sites hidden");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 0, RegistryValueKind.DWord, "Edge default top sites shown");
    }
}
