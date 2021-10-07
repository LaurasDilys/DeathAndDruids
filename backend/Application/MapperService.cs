using Business.Interfaces;
using Business.Models;
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
            if (patch.Value == "") return;

            int intValue;
            bool boolValue;
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
            }
        }
    }
}
