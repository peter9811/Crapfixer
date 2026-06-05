using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.Edge
{
    public class BrowserSignin : FeatureBase
    {
        private const string keyName = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const string valueName = "BrowserSignin";

        public override string GetFeatureDetails() => $"{keyName} | Recommended: 0";
        public override string ID() => "Disable Edge Browser Sign-in";
        public override string Info() => "Disables browser sign-in in Microsoft Edge.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, valueName, 0));
        public override Task<bool> DoFeature() => RegistryHelper.SetValue(keyName, valueName, 0, RegistryValueKind.DWord, "Edge browser sign-in disabled");
        public override Task<bool> UndoFeature() => RegistryHelper.SetValue(keyName, valueName, 1, RegistryValueKind.DWord, "Edge browser sign-in enabled");
    }
}
