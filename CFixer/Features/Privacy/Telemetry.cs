using Microsoft.Win32;
using CrapFixer;
using System.Threading.Tasks;

namespace Settings.Privacy
{
    public class Telemetry : FeatureBase
    {
        private const string dataCollection = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\DataCollection";
        private const string diagTrack = @"HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Services\DiagTrack";

        public override string ID() => "Turn off Telemetry data collection";
        public override string Info() => "Turns off telemetry data collection and prevents sending it to Microsoft.";
        public override string GetFeatureDetails() => $"{dataCollection} | {diagTrack}";

        public override Task<bool> CheckFeature() => Task.FromResult(Utils.IntEquals(dataCollection, "AllowTelemetry", 0) && Utils.IntEquals(diagTrack, "Start", 4));

        public override async Task<bool> DoFeature()
        {
            bool r1 = await RegistryHelper.SetValue(dataCollection, "AllowTelemetry", 0, RegistryValueKind.DWord);
            bool r2 = await RegistryHelper.SetValue(diagTrack, "Start", 4, RegistryValueKind.DWord);
            return r1 && r2;
        }

        public override async Task<bool> UndoFeature()
        {
            bool r1 = await RegistryHelper.SetValue(dataCollection, "AllowTelemetry", 1, RegistryValueKind.DWord);
            bool r2 = await RegistryHelper.SetValue(diagTrack, "Start", 2, RegistryValueKind.DWord);
            return r1 && r2;
        }
    }
}
