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

        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            var coins = from m in _context.Coins
                        select m;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CountrySortParm = sortOrder == "Country" ? "country_desc" : "Country";

            ViewBag.FaceValueSortParm = sortOrder == "FaceValue" ? "faceValue_desc" : "FaceValue";

            ViewBag.ValuesSortParm = sortOrder == "Values" ? "values_desc" : "values";

            ViewBag.YearSortParm = sortOrder == "Year" ? "year_desc" : "Year";

            ViewBag.MetalOrAlloySortParm = sortOrder == "MetalOrAlloy" ? "metalOrAlloy_desc" : "MetalOrAlloy";

            ViewBag.NumberOfCoinsSortParm = sortOrder == "NumberOfCoins" ? "numberOfCoins_desc" : "NumberOfCoins";

            ViewBag.FeaturesSortParm = sortOrder == "Features" ? "features_desc" : "Features";

            switch (sortOrder)
            {
                case "name_desc":
                    coins = coins.OrderByDescending(m => m.CoinsName);
                    break;
                case "Country":
                    coins = coins.OrderBy(m => m.Country);
                    break;
                case "country_desc":
                    coins = coins.OrderByDescending(m => m.Country);
                    break;
                case "FaceValue":
                    coins = coins.OrderBy(m => m.FaceValue);
                    break;
                case "faceValue_desc":
                    coins = coins.OrderByDescending(m => m.FaceValue);
                    break;
                case "Year":
                    coins = coins.OrderBy(m => m.Year);
                    break;
                case "year_desc":
                    coins = coins.OrderByDescending(m => m.Year);
                    break;
                case "MetalOrAlloy":
                    coins = coins.OrderBy(m => m.MetalOrAlloy);
                    break;
                case "metalOrAlloy_desc":
                    coins = coins.OrderByDescending(m => m.MetalOrAlloy);
                    break;
                case "NumberOfCoins":
                    coins = coins.OrderBy(m => m.NumberOfCoins);
                    break;
                case "numberOfCoins_desc":
                    coins = coins.OrderByDescending(m => m.NumberOfCoins);
                    break;
                case "Features":
                    coins = coins.OrderBy(m => m.Features);
                    break;
                case "features_desc":
                    coins = coins.OrderByDescending(m => m.Features);
                    break;

                default:
                    coins = coins.OrderBy(m => m.CoinsName);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                coins = coins.Where(m => m.Country.Contains(searchString) || m.FaceValue.Contains(searchString) || m.MetalOrAlloy.Contains(searchString) || m.Features.Contains(searchString) || m.Year.Contains(searchString) || m.NumberOfCoins.Contains(searchString) || m.CoinsName.Contains(searchString));
            }
            return View(await coins.ToListAsync());

        }
    }
}
