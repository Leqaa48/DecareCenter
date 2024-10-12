using DecareCenter.Data;
using Microsoft.AspNetCore.Mvc;

namespace DecareCenter.Models.ViewComponents
{
    public class DoctorViewComponent :ViewComponent
    {
        private AppDbContext db;
        public DoctorViewComponent (AppDbContext _db)
        {
            db = _db;

        }
        public IViewComponentResult Invoke()
        {
            return View(db.Doctors.ToList());
        }
    }
}
