using System.IO;
using System.Reflection;
using System.Text.Json;


namespace SellAgain {
    public class ModConfig {
        public int dealCooldown { get; set; } = 360;
        public bool allowSellingAfterCompletedDeal { get; set; } = true;
        public bool allowSellingWithPendingContract { get; set; } = true;
        public bool allowOfferingAgain { get; set; } = true;
    }

    public static class Config {
        private static string ConfigPath => Path.Combine(ModDirectory, "SellAgainConfig.json");

        private static readonly string ModDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static ModConfig Data { get; private set; }

        public static void Init() {
            if (!File.Exists(ConfigPath)) {
                Data = new ModConfig();
                Save();
            } else {
                Load();
            }
        }

        public static void Load() {
            try {
                var json = File.ReadAllText(ConfigPath);
                Data = JsonSerializer.Deserialize<ModConfig>(json);
            } catch {
                Data = new ModConfig();
            }
        }

        public static void Save() {
            var json = JsonSerializer.Serialize(Data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ConfigPath, json);
        }

        public static void Reload() => Load();
    }
}