using MelonLoader;

[assembly: MelonInfo(typeof(SellAgain.Main), "Sell Again", "1.1.0", "Dillon Rodgers")]
[assembly: MelonGame("TVGS", "Schedule I")]

namespace SellAgain {
    public class Main : MelonMod {
        
        public override void OnInitializeMelon() {
            LoggerInstance.Msg("Initializing SellAgain mod with configuration...");
            Config.Init();
            new HarmonyLib.Harmony("com.sellagain").PatchAll();
            LoggerInstance.Msg("Initialized.");
        }
    }
}