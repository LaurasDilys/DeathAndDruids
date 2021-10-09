using Data.Models;
using System.Linq;

namespace Data.Repositories
{
    public class CreationRepository
    {
        private readonly DataContext _context;

        public CreationRepository(DataContext context)
        {
            _context = context;
        }

        public bool Exists()
        {
            return _context.Creation.Any();
        }

        public SavableOpenedMonster GetOpened()
        {
            return _context.Creation.FirstOrDefault();
        }

        public void Add(SavableOpenedMonster monster)
        {
            _context.Creation.Add(monster);
            SaveChanges();
        }

        public void DeleteAll()
        {
            _context.Creation.RemoveRange(_context.Creation);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
