using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ConverterService
    {
        public void TransformIntoFullCharacter(Character character, CharacterDataModel characterDb)
        {
            character.Name = characterDb.Name;
            //character.Class = characterDb.Class;
            //character.Race = characterDb.Race;
            //character.Background = characterDb.Background;
            //character.Alignment = characterDb.Alignment;


            //character.Level = characterDb.Level;
            //character.ExperiencePoints = characterDb.ExperiencePoints;
            character.ProficiencyBonus = characterDb.ProficiencyBonus;
            //character.Inspiration = characterDb.Inspiration;


            //character.ArmorClass = characterDb.ArmorClass;
            //character.CurrentArmorClass = characterDb.CurrentArmorClass;


            //character.HitPoints = characterDb.HitPoints;
            //character.TemporaryHitPoints = characterDb.TemporaryHitPoints;
            //character.CurrentHitPoints = characterDb.CurrentHitPoints;


            character.Initiative = characterDb.Initiative;
            //character.CurrentInitiative = characterDb.CurrentInitiative;


            //character.Speed = characterDb.Speed;
            //character.CurrentSpeed = characterDb.CurrentSpeed;


            //character.UsedHitDice = characterDb.UsedHitDice;


            //character.DeathSaveSuccess1 = characterDb.DeathSaveSuccess1;
            //character.DeathSaveSuccess2 = characterDb.DeathSaveSuccess2;
            //character.DeathSaveSuccess3 = characterDb.DeathSaveSuccess3;
            //character.DeathSaveFailure1 = characterDb.DeathSaveFailure1;
            //character.DeathSaveFailure2 = characterDb.DeathSaveFailure2;
            //character.DeathSaveFailure3 = characterDb.DeathSaveFailure3;


            //character.Traits = characterDb.Traits;
            //character.Notes = characterDb.Notes;


            List<int> characterDbAbilityScores = new List<int>()
            {
                characterDb.Strength,
                //characterDb.Dexterity,
                //characterDb.Constitution,
                //characterDb.Intelligence,
                //characterDb.Wisdom,
                //characterDb.Charisma,
            };

            int i = 0;

            foreach (Ability ability in character.Abilities)
            {
                ability.Score = characterDbAbilityScores[i++];
            }


            List<bool> characterDbProficiencies = new List<bool>()
            {
                characterDb.StrengthSavingThrowProficiency,
                characterDb.AthleticsProficiency,

                //characterDb.DexteritySavingThrowProficiency,
                //characterDb.AcrobaticsProficiency,
                //characterDb.SleightOfHandProficiency,
                //characterDb.StealthProficiency,

                //characterDb.ConstitutionSavingThrowProficiency,

                //characterDb.IntelligenceSavingThrowProficiency,
                //characterDb.ArcanaProficiency,
                //characterDb.HistoryProficiency,
                //characterDb.InvestigationProficiency,
                //characterDb.NatureProficiency,
                //characterDb.ReligionProficiency,

                //characterDb.WisdomSavingThrowProficiency,
                //characterDb.AnimalHandlingProficiency,
                //characterDb.InsightProficiency,
                //characterDb.MedicineProficiency,
                //characterDb.PerceptionProficiency,
                //characterDb.SurvivalProficiency,

                //characterDb.CharismaSavingThrowProficiency,
                //characterDb.DeceptionProficiency,
                //characterDb.IntimidationProficiency,
                //characterDb.PerformanceProficiency,
                //characterDb.PersuasionProficiency,
            };

            int j = 0;

            foreach (Ability ability in character.Abilities)
            {
                ability.SavingThrow.Proficiency = characterDbProficiencies[j++];
                foreach (Skill skill in ability.Skills)
                {
                    skill.Proficiency = characterDbProficiencies[j++];
                }
            }
        }

        public void TransformIntoDataModel(CharacterDataModel characterDb, Character character)
        {
            characterDb.Name = character.Name;
            //characterDb.Class = character.Class;
            //characterDb.Race = character.Race;
            //characterDb.Background = character.Background;
            //characterDb.Alignment = character.Alignment;


            //characterDb.Level = character.Level;
            //characterDb.ExperiencePoints = character.ExperiencePoints;
            characterDb.ProficiencyBonus = character.ProficiencyBonus;
            //characterDb.Inspiration = character.Inspiration;


            //characterDb.ArmorClass = character.ArmorClass;
            //characterDb.CurrentArmorClass = character.CurrentArmorClass;


            //characterDb.HitPoints = character.HitPoints;
            //characterDb.TemporaryHitPoints = character.TemporaryHitPoints;
            //characterDb.CurrentHitPoints = character.CurrentHitPoints;


            characterDb.Initiative = character.Initiative;
            //characterDb.CurrentInitiative = character.CurrentInitiative;


            //characterDb.Speed = character.Speed;
            //characterDb.CurrentSpeed = character.CurrentSpeed;


            //characterDb.UsedHitDice = character.UsedHitDice;


            //characterDb.DeathSaveSuccess1 = character.DeathSaveSuccess1;
            //characterDb.DeathSaveSuccess2 = character.DeathSaveSuccess2;
            //characterDb.DeathSaveSuccess3 = character.DeathSaveSuccess3;
            //characterDb.DeathSaveFailure1 = character.DeathSaveFailure1;
            //characterDb.DeathSaveFailure2 = character.DeathSaveFailure2;
            //characterDb.DeathSaveFailure3 = character.DeathSaveFailure3;


            //characterDb.Traits = character.Traits;
            //characterDb.Notes = character.Notes;


            int i = 0;

            characterDb.Strength = character.Abilities[i++].Score;
            //characterDb.Dexterity = character.Abilities[i++].Score;
            //characterDb.Constitution = character.Abilities[i++].Score;
            //characterDb.Intelligence = character.Abilities[i++].Score;
            //characterDb.Wisdom = character.Abilities[i++].Score;
            //characterDb.Charisma = character.Abilities[i].Score;


            List<bool> characterProficiencies = new List<bool>();
            foreach (Ability ability in character.Abilities)
            {
                characterProficiencies.Add(ability.SavingThrow.Proficiency);
                foreach (Skill skill in ability.Skills)
                {
                    characterProficiencies.Add(skill.Proficiency);
                }
            }

            int j = 0;

            characterDb.StrengthSavingThrowProficiency = characterProficiencies[j++];
            characterDb.AthleticsProficiency = characterProficiencies[j++];

            //characterDb.DexteritySavingThrowProficiency = characterProficiencies[j++];
            //characterDb.AcrobaticsProficiency = characterProficiencies[j++];
            //characterDb.SleightOfHandProficiency = characterProficiencies[j++];
            //characterDb.StealthProficiency = characterProficiencies[j++];

            //characterDb.ConstitutionSavingThrowProficiency = characterProficiencies[j++];

            //characterDb.IntelligenceSavingThrowProficiency = characterProficiencies[j++];
            //characterDb.ArcanaProficiency = characterProficiencies[j++];
            //characterDb.HistoryProficiency = characterProficiencies[j++];
            //characterDb.InvestigationProficiency = characterProficiencies[j++];
            //characterDb.NatureProficiency = characterProficiencies[j++];
            //characterDb.ReligionProficiency = characterProficiencies[j++];

            //characterDb.WisdomSavingThrowProficiency = characterProficiencies[j++];
            //characterDb.AnimalHandlingProficiency = characterProficiencies[j++];
            //characterDb.InsightProficiency = characterProficiencies[j++];
            //characterDb.MedicineProficiency = characterProficiencies[j++];
            //characterDb.PerceptionProficiency = characterProficiencies[j++];
            //characterDb.SurvivalProficiency = characterProficiencies[j++];

            //characterDb.CharismaSavingThrowProficiency = characterProficiencies[j++];
            //characterDb.DeceptionProficiency = characterProficiencies[j++];
            //characterDb.IntimidationProficiency = characterProficiencies[j++];
            //characterDb.PerformanceProficiency = characterProficiencies[j++];
            //characterDb.PersuasionProficiency = characterProficiencies[j];
        }
    }
}
