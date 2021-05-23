using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Site.Data;

namespace Site.Controllers
{
    [Authorize]
    public class PresentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PresentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Presents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Presents.ToListAsync());
        }

        // GET: Presents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presents = await _context.Presents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (presents == null)
            {
                return NotFound();
            }

            return View(presents);
        }

        // GET: Presents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Presents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date")] Present presents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(presents);
        }

        // GET: Presents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presents = await _context.Presents.FindAsync(id);
            if (presents == null)
            {
                return NotFound();
            }
            return View(presents);
        }

        // POST: Presents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Date")] Present presents)
        {
            if (id != presents.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresentsExists(presents.Id))
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
            return View(presents);
        }

        // GET: Presents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presents = await _context.Presents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (presents == null)
            {
                return NotFound();
            }

            return View(presents);
        }

        // POST: Presents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var presents = await _context.Presents.FindAsync(id);
            _context.Presents.Remove(presents);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresentsExists(int? id)
        {
            return _context.Presents.Any(e => e.Id == id);
        }
    }
}
