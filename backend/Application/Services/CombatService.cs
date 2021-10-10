﻿using Application.Dto;
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

        public bool Add(CombatRequest request)
        {
            var req = request.Request;
            var ids = req.Select(r => r.Id);
            var monsters = _monstersRepository.Get().Where(m => ids.Contains(m.Id));

            // Some incorrect ids were requested
            if (monsters.Count() != ids.Count()) return false;

            var combatants = new List<OpenedMonster>(req.Sum(r => r.Amount));
            foreach (var requestedMonster in req)
            {
                var monster = monsters.Single(m => m.Id == requestedMonster.Id);
                monster.InCombat = true;

                for (int i = 0; i < requestedMonster.Amount; i++)
                {
                    var combatant = new OpenedMonster();
                    _mapper.ReplaceWith(monster, combatant);
                    combatants.Add(combatant);
                }
            }
            _combatRepository.AddRange(combatants);
            _combatRepository.SaveChanges();
            return true;
        }

        public IEnumerable<OpenedMonster> Get()
        {
            return _combatRepository.Get();
        }
    }
}