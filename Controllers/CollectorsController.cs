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
    public class CollectorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CollectorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Collectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collectors = await _context.Collectors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (collectors == null)
            {
                return NotFound();
            }

            return View(collectors);
        }

        // GET: Collectors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Collectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Country,Name,Contacts,AvailabilityInCollection")] Collectors collectors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collectors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(collectors);
        }

        // GET: Collectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collectors = await _context.Collectors.FindAsync(id);
            if (collectors == null)
            {
                return NotFound();
            }
            return View(collectors);
        }

        // POST: Collectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Country,Name,Contacts,AvailabilityInCollection")] Collectors collectors)
        {
            if (id != collectors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collectors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollectorsExists(collectors.Id))
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
            return View(collectors);
        }

        // GET: Collectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collectors = await _context.Collectors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (collectors == null)
            {
                return NotFound();
            }

            return View(collectors);
        }

        // POST: Collectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collectors = await _context.Collectors.FindAsync(id);
            _context.Collectors.Remove(collectors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollectorsExists(int id)
        {
            return _context.Collectors.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            var collectors = from m in _context.Collectors
                        select m;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CountrySortParm = sortOrder == "Country" ? "country_desc" : "Country";

            ViewBag.ContactsSortParm = sortOrder == "Contacts" ? "contacts_desc" : "Contacts";

            ViewBag.AvailabilityInCollectionSortParm = sortOrder == "AvailabilityInCollection" ? "availabilityInCollection_desc" : "AvailabilityInCollection";

      

            switch (sortOrder)
            {
                case "name_desc":
                    collectors = collectors.OrderByDescending(m => m.Name);
                    break;
                case "Country":
                    collectors = collectors.OrderBy(m => m.Country);
                    break;
                case "country_desc":
                    collectors = collectors.OrderByDescending(m => m.Country);
                    break;
                case "Contacts":
                    collectors = collectors.OrderBy(m => m.Contacts);
                    break;
                case "contacts_desc":
                    collectors = collectors.OrderByDescending(m => m.Contacts);
                    break;
                case "AvailabilityInCollection":
                    collectors = collectors.OrderBy(m => m.AvailabilityInCollection);
                    break;              
                default:
                    collectors = collectors.OrderBy(m => m.Name);
                    break;
            }


            if (!String.IsNullOrEmpty(searchString))
            {
                collectors = collectors.Where(s => s.Country.Contains(searchString) || s.Name.Contains(searchString) || s.Contacts.Contains(searchString) || s.AvailabilityInCollection.Contains(searchString));
            }
            return View(await collectors.ToListAsync());
        }
    }
}
