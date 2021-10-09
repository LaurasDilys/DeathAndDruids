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
    public class CombatController : ControllerBase
    {
        private readonly CombatService _service;

        public CombatController(CombatService combatService)
        {
            _service = combatService;
        }

        [HttpPost(nameof(Start))]
        public ActionResult Start()
        {
            _service.Add(3);

            return Ok();
        }
    }
}
