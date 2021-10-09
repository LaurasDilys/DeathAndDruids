using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
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

        public void Delete(int key)
        {
            var monster = _monstersRepository.Get(key);

            _monstersRepository.Delete(monster);
        }
    }
}
