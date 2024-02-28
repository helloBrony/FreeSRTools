using System.Security.Cryptography.X509Certificates;

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
            cboxRelicHeadSubAffix1.SelectedIndex = 0;
            cboxRelicHeadSubAffix2.SelectedIndex = 1;
            cboxRelicHeadSubAffix3.SelectedIndex = 2;
            cboxRelicHeadSubAffix4.SelectedIndex = 3;
            cboxRelicHandSubAffix1.SelectedIndex = 0;
            cboxRelicHandSubAffix2.SelectedIndex = 1;
            cboxRelicHandSubAffix3.SelectedIndex = 2;
            cboxRelicHandSubAffix4.SelectedIndex = 3;
            cboxRelicBodySubAffix1.SelectedIndex = 0;
            cboxRelicBodySubAffix2.SelectedIndex = 1;
            cboxRelicBodySubAffix3.SelectedIndex = 2;
            cboxRelicBodySubAffix4.SelectedIndex = 3;
            cboxRelicFootSubAffix1.SelectedIndex = 0;
            cboxRelicFootSubAffix2.SelectedIndex = 1;
            cboxRelicFootSubAffix3.SelectedIndex = 2;
            cboxRelicFootSubAffix4.SelectedIndex = 3;
            cboxRelicNeckSubAffix1.SelectedIndex = 0;
            cboxRelicNeckSubAffix2.SelectedIndex = 1;
            cboxRelicNeckSubAffix3.SelectedIndex = 2;
            cboxRelicNeckSubAffix4.SelectedIndex = 3;
            cboxRelicObjectSubAffix1.SelectedIndex = 0;
            cboxRelicObjectSubAffix2.SelectedIndex = 1;
            cboxRelicObjectSubAffix3.SelectedIndex = 2;
            cboxRelicObjectSubAffix4.SelectedIndex = 3;
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
            RelicTools.RelicSubAffixChange(1, 1, cboxRelicHeadSubAffix1, nudRelicHeadSubAffixCnt1, nudRelicHeadSubAffixStep1, lblRelicHeadSubAffixValue1);
            RelicTools.RelicSubAffixChange(1, 2, cboxRelicHeadSubAffix2, nudRelicHeadSubAffixCnt2, nudRelicHeadSubAffixStep2, lblRelicHeadSubAffixValue2);
            RelicTools.RelicSubAffixChange(1, 3, cboxRelicHeadSubAffix3, nudRelicHeadSubAffixCnt3, nudRelicHeadSubAffixStep3, lblRelicHeadSubAffixValue3);
            RelicTools.RelicSubAffixChange(1, 4, cboxRelicHeadSubAffix4, nudRelicHeadSubAffixCnt4, nudRelicHeadSubAffixStep4, lblRelicHeadSubAffixValue4);
        }

        private void cboxRelicHandSet_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSetChange(2, cboxRelicHandSet);
            RelicTools.RelicMainAffixChange(2, cboxRelicHandMainAffix, cboxRelicHandLevel, lblRelicHandMainAffixValue);
            RelicTools.RelicSubAffixChange(2, 1, cboxRelicHandSubAffix1, nudRelicHandSubAffixCnt1, nudRelicHandSubAffixStep1, lblRelicHandSubAffixValue1);
            RelicTools.RelicSubAffixChange(2, 2, cboxRelicHandSubAffix2, nudRelicHandSubAffixCnt2, nudRelicHandSubAffixStep2, lblRelicHandSubAffixValue2);
            RelicTools.RelicSubAffixChange(2, 3, cboxRelicHandSubAffix3, nudRelicHandSubAffixCnt3, nudRelicHandSubAffixStep3, lblRelicHandSubAffixValue3);
            RelicTools.RelicSubAffixChange(2, 4, cboxRelicHandSubAffix4, nudRelicHandSubAffixCnt4, nudRelicHandSubAffixStep4, lblRelicHandSubAffixValue4);
        }

        private void cboxRelicBodySet_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSetChange(3, cboxRelicBodySet);
            RelicTools.RelicMainAffixChange(3, cboxRelicBodyMainAffix, cboxRelicBodyLevel, lblRelicBodyMainAffixValue);
            RelicTools.RelicSubAffixChange(3, 1, cboxRelicBodySubAffix1, nudRelicBodySubAffixCnt1, nudRelicBodySubAffixStep1, lblRelicBodySubAffixValue1);
            RelicTools.RelicSubAffixChange(3, 2, cboxRelicBodySubAffix2, nudRelicBodySubAffixCnt2, nudRelicBodySubAffixStep2, lblRelicBodySubAffixValue2);
            RelicTools.RelicSubAffixChange(3, 3, cboxRelicBodySubAffix3, nudRelicBodySubAffixCnt3, nudRelicBodySubAffixStep3, lblRelicBodySubAffixValue3);
            RelicTools.RelicSubAffixChange(3, 4, cboxRelicBodySubAffix4, nudRelicBodySubAffixCnt4, nudRelicBodySubAffixStep4, lblRelicBodySubAffixValue4);
        }

        private void cboxRelicFootSet_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSetChange(4, cboxRelicFootSet);
            RelicTools.RelicMainAffixChange(4, cboxRelicFootMainAffix, cboxRelicFootLevel, lblRelicFootMainAffixValue);
            RelicTools.RelicSubAffixChange(4, 1, cboxRelicFootSubAffix1, nudRelicFootSubAffixCnt1, nudRelicFootSubAffixStep1, lblRelicFootSubAffixValue1);
            RelicTools.RelicSubAffixChange(4, 2, cboxRelicFootSubAffix2, nudRelicFootSubAffixCnt2, nudRelicFootSubAffixStep2, lblRelicFootSubAffixValue2);
            RelicTools.RelicSubAffixChange(4, 3, cboxRelicFootSubAffix3, nudRelicFootSubAffixCnt3, nudRelicFootSubAffixStep3, lblRelicFootSubAffixValue3);
            RelicTools.RelicSubAffixChange(4, 4, cboxRelicFootSubAffix4, nudRelicFootSubAffixCnt4, nudRelicFootSubAffixStep4, lblRelicFootSubAffixValue4);
        }

        private void cboxRelicNeckSet_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSetChange(5, cboxRelicNeckSet);
            RelicTools.RelicMainAffixChange(5, cboxRelicNeckMainAffix, cboxRelicNeckLevel, lblRelicNeckMainAffixValue);
            RelicTools.RelicSubAffixChange(5, 1, cboxRelicNeckSubAffix1, nudRelicNeckSubAffixCnt1, nudRelicNeckSubAffixStep1, lblRelicNeckSubAffixValue1);
            RelicTools.RelicSubAffixChange(5, 2, cboxRelicNeckSubAffix2, nudRelicNeckSubAffixCnt2, nudRelicNeckSubAffixStep2, lblRelicNeckSubAffixValue2);
            RelicTools.RelicSubAffixChange(5, 3, cboxRelicNeckSubAffix3, nudRelicNeckSubAffixCnt3, nudRelicNeckSubAffixStep3, lblRelicNeckSubAffixValue3);
            RelicTools.RelicSubAffixChange(5, 4, cboxRelicNeckSubAffix4, nudRelicNeckSubAffixCnt4, nudRelicNeckSubAffixStep4, lblRelicNeckSubAffixValue4);
        }

        private void cboxRelicObjectSet_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSetChange(6, cboxRelicObjectSet);
            RelicTools.RelicMainAffixChange(6, cboxRelicObjectMainAffix, cboxRelicObjectLevel, lblRelicObjectMainAffixValue);
            RelicTools.RelicSubAffixChange(6, 1, cboxRelicObjectSubAffix1, nudRelicObjectSubAffixCnt1, nudRelicObjectSubAffixStep1, lblRelicObjectSubAffixValue1);
            RelicTools.RelicSubAffixChange(6, 2, cboxRelicObjectSubAffix2, nudRelicObjectSubAffixCnt2, nudRelicObjectSubAffixStep2, lblRelicObjectSubAffixValue2);
            RelicTools.RelicSubAffixChange(6, 3, cboxRelicObjectSubAffix3, nudRelicObjectSubAffixCnt3, nudRelicObjectSubAffixStep3, lblRelicObjectSubAffixValue3);
            RelicTools.RelicSubAffixChange(6, 4, cboxRelicObjectSubAffix4, nudRelicObjectSubAffixCnt4, nudRelicObjectSubAffixStep4, lblRelicObjectSubAffixValue4);
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

        private void cboxRelicHeadSubAffix1_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(1, 1, cboxRelicHeadSubAffix1, nudRelicHeadSubAffixCnt1, nudRelicHeadSubAffixStep1, lblRelicHeadSubAffixValue1);
        }

        private void nudRelicHeadSubAffixCnt1_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(1, 1, cboxRelicHeadSubAffix1, nudRelicHeadSubAffixCnt1, nudRelicHeadSubAffixStep1, lblRelicHeadSubAffixValue1);
        }

        private void nudRelicHeadSubAffixStep1_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(1, 1, cboxRelicHeadSubAffix1, nudRelicHeadSubAffixCnt1, nudRelicHeadSubAffixStep1, lblRelicHeadSubAffixValue1);
        }

        private void cboxRelicHeadSubAffix2_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(1, 2, cboxRelicHeadSubAffix2, nudRelicHeadSubAffixCnt2, nudRelicHeadSubAffixStep2, lblRelicHeadSubAffixValue2);
        }

        private void nudRelicHeadSubAffixCnt2_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(1, 2, cboxRelicHeadSubAffix2, nudRelicHeadSubAffixCnt2, nudRelicHeadSubAffixStep2, lblRelicHeadSubAffixValue2);
        }

        private void nudRelicHeadSubAffixStep2_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(1, 2, cboxRelicHeadSubAffix2, nudRelicHeadSubAffixCnt2, nudRelicHeadSubAffixStep2, lblRelicHeadSubAffixValue2);
        }

        private void cboxRelicHeadSubAffix3_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(1, 3, cboxRelicHeadSubAffix3, nudRelicHeadSubAffixCnt3, nudRelicHeadSubAffixStep3, lblRelicHeadSubAffixValue3);
        }

        private void nudRelicHeadSubAffixCnt3_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(1, 3, cboxRelicHeadSubAffix3, nudRelicHeadSubAffixCnt3, nudRelicHeadSubAffixStep3, lblRelicHeadSubAffixValue3);
        }

        private void nudRelicHeadSubAffixStep3_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(1, 3, cboxRelicHeadSubAffix3, nudRelicHeadSubAffixCnt3, nudRelicHeadSubAffixStep3, lblRelicHeadSubAffixValue3);
        }

        private void cboxRelicHeadSubAffix4_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(1, 4, cboxRelicHeadSubAffix4, nudRelicHeadSubAffixCnt4, nudRelicHeadSubAffixStep4, lblRelicHeadSubAffixValue4);
        }

        private void nudRelicHeadSubAffixCnt4_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(1, 4, cboxRelicHeadSubAffix4, nudRelicHeadSubAffixCnt4, nudRelicHeadSubAffixStep4, lblRelicHeadSubAffixValue4);
        }

        private void nudRelicHeadSubAffixStep4_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(1, 4, cboxRelicHeadSubAffix4, nudRelicHeadSubAffixCnt4, nudRelicHeadSubAffixStep4, lblRelicHeadSubAffixValue4);
        }

        private void cboxRelicHandSubAffix1_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(2, 1, cboxRelicHandSubAffix1, nudRelicHandSubAffixCnt1, nudRelicHandSubAffixStep1, lblRelicHandSubAffixValue1);
        }

        private void nudRelicHandSubAffixCnt1_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(2, 1, cboxRelicHandSubAffix1, nudRelicHandSubAffixCnt1, nudRelicHandSubAffixStep1, lblRelicHandSubAffixValue1);
        }

        private void nudRelicHandSubAffixStep1_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(2, 1, cboxRelicHandSubAffix1, nudRelicHandSubAffixCnt1, nudRelicHandSubAffixStep1, lblRelicHandSubAffixValue1);
        }

        private void cboxRelicHandSubAffix2_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(2, 2, cboxRelicHandSubAffix2, nudRelicHandSubAffixCnt2, nudRelicHandSubAffixStep2, lblRelicHandSubAffixValue2);
        }

        private void nudRelicHandSubAffixCnt2_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(2, 2, cboxRelicHandSubAffix2, nudRelicHandSubAffixCnt2, nudRelicHandSubAffixStep2, lblRelicHandSubAffixValue2);
        }

        private void nudRelicHandSubAffixStep2_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(2, 2, cboxRelicHandSubAffix2, nudRelicHandSubAffixCnt2, nudRelicHandSubAffixStep2, lblRelicHandSubAffixValue2);
        }

        private void cboxRelicHandSubAffix3_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(2, 3, cboxRelicHandSubAffix3, nudRelicHandSubAffixCnt3, nudRelicHandSubAffixStep3, lblRelicHandSubAffixValue3);
        }

        private void nudRelicHandSubAffixCnt3_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(2, 3, cboxRelicHandSubAffix3, nudRelicHandSubAffixCnt3, nudRelicHandSubAffixStep3, lblRelicHandSubAffixValue3);
        }

        private void nudRelicHandSubAffixStep3_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(2, 3, cboxRelicHandSubAffix3, nudRelicHandSubAffixCnt3, nudRelicHandSubAffixStep3, lblRelicHandSubAffixValue3);
        }

        private void cboxRelicHandSubAffix4_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(2, 4, cboxRelicHandSubAffix4, nudRelicHandSubAffixCnt4, nudRelicHandSubAffixStep4, lblRelicHandSubAffixValue4);
        }

        private void nudRelicHandSubAffixCnt4_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(2, 4, cboxRelicHandSubAffix4, nudRelicHandSubAffixCnt4, nudRelicHandSubAffixStep4, lblRelicHandSubAffixValue4);
        }

        private void nudRelicHandSubAffixStep4_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(2, 4, cboxRelicHandSubAffix4, nudRelicHandSubAffixCnt4, nudRelicHandSubAffixStep4, lblRelicHandSubAffixValue4);
        }

        private void cboxRelicBodySubAffix1_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(3, 1, cboxRelicBodySubAffix1, nudRelicBodySubAffixCnt1, nudRelicBodySubAffixStep1, lblRelicBodySubAffixValue1);
        }

        private void nudRelicBodySubAffixCnt1_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(3, 1, cboxRelicBodySubAffix1, nudRelicBodySubAffixCnt1, nudRelicBodySubAffixStep1, lblRelicBodySubAffixValue1);
        }

        private void nudRelicBodySubAffixStep1_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(3, 1, cboxRelicBodySubAffix1, nudRelicBodySubAffixCnt1, nudRelicBodySubAffixStep1, lblRelicBodySubAffixValue1);
        }

        private void cboxRelicBodySubAffix2_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(3, 2, cboxRelicBodySubAffix2, nudRelicBodySubAffixCnt2, nudRelicBodySubAffixStep2, lblRelicBodySubAffixValue2);
        }

        private void nudRelicBodySubAffixCnt2_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(3, 2, cboxRelicBodySubAffix2, nudRelicBodySubAffixCnt2, nudRelicBodySubAffixStep2, lblRelicBodySubAffixValue2);
        }

        private void nudRelicBodySubAffixStep2_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(3, 2, cboxRelicBodySubAffix2, nudRelicBodySubAffixCnt2, nudRelicBodySubAffixStep2, lblRelicBodySubAffixValue2);
        }

        private void cboxRelicBodySubAffix3_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(3, 3, cboxRelicBodySubAffix3, nudRelicBodySubAffixCnt3, nudRelicBodySubAffixStep3, lblRelicBodySubAffixValue3);
        }

        private void nudRelicBodySubAffixCnt3_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(3, 3, cboxRelicBodySubAffix3, nudRelicBodySubAffixCnt3, nudRelicBodySubAffixStep3, lblRelicBodySubAffixValue3);
        }

        private void nudRelicBodySubAffixStep3_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(3, 3, cboxRelicBodySubAffix3, nudRelicBodySubAffixCnt3, nudRelicBodySubAffixStep3, lblRelicBodySubAffixValue3);
        }

        private void cboxRelicBodySubAffix4_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(3, 4, cboxRelicBodySubAffix4, nudRelicBodySubAffixCnt4, nudRelicBodySubAffixStep4, lblRelicBodySubAffixValue4);
        }

        private void nudRelicBodySubAffixCnt4_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(3, 4, cboxRelicBodySubAffix4, nudRelicBodySubAffixCnt4, nudRelicBodySubAffixStep4, lblRelicBodySubAffixValue4);
        }

        private void nudRelicBodySubAffixStep4_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(3, 4, cboxRelicBodySubAffix4, nudRelicBodySubAffixCnt4, nudRelicBodySubAffixStep4, lblRelicBodySubAffixValue4);
        }

        private void cboxRelicFootSubAffix1_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(4, 1, cboxRelicFootSubAffix1, nudRelicFootSubAffixCnt1, nudRelicFootSubAffixStep1, lblRelicFootSubAffixValue1);
        }

        private void nudRelicFootSubAffixCnt1_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(4, 1, cboxRelicFootSubAffix1, nudRelicFootSubAffixCnt1, nudRelicFootSubAffixStep1, lblRelicFootSubAffixValue1);
        }

        private void nudRelicFootSubAffixStep1_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(4, 1, cboxRelicFootSubAffix1, nudRelicFootSubAffixCnt1, nudRelicFootSubAffixStep1, lblRelicFootSubAffixValue1);
        }

        private void cboxRelicFootSubAffix2_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(4, 2, cboxRelicFootSubAffix2, nudRelicFootSubAffixCnt2, nudRelicFootSubAffixStep2, lblRelicFootSubAffixValue2);
        }

        private void nudRelicFootSubAffixCnt2_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(4, 2, cboxRelicFootSubAffix2, nudRelicFootSubAffixCnt2, nudRelicFootSubAffixStep2, lblRelicFootSubAffixValue2);
        }

        private void nudRelicFootSubAffixStep2_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(4, 2, cboxRelicFootSubAffix2, nudRelicFootSubAffixCnt2, nudRelicFootSubAffixStep2, lblRelicFootSubAffixValue2);
        }

        private void cboxRelicFootSubAffix3_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(4, 3, cboxRelicFootSubAffix3, nudRelicFootSubAffixCnt3, nudRelicFootSubAffixStep3, lblRelicFootSubAffixValue3);
        }

        private void nudRelicFootSubAffixCnt3_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(4, 3, cboxRelicFootSubAffix3, nudRelicFootSubAffixCnt3, nudRelicFootSubAffixStep3, lblRelicFootSubAffixValue3);
        }

        private void nudRelicFootSubAffixStep3_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(4, 3, cboxRelicFootSubAffix3, nudRelicFootSubAffixCnt3, nudRelicFootSubAffixStep3, lblRelicFootSubAffixValue3);
        }

        private void cboxRelicFootSubAffix4_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(4, 4, cboxRelicFootSubAffix4, nudRelicFootSubAffixCnt4, nudRelicFootSubAffixStep4, lblRelicFootSubAffixValue4);
        }

        private void nudRelicFootSubAffixCnt4_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(4, 4, cboxRelicFootSubAffix4, nudRelicFootSubAffixCnt4, nudRelicFootSubAffixStep4, lblRelicFootSubAffixValue4);
        }

        private void nudRelicFootSubAffixStep4_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(4, 4, cboxRelicFootSubAffix4, nudRelicFootSubAffixCnt4, nudRelicFootSubAffixStep4, lblRelicFootSubAffixValue4);
        }

        private void cboxRelicNeckSubAffix1_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(5, 1, cboxRelicNeckSubAffix1, nudRelicNeckSubAffixCnt1, nudRelicNeckSubAffixStep1, lblRelicNeckSubAffixValue1);
        }

        private void nudRelicNeckSubAffixCnt1_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(5, 1, cboxRelicNeckSubAffix1, nudRelicNeckSubAffixCnt1, nudRelicNeckSubAffixStep1, lblRelicNeckSubAffixValue1);
        }

        private void nudRelicNeckSubAffixStep1_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(5, 1, cboxRelicNeckSubAffix1, nudRelicNeckSubAffixCnt1, nudRelicNeckSubAffixStep1, lblRelicNeckSubAffixValue1);
        }

        private void cboxRelicNeckSubAffix2_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(5, 2, cboxRelicNeckSubAffix2, nudRelicNeckSubAffixCnt2, nudRelicNeckSubAffixStep2, lblRelicNeckSubAffixValue2);
        }

        private void nudRelicNeckSubAffixCnt2_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(5, 2, cboxRelicNeckSubAffix2, nudRelicNeckSubAffixCnt2, nudRelicNeckSubAffixStep2, lblRelicNeckSubAffixValue2);
        }

        private void nudRelicNeckSubAffixStep2_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(5, 2, cboxRelicNeckSubAffix2, nudRelicNeckSubAffixCnt2, nudRelicNeckSubAffixStep2, lblRelicNeckSubAffixValue2);
        }

        private void cboxRelicNeckSubAffix3_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(5, 3, cboxRelicNeckSubAffix3, nudRelicNeckSubAffixCnt3, nudRelicNeckSubAffixStep3, lblRelicNeckSubAffixValue3);
        }

        private void nudRelicNeckSubAffixCnt3_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(5, 3, cboxRelicNeckSubAffix3, nudRelicNeckSubAffixCnt3, nudRelicNeckSubAffixStep3, lblRelicNeckSubAffixValue3);
        }

        private void nudRelicNeckSubAffixStep3_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(5, 3, cboxRelicNeckSubAffix3, nudRelicNeckSubAffixCnt3, nudRelicNeckSubAffixStep3, lblRelicNeckSubAffixValue3);
        }

        private void cboxRelicNeckSubAffix4_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(5, 4, cboxRelicNeckSubAffix4, nudRelicNeckSubAffixCnt4, nudRelicNeckSubAffixStep4, lblRelicNeckSubAffixValue4);
        }

        private void nudRelicNeckSubAffixCnt4_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(5, 4, cboxRelicNeckSubAffix4, nudRelicNeckSubAffixCnt4, nudRelicNeckSubAffixStep4, lblRelicNeckSubAffixValue4);
        }

        private void nudRelicNeckSubAffixStep4_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(5, 4, cboxRelicNeckSubAffix4, nudRelicNeckSubAffixCnt4, nudRelicNeckSubAffixStep4, lblRelicNeckSubAffixValue4);
        }

        private void cboxRelicObjectSubAffix1_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(6, 1, cboxRelicObjectSubAffix1, nudRelicObjectSubAffixCnt1, nudRelicObjectSubAffixStep1, lblRelicObjectSubAffixValue1);
        }

        private void nudRelicObjectSubAffixCnt1_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(6, 1, cboxRelicObjectSubAffix1, nudRelicObjectSubAffixCnt1, nudRelicObjectSubAffixStep1, lblRelicObjectSubAffixValue1);
        }

        private void nudRelicObjectSubAffixStep1_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(6, 1, cboxRelicObjectSubAffix1, nudRelicObjectSubAffixCnt1, nudRelicObjectSubAffixStep1, lblRelicObjectSubAffixValue1);
        }

        private void cboxRelicObjectSubAffix2_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(6, 2, cboxRelicObjectSubAffix2, nudRelicObjectSubAffixCnt2, nudRelicObjectSubAffixStep2, lblRelicObjectSubAffixValue2);
        }

        private void nudRelicObjectSubAffixCnt2_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(6, 2, cboxRelicObjectSubAffix2, nudRelicObjectSubAffixCnt2, nudRelicObjectSubAffixStep2, lblRelicObjectSubAffixValue2);
        }

        private void nudRelicObjectSubAffixStep2_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(6, 2, cboxRelicObjectSubAffix2, nudRelicObjectSubAffixCnt2, nudRelicObjectSubAffixStep2, lblRelicObjectSubAffixValue2);
        }

        private void cboxRelicObjectSubAffix3_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(6, 3, cboxRelicObjectSubAffix3, nudRelicObjectSubAffixCnt3, nudRelicObjectSubAffixStep3, lblRelicObjectSubAffixValue3);
        }

        private void nudRelicObjectSubAffixCnt3_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(6, 3, cboxRelicObjectSubAffix3, nudRelicObjectSubAffixCnt3, nudRelicObjectSubAffixStep3, lblRelicObjectSubAffixValue3);
        }

        private void nudRelicObjectSubAffixStep3_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(6, 3, cboxRelicObjectSubAffix3, nudRelicObjectSubAffixCnt3, nudRelicObjectSubAffixStep3, lblRelicObjectSubAffixValue3);
        }

        private void cboxRelicObjectSubAffix4_SelectedIndexChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(6, 4, cboxRelicObjectSubAffix4, nudRelicObjectSubAffixCnt4, nudRelicObjectSubAffixStep4, lblRelicObjectSubAffixValue4);
        }

        private void nudRelicObjectSubAffixCnt4_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(6, 4, cboxRelicObjectSubAffix4, nudRelicObjectSubAffixCnt4, nudRelicObjectSubAffixStep4, lblRelicObjectSubAffixValue4);
        }

        private void nudRelicObjectSubAffixStep4_ValueChanged(object sender, EventArgs e) {
            RelicTools.RelicSubAffixChange(6, 4, cboxRelicObjectSubAffix4, nudRelicObjectSubAffixCnt4, nudRelicObjectSubAffixStep4, lblRelicObjectSubAffixValue4);
        }

        private void ExportToolStripMenuItem_Click(object sender, EventArgs e) {
            MenuBar.ExportCharacterConfig();
            MessageBox.Show("Over!");
        }
    }
}
