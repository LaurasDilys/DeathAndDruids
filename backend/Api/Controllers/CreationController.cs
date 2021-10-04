using Data;
using Data.Models;
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
        private readonly DataContext _context;

        public CreationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("New")]
        public IActionResult New()
        {
            var res = new
            {
                Id = DateTime.Now.Second,
                Name = DateTime.Now.Second,
                Initiative = 0,
                Hp = 0,
                MaxHp = 0
            };

            return Ok(res);
        }

        [HttpGet("Test")]
        public IActionResult Test()
        {
            _context.SaveChanges();

            return Ok();
        }
    }
}
