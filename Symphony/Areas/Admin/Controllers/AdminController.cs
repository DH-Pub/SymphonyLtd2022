using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
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
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token); // send header token for api authentication
            string param = (string.IsNullOrWhiteSpace(search)) ? "" : "?search=";
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Admin/ShowAdmins" + param + search).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            AdminListApiShow result = JsonSerializer.Deserialize<AdminListApiShow>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return View(new AdminShowModel());
        }

        // Create View
        public IActionResult Create()
        {
            return View();
        }
        // Create Post to Api
        [HttpPost]
        public IActionResult Create(AdminCreateModel admin)
        {
            if (admin.Password != admin.ConfirmPassword)
            {
                ViewData["confirmPwd"] = "Password and Confirm Password are different";
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

        // Details of Admin
        public IActionResult Details(long id)
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
            return View(new AdminShowModel());
        }

        // Update View
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
        //Update View Post
        [HttpPost]
        public IActionResult Update(AdminShowModel model)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var post = new
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Role = model.Role,
                Details = model.Details
            };
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(post), Encoding.UTF8, "application/json");
            var res = httpClient.PostAsync(Program.ApiAddress + "api/Admin/UpdateAdminDetails", stringContent).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            AdminListApiShow result = JsonSerializer.Deserialize<AdminListApiShow>(data);
            if (result.Status)
            {
                return RedirectToAction("Details", new { id = model.Id });
            }
            return View(model);
        }

        public IActionResult Delete(long id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.DeleteAsync(Program.ApiAddress + "api/Admin/DeleteAdmin?id=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            AdminListApiShow result = JsonSerializer.Deserialize<AdminListApiShow>(data);
            if (result.Status)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult UpdatePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdatePassword(AdminPassUpdate admin)
        {
            var adminId = User.Claims.FirstOrDefault(a => a.Type == "id").Value;
            admin.Id = long.Parse(adminId);
            if (admin.NewPassword != admin.NewPasswordConfirm)
            {
                ViewData["err"] = "New password and confirm do not match";
                return View();
            }
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var post = new
            {
                Id = admin.Id,
                OldPassword = admin.OldPassword,
                NewPassword = admin.NewPassword
            };
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(post), Encoding.UTF8, "application/json");
            var res = httpClient.PostAsync(Program.ApiAddress + "api/Admin/UpdateAdminPassword", stringContent).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            AdminApiResult result = JsonSerializer.Deserialize<AdminApiResult>(data);
            if (result.Status)
            {
                return RedirectToAction("Index");
            }
            ViewData["err"] = result.Message;
            return View();
        }
    }
}
