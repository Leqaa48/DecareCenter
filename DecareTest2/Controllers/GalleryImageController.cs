using Microsoft.AspNetCore.Mvc;

namespace DecareCenter.Controllers
{
    public class GalleryImageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
