using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _context.OpenedMonsters.Any();
        }
    }
}
