using RimVore2;
using System;
using Verse;

namespace RV2_Bulges
{
    public class RV2B_Hediff_VoreBulges : Hediff
    {
        public override float Severity
        {
            get
            {
                float num = severityInt = 0.01f;
                if (pawn.IsActivePredator()
                 && pawn.PawnData(true) != null
                 && pawn.PawnData(true).VoreTracker != null)
                    foreach (VoreTrackerRecord voreTrackerRecord in pawn.PawnData(true).VoreTracker.VoreTrackerRecords)
                    {
                        if (voreTrackerRecord.CurrentVoreStage.def.DisplayPartName == "stomach"
                         || voreTrackerRecord.CurrentVoreStage.def.DisplayPartName == "intestines"
                         || voreTrackerRecord.CurrentVoreStage.def.DisplayPartName == "womb")
                        {
                            num += voreTrackerRecord.Prey.BodySize;
                            if (voreTrackerRecord.Prey.IsActivePredator()
                             && voreTrackerRecord.Prey.PawnData(true) != null
                             && voreTrackerRecord.Prey.PawnData(true).VoreTracker != null)
                                foreach (VoreTrackerRecord voreTrackerRecord2 in voreTrackerRecord.Prey.PawnData(true).VoreTracker.VoreTrackerRecords)
                                {
                                    num += voreTrackerRecord2.Prey.BodySize;
                                }
                        }

                        severityInt = Math.Min(2f, num / pawn.BodySize);
                    }
                return severityInt;
            }
        }

        public override bool Visible
        {
            get
            {
                return false;
            }
        }

        public override void Tick()
        {
            base.Tick();
            if (ageTicks % (RV2Mod.Settings.debug.HediffLabelRefreshInterval * 30) == 0)
                pawn.health.capacities.Notify_CapacityLevelsDirty(); // Pawns sometimes ignore how their moving capacity changes, and I'm not sure why
        }
    }
}
