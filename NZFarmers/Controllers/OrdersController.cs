using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NZFarmers.Areas.Identity.Data;
using NZFarmers.Data;
using NZFarmers.Models;

namespace NZFarmers.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly NZFarmersContext _context;
        private readonly UserManager<NZFarmersUser> _userManager;

        public OrdersController(NZFarmersContext context, UserManager<NZFarmersUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var nZFarmersContext = _context.Orders.Include(o => o.User);
            return View(await nZFarmersContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["Status"] = new SelectList(Enum.GetValues(typeof(OrderStatus)));
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TotalPrice,Status")] Order order)
        {
            if (!ModelState.IsValid)
            {
                // Get current user ID
                var userId = _userManager.GetUserId(User);
                order.UserID = userId!;
                order.CreatedAt = DateTime.UtcNow;

                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Status"] = new SelectList(Enum.GetValues(typeof(OrderStatus)), order.Status);
            return View(order);
        }


        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,TotalPrice,Status,CreatedAt")] Order order)
        {
            if (id != order.OrderID) return NotFound();

            if (!ModelState.IsValid)
            {
                try
                {
                    var userId = _userManager.GetUserId(User);
                    order.UserID = userId!;
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderID)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }


        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> PaymentSuccess()
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
                return Challenge();

            // Retrieve the user's shopping cart items
            var cartItems = await _context.ShoppingCartItems
                .Include(ci => ci.FarmerProduct)
                .Where(ci => ci.UserID == userId)
                .ToListAsync();

            if (!cartItems.Any())
                return RedirectToAction("Index", "ShoppingCartItems");

            // Calculate total
            decimal totalPrice = cartItems.Sum(item => item.Quantity * item.FarmerProduct.Price);

            // Create new Order
            var order = new Order
            {
                UserID = userId,
                TotalPrice = totalPrice,
                Status = OrderStatus.Processing,
                CreatedAt = DateTime.UtcNow
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(); // So we get the OrderID for foreign key

            // Create OrderDetails
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    OrderID = order.OrderID,
                    FarmerProductID = item.FarmerProductID,
                    Quantity = item.Quantity,
                    Subtotal = item.Quantity * item.FarmerProduct.Price
                };
                _context.OrderDetails.Add(orderDetail);
            }

            // Clear cart
            _context.ShoppingCartItems.RemoveRange(cartItems);

            await _context.SaveChangesAsync();

            return View(); // Optionally pass `order` to the view
        }


        // GET: Orders/PaymentCanceled
        [HttpGet]
        public IActionResult PaymentCanceled()
        {
            // Inform the user that the payment was canceled and perhaps offer to try again.
            return View();
        }
        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
