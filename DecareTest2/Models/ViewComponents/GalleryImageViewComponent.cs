using DecareCenter.Data;
using Microsoft.AspNetCore.Mvc;

namespace DecareCenter.Models.ViewComponents
{
    public class GalleryImageViewComponent : ViewComponent
    {
        private AppDbContext db;
        public GalleryImageViewComponent(AppDbContext _db)
        {
            db = _db;

        }
        public IViewComponentResult Invoke()
        {
            return View(db.GalleryImages.ToList());
        }
    }
}
