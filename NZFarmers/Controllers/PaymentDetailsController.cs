using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NZFarmers.Areas.Identity.Data;
using NZFarmers.Data;
using NZFarmers.Models;

namespace NZFarmers.Controllers
{
    public class PaymentDetailsController : Controller
    {
        private readonly NZFarmersContext _context;
        private readonly UserManager<NZFarmersUser> _userManager;

        public PaymentDetailsController(NZFarmersContext context, UserManager<NZFarmersUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: PaymentDetails
        public async Task<IActionResult> Index()
        {
            var payments = _context.PaymentDetails
                .Include(p => p.User) 
                .Include(p => p.Order);
            return View(await payments.ToListAsync());
        }


        // GET: PaymentDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentDetail = await _context.PaymentDetails
                .Include(p => p.User)
                .Include(p => p.Order)
                .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            return View(paymentDetail);
        }

        // GET: PaymentDetails/Create
        public IActionResult Create()
        {
            // Instead of letting the user select the UserID, we use the logged-in user's info.
            // For OrderID, we populate a dropdown if needed.
            ViewBag.OrderID = new SelectList(_context.Orders, "OrderID", "OrderID");
            ViewData["Status"] = new SelectList(Enum.GetValues(typeof(PaymentStatus)).Cast<PaymentStatus>());
            ViewData["Method"] = new SelectList(Enum.GetValues(typeof(PaymentMethod)).Cast<PaymentMethod>());
            return View();
        }

        // POST: PaymentDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,Amount,Status,Method")] PaymentDetail paymentDetail)
        {
            // Automatically assign the current user's ID
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Challenge(); // Forces login if not authenticated
            }
            paymentDetail.UserID = userId;
            paymentDetail.CreatedAt = DateTime.UtcNow;

            if (!ModelState.IsValid)
            {
                _context.Add(paymentDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.OrderID = new SelectList(_context.Orders, "OrderID", "OrderID", paymentDetail.OrderID);
            ViewData["Status"] = new SelectList(Enum.GetValues(typeof(PaymentStatus)).Cast<PaymentStatus>(), paymentDetail.Status);
            ViewData["Method"] = new SelectList(Enum.GetValues(typeof(PaymentMethod)).Cast<PaymentMethod>(), paymentDetail.Method);
            return View(paymentDetail);
        }

        // GET: PaymentDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentDetail = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            ViewBag.OrderID = new SelectList(_context.Orders, "OrderID", "OrderID", paymentDetail.OrderID);
            ViewData["Status"] = new SelectList(Enum.GetValues(typeof(PaymentStatus)).Cast<PaymentStatus>(), paymentDetail.Status);
            ViewData["Method"] = new SelectList(Enum.GetValues(typeof(PaymentMethod)).Cast<PaymentMethod>(), paymentDetail.Method);
            return View(paymentDetail);
        }

        // POST: PaymentDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentID,OrderID,Amount,Status,Method,CreatedAt")] PaymentDetail paymentDetail)
        {
            if (id != paymentDetail.PaymentID)
            {
                return NotFound();
            }

            // Ensure that the logged-in user's ID is preserved
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Challenge();
            }
            paymentDetail.UserID = userId;

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentDetailExists(paymentDetail.PaymentID))
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

            ViewBag.OrderID = new SelectList(_context.Orders, "OrderID", "OrderID", paymentDetail.OrderID);
            ViewData["Status"] = new SelectList(Enum.GetValues(typeof(PaymentStatus)).Cast<PaymentStatus>(), paymentDetail.Status);
            ViewData["Method"] = new SelectList(Enum.GetValues(typeof(PaymentMethod)).Cast<PaymentMethod>(), paymentDetail.Method);
            return View(paymentDetail);
        }

        // GET: PaymentDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentDetail = await _context.PaymentDetails
                .Include(p => p.User)
                .Include(p => p.Order)
                .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            return View(paymentDetail);
        }

        // POST: PaymentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetail != null)
            {
                _context.PaymentDetails.Remove(paymentDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PaymentDetailExists(int id)
        {
            return _context.PaymentDetails.Any(e => e.PaymentID == id);
        }
    }
}
