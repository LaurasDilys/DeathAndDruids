using Application;
using Application.Dto;
using Application.Services;
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
        private readonly MonstersService _monstersService;
        private readonly PatchService _patchService;

        public MonstersController(MonstersService monstersService, PatchService patchService)
        {
            _monstersService = monstersService;
            _patchService = patchService;
        }

        [HttpDelete("Delete/{key:int}", Name = nameof(Delete))]
        public IActionResult Delete(int key)
        {
            if (!_monstersService.Exists(key))
            {
                return BadRequest();
            }

            _monstersService.Delete(key);

            return Ok();
        }

        [HttpGet(nameof(Get))]
        public ActionResult<IEnumerable<Monster>> Get()
        {
            return Ok(_monstersService.Get());
        }

        [HttpPatch(nameof(Patch))]
        public IActionResult Patch(MonsterPatchRequest patch)
        {
            if (_patchService.Patch(patch))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
