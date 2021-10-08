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
        private readonly MonstersRepository _monstersRepository;
        private readonly CreationRepository _creationRepository;
        private readonly MapperService _mapper;

        public MonstersService(MonstersRepository monsterRepository,
            CreationRepository creationRepository,
            MapperService mapper)
        {
            _monstersRepository = monsterRepository;
            _creationRepository = creationRepository;
            _mapper = mapper;
        }

        public bool Any()
        {
            return _monstersRepository.Any();
        }

        public bool Exists(int key)
        {
            return _monstersRepository.Exists(key);
        }

        public IEnumerable<Monster> Get()
        {
            return _monstersRepository.Get();
        }

        // TO CREATION
        public void Open(int key)
        {
            var monster = _monstersRepository.Get(key);
            OpenedMonster currentlyOpened;
            if (_creationRepository.Exists())
            {
                currentlyOpened = _creationRepository.GetOpened();

                int? sourceId = currentlyOpened.SourceId;
                if (sourceId != null && sourceId != monster.Id
                    && _monstersRepository.Exists((int)sourceId)) // extra precaution
                {
                    // change previously opened accordingly
                    _monstersRepository.Get((int)sourceId).InCreation = false;
                }

                _mapper.ReplaceWith(monster, currentlyOpened);
                monster.InCreation = true;
            }
            else
            {
                currentlyOpened = new OpenedMonster();

                _mapper.ReplaceWith(monster, currentlyOpened);
                monster.InCreation = true;

                currentlyOpened.SourceId = monster.Id;
                _creationRepository.Add(currentlyOpened);
            }

            _monstersRepository.SaveChanges();
        }

        public void OpenLast()
        {
            Open(_monstersRepository.Get().Last().Id);
        }
        //

        public void Delete(int key)
        {
            var monster = _monstersRepository.Get(key);

            _monstersRepository.Delete(monster);
        }
    }
}
