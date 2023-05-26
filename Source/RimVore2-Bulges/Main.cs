using HarmonyLib;
using Verse;

namespace RV2_Bulges
{
    [StaticConstructorOnStartup]
    internal static class Main
    {
        static Main()
        {
            new Harmony("Rut.RV2Bulges").PatchAll();
        }

        public const string Id = "Rut.RV2Bulges";

        public const string ModName = "RV2Bulges";

        public const string Version = "8.88";
    }
}
