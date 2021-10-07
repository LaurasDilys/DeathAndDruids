﻿using Application.Dto;
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

namespace Application
{
    public class MapperService
    {
        private readonly ConverterService _converter;

        public MapperService(ConverterService converter)
        {
            _converter = converter;
        }

        public void TransformIntoFullCharacter(Character character, CharacterDataModel characterDb)
        {
            _converter.TransformIntoFullCharacter(character, characterDb);
        }

        public void TransformIntoDataModel(CharacterDataModel characterDb, Character character)
        {
            _converter.TransformIntoDataModel(characterDb, character);
        }

        public void TransformIntoViewModel(OpenedMonsterViewModel viewModel, Character creature)
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

        public Monster NewMonsterFromOpened(OpenedMonster monster)
        {
            var newMonster = new Monster { Type = "monster" };
            SetValuesFrom(monster, newMonster);
            return newMonster;
        }

        public void ReplaceWith(OpenedMonster monster, Monster previousSave)
        {
            SetValuesFrom(monster, previousSave);
        }

        private void SetValuesFrom(CharacterDataModel creature,
            CharacterDataModel creatureWithOldValues)
        {
            foreach (var propertyInfo in typeof(CharacterDataModel)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var newValue = propertyInfo.GetValue(creature);
                propertyInfo.SetValue(creatureWithOldValues, newValue);
            }
        }
        
        public void PatchName(OpenedMonster monster, IMonsterPatchRequest patch)
        {
            if (patch.Value != "")
            {
                monster.Name = patch.Value;
            }
        }

        public void Patch(Character creature, IMonsterPatchRequest patch)
        {
                                // CreationController Patch() method will catch this
            if (patch.Value == "") throw new NullReferenceException();

            int intValue;
            bool boolValue;
            double doubleValue;
            var stringValue = patch.Value;

            // capitalize property name
            var name = $"{char.ToUpper(patch.Name[0])}{patch.Name.Substring(1)}";
            var type = typeof(Character);

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
                if (name == abilityName && int.TryParse(stringValue, out intValue))
                {
                    (type.GetProperty(abilityName).GetValue(creature) as Ability).Score = intValue;
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
                (type.GetProperty(skillName).GetValue(creature) as Skill).Proficiency = boolValue;
            }
            // setting any other value
            else
            {
                var prop = type.GetProperty(name);
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
        }
    }
}
