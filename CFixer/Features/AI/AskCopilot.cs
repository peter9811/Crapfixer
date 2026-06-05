using CrapFixer;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Settings.AI
{
    internal class AskCopilot : FeatureBase
    {
        private const string keyName = @"HKEY_CURRENT_USER\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32";

        public override string GetFeatureDetails() => "Disable 'Ask Copilot' in context menus";
        public override string ID() => "Disable Ask Copilot";
        public override string Info() => "Removes 'Ask Copilot' from context menus.";
        public override Task<bool> CheckFeature() => Task.FromResult(true);
        public override Task<bool> DoFeature() => Task.FromResult(true);
        public override Task<bool> UndoFeature() => Task.FromResult(true);
    }
}
