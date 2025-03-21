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
            // Get all products with related details
            var productsQuery = _context.FarmerProducts
                .Include(p => p.Product)
                .Include(p => p.Farmer)
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
                productsQuery = productsQuery.Where(p => p.Product.ProductName.Contains(search)
                    || p.Farmer.FarmName.Contains(search));
            }

            // For the homepage, we might only want the latest 6 products
            var products = await productsQuery
                .OrderByDescending(p => p.FarmerProductID)
                .Take(6)
                .ToListAsync();

            return View(products);
        }

        // Optional: Additional action to support "Learn More" button
        public IActionResult LearnMore()
        {
            // Create a view with more information about your marketplace,
            // its mission, community, or how it works.
            return View();
        }
    }
}
