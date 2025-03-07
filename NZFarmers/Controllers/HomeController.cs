using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZFarmers.Data;
using NZFarmers.Models;

public class HomeController : Controller
{
    private readonly NZFarmersContext _context;

    public HomeController(NZFarmersContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string category, string search)
    {
        var products = _context.FarmerProducts
            .Include(p => p.Product)
            .Include(p => p.Farmer)
            .AsQueryable();

        if (!string.IsNullOrEmpty(category))
        {
            if (Enum.TryParse(category, out ProductCategory selectedCategory))
            {
                products = products.Where(p => p.Category == selectedCategory);
            }
        }

        if (!string.IsNullOrEmpty(search))
        {
            products = products.Where(p => p.Product.ProductName.Contains(search) || p.Farmer.FarmName.Contains(search));
        }

        return View(await products.ToListAsync());
    }
}
