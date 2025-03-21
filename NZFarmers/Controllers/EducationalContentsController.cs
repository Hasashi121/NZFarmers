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
    public class EducationalContentsController : Controller
    {
        private readonly NZFarmersContext _context;

        public EducationalContentsController(NZFarmersContext context)
        {
            _context = context;
        }

        // GET: EducationalContents
        public async Task<IActionResult> Index()
        {
            return View(await _context.EducationalContents.ToListAsync());
        }

        // GET: EducationalContents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationalContent = await _context.EducationalContents
                .FirstOrDefaultAsync(m => m.ContentID == id);
            if (educationalContent == null)
            {
                return NotFound();
            }

            return View(educationalContent);
        }

        // GET: EducationalContents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EducationalContents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContentID,Title,Description,ContentURL,CreatedAt")] EducationalContent educationalContent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educationalContent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(educationalContent);
        }

        // GET: EducationalContents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationalContent = await _context.EducationalContents.FindAsync(id);
            if (educationalContent == null)
            {
                return NotFound();
            }
            return View(educationalContent);
        }

        // POST: EducationalContents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContentID,Title,Description,ContentURL,CreatedAt")] EducationalContent educationalContent)
        {
            if (id != educationalContent.ContentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educationalContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationalContentExists(educationalContent.ContentID))
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
            return View(educationalContent);
        }

        // GET: EducationalContents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationalContent = await _context.EducationalContents
                .FirstOrDefaultAsync(m => m.ContentID == id);
            if (educationalContent == null)
            {
                return NotFound();
            }

            return View(educationalContent);
        }

        // POST: EducationalContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var educationalContent = await _context.EducationalContents.FindAsync(id);
            if (educationalContent != null)
            {
                _context.EducationalContents.Remove(educationalContent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationalContentExists(int id)
        {
            return _context.EducationalContents.Any(e => e.ContentID == id);
        }
    }
}
