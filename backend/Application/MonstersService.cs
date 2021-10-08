using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class MonstersService
    {
        private readonly MonstersRepository _monsterRepository;
        private readonly CreationRepository _creationRepository;
        private readonly MapperService _mapper;

        public MonstersService(MonstersRepository monsterRepository,
            CreationRepository creationRepository,
            MapperService mapper)
        {
            _monsterRepository = monsterRepository;
            _creationRepository = creationRepository;
            _mapper = mapper;
        }

        public IEnumerable<Monster> Get()
        {
            return _monsterRepository.Get();
        }

        public bool Exists(int key)
        {
            return _monsterRepository.Exists(key);
        }

        public void Open(int key)
        {
            var monster = _monsterRepository.Get(key);
            var previouslyOpened = _creationRepository.GetOpened();

            int? prevId = previouslyOpened.SourceId;
            if (prevId != null && prevId != monster.Id)
            {
                // change previously opened accordingly
                _monsterRepository.Get((int)previouslyOpened.SourceId).InCreation = false;
            }

            _mapper.ReplaceWith(monster, previouslyOpened);
            monster.InCreation = true;

            _monsterRepository.SaveChanges();
        }
    }
}
