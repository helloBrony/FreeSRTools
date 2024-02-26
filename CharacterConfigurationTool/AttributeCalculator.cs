namespace CharacterConfigurationTool {
    public static class AttributeCalculator {
        public static void DetailsCalculator() {
            AttributeDetails.Hp = Character.BaseHp * 7.35 + Character.EquipmentLightcone.BaseHp * 22.05;
            AttributeDetails.Atk = Character.BaseAtk * 7.35 + Character.EquipmentLightcone.BaseAtk * 22.05;
            AttributeDetails.Def = Character.BaseDef * 7.35 + Character.EquipmentLightcone.BaseDef * 22.05;
            AttributeDetails.Spd = Character.BaseSpd;


            Program.FormMain.lblHp.Text = Math.Floor(AttributeDetails.Hp).ToString();
            Program.FormMain.lblAtk.Text = Math.Floor(AttributeDetails.Atk).ToString();
            Program.FormMain.lblDef.Text = Math.Floor(AttributeDetails.Def).ToString();
            Program.FormMain.lblSpd.Text = Math.Floor(AttributeDetails.Spd).ToString();
            Program.FormMain.lblCritRate.Text = (Math.Floor(AttributeDetails.CritRate * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblCritDmg.Text = (Math.Floor(AttributeDetails.CritDmg * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblBreakEffect.Text = (Math.Floor(AttributeDetails.BreakEffect * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblHealBoost.Text = (Math.Floor(AttributeDetails.HealBoost * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblEnergyRegenerationRate.Text = (Math.Floor(AttributeDetails.EnergyRegenerationRate * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblEffectHitRate.Text = (Math.Floor(AttributeDetails.EffectHitRate * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblEffectRes.Text = (Math.Floor(AttributeDetails.EffectRes * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblPhysicalDmgBoost.Text = (Math.Floor(AttributeDetails.PhysicalDmgBoost * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblFireDmgBoost.Text = (Math.Floor(AttributeDetails.FireDmgBoost * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblIceDmgBoost.Text = (Math.Floor(AttributeDetails.IceDmgBoost * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblLightningDmgBoost.Text = (Math.Floor(AttributeDetails.LightningDmgBoost * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblWindDmgBoost.Text = (Math.Floor(AttributeDetails.WindDmgBoost * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblQuantumDmgBoost.Text = (Math.Floor(AttributeDetails.QuantumDmgBoost * 1000) / 10).ToString("0.0") + '%';
            Program.FormMain.lblImaginaryDmgBoost.Text = (Math.Floor(AttributeDetails.ImaginaryDmgBoost * 1000) / 10).ToString("0.0") + '%';
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

    public static class AttributeDetails {
        public static double Hp { get; set; }
        public static double Atk { get; set; }
        public static double Def { get; set; }
        public static double Spd { get; set; }
        public static double CritRate { get; set; } = 0.05f;
        public static double CritDmg { get; set; } = 0.5f;
        public static double BreakEffect { get; set; }
        public static double HealBoost { get; set; }
        public static double EnergyRegenerationRate { get; set; }
        public static double EffectHitRate { get; set; }
        public static double EffectRes { get; set; }
        public static double PhysicalDmgBoost { get; set; }
        public static double FireDmgBoost { get; set; }
        public static double IceDmgBoost { get; set; }
        public static double LightningDmgBoost { get; set; }
        public static double WindDmgBoost { get; set; }
        public static double QuantumDmgBoost { get; set; }
        public static double ImaginaryDmgBoost { get; set; }

    }
}
