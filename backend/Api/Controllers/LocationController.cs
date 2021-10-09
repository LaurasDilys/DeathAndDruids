using Application.Dto;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
