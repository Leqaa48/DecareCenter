using DecareCenter.Data;
using Microsoft.AspNetCore.Mvc;

namespace DecareCenter.Models.ViewComponents
{
    public class ServiceViewComponent :ViewComponent
    {
        private AppDbContext db;
        public ServiceViewComponent (AppDbContext _db)
        {
            db = _db;

        }
        public IViewComponentResult Invoke()
        {
            return View(db.Services.ToList());
        }
    }
}
