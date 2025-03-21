using System;
using System.Collections.Generic;
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
        public async Task<IActionResult> Index()
        {
            var nZFarmersContext = _context.FarmerProducts.Include(f => f.Farmer).Include(f => f.Product);
            return View(await nZFarmersContext.ToListAsync());
        }

        // GET: FarmerProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerProduct = await _context.FarmerProducts
                .Include(f => f.Farmer)
                .Include(f => f.Product)
                .FirstOrDefaultAsync(m => m.FarmerProductID == id);
            if (farmerProduct == null)
            {
                return NotFound();
            }

            return View(farmerProduct);
        }

        // GET: FarmerProducts/Create
        public IActionResult Create()
        {

            // Populate dropdowns with valid data
            ViewData["FarmerID"] = new SelectList(_context.Farmers, "FarmerID", "FarmName");
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductName");
            ViewData["Category"] = new SelectList(Enum.GetValues(typeof(ProductCategory)));
            return View();
        }


        // POST: FarmerProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FarmerProduct farmerProduct)
        {
            if (!ModelState.IsValid)
            {
                // If valid, handle file upload & save to DB
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

            // If we get here, ModelState was invalid. Re-populate the dropdowns:
            ViewData["FarmerID"] = new SelectList(_context.Farmers, "FarmerID", "FarmName", farmerProduct.FarmerID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductName", farmerProduct.ProductID);
            ViewData["Category"] = new SelectList(Enum.GetValues(typeof(ProductCategory)), farmerProduct.Category);

            // Return the same view with the re-populated data
            return View(farmerProduct);
        }



        // GET: FarmerProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerProduct = await _context.FarmerProducts.FindAsync(id);
            if (farmerProduct == null)
            {
                return NotFound();
            }
            ViewData["FarmerID"] = new SelectList(_context.Farmers, "FarmerID", "FarmName", farmerProduct.FarmerID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductName", farmerProduct.ProductID);
            ViewData["Category"] = new SelectList(Enum.GetValues(typeof(ProductCategory)), farmerProduct.Category);
            return View(farmerProduct);
        }


        // POST: FarmerProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FarmerProductID,FarmerID,ProductID,Price,Stock,ImageURL")] FarmerProduct farmerProduct)
        {
            if (id != farmerProduct.FarmerProductID)
            {
                return NotFound();
            }

            // Corrected logic:
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

            // ModelState is invalid, so re-populate dropdowns
            ViewData["FarmerID"] = new SelectList(_context.Farmers, "FarmerID", "FarmName", farmerProduct.FarmerID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductName", farmerProduct.ProductID);
            ViewData["Category"] = new SelectList(Enum.GetValues(typeof(ProductCategory)), farmerProduct.Category);

            return View(farmerProduct);
        }


        // GET: FarmerProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerProduct = await _context.FarmerProducts
                .Include(f => f.Farmer)
                .Include(f => f.Product)
                .FirstOrDefaultAsync(m => m.FarmerProductID == id);
            if (farmerProduct == null)
            {
                return NotFound();
            }

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
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmerProductExists(int id)
        {
            return _context.FarmerProducts.Any(e => e.FarmerProductID == id);
        }
    }
}
