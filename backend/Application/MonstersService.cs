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
        private readonly MonstersRepository _repository;

        public MonstersService(MonstersRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Monster> Get()
        {
            return _repository.Get();
        }
    }
}
