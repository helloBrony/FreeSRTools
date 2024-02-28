using System.Text.Json;

namespace CharacterConfigurationTool {
    public static class MenuBar {
        public static void ExportCharacterConfig() {
            var characterConfig = new CharacterConfig();
            characterConfig.Id = Character.Id;
            characterConfig.Level = Character.Level;
            characterConfig.Promotion = Character.Promotion;
            characterConfig.Rank = Character.Rank;
            characterConfig.Equipment.Id = Character.EquipmentLightcone.Id;
            characterConfig.Equipment.Level = Character.EquipmentLightcone.Level;
            characterConfig.Equipment.Promotion = Character.EquipmentLightcone.Promotion;
            characterConfig.Equipment.Rank = Character.EquipmentLightcone.Rank;
            foreach (var relic in Character.RelicList) {
                characterConfig.RelicList.Add(new RelicConfig {
                    Id = relic.Id,
                    SetId = relic.SetId,
                    Type = relic.Type,
                    Level = relic.Level,
                    MainAffixId = relic.MainAffixId
                });
                foreach (var subAffix in relic.SubAffixList) {
                    characterConfig.RelicList[Character.RelicList.IndexOf(relic)].SubAffixList.Add(new RelicSubAffixConfig {
                        SubAffixId = subAffix.SubAffixId,
                        Cnt = subAffix.Cnt,
                        Step = subAffix.Step
                    });
                }
            }
            string characterConfigJson = JsonSerializer.Serialize(characterConfig, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText($"./{characterConfig.Id}.json", characterConfigJson);
        }
    }

    class CharacterConfig {
        public uint Id { get; set; }
        public uint Level { get; set; }
        public uint Promotion { get; set; }
        public uint Rank { get; set; }
        public EquipmentConfig Equipment { get; set; } = new EquipmentConfig();
        public List<RelicConfig> RelicList { get; set; } = new List<RelicConfig>();

    }
    class EquipmentConfig {
        public uint Id { get; set; }
        public uint Level { get; set; }
        public uint Promotion { get; set; }
        public uint Rank { get; set; }
    }
    class RelicConfig {
        public uint Id { get; set; }
        public uint SetId { get; set; }
        public uint Type { get; set; }
        public uint Level { get; set; }
        public uint MainAffixId { get; set; }
        public List<RelicSubAffixConfig> SubAffixList { get; set; } = new List<RelicSubAffixConfig>();

    }
    public class RelicSubAffixConfig {
        public uint SubAffixId { get; set; }
        public uint Cnt { get; set; }
        public uint Step { get; set; }
    }
}
