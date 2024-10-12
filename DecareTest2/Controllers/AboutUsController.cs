using Microsoft.AspNetCore.Mvc;

namespace DecareCenter.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
