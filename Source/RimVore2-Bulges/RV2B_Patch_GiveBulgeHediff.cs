using HarmonyLib;
using RimWorld;
using RimVore2;
using Verse;

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
                foreach (HediffDef hediff in RV2B_Common.BulgeHediffs)
                {

                    if (!record.Predator.health.hediffSet.HasHediff(hediff))
                        record.Predator.health.AddHediff(hediff);

                }
            }
        }
    }
}
