using DecareCenter.Data;
using Microsoft.AspNetCore.Mvc;

namespace DecareCenter.Controllers
{
    public class CenterController : Controller
    {
        private readonly AppDbContext _context;

        public CenterController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            var center = _context.Centers.Find(1);
            return View(center);
        }
    }
}
