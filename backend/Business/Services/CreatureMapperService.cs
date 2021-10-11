using Business.Models;
using System.Collections.Generic;

namespace Business.Services
{
    public class CreatureMapperService
    {
        public void TransformIntoExpanded(Creature creature, FlatCreature flatCreature)
        {
            creature.Name = flatCreature.Name;
            creature.Alignment = flatCreature.Alignment;
            creature.ChallengeRating = flatCreature.ChallengeRating;
            creature.ProficiencyBonus = flatCreature.ProficiencyBonus;


            creature.ArmorClass = flatCreature.ArmorClass;
            creature.CurrentArmorClass = flatCreature.CurrentArmorClass;


            creature.HitPoints = flatCreature.HitPoints;
            creature.CurrentHitPoints = flatCreature.CurrentHitPoints;
            creature.TemporaryHitPoints = flatCreature.TemporaryHitPoints;


            creature.Initiative = flatCreature.Initiative;
            creature.Speed = flatCreature.Speed;
            creature.CurrentSpeed = flatCreature.CurrentSpeed;


            creature.Traits = flatCreature.Traits;
            creature.Notes = flatCreature.Notes;


            List<int> characterDbAbilityScores = new List<int>()
            {
                flatCreature.Strength,
                flatCreature.Dexterity,
                flatCreature.Constitution,
                flatCreature.Intelligence,
                flatCreature.Wisdom,
                flatCreature.Charisma,
            };

            int i = 0;

            foreach (Ability ability in creature.Abilities)
            {
                ability.Score = characterDbAbilityScores[i++];
            }


            List<bool> characterDbProficiencies = new List<bool>()
            {
                flatCreature.StrengthSavingThrowProficiency,
                flatCreature.AthleticsProficiency,

                flatCreature.DexteritySavingThrowProficiency,
                flatCreature.AcrobaticsProficiency,
                flatCreature.SleightOfHandProficiency,
                flatCreature.StealthProficiency,

                flatCreature.ConstitutionSavingThrowProficiency,

                flatCreature.IntelligenceSavingThrowProficiency,
                flatCreature.ArcanaProficiency,
                flatCreature.HistoryProficiency,
                flatCreature.InvestigationProficiency,
                flatCreature.NatureProficiency,
                flatCreature.ReligionProficiency,

                flatCreature.WisdomSavingThrowProficiency,
                flatCreature.AnimalHandlingProficiency,
                flatCreature.InsightProficiency,
                flatCreature.MedicineProficiency,
                flatCreature.PerceptionProficiency,
                flatCreature.SurvivalProficiency,

                flatCreature.CharismaSavingThrowProficiency,
                flatCreature.DeceptionProficiency,
                flatCreature.IntimidationProficiency,
                flatCreature.PerformanceProficiency,
                flatCreature.PersuasionProficiency,
            };

            int j = 0;

            foreach (Ability ability in creature.Abilities)
            {
                ability.SavingThrow.Proficiency = characterDbProficiencies[j++];
                foreach (Skill skill in ability.Skills)
                {
                    skill.Proficiency = characterDbProficiencies[j++];
                }
            }
        }

        public void TransformIntoFlat(FlatCreature flatCreature, Creature creature)
        {
            flatCreature.Name = creature.Name;
            flatCreature.Alignment = creature.Alignment;
            flatCreature.ChallengeRating = creature.ChallengeRating;
            flatCreature.ProficiencyBonus = creature.ProficiencyBonus;


            flatCreature.ArmorClass = creature.ArmorClass;
            flatCreature.CurrentArmorClass = creature.CurrentArmorClass;


            flatCreature.HitPoints = creature.HitPoints;
            flatCreature.CurrentHitPoints = creature.CurrentHitPoints;
            flatCreature.TemporaryHitPoints = creature.TemporaryHitPoints;


            flatCreature.Initiative = creature.Initiative;
            flatCreature.Speed = creature.Speed;
            flatCreature.CurrentSpeed = creature.CurrentSpeed;


            flatCreature.Traits = creature.Traits;
            flatCreature.Notes = creature.Notes;


            int i = 0;

            flatCreature.Strength = creature.Abilities[i++].Score;
            flatCreature.Dexterity = creature.Abilities[i++].Score;
            flatCreature.Constitution = creature.Abilities[i++].Score;
            flatCreature.Intelligence = creature.Abilities[i++].Score;
            flatCreature.Wisdom = creature.Abilities[i++].Score;
            flatCreature.Charisma = creature.Abilities[i].Score;


            List<bool> characterProficiencies = new List<bool>();
            foreach (Ability ability in creature.Abilities)
            {
                characterProficiencies.Add(ability.SavingThrow.Proficiency);
                foreach (Skill skill in ability.Skills)
                {
                    characterProficiencies.Add(skill.Proficiency);
                }
            }

            int j = 0;

            flatCreature.StrengthSavingThrowProficiency = characterProficiencies[j++];
            flatCreature.AthleticsProficiency = characterProficiencies[j++];

            flatCreature.DexteritySavingThrowProficiency = characterProficiencies[j++];
            flatCreature.AcrobaticsProficiency = characterProficiencies[j++];
            flatCreature.SleightOfHandProficiency = characterProficiencies[j++];
            flatCreature.StealthProficiency = characterProficiencies[j++];

            flatCreature.ConstitutionSavingThrowProficiency = characterProficiencies[j++];

            flatCreature.IntelligenceSavingThrowProficiency = characterProficiencies[j++];
            flatCreature.ArcanaProficiency = characterProficiencies[j++];
            flatCreature.HistoryProficiency = characterProficiencies[j++];
            flatCreature.InvestigationProficiency = characterProficiencies[j++];
            flatCreature.NatureProficiency = characterProficiencies[j++];
            flatCreature.ReligionProficiency = characterProficiencies[j++];

            flatCreature.WisdomSavingThrowProficiency = characterProficiencies[j++];
            flatCreature.AnimalHandlingProficiency = characterProficiencies[j++];
            flatCreature.InsightProficiency = characterProficiencies[j++];
            flatCreature.MedicineProficiency = characterProficiencies[j++];
            flatCreature.PerceptionProficiency = characterProficiencies[j++];
            flatCreature.SurvivalProficiency = characterProficiencies[j++];

            flatCreature.CharismaSavingThrowProficiency = characterProficiencies[j++];
            flatCreature.DeceptionProficiency = characterProficiencies[j++];
            flatCreature.IntimidationProficiency = characterProficiencies[j++];
            flatCreature.PerformanceProficiency = characterProficiencies[j++];
            flatCreature.PersuasionProficiency = characterProficiencies[j];
        }
    }
}
