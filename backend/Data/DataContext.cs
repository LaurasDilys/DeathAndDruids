using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataContext : DbContext
    {
        public DbSet<Monster> Monsters { get; set; }
        // public DbSet<Location> Location { get; set; }
        public DbSet<SavableOpenedMonster> Creation { get; set; }
        // public DbSet<OpenedMonster> Combat { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
