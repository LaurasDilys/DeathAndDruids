namespace Business.Models
{
    public class FlatCreature
    {
        public string Name { get; set; }
        public string Alignment { get; set; }
        public double ChallengeRating { get; set; }
        public int ProficiencyBonus { get; set; }

        public int ArmorClass { get; set; }
        public int CurrentArmorClass { get; set; }

        public int HitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public int TemporaryHitPoints { get; set; }

        public int Initiative { get; set; }
        public int Speed { get; set; }
        public int CurrentSpeed { get; set; }

        public string Traits { get; set; }
        public string Notes { get; set; }


        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }


        public bool StrengthSavingThrowProficiency { get; set; }
        public bool AthleticsProficiency { get; set; }

        public bool DexteritySavingThrowProficiency { get; set; }
        public bool AcrobaticsProficiency { get; set; }
        public bool SleightOfHandProficiency { get; set; }
        public bool StealthProficiency { get; set; }

        public bool ConstitutionSavingThrowProficiency { get; set; }

        public bool IntelligenceSavingThrowProficiency { get; set; }
        public bool ArcanaProficiency { get; set; }
        public bool HistoryProficiency { get; set; }
        public bool InvestigationProficiency { get; set; }
        public bool NatureProficiency { get; set; }
        public bool ReligionProficiency { get; set; }

        public bool WisdomSavingThrowProficiency { get; set; }
        public bool AnimalHandlingProficiency { get; set; }
        public bool InsightProficiency { get; set; }
        public bool MedicineProficiency { get; set; }
        public bool PerceptionProficiency { get; set; }
        public bool SurvivalProficiency { get; set; }

        public bool CharismaSavingThrowProficiency { get; set; }
        public bool DeceptionProficiency { get; set; }
        public bool IntimidationProficiency { get; set; }
        public bool PerformanceProficiency { get; set; }
        public bool PersuasionProficiency { get; set; }
    }
}
