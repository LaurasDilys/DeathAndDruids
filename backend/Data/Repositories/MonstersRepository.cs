using Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class MonstersRepository
    {
        private readonly DataContext _context;

        public MonstersRepository(DataContext context)
        {
            _context = context;
        }

        public bool Any()
        {
            return _context.Monsters.Any();
        }

        public bool Exists(int key)
        {
            if (_context.Monsters.Find(key) == null)
            {
                return false;
            }
            return true;
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

        public void Delete(Monster monster)
        {
            _context.Monsters.Remove(monster);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
