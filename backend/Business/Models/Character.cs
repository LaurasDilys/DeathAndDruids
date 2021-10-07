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

            ChallengeRating = 0;
        }

        public string Name { get; set; } = "";
        public string Alignment { get; set; } = "";

        private double challengeRating;
        public double ChallengeRating
        {
            get { return challengeRating; }
            set
            {
                challengeRating = value.Between(StaticValues.MinCR, StaticValues.MaxCR);
                ProficiencyBonus = StaticValues.ProfBonusFromCR(challengeRating);
            }
        }

        private int proficiencyBonus;
        public int ProficiencyBonus
        {
            get { return proficiencyBonus; }
            set
            {
                proficiencyBonus = value;
                SendNewProficiencyBonusToSkillsAndSavingThrows();
            }
        }


        private int armorClass;
        public int ArmorClass
        {
            get { return armorClass; }
            set
            {
                if (value < 0) { armorClass = 0; }
                else { armorClass = value; }
            }
        }

        private int currentArmorClass;
        public int CurrentArmorClass
        {
            get { return currentArmorClass; }
            set
            {
                if (value < 0) { currentArmorClass = 0; }
                else { currentArmorClass = value; }
            }
        }


        private int hitPoints;
        public int HitPoints
        {
            get { return hitPoints; }
            set
            {
                if (value < 0) { hitPoints = 0; }
                else { hitPoints = value; }
            }
        }
        public int CurrentHitPoints { get; set; }

        private int temporaryHitPoints;
        public int TemporaryHitPoints
        {
            get { return temporaryHitPoints; }
            set
            {
                if (value < 0) { temporaryHitPoints = 0; }
                else { temporaryHitPoints = value; }
            }
        }


        public int Initiative { get; set; }
        public int Speed { get; set; }
        public int CurrentSpeed { get; set; }


        public string Traits { get; set; } = "";
        public string Notes { get; set; } = "";


        //Abilities
        public List<Ability> Abilities { get; set; } = new List<Ability>();
        public Ability Strength { get; set; } = new Ability();
        public Ability Dexterity { get; set; } = new Ability();
        public Ability Constitution { get; set; } = new Ability();
        public Ability Intelligence { get; set; } = new Ability();
        public Ability Wisdom { get; set; } = new Ability();
        public Ability Charisma { get; set; } = new Ability();


        //Skills
        //Strength based
        public Skill Athletics { get; set; } = new Skill();

        //Dexterity based skills
        public Skill Acrobatics { get; set; } = new Skill();
        public Skill SleightOfHand { get; set; } = new Skill();
        public Skill Stealth { get; set; } = new Skill();

        //Intelligence based skills
        public Skill Arcana { get; set; } = new Skill();
        public Skill History { get; set; } = new Skill();
        public Skill Investigation { get; set; } = new Skill();
        public Skill Nature { get; set; } = new Skill();
        public Skill Religion { get; set; } = new Skill();

        //Wisdom based skills
        public Skill AnimalHandling { get; set; } = new Skill();
        public Skill Insight { get; set; } = new Skill();
        public Skill Medicine { get; set; } = new Skill();
        public Skill Perception { get; set; } = new Skill();
        public Skill Survival { get; set; } = new Skill();

        //Charisma based skills
        public Skill Deception { get; set; } = new Skill();
        public Skill Intimidation { get; set; } = new Skill();
        public Skill Performance { get; set; } = new Skill();
        public Skill Persuasion { get; set; } = new Skill();


        private void BuildListsOfSkills()
        {
            Strength.Skills.Add(Athletics);

            Dexterity.Skills.Add(Acrobatics);
            Dexterity.Skills.Add(SleightOfHand);
            Dexterity.Skills.Add(Stealth);

            Intelligence.Skills.Add(Arcana);
            Intelligence.Skills.Add(History);
            Intelligence.Skills.Add(Investigation);
            Intelligence.Skills.Add(Nature);
            Intelligence.Skills.Add(Religion);

            Wisdom.Skills.Add(AnimalHandling);
            Wisdom.Skills.Add(Insight);
            Wisdom.Skills.Add(Medicine);
            Wisdom.Skills.Add(Perception);
            Wisdom.Skills.Add(Survival);

            Charisma.Skills.Add(Deception);
            Charisma.Skills.Add(Intimidation);
            Charisma.Skills.Add(Performance);
            Charisma.Skills.Add(Persuasion);
        }

        private void BuildListOfAbilities()
        {
            Abilities.Add(Strength);
            Abilities.Add(Dexterity);
            Abilities.Add(Constitution);
            Abilities.Add(Intelligence);
            Abilities.Add(Wisdom);
            Abilities.Add(Charisma);
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
