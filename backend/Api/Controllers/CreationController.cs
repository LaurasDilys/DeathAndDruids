using Application.Dto;
using Application.Services;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreationController : ControllerBase
    {
        private readonly CreationService _creationService;
        private readonly MonstersService _monstersService;
        private readonly PatchService _patchService;

        public CreationController(CreationService creationService,
            MonstersService monstersService,
            PatchService patchService)
        {
            _creationService = creationService;
            _monstersService = monstersService;
            _patchService = patchService;
        }

        [HttpPost(nameof(New))]
        public IActionResult New()
        {
            _creationService.New();

            return Ok();
        }

        [HttpGet(nameof(Get))]
        public ActionResult<SavableOpenedMonsterViewModel> Get()
        {
            if (!_creationService.OpenedExists())
                return NotFound();

            return Ok(_creationService.GetOpened());
        }

        [HttpGet(nameof(GetLast))]
        public ActionResult<SavableOpenedMonsterViewModel> GetLast()
        {
            if (!_monstersService.Any())
            {
                return NotFound();
            }

            _creationService.OpenLast();
            return Ok(_creationService.GetOpened());
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

            _creationService.Open(key);

            return Ok();
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
