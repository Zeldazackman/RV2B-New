using HarmonyLib;
using RimVore2;

namespace RV2_Bulges
{
    [HarmonyPatch(typeof(PreVoreUtility), "PopulateRecord")]
    public class RV2B_Patch_GiveBulgeHediff
    {
        [HarmonyPostfix]
        private static void RV2B_GiveBulgeHediff(ref VoreTrackerRecord record)
        {
            if (!record.Predator.health.hediffSet.HasHediff(RV2B_Common.Bulge, false))
                record.Predator.health.AddHediff(RV2B_Common.Bulge, null, null, null);
        } // I know we're supposed to add the hediffs on pawn creation, but this works as a drop-in much better
    }
}
