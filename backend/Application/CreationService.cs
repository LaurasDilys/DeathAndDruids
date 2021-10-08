using Application.Dto;
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

        public OpenedMonsterViewModel GetOpened()
        {
            var dataModel = _creationRepository.GetOpened();

            var creature = new Character();
            _mapper.TransformIntoFullCharacter(creature, dataModel);

            var viewModel = new OpenedMonsterViewModel(
                dataModel.Id, dataModel.SourceId, dataModel.Saved);
            _mapper.TransformIntoViewModel(viewModel, creature);

            return viewModel;
        }

        public void New()
        {
            var creature = new Character();
            var monster = new OpenedMonster();
            _mapper.TransformIntoDataModel(monster, creature);

            if (OpenedExists())
            {
                var previouslyInCreation = _monstersRepository.Get().Where(x => x.InCreation);
                foreach (var creation in previouslyInCreation) creation.InCreation = false;
                _creationRepository.DeleteAll();
            }

            _creationRepository.Add(monster);
        }

        public void Save()
        {
            var monster = _creationRepository.GetOpened();

            if (monster.Name == "") return; // if attempting to save without a name
            
            if (monster.SourceId != null) // if this monster had already been saved
            {
                var previuosSave = _monstersRepository.Get((int)monster.SourceId);
                _mapper.ReplaceWith(monster, previuosSave);
            }
            else // if this is a new monster, that hasn't been saved before
            {
                var allMonsters = _monstersRepository.Get();
                // do not allow saving of a monster with a name that's already in use
                if (allMonsters.Select(x => x.Name).Contains(monster.Name)) return;

                var newMonster = _mapper.NewMonsterFromOpened(monster);
                newMonster.InCreation = true;
                int newId =_monstersRepository.Add(newMonster);
                _creationRepository.GetOpened().SourceId = newId;
            }

            monster.Saved = true;
            _creationRepository.SaveChanges();
        }

        public bool Patch(IMonsterPatchRequest patch)
       {
            var monster = _creationRepository.GetOpened();

            var creature = new Character();
            _mapper.TransformIntoFullCharacter(creature, monster);
            if (_mapper.Patch(creature, patch))
            {
                _mapper.TransformIntoDataModel(monster, creature);

                monster.Saved = false;

                _creationRepository.SaveChanges();

                return true;
            }
            return false;
        }
    }
}
