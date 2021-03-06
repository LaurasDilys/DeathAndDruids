namespace Business.Models
{
    public class Skill
    {
        private int modifier;
        public int Modifier
        {
            get { return modifier; }
            set
            {
                modifier = value;
                Passive = Modifier + 10; // this is just how Passive Skill is determined
                if (modifier > 0) ModifierText = $"+{modifier}";
                else ModifierText = modifier.ToString();
            }
        }
        public string ModifierText { get; set; }


        private int proficiencyBonus;
        public int ProficiencyBonus
        {
            get { return proficiencyBonus; }
            set
            {
                proficiencyBonus = value;
                UpdateModifier();
            }
        }


        private int correspondingAbilityModifier;
        public int CorrespondingAbilityModifier
        {
            get { return correspondingAbilityModifier; }
            set
            {
                correspondingAbilityModifier = value;
                UpdateModifier();
            }
        }


        private bool proficiency;
        public bool Proficiency
        {
            get { return proficiency; }
            set
            {
                proficiency = value;
                UpdateModifier();
            }
        }


        public int Passive { get; set; }


        private void UpdateModifier()
        {
            int prof = Proficiency ? 1 : 0;
            Modifier = CorrespondingAbilityModifier + prof * ProficiencyBonus;
        }
    }
}
