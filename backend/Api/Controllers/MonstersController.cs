using Application;
using Data.Models;
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
    public class MonstersController : ControllerBase
    {
        private readonly MonstersService _service;

        public MonstersController(MonstersService service)
        {
            _service = service;
        }

        [HttpGet("Get", Name = nameof(Get))]
        public ActionResult<IEnumerable<Monster>> Get()
        {
            return Ok(_service.Get());
        }

        [HttpGet("Open/{key:int}", Name = nameof(Open))]
        public IActionResult Open(int key)
        {
            if (!_service.Exists(key))
            {
                return NotFound();
            }

            _service.Open(key);

            return Ok();
        }
    }
}
