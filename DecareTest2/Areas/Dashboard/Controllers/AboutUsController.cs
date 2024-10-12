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

namespace DecareCenter.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize (Roles ="Admin")]
    public class AboutUsController : Controller
    {
        private readonly AppDbContext _context;

        public AboutUsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Dashboard/AboutUs
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.AboutUs.Include(a => a.Center);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Dashboard/AboutUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutUs = await _context.AboutUs
                .Include(a => a.Center)
                .FirstOrDefaultAsync(m => m.AboutUsId == id);
            if (aboutUs == null)
            {
                return NotFound();
            }

            return View(aboutUs);
        }

        // GET: Dashboard/AboutUs/Create
        public IActionResult Create()
        {
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterName");
            return View();
        }
        
        // POST: Dashboard/AboutUs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( AboutUs aboutUs)
        {
            if (ModelState.IsValid)
            {
                if (aboutUs.ImageFile != null && aboutUs.ImageFile.Length > 0)
                {
                    // Define the path to save the image
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    var fileName = Path.GetFileName(aboutUs.ImageFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    // Ensure the uploads folder exists
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Save the file to the server
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await aboutUs.ImageFile.CopyToAsync(fileStream);
                    }

                    // Set the image path in the model (you may want to adjust this based on your requirements)
                    aboutUs.Image = $"/images/{fileName}";

                    _context.Add(aboutUs);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                
            }
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterName", aboutUs.CenterId);
            return View(aboutUs);
        }

        // GET: Dashboard/AboutUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutUs = await _context.AboutUs.FindAsync(id);
            if (aboutUs == null)
            {
                return NotFound();
            }
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterName", aboutUs.CenterId);
            return View(aboutUs);
        }
        
        // POST: Dashboard/AboutUs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AboutUs aboutUs)
        {
            if (id != aboutUs.AboutUsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (aboutUs.ImageFile != null && aboutUs.ImageFile.Length > 0)
                    {
                        // Define the path to save the image
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                        var fileName = Path.GetFileName(aboutUs.ImageFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);

                        // Ensure the uploads folder exists
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        // Save the file to the server
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await aboutUs.ImageFile.CopyToAsync(fileStream);
                        }

                        // Update the image path in the model
                        aboutUs.Image = $"/images/{fileName}";
                    }
                    else
                    {
                        // If no new file is uploaded, retain the existing image path
                        var existingCategory = await _context.AboutUs.FindAsync(id);
                        aboutUs.Image = existingCategory.Image;
                    }
                    _context.Update(aboutUs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutUsExists(aboutUs.AboutUsId))
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
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterName", aboutUs.CenterId);
            return View(aboutUs);
        }

        // GET: Dashboard/AboutUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutUs = await _context.AboutUs
                .Include(a => a.Center)
                .FirstOrDefaultAsync(m => m.AboutUsId == id);
            if (aboutUs == null)
            {
                return NotFound();
            }

            return View(aboutUs);
        }

        // POST: Dashboard/AboutUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aboutUs = await _context.AboutUs.FindAsync(id);
            if (aboutUs != null)
            {
                _context.AboutUs.Remove(aboutUs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutUsExists(int id)
        {
            return _context.AboutUs.Any(e => e.AboutUsId == id);
        }
    }
}
