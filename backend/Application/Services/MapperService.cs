using Application.Dto;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MapperService
    {
        private readonly CreatureMapperService _creatureMapper;

        public MapperService(CreatureMapperService creatureMapper)
        {
            _creatureMapper = creatureMapper;
        }

        public void TransformIntoFullCharacter(Creature creature, FlatCreature flatCreature)
        {
            _creatureMapper.TransformIntoExpanded(creature, flatCreature);
        }

        public void TransformIntoDataModel(FlatCreature flatCreature, Creature creature)
        {
            _creatureMapper.TransformIntoFlat(flatCreature, creature);
        }

        public void TransformIntoViewModel(SavableOpenedMonsterViewModel viewModel, Creature creature)
        {
            TransformIntoDataModel(viewModel, creature);

            viewModel.StrengthModifier = creature.Strength.ModifierText;
            viewModel.DexterityModifier = creature.Dexterity.ModifierText;
            viewModel.ConstitutionModifier = creature.Constitution.ModifierText;
            viewModel.IntelligenceModifier = creature.Intelligence.ModifierText;
            viewModel.WisdomModifier = creature.Wisdom.ModifierText;
            viewModel.CharismaModifier = creature.Charisma.ModifierText;

            viewModel.StrengthSavingThrow = creature.Strength.SavingThrow.ModifierText;
            viewModel.Athletics = creature.Athletics.ModifierText;

            viewModel.DexteritySavingThrow = creature.Dexterity.SavingThrow.ModifierText;
            viewModel.Acrobatics = creature.Acrobatics.ModifierText;
            viewModel.SleightOfHand = creature.SleightOfHand.ModifierText;
            viewModel.Stealth = creature.Stealth.ModifierText;

            viewModel.ConstitutionSavingThrow = creature.Constitution.SavingThrow.ModifierText;

            viewModel.IntelligenceSavingThrow = creature.Intelligence.SavingThrow.ModifierText;
            viewModel.Arcana = creature.Arcana.ModifierText;
            viewModel.History = creature.History.ModifierText;
            viewModel.Investigation = creature.Investigation.ModifierText;
            viewModel.Nature = creature.Nature.ModifierText;
            viewModel.Religion = creature.Religion.ModifierText;

            viewModel.WisdomSavingThrow = creature.Wisdom.SavingThrow.ModifierText;
            viewModel.AnimalHandling = creature.AnimalHandling.ModifierText;
            viewModel.Insight = creature.Insight.ModifierText;
            viewModel.Medicine = creature.Medicine.ModifierText;
            viewModel.Perception = creature.Perception.ModifierText;
            viewModel.Survival = creature.Survival.ModifierText;

            viewModel.CharismaSavingThrow = creature.Charisma.SavingThrow.ModifierText;
            viewModel.Deception = creature.Deception.ModifierText;
            viewModel.Intimidation = creature.Intimidation.ModifierText;
            viewModel.Performance = creature.Performance.ModifierText;
            viewModel.Persuasion = creature.Persuasion.ModifierText;
        }

        public Monster NewMonsterFromOpened(SavableOpenedMonster monster)
        {
            var newMonster = new Monster { Type = "monster" };
            SetValuesFrom(monster, newMonster);
            return newMonster;
        }

        public void ReplaceWith(Monster monster, SavableOpenedMonster previouslyOpened)
        {
            SetValuesFrom(monster, previouslyOpened);
            previouslyOpened.SourceId = monster.Id;
            previouslyOpened.Saved = true;
        }

        public void ReplaceWith(SavableOpenedMonster monster, Monster previousSave)
        {
            SetValuesFrom(monster, previousSave);
        }

        private void SetValuesFrom(FlatCreature creature,
            FlatCreature creatureWithOldValues)
        {
            foreach (var propertyInfo in typeof(FlatCreature)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var newValue = propertyInfo.GetValue(creature);
                propertyInfo.SetValue(creatureWithOldValues, newValue);
            }
        }
        
        //public void PatchName(OpenedMonster monster, IMonsterPatchRequest patch)
        //{
        //    if (patch.Value != "")
        //    {
        //        monster.Name = patch.Value;
        //    }
        //}

        public bool Patch(Creature creature, IMonsterPatchRequest patch)
        {
            int intValue;
            bool boolValue;
            double doubleValue;
            var stringValue = patch.Value;

            // capitalize property name
            var name = $"{char.ToUpper(patch.Name[0])}{patch.Name.Substring(1)}";
            var type = typeof(Creature);

            var abilityNames = new string[]
            {
                "Strength",
                "Dexterity",
                "Constitution",
                "Intelligence",
                "Wisdom",
                "Charisma"
            };

            var abilityName = abilityNames.FirstOrDefault(x => name.Contains(x));

            if (abilityName != null)
            {
                // setting the ability score, for example "Strength"
                if (name == abilityName)
                {
                    if (stringValue == "")
                    {
                        intValue = 0;
                        (type.GetProperty(abilityName).GetValue(creature) as Ability).Score = intValue;
                    }
                    else if (int.TryParse(stringValue, out intValue))
                    {
                        (type.GetProperty(abilityName).GetValue(creature) as Ability).Score = intValue;
                    }
                }
                // setting saving throw proficiency, for example "StrengthSavingThrowProficiency"
                else if (bool.TryParse(stringValue, out boolValue))
                {
                    (type.GetProperty(abilityName).GetValue(creature) as Ability).SavingThrow.Proficiency = boolValue;
                }
            }
            // setting other proficiency
            else if (name.Contains("Proficiency") && bool.TryParse(stringValue, out boolValue))
            {
                // remove the "Proficiency" part
                var skillName = name.Replace("Proficiency", "");
                var prop = type.GetProperty(skillName);
                if (prop == null) return false;
                (prop.GetValue(creature) as Skill).Proficiency = boolValue;
            }
            // setting any other value
            else
            {
                var prop = type.GetProperty(name);
                if (prop == null) return false;
                var propType = prop.PropertyType;
                if (propType.Equals(typeof(string)))
                {
                    prop.SetValue(creature, stringValue);
                }
                else if (propType.Equals(typeof(int)) && int.TryParse(stringValue, out intValue))
                {
                    prop.SetValue(creature, intValue);
                }
                else if (propType.Equals(typeof(bool)) && bool.TryParse(stringValue, out boolValue))
                {
                    prop.SetValue(creature, boolValue);
                }
                else if (propType.Equals(typeof(double)) && double.TryParse(stringValue, out doubleValue))
                {
                    prop.SetValue(creature, doubleValue);
                }
            }

            return true;
        }
    }
}
