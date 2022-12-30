using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Symphony.Areas.Admin.Models;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Symphony.Areas.Student.Controllers
{
    [Area("student")]
    public class CourseDetailController : Controller
    {
        private const string _tokenName = "token";
        public IActionResult Index(string id)
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
            return RedirectToAction("Home/Index");
        }
    }
}
