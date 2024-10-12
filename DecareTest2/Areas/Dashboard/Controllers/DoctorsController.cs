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
    public class DoctorsController : Controller
    {
        private readonly AppDbContext _context;

        public DoctorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Dashboard/Doctors
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Doctors.Include(d => d.Center);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Dashboard/Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .Include(d => d.Center)
                .FirstOrDefaultAsync(m => m.DoctorId == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Dashboard/Doctors/Create
        public IActionResult Create()
        {
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterName");
            return View();
        }

        // POST: Dashboard/Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                if (doctor.ImageFile != null && doctor.ImageFile.Length > 0)
                {
                    // Define the path to save the image
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    var fileName = Path.GetFileName(doctor.ImageFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    // Ensure the uploads folder exists
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Save the file to the server
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await doctor.ImageFile.CopyToAsync(fileStream);
                    }

                    // Set the image path in the model (you may want to adjust this based on your requirements)
                    doctor.DoctorImage = $"/images/{fileName}";

                    _context.Add(doctor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterName", doctor.CenterId);
            return View(doctor);
        }

        // GET: Dashboard/Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterName", doctor.CenterId);
            return View(doctor);
        }

        // POST: Dashboard/Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Doctor doctor)
        {
            if (id != doctor.DoctorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (doctor.ImageFile != null && doctor.ImageFile.Length > 0)
                    {
                        // Define the path to save the image
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                        var fileName = Path.GetFileName(doctor.ImageFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);

                        // Ensure the uploads folder exists
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        // Save the file to the server
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await doctor.ImageFile.CopyToAsync(fileStream);
                        }

                        // Update the image path in the model
                        doctor.DoctorImage = $"/images/{fileName}";
                    }
                    else
                    {
                        // If no new file is uploaded, retain the existing image path
                        var existingCategory = await _context.Doctors.FindAsync(id);
                        doctor.DoctorImage = existingCategory.DoctorImage;
                    }
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.DoctorId))
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
            ViewData["CenterId"] = new SelectList(_context.Centers, "CenterId", "CenterName", doctor.CenterId);
            return View(doctor);
        }

        // GET: Dashboard/Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .Include(d => d.Center)
                .FirstOrDefaultAsync(m => m.DoctorId == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Dashboard/Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.DoctorId == id);
        }
    }
}
