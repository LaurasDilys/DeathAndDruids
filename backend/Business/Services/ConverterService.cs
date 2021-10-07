using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ConverterService // CreatureMapperService
    {
        public void TransformIntoFullCharacter(Character character, CharacterDataModel characterDb)
        {
            character.Name = characterDb.Name;
            character.Alignment = characterDb.Alignment;
            character.ChallengeRating = characterDb.ChallengeRating;
            character.ProficiencyBonus = characterDb.ProficiencyBonus;


            character.ArmorClass = characterDb.ArmorClass;
            character.CurrentArmorClass = characterDb.CurrentArmorClass;


            character.HitPoints = characterDb.HitPoints;
            character.CurrentHitPoints = characterDb.CurrentHitPoints;
            character.TemporaryHitPoints = characterDb.TemporaryHitPoints;


            character.Initiative = characterDb.Initiative;
            character.Speed = characterDb.Speed;
            character.CurrentSpeed = characterDb.CurrentSpeed;


            character.Traits = characterDb.Traits;
            character.Notes = characterDb.Notes;


            List<int> characterDbAbilityScores = new List<int>()
            {
                characterDb.Strength,
                characterDb.Dexterity,
                characterDb.Constitution,
                characterDb.Intelligence,
                characterDb.Wisdom,
                characterDb.Charisma,
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

                characterDb.DexteritySavingThrowProficiency,
                characterDb.AcrobaticsProficiency,
                characterDb.SleightOfHandProficiency,
                characterDb.StealthProficiency,

                characterDb.ConstitutionSavingThrowProficiency,

                characterDb.IntelligenceSavingThrowProficiency,
                characterDb.ArcanaProficiency,
                characterDb.HistoryProficiency,
                characterDb.InvestigationProficiency,
                characterDb.NatureProficiency,
                characterDb.ReligionProficiency,

                characterDb.WisdomSavingThrowProficiency,
                characterDb.AnimalHandlingProficiency,
                characterDb.InsightProficiency,
                characterDb.MedicineProficiency,
                characterDb.PerceptionProficiency,
                characterDb.SurvivalProficiency,

                characterDb.CharismaSavingThrowProficiency,
                characterDb.DeceptionProficiency,
                characterDb.IntimidationProficiency,
                characterDb.PerformanceProficiency,
                characterDb.PersuasionProficiency,
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
            characterDb.Alignment = character.Alignment;
            characterDb.ChallengeRating = character.ChallengeRating;
            characterDb.ProficiencyBonus = character.ProficiencyBonus;


            characterDb.ArmorClass = character.ArmorClass;
            characterDb.CurrentArmorClass = character.CurrentArmorClass;


            characterDb.HitPoints = character.HitPoints;
            characterDb.CurrentHitPoints = character.CurrentHitPoints;
            characterDb.TemporaryHitPoints = character.TemporaryHitPoints;


            characterDb.Initiative = character.Initiative;
            characterDb.Speed = character.Speed;
            characterDb.CurrentSpeed = character.CurrentSpeed;


            characterDb.Traits = character.Traits;
            characterDb.Notes = character.Notes;


            int i = 0;

            characterDb.Strength = character.Abilities[i++].Score;
            characterDb.Dexterity = character.Abilities[i++].Score;
            characterDb.Constitution = character.Abilities[i++].Score;
            characterDb.Intelligence = character.Abilities[i++].Score;
            characterDb.Wisdom = character.Abilities[i++].Score;
            characterDb.Charisma = character.Abilities[i].Score;


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

            characterDb.DexteritySavingThrowProficiency = characterProficiencies[j++];
            characterDb.AcrobaticsProficiency = characterProficiencies[j++];
            characterDb.SleightOfHandProficiency = characterProficiencies[j++];
            characterDb.StealthProficiency = characterProficiencies[j++];

            characterDb.ConstitutionSavingThrowProficiency = characterProficiencies[j++];

            characterDb.IntelligenceSavingThrowProficiency = characterProficiencies[j++];
            characterDb.ArcanaProficiency = characterProficiencies[j++];
            characterDb.HistoryProficiency = characterProficiencies[j++];
            characterDb.InvestigationProficiency = characterProficiencies[j++];
            characterDb.NatureProficiency = characterProficiencies[j++];
            characterDb.ReligionProficiency = characterProficiencies[j++];

            characterDb.WisdomSavingThrowProficiency = characterProficiencies[j++];
            characterDb.AnimalHandlingProficiency = characterProficiencies[j++];
            characterDb.InsightProficiency = characterProficiencies[j++];
            characterDb.MedicineProficiency = characterProficiencies[j++];
            characterDb.PerceptionProficiency = characterProficiencies[j++];
            characterDb.SurvivalProficiency = characterProficiencies[j++];

            characterDb.CharismaSavingThrowProficiency = characterProficiencies[j++];
            characterDb.DeceptionProficiency = characterProficiencies[j++];
            characterDb.IntimidationProficiency = characterProficiencies[j++];
            characterDb.PerformanceProficiency = characterProficiencies[j++];
            characterDb.PersuasionProficiency = characterProficiencies[j];
        }
    }
}
