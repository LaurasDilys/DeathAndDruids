using Application.Dto;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombatController : ControllerBase
    {
        private readonly CombatService _combatService;
        private readonly PatchService _patchService;

        public CombatController(CombatService combatService, PatchService patchService)
        {
            _combatService = combatService;
            _patchService = patchService;
        }

        [HttpPost(nameof(Start))]
        public IActionResult Start(CombatRequest request)
        {
            if (!_combatService.Add(request))
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet(nameof(Get))]
        public ActionResult<IEnumerable<OpenedMonsterViewModel>> Get()
        {
            return Ok(_combatService.Get());
        }

        [HttpPatch(nameof(Patch))]
        public IActionResult Patch(CombatantPatchRequest patch)
        {
            if (!_patchService.PatchCombatant(patch))
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("Delete/{key:int}", Name = nameof(Delete))]
        public IActionResult Delete(int key)
        {
            if (!_combatService.Delete(key))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
