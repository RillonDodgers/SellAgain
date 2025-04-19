using HarmonyLib;
using Il2CppScheduleOne.Economy;

namespace SellAgain.Patches;

[HarmonyPatch(typeof(Customer), "OfferDealValid")]
public static class OfferDealValidPatch {
    [HarmonyPrefix]
    public static bool Prefix(ref string invalidReason, ref bool __result) {
        invalidReason = string.Empty;
        __result = true;
        return false;
    }
}