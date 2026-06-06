using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.UI
{
    internal class FullContextMenus : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32";

        public override string GetFeatureDetails() => keyName;
        public override string ID() => "Enable Windows 10 Full Context Menus";
        public override string Info() => "Restores the classic full context menus in Windows 11.";

        public override Task<bool> CheckFeature()
        {
            object value = Registry.GetValue(keyName, "", null);
            return Task.FromResult(value != null);
        }

        public override async Task<bool> DoFeature()
        {
            bool ok = await RegistryHelper.SetValue(keyName, "", "", RegistryValueKind.String, "Full Context Menus enabled");
            if (ok) Utils.RestartExplorer();
            return ok;
        }

        public override async Task<bool> UndoFeature()
        {
            bool ok = await RegistryHelper.DeleteValue(@"HKEY_CURRENT_USER\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}", "", "Full Context Menus disabled");
            if (ok) Utils.RestartExplorer();
            return ok;
        }
    }
}
