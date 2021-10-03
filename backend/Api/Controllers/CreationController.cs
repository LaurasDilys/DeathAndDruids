using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreationController : ControllerBase
    {
        [HttpGet("New")]
        public IActionResult New()
        {
            var res = new
            {
                Id = 0,
                Name = "Zero",
                Initiative = 0,
                Hp = 0,
                MaxHp = 0
            };

            return Ok(res);
        }
    }
}
