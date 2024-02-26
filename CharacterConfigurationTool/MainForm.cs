namespace CharacterConfigurationTool {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void fMain_Load(object sender, EventArgs e) {
            var characterDataDict = JsonParser.CharacterJsonParser();
            foreach (var kvp in characterDataDict) {
                var characterData = kvp.Value;
                cboxCharacterSelect.Items.Add(characterData.Name);
            }

            var lightconeDataDict = JsonParser.LightconeJsonParser();
            foreach (var kvp in lightconeDataDict) {
                var lightconeData = kvp.Value;
                cboxLightconeSelect.Items.Add(lightconeData.Name);
            }

            var relicSetDataDict = JsonParser.RelicSetJsonParser();
            foreach (var kvp in relicSetDataDict) {
                var relicSetData = kvp.Value;
                if (relicSetData.SetType == 2) {
                    cboxRelicNeckSet.Items.Add(relicSetData.Name);
                    cboxRelicObjectSet.Items.Add(relicSetData.Name);
                } else if (relicSetData.SetType == 4) {
                    cboxRelicHeadSet.Items.Add(relicSetData.Name);
                    cboxRelicHandSet.Items.Add(relicSetData.Name);
                    cboxRelicBodySet.Items.Add(relicSetData.Name);
                    cboxRelicFootSet.Items.Add(relicSetData.Name);
                }
            }

            cboxCharacterSelect.SelectedIndex = 0;
            cboxCharacterRank.SelectedIndex = 0;
            cboxLightconeSelect.SelectedIndex = 0;
            cboxLightconeRank.SelectedIndex = 0;
            cboxRelicHeadSet.SelectedIndex = 0;
            cboxRelicHandSet.SelectedIndex = 0;
            cboxRelicBodySet.SelectedIndex = 0;
            cboxRelicFootSet.SelectedIndex = 0;
            cboxRelicNeckSet.SelectedIndex = 0;
            cboxRelicObjectSet.SelectedIndex = 0;
            cboxRelicHeadMainAffix.SelectedIndex = 0;
            cboxRelicHandMainAffix.SelectedIndex = 0;
            cboxRelicBodyMainAffix.SelectedIndex = 0;
            cboxRelicFootMainAffix.SelectedIndex = 0;
            cboxRelicNeckMainAffix.SelectedIndex = 0;
            cboxRelicObjectMainAffix.SelectedIndex = 0;
            cboxRelicHeadLevel.SelectedIndex = 15;
            cboxRelicHandLevel.SelectedIndex = 15;
            cboxRelicBodyLevel.SelectedIndex = 15;
            cboxRelicFootLevel.SelectedIndex = 15;
            cboxRelicNeckLevel.SelectedIndex = 15;
            cboxRelicObjectLevel.SelectedIndex = 15;
        }

        private void cboxCharacterSelect_SelectedIndexChanged(object sender, EventArgs e) {
            if (cboxCharacterSelect.Items.Contains(cboxCharacterSelect.SelectedItem)) {
                var characterDataDict = JsonParser.CharacterJsonParser();
                foreach (var kvp in characterDataDict) {
                    var characterData = kvp.Value;
                    if (characterData.Name == cboxCharacterSelect.SelectedItem.ToString()) {
                        Character.Id = kvp.Key;
                        Character.Level = 80;
                        Character.Promotion = 6;
                        Character.BaseHp = characterData.BaseHp;
                        Character.BaseAtk = characterData.BaseAtk;
                        Character.BaseDef = characterData.BaseDef;
                        Character.BaseSpd = characterData.Spd;

                        Console.WriteLine($"Character:{Character.Id}, HP:{Character.BaseHp}, ATK:{Character.BaseAtk}, DEF:{Character.BaseDef}, SPD:{Character.BaseSpd}");

                        break;
                    }
                }
                AttributeCalculator.DetailsCalculator();
            }
        }

        private void cboxCharacterRank_SelectedIndexChanged(object sender, EventArgs e) {
            Character.Rank = (uint)cboxCharacterRank.SelectedIndex;
        }

        private void cboxLightconeSelect_SelectedIndexChanged(object sender, EventArgs e) {
            if (cboxCharacterSelect.Items.Contains(cboxCharacterSelect.SelectedItem)) {
                if (cboxLightconeSelect.SelectedIndex == 0) {
                    Character.EquipmentLightcone.Id = 0;
                    Character.EquipmentLightcone.Level = 0;
                    Character.EquipmentLightcone.Promotion = 0;
                    Character.EquipmentLightcone.BaseHp = 0;
                    Character.EquipmentLightcone.BaseAtk = 0;
                    Character.EquipmentLightcone.BaseDef = 0;
                } else {
                    var lightconeDataDict = JsonParser.LightconeJsonParser();
                    foreach (var kvp in lightconeDataDict) {
                        var lightconeData = kvp.Value;
                        if (kvp.Value.Name == cboxLightconeSelect.SelectedItem.ToString()) {
                            Character.EquipmentLightcone.Id = kvp.Key;
                            Character.EquipmentLightcone.Level = 80;
                            Character.EquipmentLightcone.Promotion = 6;
                            Character.EquipmentLightcone.BaseHp = lightconeData.BaseHp;
                            Character.EquipmentLightcone.BaseAtk = lightconeData.BaseAtk;
                            Character.EquipmentLightcone.BaseDef = lightconeData.BaseDef;

                            Console.WriteLine($"Lightcone:{Character.Id}, HP:{Character.EquipmentLightcone.BaseHp}, ATK:{Character.EquipmentLightcone.BaseAtk}, DEF:{Character.EquipmentLightcone.BaseDef}");

                            break;
                        }
                    }
                }
                AttributeCalculator.DetailsCalculator();
            }
        }

        private void cboxLightconeRank_SelectedIndexChanged(object sender, EventArgs e) {
            Character.EquipmentLightcone.Rank = (uint)cboxCharacterRank.SelectedIndex + 1;
        }

        private void cboxRelicHeadSet_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSetChange(1, cboxRelicHeadSet);
            RelicTools.RelicMainAffixChange(1, cboxRelicHeadMainAffix, cboxRelicHeadLevel, lblRelicHeadMainAffixValue);
        }

        private void cboxRelicHandSet_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSetChange(2, cboxRelicHandSet);
            RelicTools.RelicMainAffixChange(2, cboxRelicHandMainAffix, cboxRelicHandLevel, lblRelicHandMainAffixValue);
        }

        private void cboxRelicBodySet_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSetChange(3, cboxRelicBodySet);
            RelicTools.RelicMainAffixChange(3, cboxRelicBodyMainAffix, cboxRelicBodyLevel, lblRelicBodyMainAffixValue);
        }

        private void cboxRelicFootSet_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSetChange(4, cboxRelicFootSet);
            RelicTools.RelicMainAffixChange(4, cboxRelicFootMainAffix, cboxRelicFootLevel, lblRelicFootMainAffixValue);
        }

        private void cboxRelicNeckSet_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSetChange(5, cboxRelicNeckSet);
            RelicTools.RelicMainAffixChange(5, cboxRelicNeckMainAffix, cboxRelicNeckLevel, lblRelicNeckMainAffixValue);
        }

        private void cboxRelicObjectSet_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSetChange(6, cboxRelicObjectSet);
            RelicTools.RelicMainAffixChange(6, cboxRelicObjectMainAffix, cboxRelicObjectLevel, lblRelicObjectMainAffixValue);
        }

        private void cboxRelicHeadMainAffix_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicMainAffixChange(1, cboxRelicHeadMainAffix, cboxRelicHeadLevel, lblRelicHeadMainAffixValue);
        }

        private void cboxRelicHeadLevel_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicMainAffixChange(1, cboxRelicHeadMainAffix, cboxRelicHeadLevel, lblRelicHeadMainAffixValue);
        }

        private void cboxRelicHandMainAffix_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicMainAffixChange(2, cboxRelicHandMainAffix, cboxRelicHandLevel, lblRelicHandMainAffixValue);
        }

        private void cboxRelicHandLevel_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicMainAffixChange(2, cboxRelicHandMainAffix, cboxRelicHandLevel, lblRelicHandMainAffixValue);
        }

        private void cboxRelicBodyMainAffix_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicMainAffixChange(3, cboxRelicBodyMainAffix, cboxRelicBodyLevel, lblRelicBodyMainAffixValue);
        }

        private void cboxRelicBodyLevel_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicMainAffixChange(3, cboxRelicBodyMainAffix, cboxRelicBodyLevel, lblRelicBodyMainAffixValue);
        }

        private void cboxRelicFootMainAffix_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicMainAffixChange(4, cboxRelicFootMainAffix, cboxRelicFootLevel, lblRelicFootMainAffixValue);
        }

        private void cboxRelicFootLevel_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicMainAffixChange(4, cboxRelicFootMainAffix, cboxRelicFootLevel, lblRelicFootMainAffixValue);
        }

        private void cboxRelicNeckMainAffix_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicMainAffixChange(5, cboxRelicNeckMainAffix, cboxRelicNeckLevel, lblRelicNeckMainAffixValue);
        }

        private void cboxRelicNeckLevel_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicMainAffixChange(5, cboxRelicNeckMainAffix, cboxRelicNeckLevel, lblRelicNeckMainAffixValue);
        }

        private void cboxRelicObjectMainAffix_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicMainAffixChange(6, cboxRelicObjectMainAffix, cboxRelicObjectLevel, lblRelicObjectMainAffixValue);
        }

        private void cboxRelicObjectLevel_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicMainAffixChange(6, cboxRelicObjectMainAffix, cboxRelicObjectLevel, lblRelicObjectMainAffixValue);
        }
    }
}
