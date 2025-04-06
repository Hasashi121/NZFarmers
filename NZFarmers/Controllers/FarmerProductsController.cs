using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

        public FarmerProductsController(NZFarmersContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: FarmerProducts
        // GET: FarmerProducts
        public async Task<IActionResult> Index(string searchString, string categoryFilter)
        {
            var query = _context.FarmerProducts
                .Include(f => f.Farmer)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(p =>
                    p.ProductName.Contains(searchString) ||
                    p.Farmer.FarmName.Contains(searchString) ||
                    p.Farmer.City.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(categoryFilter) && Enum.TryParse<ProductCategory>(categoryFilter, out var parsedCategory))
            {
                query = query.Where(p => p.Category == parsedCategory);
            }

            ViewData["CurrentSearch"] = searchString;
            ViewData["CurrentCategory"] = categoryFilter;
            ViewData["CategoryList"] = new SelectList(Enum.GetValues(typeof(ProductCategory)));

            var farmerProducts = await query.ToListAsync();
            return View(farmerProducts);
        }



        // GET: FarmerProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            // Removed .Include(f => f.Product)
            var farmerProduct = await _context.FarmerProducts
                .Include(f => f.Farmer)
                .FirstOrDefaultAsync(m => m.FarmerProductID == id);

            if (farmerProduct == null)
                return NotFound();

            return View(farmerProduct);
        }

        // GET: FarmerProducts/Create
        public IActionResult Create()
        {
            ViewData["FarmerID"] = new SelectList(_context.Farmers, "FarmerID", "FarmName");
            ViewData["Category"] = new SelectList(Enum.GetValues(typeof(ProductCategory)));

            return View(); 
        }



        // POST: FarmerProducts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FarmerProduct farmerProduct)
        {
            // Typical pattern: if valid, save; otherwise re-show form
            if (!ModelState.IsValid)
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

        // GET: FarmerProducts/Edit/5
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

        // POST: FarmerProducts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FarmerProductID,FarmerID,Category,Price,Stock,ImageURL")] FarmerProduct farmerProduct)
        {
            if (id != farmerProduct.FarmerProductID)
                return NotFound();

            if (!ModelState.IsValid)
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
