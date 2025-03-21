﻿using System;
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
            var nZFarmersContext = _context.PaymentDetails.Include(p => p.User);
            return View(await nZFarmersContext.ToListAsync());
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
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return Challenge(); // User not logged in
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

            ViewData["UserID"] = new SelectList(_context.Users.ToList(), "Id", "Email", paymentDetail.UserID);
            ViewData["Status"] = new SelectList(Enum.GetValues(typeof(PaymentStatus)).Cast<PaymentStatus>(), paymentDetail.Status);
            ViewData["Method"] = new SelectList(Enum.GetValues(typeof(PaymentMethod)).Cast<PaymentMethod>(), paymentDetail.Method);
            return View(paymentDetail);
        }

        // POST: PaymentDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentID,UserID,Amount,Status,Method,CreatedAt")] PaymentDetail paymentDetail)
        {
            if (id != paymentDetail.PaymentID)
            {
                return NotFound();
            }

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
            ViewData["UserID"] = new SelectList(_context.Users.ToList(), "Id", "Email", paymentDetail.UserID);
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
