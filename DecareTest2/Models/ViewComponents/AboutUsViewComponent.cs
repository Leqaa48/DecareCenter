using DecareCenter.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace DecareCenter.Models.ViewComponents
{
    public class AboutUsViewComponent : ViewComponent
    {
        private AppDbContext db;
        public AboutUsViewComponent(AppDbContext _db)
        {
            db = _db;

        }
        public IViewComponentResult Invoke()
        {
            var getYearsOfExperience = db.Centers.Find(1).YearsOfExperience;
            ViewBag.GetYearsOfExperience = getYearsOfExperience;
            return View(db.AboutUs.ToList());
        }

    }
}
