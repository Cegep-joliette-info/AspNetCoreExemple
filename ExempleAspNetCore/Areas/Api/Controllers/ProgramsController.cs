using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExempleAspNetCore.Data;
using ExempleAspNetCore.Models;
using ExempleAspNetCore.Areas.Api.ViewModels;

namespace ExempleAspNetCore.Areas.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Programs")]
    public class ProgramsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProgramsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Programs
        [HttpGet]
        public IEnumerable<ProgramIndexViewModel> GetPrograms()
        {
            return _context.Programs.Select(x => new ProgramIndexViewModel
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name
            }).ToList();
        }

        // GET: api/Programs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgramm([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var programm = await _context.Programs.SingleOrDefaultAsync(m => m.Id == id);

            if (programm == null)
            {
                return NotFound();
            }

            return Ok(new ProgramDetailViewModel
            {
                Id = programm.Id,
                Code = programm.Code,
                Name = programm.Name,
                Description = programm.Description
            });
        }
    }
}