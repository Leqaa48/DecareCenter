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
    public class GalleryImagesController : Controller
    {
        private readonly AppDbContext _context;

        public GalleryImagesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Dashboard/GalleryImages
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.GalleryImages.Include(g => g.Center);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Dashboard/GalleryImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galleryImage = await _context.GalleryImages
                .Include(g => g.Center)
                .FirstOrDefaultAsync(m => m.GalleryImageId == id);
            if (galleryImage == null)
            {
                return NotFound();
            }

            return View(galleryImage);
        }

        // GET: Dashboard/GalleryImages/Create
        public IActionResult Create()
        {
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterName");
            return View();
        }

        // POST: Dashboard/GalleryImages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GalleryImage galleryImage)
        {
            if (ModelState.IsValid)
            {
                if (galleryImage.ImageFile != null && galleryImage.ImageFile.Length > 0)
                {
                    // Define the path to save the image
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    var fileName = Path.GetFileName(galleryImage.ImageFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    // Ensure the uploads folder exists
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Save the file to the server
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await galleryImage.ImageFile.CopyToAsync(fileStream);
                    }

                    // Set the image path in the model (you may want to adjust this based on your requirements)
                    galleryImage.Image = $"/images/{fileName}";

                    _context.Add(galleryImage);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterName", galleryImage.CenterId);
            return View(galleryImage);
        }

        // GET: Dashboard/GalleryImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galleryImage = await _context.GalleryImages.FindAsync(id);
            if (galleryImage == null)
            {
                return NotFound();
            }
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterName", galleryImage.CenterId);
            return View(galleryImage);
        }

        // POST: Dashboard/GalleryImages/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GalleryImage galleryImage)
        {
            if (id != galleryImage.GalleryImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (galleryImage.ImageFile != null && galleryImage.ImageFile.Length > 0)
                    {
                        // Define the path to save the image
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                        var fileName = Path.GetFileName(galleryImage.ImageFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);

                        // Ensure the uploads folder exists
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        // Save the file to the server
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await galleryImage.ImageFile.CopyToAsync(fileStream);
                        }

                        // Update the image path in the model
                        galleryImage.Image = $"/images/{fileName}";
                    }
                    else
                    {
                        // If no new file is uploaded, retain the existing image path
                        var existingCategory = await _context.GalleryImages.FindAsync(id);
                        galleryImage.Image = existingCategory.Image;
                    }
                    _context.Update(galleryImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GalleryImageExists(galleryImage.GalleryImageId))
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
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterName", galleryImage.CenterId);
            return View(galleryImage);
        }

        // GET: Dashboard/GalleryImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galleryImage = await _context.GalleryImages
                .Include(g => g.Center)
                .FirstOrDefaultAsync(m => m.GalleryImageId == id);
            if (galleryImage == null)
            {
                return NotFound();
            }

            return View(galleryImage);
        }

        // POST: Dashboard/GalleryImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var galleryImage = await _context.GalleryImages.FindAsync(id);
            if (galleryImage != null)
            {
                _context.GalleryImages.Remove(galleryImage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GalleryImageExists(int id)
        {
            return _context.GalleryImages.Any(e => e.GalleryImageId == id);
        }
    }
}
