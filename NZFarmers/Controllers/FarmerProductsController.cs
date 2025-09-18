using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NZFarmers.Data;
using NZFarmers.Models;

namespace NZFarmers.Controllers
{

    public class FarmerProductsController : Controller
    {
        private readonly NZFarmersContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private const int PageSize = 12; // Products per page

        public FarmerProductsController(NZFarmersContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: FarmerProducts
        public async Task<IActionResult> Index(
            string searchString,
            string categoryFilter,
            int? pageNumber)
        {
            var query = _context.FarmerProducts
                .Include(f => f.Farmer)
                .AsQueryable();

            // Search functionality
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(p =>
                    p.ProductName.Contains(searchString) ||
                    p.Farmer.FarmName.Contains(searchString) ||
                    p.Farmer.City.Contains(searchString));
            }

            // Category filter
            if (!string.IsNullOrEmpty(categoryFilter) && Enum.TryParse<ProductCategory>(categoryFilter, out var parsedCategory))
            {
                query = query.Where(p => p.Category == parsedCategory);
            }

            // Order by product name for consistent pagination
            query = query.OrderBy(p => p.ProductName);

            // Store current filters for view
            ViewData["CurrentSearch"] = searchString;
            ViewData["CurrentCategory"] = categoryFilter;
            ViewData["CategoryList"] = new SelectList(Enum.GetValues(typeof(ProductCategory)));

            // Apply pagination
            int pageIndex = pageNumber ?? 1;
            var paginatedProducts = await PaginatedList<FarmerProduct>.CreateAsync(
                query.AsNoTracking(), pageIndex, PageSize);

            return View(paginatedProducts);
        }

        // GET: FarmerProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var farmerProduct = await _context.FarmerProducts
                .Include(f => f.Farmer)
                .FirstOrDefaultAsync(m => m.FarmerProductID == id);

            if (farmerProduct == null)
                return NotFound();

            return View(farmerProduct);
        }

        // GET: FarmerProducts/Create
        [Authorize(Roles = "Admin,Farmer")]
        public IActionResult Create()
        {
            ViewData["FarmerID"] = new SelectList(_context.Farmers, "FarmerID", "FarmName");
            ViewData["Category"] = new SelectList(Enum.GetValues(typeof(ProductCategory)));

            return View();
        }

        // POST: FarmerProducts/Create
        [Authorize(Roles = "Admin,Farmer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FarmerProduct farmerProduct)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload if present
                if (farmerProduct.ImageFile != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadsFolder);

                    string uniqueFileName = Guid.NewGuid().ToString()
                        + "_" + Path.GetFileName(farmerProduct.ImageFile.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await farmerProduct.ImageFile.CopyToAsync(fileStream);
                    }
                    farmerProduct.ImageURL = "/uploads/" + uniqueFileName;
                }

                _context.Add(farmerProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // If we got here, ModelState was invalid. Re-populate the dropdowns:
            ViewData["FarmerID"] = new SelectList(_context.Farmers, "FarmerID", "FarmName", farmerProduct.FarmerID);
            ViewData["Category"] = new SelectList(Enum.GetValues(typeof(ProductCategory)), farmerProduct.Category);

            return View(farmerProduct);
        }

        // GET: FarmerProducts/Edit/
        [Authorize(Roles = "Admin,Farmer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var farmerProduct = await _context.FarmerProducts.FindAsync(id);
            if (farmerProduct == null)
                return NotFound();

            ViewData["FarmerID"] = new SelectList(_context.Farmers, "FarmerID", "FarmName", farmerProduct.FarmerID);
            ViewData["Category"] = new SelectList(Enum.GetValues(typeof(ProductCategory)), farmerProduct.Category);
            return View(farmerProduct);
        }

        // POST: FarmerProducts/Edit/
        [Authorize(Roles = "Admin,Farmer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FarmerProductID,FarmerID,ProductName,Description,Category,Price,Stock,ImageURL")] FarmerProduct farmerProduct)
        {
            if (id != farmerProduct.FarmerProductID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmerProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmerProductExists(farmerProduct.FarmerProductID))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            // ModelState invalid; re-populate dropdowns
            ViewData["FarmerID"] = new SelectList(_context.Farmers, "FarmerID", "FarmName", farmerProduct.FarmerID);
            ViewData["Category"] = new SelectList(Enum.GetValues(typeof(ProductCategory)), farmerProduct.Category);
            return View(farmerProduct);
        }

        // GET: FarmerProducts/Delete/5
        [Authorize(Roles = "Admin,Farmer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var farmerProduct = await _context.FarmerProducts
                .Include(f => f.Farmer)
                .FirstOrDefaultAsync(m => m.FarmerProductID == id);

            if (farmerProduct == null)
                return NotFound();

            return View(farmerProduct);
        }

        // POST: FarmerProducts/Delete/5
        [Authorize(Roles = "Admin,Farmer")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var farmerProduct = await _context.FarmerProducts.FindAsync(id);
            if (farmerProduct != null)
            {
                _context.FarmerProducts.Remove(farmerProduct);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool FarmerProductExists(int id)
        {
            return _context.FarmerProducts.Any(e => e.FarmerProductID == id);
        }
    }
}