using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Character // Creature
    {
        public Character()
        {
            BuildListsOfSkills();
            BuildListOfAbilities();
            SetInitialAbilityScoreValues();

            Name = "";
        }

        public string Name { get; set; }
        public int Initiative { get; set; }

        private int proficiencyBonus;
        public int ProficiencyBonus
        {
            get { return proficiencyBonus; }
            set
            {
                proficiencyBonus = value;
                SendNewProficiencyBonusToSkillsAndSavingThrows();
                //OnPropertyChanged();
            }
        }

        //Abilities
        public List<Ability> Abilities { get; set; } = new List<Ability>();
        public Ability Strength { get; set; } = new Ability();

        //Skills
        //Strength based
        public Skill Athletics { get; set; } = new Skill();

        private void BuildListOfAbilities()
        {
            Abilities.Add(Strength);
        }

        private void BuildListsOfSkills()
        {
            Strength.Skills.Add(Athletics);
        }

        private void SendNewProficiencyBonusToSkillsAndSavingThrows()
        {
            foreach (Ability ability in Abilities)
            {
                ability.SavingThrow.ProficiencyBonus = ProficiencyBonus;
                foreach (Skill skill in ability.Skills)
                {
                    skill.ProficiencyBonus = ProficiencyBonus;
                }
            }
        }

        private void SetInitialAbilityScoreValues()
        {
            foreach (Ability ability in Abilities)
            {
                ability.Score = StaticValues.InitialAbilityScoreValue;
            }
        }
    }
}
