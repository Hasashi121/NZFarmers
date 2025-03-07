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
    public class FarmerProductsController : Controller
    {
        private readonly NZFarmersContext _context;

        public FarmerProductsController(NZFarmersContext context)
        {
            _context = context;
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
        public async Task<IActionResult> Create([Bind("FarmerProductID,FarmerID,ProductID,Category,Price,Stock,ImageURL")] FarmerProduct farmerProduct)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(farmerProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FarmerID"] = new SelectList(_context.Farmers, "FarmerID", "FarmName", farmerProduct.FarmerID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductName", farmerProduct.ProductID);
            ViewData["Category"] = new SelectList(Enum.GetValues(typeof(ProductCategory)), farmerProduct.Category);
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
            ViewData["FarmerID"] = new SelectList(_context.Farmers, "FarmerID", "Address", farmerProduct.FarmerID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductName", farmerProduct.ProductID);
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
