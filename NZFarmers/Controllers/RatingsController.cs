using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NZFarmers.Data;
using NZFarmers.Models;
using NZFarmers.Areas.Identity.Data; 

namespace NZFarmers.Controllers
{
    public class RatingsController : Controller
    {
        private readonly NZFarmersContext _context;

        public RatingsController(NZFarmersContext context)
        {
            _context = context;
        }

        // GET: Ratings
        public async Task<IActionResult> Index()
        {
            var ratingsQuery = _context.Ratings
                .Include(r => r.Farmer)
                .Include(r => r.User); // references NZFarmersUser

            return View(await ratingsQuery.ToListAsync());
        }

        // GET: Ratings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var rating = await _context.Ratings
                .Include(r => r.Farmer)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RatingID == id);

            if (rating == null)
                return NotFound();

            return View(rating);
        }

        // GET: Ratings/Create
        public IActionResult Create()
        {
            // Dropdown for Farmer
            ViewData["FarmerID"] = new SelectList(_context.Farmers, "FarmerID", "FarmName");

            // Dropdown for User (Identity). 
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");

            return View();
        }

        // POST: Ratings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RatingID,UserId,FarmerID,RatingValue,Comment,CreatedAt")] Rating rating)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(rating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // ModelState invalid, so re-populate dropdowns
            ViewData["FarmerID"] = new SelectList(_context.Farmers, "FarmerID", "FarmName", rating.FarmerID);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", rating.UserId);
            return View(rating);
        }

        // GET: Ratings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var rating = await _context.Ratings.FindAsync(id);
            if (rating == null)
                return NotFound();

            ViewData["FarmerID"] = new SelectList(_context.Farmers, "FarmerID", "FarmName", rating.FarmerID);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", rating.UserId);
            return View(rating);
        }

        // POST: Ratings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RatingID,UserId,FarmerID,RatingValue,Comment,CreatedAt")] Rating rating)
        {
            if (id != rating.RatingID)
                return NotFound();

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(rating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RatingExists(rating.RatingID))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            // ModelState invalid; re-populate dropdowns
            ViewData["FarmerID"] = new SelectList(_context.Farmers, "FarmerID", "FarmName", rating.FarmerID);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", rating.UserId);
            return View(rating);
        }

        // GET: Ratings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var rating = await _context.Ratings
                .Include(r => r.Farmer)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RatingID == id);

            if (rating == null)
                return NotFound();

            return View(rating);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rating = await _context.Ratings.FindAsync(id);
            if (rating != null)
            {
                _context.Ratings.Remove(rating);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool RatingExists(int id)
        {
            return _context.Ratings.Any(e => e.RatingID == id);
        }
    }
}