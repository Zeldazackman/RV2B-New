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
            if (record.Predator.IsHumanoid())
            {
                if (!record.Predator.health.hediffSet.HasHediff(RV2B_Common.BellyBulge, false))
                    record.Predator.health.AddHediff(RV2B_Common.BellyBulge, null, null, null);
                if (!record.Predator.health.hediffSet.HasHediff(RV2B_Common.StomachBulge, false))
                    record.Predator.health.AddHediff(RV2B_Common.StomachBulge, null, null, null);
                if (!record.Predator.health.hediffSet.HasHediff(RV2B_Common.WombBulge, false))
                    record.Predator.health.AddHediff(RV2B_Common.WombBulge, null, null, null);
                if (!record.Predator.health.hediffSet.HasHediff(RV2B_Common.TestiesBulge, false))
                    record.Predator.health.AddHediff(RV2B_Common.TestiesBulge, null, null, null);
                if (!record.Predator.health.hediffSet.HasHediff(RV2B_Common.BreastBulge, false))
                    record.Predator.health.AddHediff(RV2B_Common.BreastBulge, null, null, null);
                if (!record.Predator.health.hediffSet.HasHediff(RV2B_Common.TailBulge, false))
                    record.Predator.health.AddHediff(RV2B_Common.TailBulge, null, null, null);
            }
        } // I know we're supposed to add the hediffs on pawn creation, but this works as a drop-in much better
    }     // And I know this looks real ugly; I'm not sure there's a cleaner way to do this
}
