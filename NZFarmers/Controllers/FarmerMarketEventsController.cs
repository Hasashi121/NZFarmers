using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        private const int PageSize = 10; // Pagination

        public FarmerMarketEventsController(NZFarmersContext context)
        {
            _context = context;
        }

        // GET: FarmerMarketEvents
        // Any authenticated user can view the list
        public async Task<IActionResult> Index(
            string searchString,
            string sortOrder,
            string locationFilter,
            DateTime? dateFilter,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["TitleSortParm"] = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["LocationSortParm"] = sortOrder == "Location" ? "location_desc" : "Location";
            ViewData["CreatedAtSortParm"] = sortOrder == "CreatedAt" ? "createdat_desc" : "CreatedAt";

            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentLocationFilter"] = locationFilter;
            ViewData["CurrentDateFilter"] = dateFilter;

            var eventsQuery = from e in _context.FarmerMarketEvents
                              select e;

            // Search functionality
            if (!string.IsNullOrEmpty(searchString))
            {
                eventsQuery = eventsQuery.Where(e => e.Title.Contains(searchString)
                                        || e.Location.Contains(searchString)
                                        || (e.Description != null && e.Description.Contains(searchString)));
            }

            // Filter by location
            if (!string.IsNullOrEmpty(locationFilter))
            {
                eventsQuery = eventsQuery.Where(e => e.Location.Contains(locationFilter));
            }

            // Filter by date
            if (dateFilter.HasValue)
            {
                eventsQuery = eventsQuery.Where(e => e.Date.Date == dateFilter.Value.Date);
            }

            // Sort functionality
            switch (sortOrder)
            {
                case "title_desc":
                    eventsQuery = eventsQuery.OrderByDescending(e => e.Title);
                    break;
                case "Date":
                    eventsQuery = eventsQuery.OrderBy(e => e.Date);
                    break;
                case "date_desc":
                    eventsQuery = eventsQuery.OrderByDescending(e => e.Date);
                    break;
                case "Location":
                    eventsQuery = eventsQuery.OrderBy(e => e.Location);
                    break;
                case "location_desc":
                    eventsQuery = eventsQuery.OrderByDescending(e => e.Location);
                    break;
                case "CreatedAt":
                    eventsQuery = eventsQuery.OrderBy(e => e.CreatedAt);
                    break;
                case "createdat_desc":
                    eventsQuery = eventsQuery.OrderByDescending(e => e.CreatedAt);
                    break;
                default:
                    eventsQuery = eventsQuery.OrderBy(e => e.Title);
                    break;
            }

            // locations for filter dropdown
            var locations = await _context.FarmerMarketEvents
                .Select(e => e.Location)
                .Distinct()
                .OrderBy(l => l)
                .ToListAsync();

            ViewBag.Locations = new SelectList(locations);

            // Apply pagination
            int pageIndex = pageNumber ?? 1;
            var paginatedEvents = await PaginatedList<FarmerMarketEvent>.CreateAsync(
                eventsQuery.AsNoTracking(), pageIndex, PageSize);

            return View(paginatedEvents);
        }

        // GET: FarmerMarketEvents/Details/
        // Any authenticated user can view details
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
        // Only Admins can create events
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: FarmerMarketEvents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("EventID,Title,Location,Date,Description")] FarmerMarketEvent farmerMarketEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmerMarketEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmerMarketEvent);
        }

        // GET: FarmerMarketEvents/Edit
        // Only Admins can edit events
        [Authorize(Roles = "Admin")]
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

        // POST: FarmerMarketEvents/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,Title,Location,Date,Description,CreatedAt")] FarmerMarketEvent farmerMarketEvent)
        {
            if (id != farmerMarketEvent.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
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

        // GET: FarmerMarketEvents/Delete
        // Only Admins can delete events
        [Authorize(Roles = "Admin")]
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

        // POST: FarmerMarketEvents/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
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