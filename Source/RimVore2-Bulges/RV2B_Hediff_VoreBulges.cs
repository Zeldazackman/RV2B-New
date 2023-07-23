using RimVore2;
using RimWorld;
using System;
using System.Linq;
using Verse;

namespace RV2_Bulges
{
    public class RV2B_Hediff_VoreBulges : Hediff
    {
        public override float Severity
        {
            get
            {
                string[] validParts = new string[0];
                float num = severityInt = 0.01f;
                float mod;
                if (pawn.IsActivePredator()
                 && pawn.PawnData(true) != null
                 && pawn.PawnData(true).VoreTracker != null)
                {
                    if (Label == "Belly Bulge")
                        validParts = new string[5] {
                            "stomach",
                            "womb",
                            "oraries",
                            "intestines",
                            "torso"
                        };
                    if (Label == "Stomach Bulge")
                        validParts = new string[3] {
                            "stomach",
                            "womb",
                            "oraries"
                        };
                    if (Label == "Intestine Bulge")
                        validParts = new string[1] {
                            "intestines"
                        };
                    if (Label == "Womb Bulge")
                        validParts = new string[2] {
                            "womb",
                            "oraries"
                        };
                    if (Label == "Cock Bulge")
                        validParts = new string[1] {
                            "cock"
                        };
                    if (Label == "Testies Bulge")
                        validParts = new string[1] {
                            "testicles"
                        };
                    if (Label == "Breast Bulge")
                        validParts = new string[2] {
                            "breast",
                            "cleaveage"
                        };
                    if (Label == "Tail Bulge")
                        validParts = new string[2] {
                            "tail",
                            "tail throat"
                        };
                    if (Label == "bulge")
                        return 0f;

                    foreach (VoreTrackerRecord voreTrackerRecord in pawn.PawnData(true).VoreTracker.VoreTrackerRecords)
                    {
                        if (validParts.Contains(voreTrackerRecord.CurrentVoreStage.def.DisplayPartName))
                        {
                            mod = 1f;
                            if (voreTrackerRecord.Prey.IsHumanoid())
                                mod = (voreTrackerRecord.Prey.story.bodyType == BodyTypeDefOf.Fat ? 1.25f : (voreTrackerRecord.Prey.story.bodyType == BodyTypeDefOf.Thin ? 0.8f : 1f));
                            num += voreTrackerRecord.Prey.BodySize * mod;
                            if (voreTrackerRecord.Prey.IsActivePredator()
                             && voreTrackerRecord.Prey.PawnData(true) != null
                             && voreTrackerRecord.Prey.PawnData(true).VoreTracker != null)
                                foreach (VoreTrackerRecord voreTrackerRecord2 in voreTrackerRecord.Prey.PawnData(true).VoreTracker.VoreTrackerRecords)
                                {
                                    mod = 1f;
                                    if (voreTrackerRecord2.Prey.IsHumanoid())
                                        mod = (voreTrackerRecord2.Prey.story.bodyType == BodyTypeDefOf.Fat ? 1.25f : (voreTrackerRecord2.Prey.story.bodyType == BodyTypeDefOf.Thin ? 0.8f : 1f));
                                    num += voreTrackerRecord2.Prey.BodySize * mod;
                                }
                        }

                        severityInt = Math.Min(2f, num / pawn.BodySize);
                    }
                }
                return severityInt;
            }
        }

        public override bool Visible
        {
            get
            {
                if (Prefs.DevMode)
                    return true;

                return false;
            }
        }
        public override string SeverityLabel
        {
            get
            {
                if (Prefs.DevMode)
                    return Severity.ToString();

                return null;
            }
        }

        public override void Tick()
        {
            base.Tick();
        }
    }
}
