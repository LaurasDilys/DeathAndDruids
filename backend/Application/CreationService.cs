using Data.Models;
using Data.Repositories;
using System;

namespace Application
{
    public class CreationService
    {
        private readonly CreationRepository _repository;

        public CreationService(CreationRepository repository)
        {
            _repository = repository;
        }

        public bool OpenedExists()
        {
            return _repository.Exists();
        }

        public OpenedMonster GetOpened()
        {
            return _repository.GetOpened();
        }

        public void New()
        {
            var monster = new OpenedMonster
            {
                Name = "",
                Initiative = 0
            };

            if (OpenedExists())
                _repository.DeleteAll();

            _repository.Add(monster);
        }
    }
}
