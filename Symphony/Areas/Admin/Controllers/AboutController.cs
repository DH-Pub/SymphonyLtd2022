using Microsoft.AspNetCore.Mvc;
using Symphony.Areas.Admin.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Symphony.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AboutController : Controller
    {
        private const string _tokenName = "token";
        public IActionResult Index(string search = "")
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token); // send header token for api authentication
            string param = (string.IsNullOrWhiteSpace(search)) ? "" : "?search=";
            var res = httpClient.GetAsync(Program.ApiAddress + "api/About/ShowAbouts" + param + search).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            AboutListApiShow result = JsonSerializer.Deserialize<AboutListApiShow>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return View(new About());
        }
        public IActionResult Create()
        {
            return View();
        }

        // Create Post to Api
        [HttpPost]
        public IActionResult Create(About abt)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var post = new
            {
                Number = abt.Number,
                Description = abt.Description,
                
            };
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(post), Encoding.UTF8, "application/json");
            var res = httpClient.PostAsync(Program.ApiAddress + "api/About/CreateAbout", stringContent).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            AboutListApiShow result = JsonSerializer.Deserialize<AboutListApiShow>(data);
            if (result.Status)
            {
                return RedirectToAction("Index");
            }
            return View(abt);
        }

        // Details of FAQ
        public IActionResult Details(int id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.GetAsync(Program.ApiAddress + "api/About/GetAbout?id=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            AboutApiResult result = JsonSerializer.Deserialize<AboutApiResult>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return View(new About());
        }

        // Update View
        public IActionResult Update(int id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.GetAsync(Program.ApiAddress + "api/About/GetAbout?id=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            AboutApiResult result = JsonSerializer.Deserialize<AboutApiResult>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return RedirectToAction("Index");
        }

        //Update View Post
        [HttpPost]
        public IActionResult Update(About model)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var post = new
            {
                Number = model.Number,
                Description = model.Description,
                
            };
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(post), Encoding.UTF8, "application/json");
            var res = httpClient.PostAsync(Program.ApiAddress + "api/About/UpdateAboutDetails", stringContent).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            AboutListApiShow result = JsonSerializer.Deserialize<AboutListApiShow>(data);
            if (result.Status)
            {
                return RedirectToAction("Details", new { id = model.Number });
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.DeleteAsync(Program.ApiAddress + "api/About/DeleteAbout?number=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            AboutListApiShow result = JsonSerializer.Deserialize<AboutListApiShow>(data);
            if (result.Status)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
