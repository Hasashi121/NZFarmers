using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZFarmers.Areas.Identity.Data;
using NZFarmers.Data;
using NZFarmers.Models;

namespace NZFarmers.Controllers
{
    public class FarmersController : Controller
    {
        private readonly NZFarmersContext _context;
        private readonly UserManager<NZFarmersUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FarmersController(NZFarmersContext context,
                                 UserManager<NZFarmersUser> userManager,
                                 IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Farmers
        public async Task<IActionResult> Index(string searchString, string sortOrder, int page = 1)
        {
            int pageSize = 10; // Show 10 farmers per page (you can change this)
            ViewData["CurrentFilter"] = searchString;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CitySortParm"] = sortOrder == "City" ? "city_desc" : "City";
            ViewData["RegionSortParm"] = sortOrder == "Region" ? "region_desc" : "Region";

            var farmers = from f in _context.Farmers.Include(f => f.User)
                          select f;

            if (!string.IsNullOrEmpty(searchString))
            {
                farmers = farmers.Where(f =>
                    f.FarmName.Contains(searchString) ||
                    f.City.Contains(searchString) ||
                    f.Region.Contains(searchString) ||
                    f.Address.Contains(searchString));
            }

            farmers = sortOrder switch
            {
                "name_desc" => farmers.OrderByDescending(f => f.FarmName),
                "City" => farmers.OrderBy(f => f.City),
                "city_desc" => farmers.OrderByDescending(f => f.City),
                "Region" => farmers.OrderBy(f => f.Region),
                "region_desc" => farmers.OrderByDescending(f => f.Region),
                _ => farmers.OrderBy(f => f.FarmName),
            };

            var paginatedFarmers = await PaginatedList<Farmers>.CreateAsync(farmers.AsNoTracking(), page, pageSize);
            return View(paginatedFarmers);
        }


        // GET: Farmers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var farmer = await _context.Farmers
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FarmerID == id);
            if (farmer == null) return NotFound();

            return View(farmer);
        }

        // GET: Farmers/Create
        public async Task<IActionResult> Create()
        {
            // Ensure the user is logged in
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Pre-set the UserID to the current user
            var model = new Farmers
            {
                UserID = user.Id
            };

            return View(model);
        }

        // POST: Farmers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FarmName,Description,PhoneNumber,ProfileImage,ProfileImageFile,Address,City,Region,ZipCode")] Farmers farmer)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            farmer.UserID = currentUser.Id;

            if (ModelState.IsValid)
            {
                // Handle file upload
                if (farmer.ProfileImageFile != null && farmer.ProfileImageFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadsFolder); // Ensure folder exists
                    string uniqueFileName = Guid.NewGuid().ToString() + "_"
                        + Path.GetFileName(farmer.ProfileImageFile.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await farmer.ProfileImageFile.CopyToAsync(fileStream);
                    }

                    // Save the relative path in the DB
                    farmer.ProfileImage = "/uploads/" + uniqueFileName;
                }

                _context.Add(farmer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // If ModelState is invalid, show the form again
            return View(farmer);
        }

        // GET: Farmers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null) return NotFound();

            return View(farmer);
        }

        // POST: Farmers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FarmerID,FarmName,Description,PhoneNumber,ProfileImage,ProfileImageFile,Address,City,Region,ZipCode")] Farmers farmer)
        {
            if (id != farmer.FarmerID) return NotFound();

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            // Keep the same user ID
            farmer.UserID = user.Id;

            if (ModelState.IsValid)
            {
                // If a new file was uploaded, overwrite the old image
                if (farmer.ProfileImageFile != null && farmer.ProfileImageFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadsFolder);
                    string uniqueFileName = Guid.NewGuid().ToString() + "_"
                        + Path.GetFileName(farmer.ProfileImageFile.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await farmer.ProfileImageFile.CopyToAsync(stream);
                    }

                    // Update the ProfileImage path
                    farmer.ProfileImage = "/uploads/" + uniqueFileName;
                }

                try
                {
                    _context.Update(farmer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmersExists(farmer.FarmerID))
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
            return View(farmer);
        }

        // GET: Farmers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var farmer = await _context.Farmers
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FarmerID == id);
            if (farmer == null) return NotFound();

            return View(farmer);
        }

        // POST: Farmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer != null)
            {
                _context.Farmers.Remove(farmer);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool FarmersExists(int id)
        {
            return _context.Farmers.Any(e => e.FarmerID == id);
        }

        // GET: Farmers/DetailsWithProducts/5
        public async Task<IActionResult> DetailsWithProducts(int? id)
        {
            if (id == null) return NotFound();

            var farmer = await _context.Farmers
                .Include(f => f.User)
                .Include(f => f.FarmerProducts)
                .FirstOrDefaultAsync(f => f.FarmerID == id);

            if (farmer == null) return NotFound();

            return View("DetailsWithProducts", farmer);
        }

    }
}
