using Application.Dto;
using Application.Services;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpGet(nameof(Get))]
        public ActionResult<IEnumerable<Monster>> Get()
        {
            return Ok(_monstersService.Get());
        }

        [HttpPatch(nameof(Patch))]
        public IActionResult Patch(CreationPatchRequest patch)
        {
            if (_patchService.PatchCreation(patch))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
