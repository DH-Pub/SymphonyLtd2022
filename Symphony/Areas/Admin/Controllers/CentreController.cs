using Microsoft.AspNetCore.Mvc;

namespace Symphony.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CentreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
