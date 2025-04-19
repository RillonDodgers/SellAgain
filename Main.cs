using MelonLoader;

[assembly: MelonInfo(typeof(SellAgain.Main), "Sell Again", "1.0.0", "Dillon Rodgers")]
[assembly: MelonGame("TVGS", "Schedule I")]

namespace SellAgain {
    public class Main : MelonMod {
        
        public override void OnInitializeMelon() {
            LoggerInstance.Msg("Initialized.");
            new HarmonyLib.Harmony("com.sellagain").PatchAll();
        }
    }
}