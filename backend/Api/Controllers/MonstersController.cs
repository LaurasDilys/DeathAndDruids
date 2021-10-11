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

        public MonstersController(MonstersService monstersService)
        {
            _monstersService = monstersService;
        }

        [HttpGet(nameof(Get))]
        public ActionResult<IEnumerable<Monster>> Get()
        {
            return Ok(_monstersService.Get());
        }
    }
}
