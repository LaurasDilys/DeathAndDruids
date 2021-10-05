﻿using Data.Models;
using Microsoft.EntityFrameworkCore;
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

        public OpenedMonster GetOpened()
        {
            return _context.OpenedMonsters.First();
        }

        public void Add(OpenedMonster monster)
        {
            _context.OpenedMonsters.Add(monster);
            SaveChanges();
        }

        public void DeleteAll()
        {
            _context.OpenedMonsters.RemoveRange(_context.OpenedMonsters);
            SaveChanges();
        }



        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
