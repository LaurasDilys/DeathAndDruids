using Application;
using Application.Dto;
using Business.Interfaces;
using Business.Models;
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
        private readonly CreationService _creationService;
        private readonly MonstersService _monstersService;
        //
        private readonly DataContext _context;

        public CreationController(CreationService creationService,
            MonstersService monstersService,
            //
            DataContext context)
        {
            _creationService = creationService;
            _monstersService = monstersService;
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
        [HttpPut(nameof(Test))]
        public ActionResult<Character> Test()
        {
            return Ok();
        }
        //
        
        [HttpPost(nameof(New))]
        public IActionResult New()
        {
            _creationService.New();

            return Ok();
        }

        [HttpGet(nameof(Get))]
        public ActionResult<OpenedMonsterViewModel> Get()
        {
            if (!_creationService.OpenedExists())
                return NotFound();

            return Ok(_creationService.GetOpened());
        }

        [HttpPatch(nameof(Patch))]
        public IActionResult Patch(MonsterPatchRequest patch)
        {
            if (!_creationService.OpenedExists())
                return UnprocessableEntity();

            if (_creationService.Patch(patch))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut(nameof(Save))]
        public IActionResult Save()
        {
            if (!_creationService.OpenedExists())
                return BadRequest();

            _creationService.Save();

            return Ok();
        }

        [HttpPost("Open/{key:int}", Name = nameof(Open))]
        public IActionResult Open(int key)
        {
            if (!_monstersService.Exists(key))
            {
                return NotFound();
            }

            _monstersService.Open(key);

            return Ok();
        }

        [HttpPost(nameof(OpenLast))]
        public IActionResult OpenLast()
        {
            if (!_monstersService.Any())
            {
                return NotFound();
            }

            _monstersService.OpenLast();

            return Ok();
        }

        [HttpDelete(nameof(Close))]
        public IActionResult Close()
        {
            if (!_creationService.OpenedExists())
                return BadRequest();

            _creationService.Close();

            return Ok();
        }

        [HttpDelete(nameof(Delete))]
        public IActionResult Delete()
        {
            if (!_creationService.OpenedExists())
                return BadRequest();

            _creationService.Delete();

            return Ok();
        }
    }
}
