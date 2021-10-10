using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CombatRepository
    {
        private readonly DataContext _context;

        public CombatRepository(DataContext context)
        {
            _context = context;
        }

        public void AddRange(IEnumerable<OpenedMonster> monsters)
        {
            _context.Combat.AddRange(monsters);
        }

        public IEnumerable<OpenedMonster> Get()
        {
            return _context.Combat;
        }

        public OpenedMonster Get(int key)
        {
            return _context.Combat.Find(key);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
