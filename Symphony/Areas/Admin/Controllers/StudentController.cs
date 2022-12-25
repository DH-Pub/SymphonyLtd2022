using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Symphony.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class StudentController : Controller
    {
        private const string _tokenName = "token";
        public IActionResult Index()
        {
            string token = Request.Cookies[_tokenName];
            ViewBag.Token = token;
            return View(ViewBag);
        }

        public IActionResult Create()
        {
            string token = Request.Cookies[_tokenName];
            ViewBag.Token = token;
            return View(ViewBag);
        }
        public IActionResult Detail()
        {
            string token = Request.Cookies[_tokenName];
            ViewBag.Token = token;
            return View(ViewBag);
        }
        public IActionResult Update()
        {
            string token = Request.Cookies[_tokenName];
            ViewBag.Token = token;
            return View(ViewBag);
        }
    }
}
