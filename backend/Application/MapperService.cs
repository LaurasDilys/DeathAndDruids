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

        //public void Patch(OpenedMonster monster, IMonsterPatchRequest patch)
        //{
        //    int newValue;

        //    if (patch.Value != "" && int.TryParse(patch.Value, out newValue))
        //    {
        //        string propName = $"{char.ToUpper(patch.Name[0])}{patch.Name.Substring(1)}";
        //        //try
        //        //{
        //            monster.GetType().GetProperty(propName).SetValue(monster, newValue);
        //        //}
        //        //finally
        //    }
        //}

        public void Patch(Character creature, IMonsterPatchRequest patch)
        {
            int newValue;

            if (patch.Value != "" && int.TryParse(patch.Value, out newValue))
            {
                string propName = $"{char.ToUpper(patch.Name[0])}{patch.Name.Substring(1)}";
                //try
                //{
                creature.GetType().GetProperty(propName).SetValue(creature, newValue);
                //}
                //finally
            }
        }
    }
}
