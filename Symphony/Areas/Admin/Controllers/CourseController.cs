using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Symphony.Areas.Admin.Models;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Symphony.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class CourseController : Controller
    {
        private const string _tokenName = "token";
        public IActionResult Index()
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Course/GetAllCourses").Result;
            var data = res.Content.ReadAsStringAsync().Result;
            CourseListApi result = JsonSerializer.Deserialize<CourseListApi>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return View(new List<CourseModel>());
        }
        public IActionResult Details(string id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Course/GetCourse?id=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            CourseApi result = JsonSerializer.Deserialize<CourseApi>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CourseModel model)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var res = httpClient.PostAsync(Program.ApiAddress + "api/Course/CreateCourse", stringContent).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            CourseApi result = JsonSerializer.Deserialize<CourseApi>(data);
            if (result.Status)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Update(string id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Course/GetCourse?id=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            CourseApi result = JsonSerializer.Deserialize<CourseApi>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(CourseModel model)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var res = httpClient.PostAsync(Program.ApiAddress + "api/Course/UpdateCourse", stringContent).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            CourseApi result = JsonSerializer.Deserialize<CourseApi>(data);
            if (result.Status)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(string id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.DeleteAsync(Program.ApiAddress + "api/Course/DeleteCourse?id=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            CourseApi result = JsonSerializer.Deserialize<CourseApi>(data);
            if (result.Status)
            {
                return RedirectToAction("Index");
            }
            TempData["err"] = result.Message;
            return RedirectToAction("Index");
        }
    }
}
