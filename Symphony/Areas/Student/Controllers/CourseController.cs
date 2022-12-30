using Microsoft.AspNetCore.Mvc;
using Symphony.Areas.Admin.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Symphony.Areas.Student.Controllers
{
    [Area("student")]
    public class CourseController : Controller
    {
        private const string _tokenName = "token";
        public IActionResult Index()
        {
            HttpClient httpClient = new HttpClient();
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Course/GetAllCourses").Result;
            var data = res.Content.ReadAsStringAsync().Result;
            CourseListApi result = JsonSerializer.Deserialize<CourseListApi>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return View(new List<CourseListApi>());
        }

        public IActionResult Detail(string id)
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
    }
}
