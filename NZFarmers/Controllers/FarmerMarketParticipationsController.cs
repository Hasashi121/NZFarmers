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
    public class FarmerMarketParticipationsController : Controller
    {
        private readonly NZFarmersContext _context;

        public FarmerMarketParticipationsController(NZFarmersContext context)
        {
            _context = context;
        }

        // GET: FarmerMarketParticipations
        public async Task<IActionResult> Index()
        {
            var nZFarmersContext = _context.FarmerMarketParticipations.Include(f => f.Farmer).Include(f => f.FarmerMarketEvent);
            return View(await nZFarmersContext.ToListAsync());
        }

        // GET: FarmerMarketParticipations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerMarketParticipation = await _context.FarmerMarketParticipations
                .Include(f => f.Farmer)
                .Include(f => f.FarmerMarketEvent)
                .FirstOrDefaultAsync(m => m.FarmerID == id);
            if (farmerMarketParticipation == null)
            {
                return NotFound();
            }

            return View(farmerMarketParticipation);
        }

        // GET: FarmerMarketParticipations/Create
        public IActionResult Create()
        {
            ViewData["FarmerID"] = new SelectList(_context.Farmers, "FarmerID", "Address");
            ViewData["EventID"] = new SelectList(_context.FarmerMarketEvents, "EventID", "Location");
            return View();
        }

        // POST: FarmerMarketParticipations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParticipationID,FarmerID,EventID")] FarmerMarketParticipation farmerMarketParticipation)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(farmerMarketParticipation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FarmerID"] = new SelectList(_context.Farmers, "FarmerID", "Address", farmerMarketParticipation.FarmerID);
            ViewData["EventID"] = new SelectList(_context.FarmerMarketEvents, "EventID", "Location", farmerMarketParticipation.EventID);
            return View(farmerMarketParticipation);
        }

        // GET: FarmerMarketParticipations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerMarketParticipation = await _context.FarmerMarketParticipations.FindAsync(id);
            if (farmerMarketParticipation == null)
            {
                return NotFound();
            }
            ViewData["FarmerID"] = new SelectList(_context.Farmers, "FarmerID", "Address", farmerMarketParticipation.FarmerID);
            ViewData["EventID"] = new SelectList(_context.FarmerMarketEvents, "EventID", "Location", farmerMarketParticipation.EventID);
            return View(farmerMarketParticipation);
        }

        // POST: FarmerMarketParticipations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParticipationID,FarmerID,EventID")] FarmerMarketParticipation farmerMarketParticipation)
        {
            if (id != farmerMarketParticipation.FarmerID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmerMarketParticipation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmerMarketParticipationExists(farmerMarketParticipation.FarmerID))
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
            ViewData["FarmerID"] = new SelectList(_context.Farmers, "FarmerID", "Address", farmerMarketParticipation.FarmerID);
            ViewData["EventID"] = new SelectList(_context.FarmerMarketEvents, "EventID", "Location", farmerMarketParticipation.EventID);
            return View(farmerMarketParticipation);
        }

        // GET: FarmerMarketParticipations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerMarketParticipation = await _context.FarmerMarketParticipations
                .Include(f => f.Farmer)
                .Include(f => f.FarmerMarketEvent)
                .FirstOrDefaultAsync(m => m.FarmerID == id);
            if (farmerMarketParticipation == null)
            {
                return NotFound();
            }

            return View(farmerMarketParticipation);
        }

        // POST: FarmerMarketParticipations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmerMarketParticipation = await _context.FarmerMarketParticipations.FindAsync(id);
            if (farmerMarketParticipation != null)
            {
                _context.FarmerMarketParticipations.Remove(farmerMarketParticipation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmerMarketParticipationExists(int id)
        {
            return _context.FarmerMarketParticipations.Any(e => e.FarmerID == id);
        }
    }
}
