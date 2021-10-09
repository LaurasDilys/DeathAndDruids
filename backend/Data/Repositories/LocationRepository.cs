using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class LocationRepository
    {
        private readonly DataContext _context;

        public LocationRepository(DataContext context)
        {
            _context = context;
        }

        private IEnumerable<Location> EnsureExists()
        {
            var table = _context.Location;
            if (!table.Any()) table.Add(new Location());
            SaveChanges();
            return table;
        }

        public void SetRoute(string route)
        {
            EnsureExists().First().Route = route;
            SaveChanges();
        }

        public string GetRoute()
        {
            var table = _context.Location;
            if (!table.Any()) return "";
            return table.First().Route;
        }

        public void SetSelectedTab(int selectedTab)
        {
            EnsureExists().First().SelectedTab = selectedTab;
            SaveChanges();
        }

        public int? GetSelectedTab()
        {
            var table = _context.Location;
            if (!table.Any()) return null;
            return table.First().SelectedTab;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
