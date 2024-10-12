using DecareCenter.Data;
using DecareCenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DecareCenter.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly AppDbContext db;

        public AppointmentsController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View(db.Appointments.ToList());
        }
        public IActionResult Create()
        {
            
            ViewBag.getCenter = db.Centers.Find(1);
            ViewBag.getServices = new SelectList(db.Services.Where(x=> x.CenterId == 1) , "ServiceId", "ServiceName");
            ViewBag.getDoctors = new SelectList(db.Doctors.Where(x => x.CenterId == 1), "DoctorId", "Name");
            ViewBag.getCenterId = new SelectList(db.Centers, "CenterId", "CenterName");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Add(appointment);
                await db.SaveChangesAsync();
                TempData["AlertMessage"] = "Your Appointment Booked Successfuly";
                return RedirectToAction(nameof(Create));
            }
            ViewBag.getCenterId = new SelectList(db.Centers, "CenterId", "CenterName", appointment.CenterId);
            return View(appointment);
        }

    }
}
