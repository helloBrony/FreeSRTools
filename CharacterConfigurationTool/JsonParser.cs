using System.Text.Json;

namespace CharacterConfigurationTool {
    public static class JsonParser {
        public static Dictionary<uint, CharacterModel> CharacterJsonParser() {
            string characterJsonStr = File.ReadAllText("./Resource/Character.json");
            var opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<Dictionary<uint, CharacterModel>>(characterJsonStr, opt);
        }
        public static Dictionary<uint, LightconeModel> LightconeJsonParser() {
            string lightconeJsonStr = File.ReadAllText("./Resource/Lightcone.json");
            var opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<Dictionary<uint, LightconeModel>>(lightconeJsonStr, opt);
        }
        public static Dictionary<uint, RelicSetModel> RelicSetJsonParser() {
            string relicSetJsonStr = File.ReadAllText("./Resource/RelicSet.json");
            var opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<Dictionary<uint, RelicSetModel>>(relicSetJsonStr, opt);
        }
        public static Dictionary<uint, Dictionary<uint, RelicMainAffixModel>> RelicMainAffixParser() {
            string relicMainAffixJsonStr = File.ReadAllText("./Resource/RelicMainAffix.json");
            var opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<Dictionary<uint, Dictionary<uint, RelicMainAffixModel>>>(relicMainAffixJsonStr, opt);
        }
        public static Dictionary<uint, RelicSubAffixModel> RelicSubAffixParser() {
            string relicSubAffixJsonStr = File.ReadAllText("./Resource/RelicSubAffix.json");
            var opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<Dictionary<uint, RelicSubAffixModel>>(relicSubAffixJsonStr, opt);
        }
    }

    public class CharacterModel {
        public string? Name { get; set; }
        public uint Rarity { get; set; }
        public double BaseHp { get; set; }
        public double BaseAtk { get; set; }
        public double BaseDef { get; set; }
        public double Spd { get; set; }
    }
    public class LightconeModel {
        public string? Name { get; set; }
        public uint Rarity { get; set; }
        public double BaseHp { get; set; }
        public double BaseAtk { get; set; }
        public double BaseDef { get; set; }
    }
    public class RelicSetModel {
        public string? Name { get; set; }
        public uint SetType { get; set; }
    }
    public class RelicMainAffixModel {
        public string? Name { get; set; }
        public double Base { get; set; }
        public double Add { get; set; }
    }
    public class RelicSubAffixModel {
        public string? Name { get; set; }
        public double Base { get; set; }
        public double Step { get; set; }
    }
}
