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
    public class DeliveryTrackingsController : Controller
    {
        private readonly NZFarmersContext _context;

        public DeliveryTrackingsController(NZFarmersContext context)
        {
            _context = context;
        }

        // GET: DeliveryTrackings
        public async Task<IActionResult> Index()
        {
            var nZFarmersContext = _context.DeliveryTrackings.Include(d => d.Order);
            return View(await nZFarmersContext.ToListAsync());
        }

        // GET: DeliveryTrackings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryTracking = await _context.DeliveryTrackings
                .Include(d => d.Order)
                .FirstOrDefaultAsync(m => m.TrackingID == id);
            if (deliveryTracking == null)
            {
                return NotFound();
            }

            return View(deliveryTracking);
        }

        // GET: DeliveryTrackings/Create
        public IActionResult Create()
        {
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "UserID");
            return View();
        }

        // POST: DeliveryTrackings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrackingID,OrderID,Status,LastUpdated")] DeliveryTracking deliveryTracking)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(deliveryTracking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "UserID", deliveryTracking.OrderID);
            return View(deliveryTracking);
        }

        // GET: DeliveryTrackings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryTracking = await _context.DeliveryTrackings.FindAsync(id);
            if (deliveryTracking == null)
            {
                return NotFound();
            }
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "UserID", deliveryTracking.OrderID);
            return View(deliveryTracking);
        }

        // POST: DeliveryTrackings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrackingID,OrderID,Status,LastUpdated")] DeliveryTracking deliveryTracking)
        {
            if (id != deliveryTracking.TrackingID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryTracking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryTrackingExists(deliveryTracking.TrackingID))
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
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "UserID", deliveryTracking.OrderID);
            return View(deliveryTracking);
        }

        // GET: DeliveryTrackings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryTracking = await _context.DeliveryTrackings
                .Include(d => d.Order)
                .FirstOrDefaultAsync(m => m.TrackingID == id);
            if (deliveryTracking == null)
            {
                return NotFound();
            }

            return View(deliveryTracking);
        }

        // POST: DeliveryTrackings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryTracking = await _context.DeliveryTrackings.FindAsync(id);
            if (deliveryTracking != null)
            {
                _context.DeliveryTrackings.Remove(deliveryTracking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryTrackingExists(int id)
        {
            return _context.DeliveryTrackings.Any(e => e.TrackingID == id);
        }
    }
}
