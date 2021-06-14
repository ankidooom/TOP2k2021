using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testje_amk.Models;

namespace testje_amk.Controllers
{
    public class LijstsController : Controller
    {
        private readonly Top2000Context _context;

        public LijstsController(Top2000Context context)
        {
            _context = context;
        }

        // GET: Lijsts
        public async Task<IActionResult> Index(string searchString)
        {
            var top2000Context = _context.Lijsts.Include(l => l.Song).Include(l => l.Top2000jaarNavigation);
            return View(await top2000Context.ToListAsync());
        }

        // GET: Lijsts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lijst = await _context.Lijsts
                .Include(l => l.Song)
                .Include(l => l.Top2000jaarNavigation)
                .FirstOrDefaultAsync(m => m.Songid == id);
            if (lijst == null)
            {
                return NotFound();
            }

            return View(lijst);
        }

        // GET: Lijsts/Create
        public IActionResult Create()
        {
            ViewData["Songid"] = new SelectList(_context.Songs, "Songid", "Titel");
            ViewData["Top2000jaar"] = new SelectList(_context.Top2000Jaars, "Jaar", "Jaar");
            return View();
        }

        // POST: Lijsts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Songid,Top2000jaar,Positie")] Lijst lijst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lijst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Songid"] = new SelectList(_context.Songs, "Songid", "Titel", lijst.Songid);
            ViewData["Top2000jaar"] = new SelectList(_context.Top2000Jaars, "Jaar", "Jaar", lijst.Top2000jaar);
            return View(lijst);
        }

        // GET: Lijsts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lijst = await _context.Lijsts.FindAsync(id);
            if (lijst == null)
            {
                return NotFound();
            }
            ViewData["Songid"] = new SelectList(_context.Songs, "Songid", "Titel", lijst.Songid);
            ViewData["Top2000jaar"] = new SelectList(_context.Top2000Jaars, "Jaar", "Jaar", lijst.Top2000jaar);
            return View(lijst);
        }

        // POST: Lijsts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Songid,Top2000jaar,Positie")] Lijst lijst)
        {
            if (id != lijst.Songid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lijst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LijstExists(lijst.Songid))
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
            ViewData["Songid"] = new SelectList(_context.Songs, "Songid", "Titel", lijst.Songid);
            ViewData["Top2000jaar"] = new SelectList(_context.Top2000Jaars, "Jaar", "Jaar", lijst.Top2000jaar);
            return View(lijst);
        }

        // GET: Lijsts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lijst = await _context.Lijsts
                .Include(l => l.Song)
                .Include(l => l.Top2000jaarNavigation)
                .FirstOrDefaultAsync(m => m.Songid == id);
            if (lijst == null)
            {
                return NotFound();
            }

            return View(lijst);
        }

        // POST: Lijsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lijst = await _context.Lijsts.FindAsync(id);
            _context.Lijsts.Remove(lijst);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LijstExists(int id)
        {
            return _context.Lijsts.Any(e => e.Songid == id);
        }
    }
}
