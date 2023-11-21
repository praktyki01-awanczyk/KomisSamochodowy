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
    public class PaliwoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaliwoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Paliwo
        public async Task<IActionResult> Index()
        {
              return _context.Paliwo != null ? 
                          View(await _context.Paliwo.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Paliwo'  is null.");
        }

        // GET: Paliwo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Paliwo == null)
            {
                return NotFound();
            }

            var paliwo = await _context.Paliwo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paliwo == null)
            {
                return NotFound();
            }

            return View(paliwo);
        }

        // GET: Paliwo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paliwo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa")] Paliwo paliwo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paliwo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paliwo);
        }

        // GET: Paliwo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Paliwo == null)
            {
                return NotFound();
            }

            var paliwo = await _context.Paliwo.FindAsync(id);
            if (paliwo == null)
            {
                return NotFound();
            }
            return View(paliwo);
        }

        // POST: Paliwo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa")] Paliwo paliwo)
        {
            if (id != paliwo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paliwo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaliwoExists(paliwo.Id))
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
            return View(paliwo);
        }

        // GET: Paliwo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Paliwo == null)
            {
                return NotFound();
            }

            var paliwo = await _context.Paliwo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paliwo == null)
            {
                return NotFound();
            }

            return View(paliwo);
        }

        // POST: Paliwo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Paliwo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Paliwo'  is null.");
            }
            var paliwo = await _context.Paliwo.FindAsync(id);
            if (paliwo != null)
            {
                _context.Paliwo.Remove(paliwo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaliwoExists(int id)
        {
          return (_context.Paliwo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
