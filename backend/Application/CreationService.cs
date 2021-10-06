using Business.Interfaces;
using Business.Models;
using Business.Services;
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

        //public void Patch(IMonsterPatchRequest patch)
        //{
        //    var monster = _creationRepository.GetOpened();

        //    if (patch.Name == "name")
        //    {
        //        _mapper.PatchName(monster, patch);
        //    }
        //    else
        //    {
        //        _mapper.Patch(monster, patch);
        //    }

        //    monster.Saved = false;

        //    _creationRepository.SaveChanges();
        //}

        public void Patch(IMonsterPatchRequest patch)
        {
            var monster = _creationRepository.GetOpened();
            if (patch.Name == "name")
            {
                _mapper.PatchName(monster, patch);
            }
            else
            {
                var experiment = new Character();
                _converter.TransformIntoFullCharacter(experiment, monster);
                _mapper.Patch(experiment, patch);
                _converter.TransformIntoDataModel(monster, experiment);
            }

            monster.Saved = false;

            _creationRepository.SaveChanges();
        }
    }
}
