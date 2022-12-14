using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using Symphony.Areas.Admin.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Symphony.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Main")]
    public class AdminController : Controller
    {
        private const string _tokenName = "token";
        public IActionResult Index(string search = "")
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(new { Search = search }), Encoding.UTF8, "application/json");
            var res = httpClient.PostAsync(Program.ApiAddress + "api/Admin/ShowAdmins", stringContent).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            AdminListApiShow result = JsonSerializer.Deserialize<AdminListApiShow>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return View(new AdminShowModel());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AdminCreateModel admin)
        {
            if (admin.Password != admin.ConfirmPassword)
            {
                return View(admin);
            }
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var post = new
            {
                Name = admin.Name,
                Email = admin.Email,
                Password = admin.Password,
                Role = admin.Role,
                Details = admin.Details
            };
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(post), Encoding.UTF8, "application/json");
            var res = httpClient.PostAsync(Program.ApiAddress + "api/Admin/CreateAdmin", stringContent).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            AdminListApiShow result = JsonSerializer.Deserialize<AdminListApiShow>(data);
            if (result.Status)
            {
                return RedirectToAction("Index");
            }
            return View(admin);
        }
        public IActionResult Update(long id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Admin/GetAdmin?id=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            AdminApiShow result = JsonSerializer.Deserialize<AdminApiShow>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return RedirectToAction("Index");
        }
    }
}
