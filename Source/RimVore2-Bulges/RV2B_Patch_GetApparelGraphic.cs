using HarmonyLib;
using RimVore2;
using RimWorld;
using System;
using UnityEngine;
using Verse;

namespace RV2_Bulges
{
    [StaticConstructorOnStartup]
    [HarmonyPatch(typeof(ApparelGraphicRecordGetter), "TryGetGraphicApparel")]
    [HarmonyBefore(new string[] { "QualityOfBuilding" })]
    public partial class RV2B_Patch_GetApparelGraphic
    {
        public static void Postfix(Apparel apparel, BodyTypeDef bodyType, ref ApparelGraphicRecord rec, ref bool __result)
        {
            bool ignore02 = false;
            if (!__result
             || apparel == null
             || bodyType == null
             || !apparel.Wearer.IsActivePredator()
             || !apparel.Wearer.health.hediffSet.HasHediff(RV2B_Common.BellyBulge, false))
                return;

            float bulgeSeverity = apparel.Wearer.health.hediffSet.GetFirstHediffOfDef(RV2B_Common.BellyBulge, false).Severity;
            if (bulgeSeverity >= 0.2f)
            {
                string path = rec.graphic.path;
                if (path == null)
                    return;

                int severityMod = (int)Math.Floor((double)(bulgeSeverity * 5f));
                if (ContentFinder<Texture2D>.Get(path + apparel.Wearer.kindDef.race.defName + "_bulged", false) != null) // eg, Things/Pawn/Humanlike/Apparel/FlakJacket/FlakJacket_Human_bulged.png
                {
                    Graphic graphic = GraphicDatabase.Get<Graphic_Multi>(path + apparel.Wearer.kindDef.race.defName + "_bulged", rec.graphic.Shader, rec.graphic.drawSize, rec.graphic.color, rec.graphic.colorTwo);
                    if (ContentFinder<Texture2D>.Get(path + apparel.Wearer.kindDef.race.defName + "_bulged_" + severityMod.ToString(), false) != null) // eg, Things/Pawn/Humanlike/Apparel/FlakJacket/FlakJacket_Human_bulged_1.png
                        graphic = GraphicDatabase.Get<Graphic_Multi>(path + apparel.Wearer.kindDef.race.defName + "_bulged_" + severityMod.ToString(), rec.graphic.Shader, rec.graphic.drawSize, rec.graphic.color, rec.graphic.colorTwo);
                    else
                    {
                        int i = severityMod;
                        Graphic found = null;
                        while (i > 1)
                        {
                            i--;
                            if (ContentFinder<Texture2D>.Get(path + apparel.Wearer.kindDef.race.defName + "_bulged_" + i.ToString(), false) != null)
                            {
                                found = GraphicDatabase.Get<Graphic_Multi>(path + apparel.Wearer.kindDef.race.defName + "_bulged_" + i.ToString(), rec.graphic.Shader, rec.graphic.drawSize, rec.graphic.color, rec.graphic.colorTwo);
                                break;
                            }

                        }
                        if (found == null)
                            ignore02 = true;
                    }

                    if (graphic != null
                    && (severityMod > 1
                      || !ignore02))
                    {
                        rec = new ApparelGraphicRecord(graphic, rec.sourceApparel);
                        return;
                    }
                    return;
                }
                else if (ContentFinder<Texture2D>.Get(path + "_bulged", false) != null) // eg, Things/Pawn/Humanlike/Apparel/FlakJacket/FlakJacket_bulged.png
                {
                    Graphic graphic2 = GraphicDatabase.Get<Graphic_Multi>(path + "_bulged", rec.graphic.Shader, rec.graphic.drawSize, rec.graphic.color, rec.graphic.colorTwo);
                    if (ContentFinder<Texture2D>.Get(path + "_bulged_" + severityMod.ToString(), false) != null) // eg, Things/Pawn/Humanlike/Apparel/FlakJacket/FlakJacket_bulged_1.png
                        graphic2 = GraphicDatabase.Get<Graphic_Multi>(path + "_bulged_" + severityMod.ToString(), rec.graphic.Shader, rec.graphic.drawSize, rec.graphic.color, rec.graphic.colorTwo);
                    else
                    {
                        int j = severityMod;
                        Graphic found2 = null;
                        while (j > 1)
                        {
                            j--;
                            if (ContentFinder<Texture2D>.Get(path + "_bulged_" + j.ToString(), false) != null)
                            {
                                found2 = GraphicDatabase.Get<Graphic_Multi>(path + "_bulged_" + j.ToString(), rec.graphic.Shader, rec.graphic.drawSize, rec.graphic.color, rec.graphic.colorTwo);
                                break;
                            }

                        }
                        if (found2 == null)
                            ignore02 = true;
                    }

                    if (graphic2 != null
                     && (severityMod > 1
                      || !ignore02))
                    {
                        rec = new ApparelGraphicRecord(graphic2, rec.sourceApparel);
                        return;
                    }
                    return;
                }
            }
        }
    }
}
