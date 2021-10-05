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
    }
}
