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

            cboxCharacterSelect.SelectedIndex = 0;
            cboxCharacterRank.SelectedIndex = 0;
            cboxLightconeSelect.SelectedIndex = 0;
            cboxLightconeRank.SelectedIndex = 0;
        }

        private void cboxCharacterSelect_SelectedIndexChanged(object sender, EventArgs e) {
            if (cboxCharacterSelect.Items.Contains(cboxCharacterSelect.SelectedItem)) {
                string selectedName = cboxCharacterSelect.SelectedItem.ToString();
                var characterDataDict = JsonParser.CharacterJsonParser();
                foreach (var kvp in characterDataDict) {
                    var characterData = kvp.Value;
                    if (characterData.Name == selectedName) {
                        Character.Id = kvp.Key;
                        Character.Level = 80;
                        Character.Promotion = 6;
                        Character.BaseHp = characterData.BaseHp;
                        Character.BaseAtk = characterData.BaseAtk;
                        Character.BaseDef = characterData.BaseDef;
                        Character.BaseSpd = characterData.Spd;
                        break;
                    }
                }
                AttributeCalculator.CalculateDetails();
            } else {
                MessageBox.Show("请选择一个有效的选项。", "提示");
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
                    string selectedName = cboxLightconeSelect.SelectedItem.ToString();
                    var lightconeDataDict = JsonParser.LightconeJsonParser();
                    foreach (var kvp in lightconeDataDict) {
                        var lightconeData = kvp.Value;
                        if (selectedName == kvp.Value.Name) {
                            Character.EquipmentLightcone.Id = kvp.Key;
                            Character.EquipmentLightcone.Level = 80;
                            Character.EquipmentLightcone.Promotion = 6;
                            Character.EquipmentLightcone.BaseHp = lightconeData.BaseHp;
                            Character.EquipmentLightcone.BaseAtk = lightconeData.BaseAtk;
                            Character.EquipmentLightcone.BaseDef = lightconeData.BaseDef;
                        }
                    }
                }
                AttributeCalculator.CalculateDetails();
            }
        }

        private void cboxLightconeRank_SelectedIndexChanged(object sender, EventArgs e) {
            Character.EquipmentLightcone.Rank = (uint)cboxCharacterRank.SelectedIndex + 1;
        }
    }
}
