using Business.Interfaces;
using Business.Models;
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
        private readonly CreationRepository _creationRepository;
        private readonly MapperService _mapper;

        public PatchService(CreationRepository creationRepository, MapperService mapper)
        {
            _creationRepository = creationRepository;
            _mapper = mapper;
        }

        public bool Patch(IMonsterPatchRequest patch)
        {
            var monster = _creationRepository.GetOpened();

            var creature = new Creature();
            _mapper.TransformIntoExpanded(creature, monster);
            if (_mapper.Patch(creature, patch))
            {
                _mapper.TransformIntoFlat(monster, creature);

                monster.Saved = false;

                _creationRepository.SaveChanges();

                return true;
            }
            return false;
        }
    }
}
