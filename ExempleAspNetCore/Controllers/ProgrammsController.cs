using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExempleAspNetCore.Data;
using ExempleAspNetCore.Models;
using ExempleAspNetCore.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace ExempleAspNetCore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProgrammsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProgrammsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Programms
        public async Task<IActionResult> Index()
        {
            List<ProgrammIndex> Programs = await _context.Programs.OrderBy(x => x.Code).Select(x => new ProgrammIndex
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                ClassCount = x.Courses.Count()
            }).ToListAsync();
            return View(Programs);
        }

        // GET: Programms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Programms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProgrammCreate programm)
        {
            if (ModelState.IsValid)
            {
                Programm DbProgram = new Programm
                {
                    Code = programm.Code,
                    Name = programm.Name,
                    Description = programm.Description
                };
                _context.Add(DbProgram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Edit), new { Id = DbProgram.Id });
            }
            return View(programm);
        }

        // GET: Programms/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ProgrammEdit programm = await _context.Programs.Select(x => new ProgrammEdit
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description
            }).SingleOrDefaultAsync(m => m.Id == id);
            if (programm == null)
            {
                return NotFound();
            }
            return View(programm);
        }

        // POST: Programms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProgrammEdit programm)
        {
            if (id != programm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Programm dbProgramm = _context.Programs.FirstOrDefault(x => x.Id == id);
                if (dbProgramm == null)
                {
                    return NotFound();
                }
                dbProgramm.Code = programm.Code;
                dbProgramm.Name = programm.Name;
                dbProgramm.Description = programm.Description;

                _context.Update(dbProgramm);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(programm);
        }

        // GET: Programms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programm = await _context.Programs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (programm == null)
            {
                return NotFound();
            }

            return View(programm);
        }

        // POST: Programms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programm = await _context.Programs.SingleOrDefaultAsync(m => m.Id == id);
            _context.Programs.Remove(programm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
