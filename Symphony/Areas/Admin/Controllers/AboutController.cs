using Microsoft.AspNetCore.Mvc;

namespace Symphony.Areas.Admin.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
