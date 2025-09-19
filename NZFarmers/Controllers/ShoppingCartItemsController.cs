using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZFarmers.Areas.Identity.Data;
using NZFarmers.Data;
using NZFarmers.Models;
using Stripe.Checkout; // Stripe namespace

namespace NZFarmers.Controllers
{
    [Authorize]
    public class ShoppingCartItemsController : Controller
    {
        private readonly NZFarmersContext _context;
        private readonly UserManager<NZFarmersUser> _userManager;

        public ShoppingCartItemsController(NZFarmersContext context, UserManager<NZFarmersUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ShoppingCartItems
        // Lists all cart items for the logged-in user
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
                return Challenge();

            // Removed the extra ThenInclude(fp => fp.Product)
            var cartItems = await _context.ShoppingCartItems
                .Include(ci => ci.FarmerProduct)
                .Where(ci => ci.UserID == userId)
                .ToListAsync();

            return View(cartItems); // Expects Views/ShoppingCartItems/Index.cshtml
        }

        // POST: ShoppingCartItems/AddToCart?farmerProductId=...&quantity=...
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int farmerProductId, int quantity = 1)
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
                return Challenge();

            // Check if product is already in the cart for this user
            var existingItem = await _context.ShoppingCartItems
                .FirstOrDefaultAsync(ci => ci.FarmerProductID == farmerProductId && ci.UserID == userId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                var cartItem = new ShoppingCartItem
                {
                    UserID = userId,
                    FarmerProductID = farmerProductId,
                    Quantity = quantity,
                    CreatedAt = DateTime.UtcNow
                };
                _context.ShoppingCartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: ShoppingCartItems/RemoveItem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveItem(int cartItemId)
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
                return Challenge();

            var cartItem = await _context.ShoppingCartItems
                .FirstOrDefaultAsync(ci => ci.ShoppingCartItemID == cartItemId && ci.UserID == userId);

            if (cartItem != null)
            {
                _context.ShoppingCartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: ShoppingCartItems/Checkout
        // Integrates Stripe payment: creates a Stripe Checkout Session and redirects the user.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout()
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
                return Challenge();

            // Retrieve all cart items for the user without then including the removed Product model
            var cartItems = await _context.ShoppingCartItems
                .Include(ci => ci.FarmerProduct)
                .Where(ci => ci.UserID == userId)
                .ToListAsync();

            if (!cartItems.Any())
                return RedirectToAction(nameof(Index));

            // Create a new Stripe Checkout Session
            var sessionOptions = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                Mode = "payment",
                SuccessUrl = Url.Action("PaymentSuccess", "Orders", null, Request.Scheme),
                CancelUrl = Url.Action("PaymentCanceled", "Orders", null, Request.Scheme),
                LineItems = new List<SessionLineItemOptions>()
            };

            foreach (var item in cartItems)
            {
                sessionOptions.LineItems.Add(new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "nzd", 
                        UnitAmount = (long)(item.FarmerProduct.Price * 100), // Stripe expects amounts in cents
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            // Use the product name directly from FarmerProduct
                            Name = item.FarmerProduct.ProductName
                        }
                    },
                    Quantity = item.Quantity
                });
            }

            var sessionService = new SessionService();
            Session stripeSession = sessionService.Create(sessionOptions);

       
            return Redirect(stripeSession.Url);
        }
    }
}




















