using DecareCenter.Data;
using Microsoft.AspNetCore.Mvc;

namespace DecareCenter.Models.ViewComponents
{
    public class NavViewComponent : ViewComponent
    {
        private AppDbContext db;
        public NavViewComponent(AppDbContext _db)
        {
            db = _db;

        }
        public IViewComponentResult Invoke()
        {
            var center = db.Centers.Find(1);
            ViewBag.getServices = db.Services.Where(x=>x.CenterId == 1);
            return View(center);
        }
    }
}
