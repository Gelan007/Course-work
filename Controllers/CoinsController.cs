using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NumizmatDictionary.Data;
using NumizmatDictionary.Models;

namespace NumizmatDictionary.Controllers
{
    public class CoinsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoinsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Coins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coins = await _context.Coins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coins == null)
            {
                return NotFound();
            }

            return View(coins);
        }

        // GET: Coins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CoinsName,Country,FaceValue,Year,MetalOrAlloy,NumberOfCoins,Features")] Coins coins)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coins);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coins);
        }

        // GET: Coins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coins = await _context.Coins.FindAsync(id);
            if (coins == null)
            {
                return NotFound();
            }
            return View(coins);
        }

        // POST: Coins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CoinsName,Country,FaceValue,Year,MetalOrAlloy,NumberOfCoins,Features")] Coins coins)
        {
            if (id != coins.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coins);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoinsExists(coins.Id))
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
            return View(coins);
        }

        // GET: Coins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coins = await _context.Coins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coins == null)
            {
                return NotFound();
            }

            return View(coins);
        }

        // POST: Coins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coins = await _context.Coins.FindAsync(id);
            _context.Coins.Remove(coins);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoinsExists(int id)
        {
            return _context.Coins.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var coins = from m in _context.Coins
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                coins = coins.Where(s => s.Country.Contains(searchString) || s.FaceValue.Contains(searchString) || s.MetalOrAlloy.Contains(searchString) || s.Features.Contains(searchString) || s.Year.Contains(searchString) || s.NumberOfCoins.Contains(searchString) || s.CoinsName.Contains(searchString));
            }
            return View(await coins.ToListAsync());
        }
    }
}
