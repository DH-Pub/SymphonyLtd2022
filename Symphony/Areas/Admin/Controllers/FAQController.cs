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
    public class FAQController : Controller
    {
        private const string _tokenName = "token";
        public IActionResult Index(string search = "")
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token); // send header token for api authentication
            string param = (string.IsNullOrWhiteSpace(search)) ? "" : "?search=";
            var res = httpClient.GetAsync(Program.ApiAddress + "api/FAQ/ShowFAQs" + param + search).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            FAQListApiShow result = JsonSerializer.Deserialize<FAQListApiShow>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return View(new FAQ());
        }

        // Create View
        public IActionResult Create()
        {
            return View();
        }

        // Create Post to Api
        [HttpPost]
        public IActionResult Create(FAQ faq)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var post = new
            {
                Number = faq.Number,
                Question = faq.Question,
                Answer = faq.Answer,
            };
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(post), Encoding.UTF8, "application/json");
            var res = httpClient.PostAsync(Program.ApiAddress + "api/FAQ/CreateFAQ", stringContent).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            FAQListApiShow result = JsonSerializer.Deserialize<FAQListApiShow>(data);
            if (result.Status)
            {
                return RedirectToAction("Index");
            }
            return View(faq);
        }


        // Details of FAQ
        public IActionResult Details(int id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.GetAsync(Program.ApiAddress + "api/FAQ/GetFAQ?id=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            FAQApiResult result = JsonSerializer.Deserialize<FAQApiResult>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return View(new FAQ());
        }



        // Update View
        public IActionResult Update(int id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.GetAsync(Program.ApiAddress + "api/FAQ/GetFAQ?id=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            FAQApiResult result = JsonSerializer.Deserialize<FAQApiResult>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return RedirectToAction("Index");
        }
        //Update View Post
        [HttpPost]
        public IActionResult Update(FAQ model)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var post = new
            {
                Number = model.Number,
                Question = model.Question,
                Answer = model.Answer,
            };
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(post), Encoding.UTF8, "application/json");
            var res = httpClient.PostAsync(Program.ApiAddress + "api/FAQ/UpdateFAQDetails", stringContent).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            FAQListApiShow result = JsonSerializer.Deserialize<FAQListApiShow>(data);
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
            var res = httpClient.DeleteAsync(Program.ApiAddress + "api/FAQ/DeleteFAQ?number=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            FAQListApiShow result = JsonSerializer.Deserialize<FAQListApiShow>(data);
            if (result.Status)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
