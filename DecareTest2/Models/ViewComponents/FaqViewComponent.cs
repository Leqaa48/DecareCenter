using DecareCenter.Data;
using Microsoft.AspNetCore.Mvc;

namespace DecareCenter.Models.ViewComponents
{
    public class FaqViewComponent : ViewComponent
    {
        private AppDbContext db;
        public FaqViewComponent(AppDbContext _db)
        {
            db = _db;

        }
        public IViewComponentResult Invoke()
        {

            return View(db.Faq.Where(x=>x.FaqId>4).ToList());
        }
    }
}
