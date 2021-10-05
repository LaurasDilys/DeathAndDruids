using Business.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class MapperService
    {
        // Use reflection and common parent class
        public Monster NewMonsterFromOpened(OpenedMonster monster)
        {
            return new Monster
            {
                Name = monster.Name,
                Initiative = monster.Initiative,
                Type = "monster"
            };
        }

        // Use reflection and common parent class
        public void ReplaceWith(OpenedMonster monster, Monster previousSave)
        {
            previousSave.Name = monster.Name;
            previousSave.Initiative = monster.Initiative;
        }

        public void PatchName(OpenedMonster monster, IMonsterPatchRequest patch)
        {
            if (patch.Value != "")
            {
                monster.Name = patch.Value;
            }
        }

        public void Patch(OpenedMonster monster, IMonsterPatchRequest patch)
        {
            int newValue;

            if (patch.Value != "" && int.TryParse(patch.Value, out newValue))
            {
                string propName = $"{char.ToUpper(patch.Name[0])}{patch.Name.Substring(1)}";
                //try
                //{
                    monster.GetType().GetProperty(propName).SetValue(monster, newValue);
                //}
                //finally
            }
        }
    }
}
