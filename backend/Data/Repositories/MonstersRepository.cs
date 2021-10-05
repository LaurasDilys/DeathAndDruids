using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class MonstersRepository
    {
        private readonly DataContext _context;

        public MonstersRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Monster> Get()
        {
            return _context.Monsters;
        }

        public Monster Get(int key)
        {
            return _context.Monsters.Find(key);
        }

        public int Add(Monster monster)
        {
            _context.Monsters.Add(monster);
            SaveChanges();
            return monster.Id;
        }



        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
