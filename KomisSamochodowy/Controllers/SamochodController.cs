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
    public class SamochodController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SamochodController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Samochod
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Samochod.Include(s => s.Marka).Include(s => s.Model).Include(s => s.Nadwozie).Include(s => s.Paliwo);
            return View(await applicationDbContext.ToListAsync());
        }


        public async Task<IActionResult> IndexLess10000()
        {
            var applicationDbContext = _context.Samochod.Include(s => s.Marka)
                .Include(s => s.Model)
                .Include(s => s.Nadwozie).
                Include(s => s.Paliwo).Where(p => p.Cena< 10000);
            return View(await applicationDbContext.ToListAsync());
        }


        public async Task<IActionResult> IndexBetween()
        {
            var applicationDbContext = _context.Samochod.Include(s => s.Marka)
                .Include(s => s.Model)
                .Include(s => s.Nadwozie)
                .Include(s => s.Paliwo).Where(p => p.Cena < 50000 && p.Cena > 10001);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> IndexMore()
        {
            var applicationDbContext = _context.Samochod.Include(s => s.Marka)
                .Include(s => s.Model)
                .Include(s => s.Nadwozie).
                Include(s => s.Paliwo).Where(p => p.Cena < 50000);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Samochod/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Samochod == null)
            {
                return NotFound();
            }

            var samochod = await _context.Samochod
                .Include(s => s.Marka)
                .Include(s => s.Model)
                .Include(s => s.Nadwozie)
                .Include(s => s.Paliwo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (samochod == null)
            {
                return NotFound();
            }

            return View(samochod);
        }

        // GET: Samochod/Create
        public IActionResult Create()
        {
            ViewData["MarkaId"] = new SelectList(_context.Marka, "Id", "Id");
            ViewData["ModelId"] = new SelectList(_context.Model, "Id", "Id");
            ViewData["NadwozieId"] = new SelectList(_context.Nadwozie, "Id", "Id");
            ViewData["PaliwoId"] = new SelectList(_context.Paliwo, "Id", "Id");
            return View();
        }

        // POST: Samochod/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Kolor,PojemnoscSilnika,Przebieg,NumerVin,Cena,MarkaId,ModelId,NadwozieId,PaliwoId")] Samochod samochod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(samochod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarkaId"] = new SelectList(_context.Marka, "Id", "Id", samochod.MarkaId);
            ViewData["ModelId"] = new SelectList(_context.Model, "Id", "Id", samochod.ModelId);
            ViewData["NadwozieId"] = new SelectList(_context.Nadwozie, "Id", "Id", samochod.NadwozieId);
            ViewData["PaliwoId"] = new SelectList(_context.Paliwo, "Id", "Id", samochod.PaliwoId);
            return View(samochod);
        }

        // GET: Samochod/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Samochod == null)
            {
                return NotFound();
            }

            var samochod = await _context.Samochod.FindAsync(id);
            if (samochod == null)
            {
                return NotFound();
            }
            ViewData["MarkaId"] = new SelectList(_context.Marka, "Id", "Id", samochod.MarkaId);
            ViewData["ModelId"] = new SelectList(_context.Model, "Id", "Id", samochod.ModelId);
            ViewData["NadwozieId"] = new SelectList(_context.Nadwozie, "Id", "Id", samochod.NadwozieId);
            ViewData["PaliwoId"] = new SelectList(_context.Paliwo, "Id", "Id", samochod.PaliwoId);
            return View(samochod);
        }

        // POST: Samochod/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Kolor,PojemnoscSilnika,Przebieg,NumerVin,Cena,MarkaId,ModelId,NadwozieId,PaliwoId")] Samochod samochod)
        {
            if (id != samochod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(samochod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SamochodExists(samochod.Id))
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
            ViewData["MarkaId"] = new SelectList(_context.Marka, "Id", "Id", samochod.MarkaId);
            ViewData["ModelId"] = new SelectList(_context.Model, "Id", "Id", samochod.ModelId);
            ViewData["NadwozieId"] = new SelectList(_context.Nadwozie, "Id", "Id", samochod.NadwozieId);
            ViewData["PaliwoId"] = new SelectList(_context.Paliwo, "Id", "Id", samochod.PaliwoId);
            return View(samochod);
        }

        // GET: Samochod/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Samochod == null)
            {
                return NotFound();
            }

            var samochod = await _context.Samochod
                .Include(s => s.Marka)
                .Include(s => s.Model)
                .Include(s => s.Nadwozie)
                .Include(s => s.Paliwo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (samochod == null)
            {
                return NotFound();
            }

            return View(samochod);
        }

        // POST: Samochod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Samochod == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Samochod'  is null.");
            }
            var samochod = await _context.Samochod.FindAsync(id);
            if (samochod != null)
            {
                _context.Samochod.Remove(samochod);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SamochodExists(int id)
        {
          return (_context.Samochod?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
