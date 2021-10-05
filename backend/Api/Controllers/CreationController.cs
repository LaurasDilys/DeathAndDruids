using Application;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreationController : ControllerBase
    {
        private readonly CreationService _service;

        public CreationController(CreationService service)
        {
            _service = service;
        }

        [HttpGet("OpenedMonster", Name = nameof(OpenedMonster))]
        public ActionResult<OpenedMonster> OpenedMonster()
        {
            if (!_service.OpenedExists())
                return NotFound();

            return Ok(_service.GetOpened());
        }
        
        [HttpPost("New")]
        public IActionResult New()
        {
            _service.New();

            return Ok();
        }
    }
}
