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
    public class FarmerMarketEventsController : Controller
    {
        private readonly NZFarmersContext _context;

        public FarmerMarketEventsController(NZFarmersContext context)
        {
            _context = context;
        }

        // GET: FarmerMarketEvents
        public async Task<IActionResult> Index()
        {
            return View(await _context.FarmerMarketEvents.ToListAsync());
        }

        // GET: FarmerMarketEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerMarketEvent = await _context.FarmerMarketEvents
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (farmerMarketEvent == null)
            {
                return NotFound();
            }

            return View(farmerMarketEvent);
        }

        // GET: FarmerMarketEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FarmerMarketEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventID,Title,Location,Date,Description,CreatedAt")] FarmerMarketEvent farmerMarketEvent)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(farmerMarketEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmerMarketEvent);
        }

        // GET: FarmerMarketEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerMarketEvent = await _context.FarmerMarketEvents.FindAsync(id);
            if (farmerMarketEvent == null)
            {
                return NotFound();
            }
            return View(farmerMarketEvent);
        }

        // POST: FarmerMarketEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,Title,Location,Date,Description,CreatedAt")] FarmerMarketEvent farmerMarketEvent)
        {
            if (id != farmerMarketEvent.EventID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmerMarketEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmerMarketEventExists(farmerMarketEvent.EventID))
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
            return View(farmerMarketEvent);
        }

        // GET: FarmerMarketEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerMarketEvent = await _context.FarmerMarketEvents
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (farmerMarketEvent == null)
            {
                return NotFound();
            }

            return View(farmerMarketEvent);
        }

        // POST: FarmerMarketEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmerMarketEvent = await _context.FarmerMarketEvents.FindAsync(id);
            if (farmerMarketEvent != null)
            {
                _context.FarmerMarketEvents.Remove(farmerMarketEvent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmerMarketEventExists(int id)
        {
            return _context.FarmerMarketEvents.Any(e => e.EventID == id);
        }
    }
}
