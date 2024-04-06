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
    public class datosController : Controller
    {
        private readonly equiposDbContext _context;

        public datosController(equiposDbContext context)
        {
            _context = context;
        }

        // GET: datos
        public async Task<IActionResult> Index()
        {
              return _context.datos != null ? 
                          View(await _context.datos.ToListAsync()) :
                          Problem("Entity set 'equiposDbContext.datos'  is null.");
        }

        // GET: datos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.datos == null)
            {
                return NotFound();
            }

            var datos = await _context.datos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datos == null)
            {
                return NotFound();
            }

            return View(datos);
        }

        // GET: datos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: datos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,facultad")] datos datos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(datos);
        }

        // GET: datos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.datos == null)
            {
                return NotFound();
            }

            var datos = await _context.datos.FindAsync(id);
            if (datos == null)
            {
                return NotFound();
            }
            return View(datos);
        }

        // POST: datos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,facultad")] datos datos)
        {
            if (id != datos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!datosExists(datos.Id))
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
            return View(datos);
        }

        // GET: datos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.datos == null)
            {
                return NotFound();
            }

            var datos = await _context.datos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datos == null)
            {
                return NotFound();
            }

            return View(datos);
        }

        // POST: datos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.datos == null)
            {
                return Problem("Entity set 'equiposDbContext.datos'  is null.");
            }
            var datos = await _context.datos.FindAsync(id);
            if (datos != null)
            {
                _context.datos.Remove(datos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool datosExists(int id)
        {
          return (_context.datos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
