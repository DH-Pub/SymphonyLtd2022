using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Symphony.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class CentreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
    }
}
