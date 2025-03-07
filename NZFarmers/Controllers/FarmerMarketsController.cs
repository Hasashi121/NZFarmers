using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NZFarmers.Data;
using NZFarmers.Models;

namespace NZFarmers.Controllers
{
    public class FarmerMarketsController : Controller
    {
        private readonly NZFarmersContext _context;

        public FarmerMarketsController(NZFarmersContext context)
        {
            _context = context;
        }

        // GET: FarmerMarkets
        public async Task<IActionResult> Index()
        {
            return View(await _context.FarmerMarkets.ToListAsync());
        }

        // GET: FarmerMarkets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerMarkets = await _context.FarmerMarkets
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (farmerMarkets == null)
            {
                return NotFound();
            }

            return View(farmerMarkets);
        }

        // GET: FarmerMarkets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FarmerMarkets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventID,Title,Location,Date,Description,CreatedAt")] FarmerMarkets farmerMarkets)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(farmerMarkets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmerMarkets);
        }

        // GET: FarmerMarkets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerMarkets = await _context.FarmerMarkets.FindAsync(id);
            if (farmerMarkets == null)
            {
                return NotFound();
            }
            return View(farmerMarkets);
        }

        // POST: FarmerMarkets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,Title,Location,Date,Description,CreatedAt")] FarmerMarkets farmerMarkets)
        {
            if (id != farmerMarkets.EventID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmerMarkets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmerMarketsExists(farmerMarkets.EventID))
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
            return View(farmerMarkets);
        }

        // GET: FarmerMarkets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerMarkets = await _context.FarmerMarkets
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (farmerMarkets == null)
            {
                return NotFound();
            }

            return View(farmerMarkets);
        }

        // POST: FarmerMarkets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmerMarkets = await _context.FarmerMarkets.FindAsync(id);
            if (farmerMarkets != null)
            {
                _context.FarmerMarkets.Remove(farmerMarkets);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmerMarketsExists(int id)
        {
            return _context.FarmerMarkets.Any(e => e.EventID == id);
        }
    }
}
