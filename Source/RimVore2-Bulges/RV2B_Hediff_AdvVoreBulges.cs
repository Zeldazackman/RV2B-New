using RimVore2;
using RimWorld;
using System;
using System.Linq;
using Verse;

namespace RV2_Bulges
{
    internal class RV2B_Hediff_AdvVoreBulges : Hediff
    {
        public override float Severity
        {
            get
            {
                float totalPrey = 0f;
                float goalPriority = 0.0f;
                float bodyType = 0.00f;
                string[] validParts;
                if (pawn.IsActivePredator()
                 && pawn.PawnData(true) != null
                 && pawn.PawnData(true).VoreTracker != null)
                {
                    if (Label == "Belly")
                        validParts = new string[5] {
                            "stomach",
                            "womb",
                            "oraries",
                            "intestines",
                            "torso"
                        };
                    if (Label == "Stomach")
                        validParts = new string[1] {
                            "stomach"
                        };
                    if (Label == "Intestine")
                        validParts = new string[1] {
                            "intestines"
                        };
                    if (Label == "Womb")
                        validParts = new string[2] {
                            "womb",
                            "oraries"
                        };
                    if (Label == "Cock")
                        validParts = new string[1] {
                            "cock"
                        };
                    if (Label == "Testies")
                        validParts = new string[1] {
                            "testicles"
                        };
                    if (Label == "Breasts")
                        validParts = new string[2] {
                            "breast",
                            "cleaveage"
                        };
                    if (Label == "Tail")
                        validParts = new string[2] {
                            "tail",
                            "tail throat"
                        };
                    else
                        return 0f;

                    foreach (VoreTrackerRecord voreTrackerRecord in pawn.PawnData(true).VoreTracker.VoreTrackerRecords)
                    {
                        if (validParts.Contains(voreTrackerRecord.CurrentVoreStage.def.DisplayPartName))
                        {
                            totalPrey += 1f;
                            String goal = voreTrackerRecord.CurrentVoreStage.def.partGoal.ToLower();
                            if (goalPriority < 0.1f && goal == "hold" || goal == "store" || goal == "heal" || goal == "pass")
                                goalPriority = 0.1f;
                            if (goalPriority < 0.2f && goal == "pleasure" || goal == "warm up")
                                goalPriority = 0.2f;
                            if (goalPriority < 0.3f && goal == "digest" || goal == "convert" || goal == "dissolve" || goal == "process")
                                goalPriority = 0.3f;

                            if (voreTrackerRecord.Prey.story.bodyType == BodyTypeDefOf.Female)
                                bodyType = 0.01f;
                            if (voreTrackerRecord.Prey.story.bodyType == BodyTypeDefOf.Thin)
                                bodyType = 0.02f;
                            if (voreTrackerRecord.Prey.story.bodyType == BodyTypeDefOf.Hulk)
                                bodyType = 0.03f;
                            if (voreTrackerRecord.Prey.story.bodyType == BodyTypeDefOf.Fat)
                                bodyType = 0.04f;

                            if (voreTrackerRecord.Prey.IsActivePredator()
                             && voreTrackerRecord.Prey.PawnData(true) != null
                             && voreTrackerRecord.Prey.PawnData(true).VoreTracker != null)
                                foreach (VoreTrackerRecord voreTrackerRecord2 in voreTrackerRecord.Prey.PawnData(true).VoreTracker.VoreTrackerRecords)
                                {
                                    totalPrey += 1f;
                                }
                        }
                    }
                }
                return totalPrey + goalPriority + bodyType + Rand.Range(0.000f, 0.009f);
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
