using Data.Models;
using Data.Repositories;
using System;

namespace Application
{
    public class CreationService
    {
        private readonly CreationRepository _creationRepository;
        private readonly MonstersRepository _monstersRepository;
        private readonly MapperService _mapper;

        public CreationService(CreationRepository creationRepository,
            MonstersRepository monstersRepository,
            MapperService mapper)
        {
            _creationRepository = creationRepository;
            _monstersRepository = monstersRepository;
            _mapper = mapper;
        }

        public bool OpenedExists()
        {
            return _creationRepository.Exists();
        }

        public OpenedMonster GetOpened()
        {
            return _creationRepository.GetOpened();
        }

        public void New()
        {
            var monster = new OpenedMonster
            {
                Name = "",
                Initiative = 0
            };

            if (OpenedExists())
                _creationRepository.DeleteAll();

            _creationRepository.Add(monster);
        }

        public void Save()
        {
            var monster = _creationRepository.GetOpened();
            
            if (monster.SourceId != null)
            {
                var previuosSave = _monstersRepository.Get((int)monster.SourceId);
                _mapper.ReplaceWith(monster, previuosSave);
            }
            else
            {
                var newMonster = _mapper.NewMonsterFromOpened(monster);
                newMonster.InCreation = true;
                int newId =_monstersRepository.Add(newMonster);
                _creationRepository.GetOpened().SourceId = newId;
            }

            monster.Saved = true;
            _creationRepository.SaveChanges();
        }
    }
}
