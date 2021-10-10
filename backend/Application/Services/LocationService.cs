using Application.Dto;
using Data.Repositories;

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

        public SelectedTabResponse GetSelectedTab()
        {
            var tab = _repository.GetSelectedTab();
            return new SelectedTabResponse { SelectedTab = tab };
        }
    }
}
