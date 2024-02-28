namespace CharacterConfigurationTool {
    public static class RelicTools {
        public static void RelicSetChange(uint type, ComboBox cbox) {
            if (cbox.Items.Contains(cbox.SelectedItem)) {
                if (cbox.SelectedIndex == 0) {
                    foreach (var relic in Character.RelicList) {
                        if (relic.Type == type) {
                            Character.RelicList.Remove(relic);
                            foreach (var kvp in RelicDetails.MainAffixDetails[type]) {
                                RelicDetails.MainAffixDetails[type][kvp.Key] = 0;
                            }
                            foreach (var kvpNum in RelicDetails.SubAffixDetails[type]) {
                                foreach(var kvp in kvpNum.Value) {
                                    RelicDetails.SubAffixDetails[type][kvpNum.Key][kvp.Key] = 0;
                                }
                            }
                            break;
                        }
                    }
                } else {
                    var relicSetDataDict = JsonParser.RelicSetJsonParser();
                    foreach (var kvp in relicSetDataDict) {
                        var relicSetData = kvp.Value;
                        if (relicSetData.Name == cbox.SelectedItem.ToString()) {
                            foreach (var relic in Character.RelicList) {
                                if (relic.Type == type) {
                                    Character.RelicList.Remove(relic);
                                    break;
                                }
                            }
                            Character.RelicList.Add(new Relic {
                                Id = 60000 + kvp.Key * 10 + type,
                                SetId = kvp.Key,
                                Type = type
                            });
                            break;
                        }
                    }
                }
            }
            AttributeCalculator.DetailsCalculator();

        }
        public static void RelicMainAffixChange(uint type, ComboBox cboxMainAffix, ComboBox cboxLevel, Label lblMainAffixValue) {
            var relicMainAffixDataDict = JsonParser.RelicMainAffixParser();
            foreach (var relic in Character.RelicList) {
                if (relic.Type == type) {
                    foreach (var kvpType in relicMainAffixDataDict) {
                        if (kvpType.Key == type) {
                            foreach (var kvpMainAffix in kvpType.Value) {
                                var relicMainAffixData = kvpMainAffix.Value;
                                if (relicMainAffixData.Name == cboxMainAffix.SelectedItem.ToString()) {
                                    foreach (var kvp in RelicDetails.MainAffixDetails[type]) {
                                        RelicDetails.MainAffixDetails[type][kvp.Key] = 0;
                                    }
                                    RelicDetails.MainAffixDetails[type][kvpMainAffix.Key] = AttributeCalculator.RelicMainAffixCalculator(type, kvpMainAffix.Key, (uint)cboxLevel.SelectedIndex);
                                    if (type == 1 || type == 2 || (type == 4 && kvpMainAffix.Key == 4)) {
                                        lblMainAffixValue.Text = Math.Floor(AttributeCalculator.RelicMainAffixCalculator(type, kvpMainAffix.Key, (uint)cboxLevel.SelectedIndex)).ToString();
                                    } else {
                                        lblMainAffixValue.Text = (Math.Floor(AttributeCalculator.RelicMainAffixCalculator(type, kvpMainAffix.Key, (uint)cboxLevel.SelectedIndex) * 1000) / 10).ToString("0.0") + '%';
                                    }
                                    Character.RelicList[Character.RelicList.IndexOf(relic)].MainAffixId = kvpMainAffix.Key;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    Character.RelicList[Character.RelicList.IndexOf(relic)].Level = (uint)cboxLevel.SelectedIndex;
                    break;
                }
            }
            AttributeCalculator.DetailsCalculator();
        }
        public static void RelicSubAffixChange(uint type, uint num, ComboBox cboxSubAffix, NumericUpDown nudCnt, NumericUpDown nudStep, Label lblValue) {
            foreach (var relic in Character.RelicList) {
                if (relic.Type == type) {
                    if (relic.SubAffixList.Count >= num) {
                        Character.RelicList[Character.RelicList.IndexOf(relic)].SubAffixList[(int)num - 1].SubAffixId = (uint)cboxSubAffix.SelectedIndex + 1;
                        Character.RelicList[Character.RelicList.IndexOf(relic)].SubAffixList[(int)num - 1].Cnt = (uint)nudCnt.Value;
                        Character.RelicList[Character.RelicList.IndexOf(relic)].SubAffixList[(int)num - 1].Step = (uint)nudStep.Value;
                    } else {
                        Character.RelicList[Character.RelicList.IndexOf(relic)].SubAffixList.Add(new RelicSubAffix {
                            SubAffixId = (uint)cboxSubAffix.SelectedIndex + 1,
                            Cnt = (uint)nudCnt.Value,
                            Step = (uint)nudStep.Value,
                        });
                    }
                    foreach (var kvp in RelicDetails.SubAffixDetails[type][num]) {
                        RelicDetails.SubAffixDetails[type][num][kvp.Key] = 0;
                    }
                    RelicDetails.SubAffixDetails[type][num][(uint)cboxSubAffix.SelectedIndex + 1] = AttributeCalculator.RelicSubAffixCalculator((uint)cboxSubAffix.SelectedIndex + 1, (uint)nudCnt.Value, (uint)nudStep.Value);
                    if (cboxSubAffix.SelectedIndex == 0 || cboxSubAffix.SelectedIndex == 1 || cboxSubAffix.SelectedIndex == 2 || cboxSubAffix.SelectedIndex == 6) {
                        lblValue.Text = Math.Floor(AttributeCalculator.RelicSubAffixCalculator((uint)cboxSubAffix.SelectedIndex + 1, (uint)nudCnt.Value, (uint)nudStep.Value)).ToString();
                    } else {
                        lblValue.Text = (Math.Floor(AttributeCalculator.RelicSubAffixCalculator((uint)cboxSubAffix.SelectedIndex + 1, (uint)nudCnt.Value, (uint)nudStep.Value) * 1000) / 10).ToString("0.0") + '%';
                    }
                    break;
                }
            }
            AttributeCalculator.DetailsCalculator();
        }
    }
}
