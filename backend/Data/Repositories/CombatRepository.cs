using Data.Models;
using System.Collections.Generic;

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

        public void Delete(OpenedMonster monster)
        {
            _context.Combat.Remove(monster);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
