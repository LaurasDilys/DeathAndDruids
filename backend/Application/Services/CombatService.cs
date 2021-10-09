using Business.Models;
using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CombatService
    {
        private readonly CombatRepository _combatRepository;
        private readonly MonstersRepository _monstersRepository;
        private readonly MapperService _mapper;

        public CombatService(CombatRepository combatRepository,
            MonstersRepository monstersRepository,
            MapperService mapper)
        {
            _combatRepository = combatRepository;
            _monstersRepository = monstersRepository;
            _mapper = mapper;
        }

        public void Add(int amount)
        {
            var monster = _monstersRepository.Get(1);
            monster.InCombat = true;

            var combatants = new List<OpenedMonster>(amount);

            for (int i = 0; i < 3; i++)
            {
                var combatant = new OpenedMonster();
                _mapper.ReplaceWith(monster, combatant);
                combatants.Add(combatant);
            }

            _combatRepository.AddRange(combatants);
            _combatRepository.SaveChanges();
        }
    }
}
