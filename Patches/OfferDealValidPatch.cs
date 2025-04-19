using HarmonyLib;
using Il2CppScheduleOne.Economy;

namespace SellAgain.Patches;

[HarmonyPatch(typeof(Customer), "OfferDealValid")]
public static class OfferDealValidPatch {
    [HarmonyPrefix]
    public static bool Prefix(Customer __instance, ref string invalidReason, ref bool __result) {
        Config.Reload();

        var cfg = Config.Data;
        invalidReason = string.Empty;

        if (!cfg.allowSellingAfterCompletedDeal && __instance.TimeSinceLastDealCompleted < cfg.dealCooldown) {
            invalidReason = "Customer recently completed a deal";
            __result = false;
            return false;
        }

        if (!cfg.allowSellingWithPendingContract && __instance.OfferedContractInfo != null) {
            invalidReason = "Customer already has a pending offer";
            __result = false;
            return false;
        }

        if (!cfg.allowOfferingAgain && __instance.TimeSinceInstantDealOffered < cfg.dealCooldown && !__instance.pendingInstantDeal) {
            invalidReason = "Already recently offered";
            __result = false;
            return false;
        }

        __result = true;
        return false;
    }
}
