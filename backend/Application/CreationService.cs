using Business.Interfaces;
using Business.Models;
using Business.Services;
using Data.Models;
using Data.Repositories;
using System;
using System.Linq;

namespace Application
{
    public class CreationService
    {
        private readonly CreationRepository _creationRepository;
        private readonly MonstersRepository _monstersRepository;
        private readonly MapperService _mapper;
        private readonly ConverterService _converter;

        public CreationService(CreationRepository creationRepository,
            MonstersRepository monstersRepository,
            MapperService mapper,
            ConverterService converter)
        {
            _creationRepository = creationRepository;
            _monstersRepository = monstersRepository;
            _mapper = mapper;
            _converter = converter;
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
            var allMonsters = _monstersRepository.Get();

            // do not allow saving of a monster with a name that's already in use
            if (allMonsters.Select(x => x.Name).Contains(monster.Name)) return;
            
            if (monster.SourceId != null) // if this monster had already been saved
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

        public void Patch(IMonsterPatchRequest patch)
        {
            var monster = _creationRepository.GetOpened();

            var creature = new Character();
            _converter.TransformIntoFullCharacter(creature, monster);
            _mapper.Patch(creature, patch);
            _converter.TransformIntoDataModel(monster, creature);

            monster.Saved = false;

            _creationRepository.SaveChanges();
        }
    }
}
