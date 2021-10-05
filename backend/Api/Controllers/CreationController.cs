using Application;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        //
        private readonly DataContext _context;

        public CreationController(CreationService service,
            //
            DataContext context)
        {
            _service = service;
            //
            _context = context;
        }

        //
        [HttpDelete(nameof(TruncateAllTables))]
        public IActionResult TruncateAllTables()
        {
            _context.Database.ExecuteSqlRaw($"TRUNCATE TABLE [Monsters]");
            _context.Database.ExecuteSqlRaw($"TRUNCATE TABLE [OpenedMonsters]");
            _context.Database.ExecuteSqlRaw($"TRUNCATE TABLE [Players]");
            return Ok();
        }
        //

        [HttpGet(nameof(Get))]
        public ActionResult<OpenedMonster> Get()
        {
            if (!_service.OpenedExists())
                return NotFound();

            return Ok(_service.GetOpened());
        }
        
        [HttpPost(nameof(New))]
        public IActionResult New()
        {
            _service.New();

            return Ok();
        }

        [HttpPut(nameof(Save))]
        public IActionResult Save()
        {
            _service.Save();

            return Ok();
        }
    }
}
