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
    public class CombatController : ControllerBase
    {
        private readonly CombatService _service;

        public CombatController(CombatService combatService)
        {
            _service = combatService;
        }

        [HttpPost(nameof(Start))]
        public IActionResult Start(CombatRequest request)
        {
            if (!_service.Add(request))
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet(nameof(Get))]
        public ActionResult<IEnumerable<OpenedMonsterViewModel>> Get()
        {
            return Ok(_service.Get());
        }

        [HttpDelete("Delete/{key:int}", Name = nameof(Delete))]
        public IActionResult Delete(int key)
        {
            if (!_service.Delete(key))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
