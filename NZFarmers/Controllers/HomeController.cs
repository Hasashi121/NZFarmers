using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZFarmers.Data;
using NZFarmers.Models;
using NZFarmers.Services;

namespace NZFarmers.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;
        readonly NZFarmersContext _context;

        public HomeController(NZFarmersContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;

        }

        // GET: Home/Index
        public async Task<IActionResult> Index(string category, string search)
        {
            // Start with all FarmerProducts
            var productsQuery = _context.FarmerProducts
                .Include(p => p.Farmer)
                .AsQueryable();

            // Filter by category if provided
            if (!string.IsNullOrEmpty(category))
            {
                if (Enum.TryParse<ProductCategory>(category, out var selectedCategory))
                {
                    productsQuery = productsQuery.Where(p => p.Category == selectedCategory);
                    ViewData["SelectedCategory"] = category;
                }
            }

            // Filter by search text if provided
            if (!string.IsNullOrEmpty(search))
            {
                productsQuery = productsQuery.Where(p =>
                    p.ProductName.Contains(search) ||
                    p.Farmer.FarmName.Contains(search));
                ViewData["SearchQuery"] = search;
            }

            // Get featured products - you can customize the logic here
            // Currently showing the latest products
            var products = await productsQuery
                .OrderByDescending(p => p.FarmerProductID)
                .Take(6)
                .ToListAsync();

            return View(products);
        }

        // Action for "Learn More"
        public IActionResult LearnMore()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        // Error handling
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
        // POST: Home/SendContactEmail
        [HttpPost]
        public async Task<IActionResult> SendContactEmail(string email, string subject, string message)
        {
            try
            {
                await _emailService.SendContactEmailAsync(email, subject, message);
                TempData["Success"] = "Thank you! Your message has been sent successfully.";
            }
            catch (Exception)
            {
                TempData["Error"] = "Sorry, we couldn't send your message. Please try again later.";
            }

            return RedirectToAction("Privacy");
        }
    }
}