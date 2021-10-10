using Business.Interfaces;
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
    public class PatchService
    {
        private readonly CombatRepository _combatRepository;
        private readonly CreationRepository _creationRepository;
        private readonly LocationRepository _locationRepository;
        private readonly MapperService _mapper;

        public PatchService(CombatRepository combatRepository,
            CreationRepository creationRepository,
            LocationRepository locationRepository,
            MapperService mapper)
        {
            _combatRepository = combatRepository;
            _creationRepository = creationRepository;
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public bool Patch(IMonsterPatchRequest patch)
        {
            var route = _locationRepository.GetRoute();
            if (route == "creation")
            {
                var monster = _creationRepository.GetOpened();
                if (monster == null) return false;

                var creature = new Creature();
                _mapper.TransformIntoExpanded(creature, monster);
                if (_mapper.Patch(creature, patch))
                {
                    _mapper.TransformIntoFlat(monster, creature);

                    monster.Saved = false;

                    _creationRepository.SaveChanges();

                    return true;
                }
                return false; // bad patch request
            }
            else if (route == "combat")
            {
                var id = _locationRepository.GetSelectedTab();
                if (id == null) return false;
                var monster = _combatRepository.Get((int)id);
                if (monster == null) return false;

                var creature = new Creature();
                _mapper.TransformIntoExpanded(creature, monster);
                if (_mapper.Patch(creature, patch))
                {
                    _mapper.TransformIntoFlat(monster, creature);

                    _creationRepository.SaveChanges();

                    return true;
                }
                return false; // bad patch request
            }
            else return false; // attempting to patch a monster
            // that's neither in combat, nor in creation
        }
    }
}
