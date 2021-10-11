using Application.Dto;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationService _service;

        public LocationController(LocationService service)
        {
            _service = service;
        }

        [HttpPut(nameof(Route))]
        public IActionResult Route(RouteChangeRequest route)
        {
            _service.SetRoute(route.Route);

            return Ok();
        }

        [HttpPut(nameof(SelectedTab))]
        public IActionResult SelectedTab(TabChangeRequest tab)
        {
            _service.SetSelectedTab(tab.SelectedTab);

            return Ok();
        }

        [HttpGet(nameof(SelectedTab))]
        public ActionResult<SelectedTabResponse> SelectedTab()
        {
            return Ok(_service.GetSelectedTab());
        }
    }
}
