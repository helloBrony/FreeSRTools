namespace CharacterConfigurationTool {
    public static class RelicTools {
        public static void RelicSetChange(uint type, ComboBox cbox) {
            if (cbox.Items.Contains(cbox.SelectedItem)) {
                if (cbox.SelectedIndex == 0) {
                    foreach (var relic in Character.RelicList) {
                        if (relic.Type == type) {
                            Character.RelicList.Remove(relic);

                            Console.WriteLine($"{type}:Selecte empty.");

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
                                Id = 60000 + kvp.Key + type,
                                SetId = kvp.Key,
                                Type = type
                            });

                            Console.WriteLine($"Type:{type}, SetId:{kvp.Key}, Id:{60000 + kvp.Key + type}");

                            break;
                        }
                    }
                }
            }
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
                                    if (type == 1 || type == 2 || (type == 4 && kvpMainAffix.Key == 4)) {
                                        lblMainAffixValue.Text = Math.Floor(AttributeCalculator.RelicMainAffixCalculator(type, kvpMainAffix.Key, (uint)cboxLevel.SelectedIndex)).ToString();
                                    } else {
                                        lblMainAffixValue.Text = (Math.Floor(AttributeCalculator.RelicMainAffixCalculator(type, kvpMainAffix.Key, (uint)cboxLevel.SelectedIndex) * 1000) / 10).ToString("0.0") + '%';
                                    }

                                    Console.WriteLine($"Id:{kvpMainAffix.Key}, Value:{AttributeCalculator.RelicMainAffixCalculator(type, kvpMainAffix.Key, (uint)cboxLevel.SelectedIndex)}");

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
        }
    }
}
