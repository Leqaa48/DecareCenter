using DecareCenter.Data;
using Microsoft.AspNetCore.Mvc;

namespace DecareCenter.Controllers
{
    public class FaqController : Controller
    {
        private AppDbContext db;
        public FaqController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View(db.Faq.ToList());
        }
    }
}
