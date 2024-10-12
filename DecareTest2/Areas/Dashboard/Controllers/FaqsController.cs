using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DecareCenter.Data;
using DecareCenter.Models;
using Microsoft.AspNetCore.Authorization;
using System.Numerics;

namespace DecareCenter.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class FaqsController : Controller
    {
        private readonly AppDbContext _context;

        public FaqsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Dashboard/Faqs
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Faq.Include(f => f.Center);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Dashboard/Faqs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = await _context.Faq
                .Include(f => f.Center)
                .FirstOrDefaultAsync(m => m.FaqId == id);
            if (faq == null)
            {
                return NotFound();
            }

            return View(faq);
        }

        // GET: Dashboard/Faqs/Create
        public IActionResult Create()
        {
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterName");
            return View();
        }

        // POST: Dashboard/Faqs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FaqId,Question,Answer,CenterId,IsActive,IsDeleted")] Faq faq)
        {
            if (ModelState.IsValid)
            {
                

                    _context.Add(faq);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                
            }
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterName", faq.CenterId);
            return View(faq);
        }

        // GET: Dashboard/Faqs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = await _context.Faq.FindAsync(id);
            if (faq == null)
            {
                return NotFound();
            }
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterName", faq.CenterId);
            return View(faq);
        }

        // POST: Dashboard/Faqs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FaqId,Question,Answer,CenterId,IsActive,IsDeleted")] Faq faq)
        {
            if (id != faq.FaqId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faq);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaqExists(faq.FaqId))
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
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterName", faq.CenterId);
            return View(faq);
        }

        // GET: Dashboard/Faqs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = await _context.Faq
                .Include(f => f.Center)
                .FirstOrDefaultAsync(m => m.FaqId == id);
            if (faq == null)
            {
                return NotFound();
            }

            return View(faq);
        }

        // POST: Dashboard/Faqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faq = await _context.Faq.FindAsync(id);
            if (faq != null)
            {
                _context.Faq.Remove(faq);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaqExists(int id)
        {
            return _context.Faq.Any(e => e.FaqId == id);
        }
    }
}
