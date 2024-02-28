namespace CharacterConfigurationTool {
    public static class AttributeCalculator {
        public static void DetailsCalculator() {
            var attributeDetails = new AttributeDetails();
            attributeDetails.HpAdd += RelicDetails.MainAffixDetails[1][1];
            attributeDetails.AtkAdd += RelicDetails.MainAffixDetails[2][1];
            foreach (var kvp in RelicDetails.MainAffixDetails) {
                if (kvp.Key == 3 || kvp.Key == 4 || kvp.Key == 5) {
                    attributeDetails.PercentHpBoost += kvp.Value[1];
                    attributeDetails.PercentAtkBoost += kvp.Value[2];
                    attributeDetails.PercentDefBoost += kvp.Value[3];
                } else if (kvp.Key == 6) {
                    attributeDetails.PercentHpBoost += kvp.Value[3];
                    attributeDetails.PercentAtkBoost += kvp.Value[4];
                    attributeDetails.PercentDefBoost += kvp.Value[5];
                }
            }
            attributeDetails.SpdAdd += RelicDetails.MainAffixDetails[4][4];
            attributeDetails.CritRate += RelicDetails.MainAffixDetails[3][4];
            attributeDetails.CritDmg += RelicDetails.MainAffixDetails[3][5];
            attributeDetails.BreakEffect += RelicDetails.MainAffixDetails[6][1];
            attributeDetails.HealBoost += RelicDetails.MainAffixDetails[3][6];
            attributeDetails.EnergyRegenerationRate += RelicDetails.MainAffixDetails[6][2];
            attributeDetails.EffectHitRate += RelicDetails.MainAffixDetails[3][7];
            attributeDetails.PhysicalDmgBoost += RelicDetails.MainAffixDetails[5][4];
            attributeDetails.FireDmgBoost += RelicDetails.MainAffixDetails[5][5];
            attributeDetails.IceDmgBoost += RelicDetails.MainAffixDetails[5][6];
            attributeDetails.LightningDmgBoost += RelicDetails.MainAffixDetails[5][7];
            attributeDetails.WindDmgBoost += RelicDetails.MainAffixDetails[5][8];
            attributeDetails.QuantumDmgBoost += RelicDetails.MainAffixDetails[5][9];
            attributeDetails.ImaginaryDmgBoost += RelicDetails.MainAffixDetails[5][10];
            foreach (var kvpType in RelicDetails.SubAffixDetails) {
                foreach (var kvpNum in kvpType.Value) {
                    attributeDetails.HpAdd += kvpNum.Value[1];
                    attributeDetails.AtkAdd += kvpNum.Value[2];
                    attributeDetails.DefAdd += kvpNum.Value[3];
                    attributeDetails.PercentHpBoost += kvpNum.Value[4];
                    attributeDetails.PercentAtkBoost += kvpNum.Value[5];
                    attributeDetails.PercentDefBoost += kvpNum.Value[6];
                    attributeDetails.SpdAdd += kvpNum.Value[7];
                    attributeDetails.CritRate += kvpNum.Value[8];
                    attributeDetails.CritDmg += kvpNum.Value[9];
                    attributeDetails.EffectHitRate += kvpNum.Value[10];
                    attributeDetails.EffectRes += kvpNum.Value[11];
                    attributeDetails.BreakEffect += kvpNum.Value[12];
                }
            }

            Program.FormMain.lblHp.Text = Math.Floor((Character.BaseHp * 7.35 + Character.EquipmentLightcone.BaseHp * 22.05) * (1 + attributeDetails.PercentHpBoost) + attributeDetails.HpAdd).ToString();
            Program.FormMain.lblAtk.Text = Math.Floor((Character.BaseAtk * 7.35 + Character.EquipmentLightcone.BaseAtk * 22.05) * (1 + attributeDetails.PercentAtkBoost) + attributeDetails.AtkAdd).ToString();
            Program.FormMain.lblDef.Text = Math.Floor((Character.BaseDef * 7.35 + Character.EquipmentLightcone.BaseDef * 22.05) * (1 + attributeDetails.PercentDefBoost) + attributeDetails.DefAdd).ToString();
            Program.FormMain.lblSpd.Text = Math.Floor(Character.BaseSpd + attributeDetails.SpdAdd).ToString();
            Program.FormMain.lblCritRate.Text = (Math.Floor(attributeDetails.CritRate * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblCritDmg.Text = (Math.Floor(attributeDetails.CritDmg * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblBreakEffect.Text = (Math.Floor(attributeDetails.BreakEffect * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblHealBoost.Text = (Math.Floor(attributeDetails.HealBoost * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblEnergyRegenerationRate.Text = (Math.Floor(attributeDetails.EnergyRegenerationRate * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblEffectHitRate.Text = (Math.Floor(attributeDetails.EffectHitRate * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblEffectRes.Text = (Math.Floor(attributeDetails.EffectRes * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblPhysicalDmgBoost.Text = (Math.Floor(attributeDetails.PhysicalDmgBoost * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblFireDmgBoost.Text = (Math.Floor(attributeDetails.FireDmgBoost * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblIceDmgBoost.Text = (Math.Floor(attributeDetails.IceDmgBoost * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblLightningDmgBoost.Text = (Math.Floor(attributeDetails.LightningDmgBoost * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblWindDmgBoost.Text = (Math.Floor(attributeDetails.WindDmgBoost * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblQuantumDmgBoost.Text = (Math.Floor(attributeDetails.QuantumDmgBoost * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblImaginaryDmgBoost.Text = (Math.Floor(attributeDetails.ImaginaryDmgBoost * 1000) / 10).ToString("0.0") + '%';
        }
        public static double RelicMainAffixCalculator(uint type, uint id, uint level) {
            var relicMainAffixDataDict = JsonParser.RelicMainAffixParser();
            foreach (var kvpType in relicMainAffixDataDict) {
                if (kvpType.Key == type) {
                    foreach (var kvpMainAffix in kvpType.Value) {
                        var relicMainAffixData = kvpMainAffix.Value;
                        if (kvpMainAffix.Key == id) {
                            return Math.Round(relicMainAffixData.Base + relicMainAffixData.Add * level, 10);
                        }
                    }
                }
            }
            return -1;
        }
        public static double RelicSubAffixCalculator(uint id, uint cnt, uint step) {
            var relicSubAffixDataDict = JsonParser.RelicSubAffixParser();
            foreach (var kvp in relicSubAffixDataDict) {
                var relicSubAffixData = kvp.Value;
                if (kvp.Key == id) {
                    return Math.Round(relicSubAffixData.Base * cnt + relicSubAffixData.Step * step, 10);
                }
            }
            return -1;
        }
    }

    public static class Character {
        public static uint Id { get; set; }
        public static uint Level { get; set; }
        public static uint Promotion { get; set; }
        public static uint Rank { get; set; }
        public static Lightcone EquipmentLightcone { get; } = new Lightcone();
        public static List<Relic> RelicList { get; } = new List<Relic>();
        public static double BaseHp { get; set; }
        public static double BaseAtk { get; set; }
        public static double BaseDef { get; set; }
        public static double BaseSpd { get; set; }
    }

    public class Lightcone {
        public uint Id { get; set; }
        public uint Level { get; set; }
        public uint Promotion { get; set; }
        public uint Rank { get; set; }
        public double BaseHp { get; set; }
        public double BaseAtk { get; set; }
        public double BaseDef { get; set; }
    }

    public class Relic {
        public uint Id { get; set; }
        public uint SetId { get; set; }
        public uint Type { get; set; }
        public uint Level { get; set; }
        public uint MainAffixId { get; set; }
        public List<RelicSubAffix> SubAffixList { get; } = new List<RelicSubAffix>();
    }

    public class RelicSubAffix {
        public uint SubAffixId { get; set; }
        public uint Cnt { get; set; }
        public uint Step { get; set; }
    }

    public class AttributeDetails {
        public double HpAdd { get; set; }
        public double AtkAdd { get; set; }
        public double DefAdd { get; set; }
        public double PercentHpBoost { get; set; }
        public double PercentAtkBoost { get; set; }
        public double PercentDefBoost { get; set; }
        public double SpdAdd { get; set; }
        public double CritRate { get; set; } = 0.05;
        public double CritDmg { get; set; } = 0.5;
        public double BreakEffect { get; set; }
        public double HealBoost { get; set; }
        public double EnergyRegenerationRate { get; set; }
        public double EffectHitRate { get; set; }
        public double EffectRes { get; set; }
        public double PhysicalDmgBoost { get; set; }
        public double FireDmgBoost { get; set; }
        public double IceDmgBoost { get; set; }
        public double LightningDmgBoost { get; set; }
        public double WindDmgBoost { get; set; }
        public double QuantumDmgBoost { get; set; }
        public double ImaginaryDmgBoost { get; set; }

    }
    public static class RelicDetails {
        public static Dictionary<uint, Dictionary<uint, double>> MainAffixDetails { get; } = new Dictionary<uint, Dictionary<uint, double>>() {
            {
                1, new Dictionary<uint, double>() {
                    {1, 0}
                }
            },
            {
                2, new Dictionary<uint, double>() {
                    {1, 0}
                }
            },
            {
                3, new Dictionary<uint, double>() {
                    {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}
                }
            },
            {
                4, new Dictionary<uint, double>() {
                    {1, 0}, {2, 0}, {3, 0}, {4, 0}
                }
            },
            {
                5, new Dictionary<uint, double>() {
                    {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0},  {9, 0}, {10, 0}
                }
            },
            {
                6, new Dictionary<uint, double>() {
                    {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}
                }
            }
        };
        public static Dictionary<uint, Dictionary<uint, Dictionary<uint, double>>> SubAffixDetails { get; } = new Dictionary<uint, Dictionary<uint, Dictionary<uint, double>>>() {
            {
                1, new Dictionary<uint, Dictionary<uint, double>>() {
                    { 1, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                    { 2, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                    { 3, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                    { 4, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                }
            },
            {
                2, new Dictionary<uint, Dictionary<uint, double>>() {
                    { 1, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                    { 2, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                    { 3, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                    { 4, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                }
            },
            {
                3, new Dictionary<uint, Dictionary<uint, double>>() {
                    { 1, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                    { 2, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                    { 3, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                    { 4, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                }
            },
            {
                4, new Dictionary<uint, Dictionary<uint, double>>() {
                    { 1, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                    { 2, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                    { 3, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                    { 4, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                }
            },
            {
                5, new Dictionary<uint, Dictionary<uint, double>>() {
                    { 1, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                    { 2, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                    { 3, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                    { 4, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                }
            },
            {
                6, new Dictionary<uint, Dictionary<uint, double>>() {
                    { 1, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                    { 2, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                    { 3, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                    { 4, new Dictionary<uint, double>(){ {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}, {6, 0}, {7, 0}, {8, 0}, {9, 0}, {10, 0}, {11, 0}, {12, 0}} },
                }
            }
        };
    }
}
