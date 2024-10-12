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
    [Authorize(Roles = "Admin")]
    public class CentersController : Controller
    {
        private readonly AppDbContext _context;

        public CentersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Dashboard/Centers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Centers.ToListAsync());
        }

        // GET: Dashboard/Centers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var center = await _context.Centers
                .FirstOrDefaultAsync(m => m.CenterId == id);
            if (center == null)
            {
                return NotFound();
            }

            return View(center);
        }

        // GET: Dashboard/Centers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Centers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Center center)
        {
            if (ModelState.IsValid)
            {
                if (center.ImageFile != null && center.ImageFile.Length > 0)
                {
                    // Define the path to save the image
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    var fileName = Path.GetFileName(center.ImageFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    // Ensure the uploads folder exists
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Save the file to the server
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await center.ImageFile.CopyToAsync(fileStream);
                    }

                    // Set the image path in the model (you may want to adjust this based on your requirements)
                    center.Image = $"/images/{fileName}";

                    _context.Add(center);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(center);
        }

        // GET: Dashboard/Centers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var center = await _context.Centers.FindAsync(id);
            if (center == null)
            {
                return NotFound();
            }
            return View(center);
        }

        // POST: Dashboard/Centers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Center center)
        {
            if (id != center.CenterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (center.ImageFile != null && center.ImageFile.Length > 0)
                    {
                        // Define the path to save the image
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                        var fileName = Path.GetFileName(center.ImageFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);

                        // Ensure the uploads folder exists
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        // Save the file to the server
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await center.ImageFile.CopyToAsync(fileStream);
                        }

                        // Update the image path in the model
                        center.Image = $"/images/{fileName}";
                    }
                    else
                    {
                        // If no new file is uploaded, retain the existing image path
                        var existingCategory = await _context.Centers.FindAsync(id);
                        center.Image = existingCategory.Image;
                    }
                    _context.Update(center);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CenterExists(center.CenterId))
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
            return View(center);
        }

        // GET: Dashboard/Centers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var center = await _context.Centers
                .FirstOrDefaultAsync(m => m.CenterId == id);
            if (center == null)
            {
                return NotFound();
            }

            return View(center);
        }

        // POST: Dashboard/Centers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var center = await _context.Centers.FindAsync(id);
            if (center != null)
            {
                _context.Centers.Remove(center);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CenterExists(int id)
        {
            return _context.Centers.Any(e => e.CenterId == id);
        }
    }
}
