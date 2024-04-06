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
    public class alumnosController : Controller
    {
        private readonly equiposDbContext _context;

        public alumnosController(equiposDbContext context)
        {
            _context = context;
        }

        // GET: alumnos
        public async Task<IActionResult> Index()
        {
              return _context.alumnos_1 != null ? 
                          View(await _context.alumnos_1.ToListAsync()) :
                          Problem("Entity set 'equiposDbContext.alumnos_1'  is null.");
        }

        // GET: alumnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.alumnos_1 == null)
            {
                return NotFound();
            }

            var alumnos = await _context.alumnos_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alumnos == null)
            {
                return NotFound();
            }

            return View(alumnos);
        }

        // GET: alumnos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: alumnos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,codigo,nombre,apellido,dui,estado")] alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumnos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alumnos);
        }

        // GET: alumnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.alumnos_1 == null)
            {
                return NotFound();
            }

            var alumnos = await _context.alumnos_1.FindAsync(id);
            if (alumnos == null)
            {
                return NotFound();
            }
            return View(alumnos);
        }

        // POST: alumnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,codigo,nombre,apellido,dui,estado")] alumnos alumnos)
        {
            if (id != alumnos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumnos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!alumnosExists(alumnos.Id))
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
            return View(alumnos);
        }

        // GET: alumnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.alumnos_1 == null)
            {
                return NotFound();
            }

            var alumnos = await _context.alumnos_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alumnos == null)
            {
                return NotFound();
            }

            return View(alumnos);
        }

        // POST: alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.alumnos_1 == null)
            {
                return Problem("Entity set 'equiposDbContext.alumnos_1'  is null.");
            }
            var alumnos = await _context.alumnos_1.FindAsync(id);
            if (alumnos != null)
            {
                _context.alumnos_1.Remove(alumnos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool alumnosExists(int id)
        {
          return (_context.alumnos_1?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
