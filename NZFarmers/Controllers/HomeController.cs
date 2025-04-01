using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZFarmers.Data;
using NZFarmers.Models;

namespace NZFarmers.Controllers
{
    public class HomeController : Controller
    {
        private readonly NZFarmersContext _context;

        public HomeController(NZFarmersContext context)
        {
            _context = context;
        }

        // GET: Home/Index
        public async Task<IActionResult> Index(string category, string search)
        {
            // Start with all FarmerProducts
            var productsQuery = _context.FarmerProducts
                .Include(p => p.Farmer) // Keep if you still want to display Farmer info
                .AsQueryable();

            // Filter by category if provided
            if (!string.IsNullOrEmpty(category))
            {
                if (Enum.TryParse<ProductCategory>(category, out var selectedCategory))
                {
                    productsQuery = productsQuery.Where(p => p.Category == selectedCategory);
                }
            }

            // Filter by search text if provided
            if (!string.IsNullOrEmpty(search))
            {
                // Replace p.ProductName with whatever property holds the product's name in FarmerProduct
                productsQuery = productsQuery.Where(p =>
                    p.ProductName.Contains(search) ||
                    p.Farmer.FarmName.Contains(search));
            }

            // Optionally show only the latest 6 products
            var products = await productsQuery
                .OrderByDescending(p => p.FarmerProductID)
                .Take(6)
                .ToListAsync();

            return View(products);
        }

        // Optional: Additional action for "Learn More"
        public IActionResult LearnMore()
        {
            return View();
        }
    }
}
