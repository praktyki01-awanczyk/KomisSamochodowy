using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KomisSamochodowy.Data;
using KomisSamochodowy.Models;

namespace KomisSamochodowy.Controllers
{
    public class NadwozieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NadwozieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nadwozie
        public async Task<IActionResult> Index()
        {
              return _context.Nadwozie != null ? 
                          View(await _context.Nadwozie.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Nadwozie'  is null.");
        }

        // GET: Nadwozie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nadwozie == null)
            {
                return NotFound();
            }

            var nadwozie = await _context.Nadwozie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nadwozie == null)
            {
                return NotFound();
            }

            return View(nadwozie);
        }

        // GET: Nadwozie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nadwozie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa")] Nadwozie nadwozie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nadwozie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nadwozie);
        }

        // GET: Nadwozie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nadwozie == null)
            {
                return NotFound();
            }

            var nadwozie = await _context.Nadwozie.FindAsync(id);
            if (nadwozie == null)
            {
                return NotFound();
            }
            return View(nadwozie);
        }

        // POST: Nadwozie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa")] Nadwozie nadwozie)
        {
            if (id != nadwozie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nadwozie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NadwozieExists(nadwozie.Id))
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
            return View(nadwozie);
        }

        // GET: Nadwozie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nadwozie == null)
            {
                return NotFound();
            }

            var nadwozie = await _context.Nadwozie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nadwozie == null)
            {
                return NotFound();
            }

            return View(nadwozie);
        }

        // POST: Nadwozie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nadwozie == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Nadwozie'  is null.");
            }
            var nadwozie = await _context.Nadwozie.FindAsync(id);
            if (nadwozie != null)
            {
                _context.Nadwozie.Remove(nadwozie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NadwozieExists(int id)
        {
          return (_context.Nadwozie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
