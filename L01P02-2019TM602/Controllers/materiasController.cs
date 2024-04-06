using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L01P02_2019TM602.Models;

namespace L01P02_2019TM602.Controllers
{
    public class materiasController : Controller
    {
        private readonly equiposDbContext _context;

        public materiasController(equiposDbContext context)
        {
            _context = context;
        }

        // GET: materias
        public async Task<IActionResult> Index()
        {
              return _context.materias_1 != null ? 
                          View(await _context.materias_1.ToListAsync()) :
                          Problem("Entity set 'equiposDbContext.materias_1'  is null.");
        }

        // GET: materias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.materias_1 == null)
            {
                return NotFound();
            }

            var materias = await _context.materias_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materias == null)
            {
                return NotFound();
            }

            return View(materias);
        }

        // GET: materias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: materias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,materia,unidades_valorativas,estado")] materias materias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materias);
        }

        // GET: materias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.materias_1 == null)
            {
                return NotFound();
            }

            var materias = await _context.materias_1.FindAsync(id);
            if (materias == null)
            {
                return NotFound();
            }
            return View(materias);
        }

        // POST: materias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,materia,unidades_valorativas,estado")] materias materias)
        {
            if (id != materias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!materiasExists(materias.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(materias);
        }

        // GET: materias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.materias_1 == null)
            {
                return NotFound();
            }

            var materias = await _context.materias_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materias == null)
            {
                return NotFound();
            }

            return View(materias);
        }

        // POST: materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.materias_1 == null)
            {
                return Problem("Entity set 'equiposDbContext.materias_1'  is null.");
            }
            var materias = await _context.materias_1.FindAsync(id);
            if (materias != null)
            {
                _context.materias_1.Remove(materias);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool materiasExists(int id)
        {
          return (_context.materias_1?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
