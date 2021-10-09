using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LocationService
    {
        private readonly LocationRepository _repository;

        public LocationService(LocationRepository repository)
        {
            _repository = repository;
        }

        public void SetRoute(string route)
        {
            _repository.SetRoute(route);
        }

        public void SetSelectedTab(int selectedTab)
        {
            _repository.SetSelectedTab(selectedTab);
        }
    }
}
