using Verse;
using System;
using System.Linq;

namespace RV2_Bulges
{
    public static class RV2B_Common
    {
        public static readonly HediffDef Bulge = HediffDef.Named("RV2B_Bulge");

        public static readonly HediffDef BellyBulge = HediffDef.Named("RV2B_BellyBulge");
        public static readonly HediffDef StomachBulge = HediffDef.Named("RV2B_StomachBulge");
        public static readonly HediffDef IntestineBulge = HediffDef.Named("RV2B_IntestineBulge");
        public static readonly HediffDef WombBulge = HediffDef.Named("RV2B_WombBulge");
        public static readonly HediffDef TestiesBulge = HediffDef.Named("RV2B_TestiesBulge");
        public static readonly HediffDef BreastBulge = HediffDef.Named("RV2B_BreastBulge");
        public static readonly HediffDef TailBulge = HediffDef.Named("RV2B_TailBulge");

        public static readonly HediffDef BellyBulgeA = HediffDef.Named("RV2B_BellyBulgeAdv");
        public static readonly HediffDef StomachBulgeA = HediffDef.Named("RV2B_StomachBulgeAdv");
        public static readonly HediffDef IntestineBulgeA = HediffDef.Named("RV2B_IntestineBulgeAdv");
        public static readonly HediffDef WombBulgeA = HediffDef.Named("RV2B_WombBulgeAdv");
        public static readonly HediffDef TestiesBulgeA = HediffDef.Named("RV2B_TestiesBulgeAdv");
        public static readonly HediffDef BreastBulgeA = HediffDef.Named("RV2B_BreastBulgeAdv");
        public static readonly HediffDef TailBulgeA = HediffDef.Named("RV2B_TailBulgeAdv");

        public static readonly HediffDef[] BulgeHediffs = new HediffDef[14] {
            BellyBulge,StomachBulge,IntestineBulge,WombBulge,TestiesBulge,BreastBulge,TailBulge,BellyBulgeA,StomachBulgeA,IntestineBulgeA,WombBulgeA,TestiesBulgeA,BreastBulgeA,TailBulgeA
        };
    }
}
