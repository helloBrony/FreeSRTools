using System.Text.Json;

namespace CharacterConfigurationTool {
    public static class JsonParser {
        public static Dictionary<uint, CharacterModel> CharacterJsonParser() {
            string characterJsonStr = File.ReadAllText("./resource/character.json");
            var opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<Dictionary<uint, CharacterModel>>(characterJsonStr, opt);
        }

        public static Dictionary<uint, CharacterModel> LightconeJsonParser() {
            string lightconeJsonStr = File.ReadAllText("./resource/lightcone.json");
            var opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<Dictionary<uint, CharacterModel>>(lightconeJsonStr, opt);
        }
    }

    public class CharacterModel {
        public string? Name { get; set; }
        public uint Rarity { get; set; }
        public float BaseHp { get; set; }
        public float BaseAtk { get; set; }
        public float BaseDef { get; set; }
        public float Spd { get; set; }
    }

    public class LightconeModel {
        public string? Name { get; set; }
        public uint Rarity { get; set; }
        public float BaseHp { get; set; }
        public float BaseAtk { get; set; }
        public float BaseDef { get; set; }
    }
}
