using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.System
{
    internal class BSODDetails : FeatureBase
    {
        private const string keyName = @"HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\CrashControl";

        public override string GetFeatureDetails() => $"{keyName} | DisplayParameters, DisplayStatus";
        public override string ID() => "Show BSOD Details";
        public override string Info() => "Enables detailed information on the Blue Screen of Death.";
        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(keyName, "DisplayParameters", 1));

        public override async Task<bool> DoFeature()
        {
            bool r1 = await RegistryHelper.SetValue(keyName, "DisplayParameters", 1, RegistryValueKind.DWord);
            bool r2 = await RegistryHelper.SetValue(keyName, "DisplayStatus", 1, RegistryValueKind.DWord);
            return r1 && r2;
        }

        public override async Task<bool> UndoFeature()
        {
            bool r1 = await RegistryHelper.SetValue(keyName, "DisplayParameters", 0, RegistryValueKind.DWord);
            bool r2 = await RegistryHelper.SetValue(keyName, "DisplayStatus", 0, RegistryValueKind.DWord);
            return r1 && r2;
        }
    }
}
