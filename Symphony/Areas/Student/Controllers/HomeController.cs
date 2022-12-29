using Microsoft.AspNetCore.Mvc;
using Symphony.Areas.Admin.Models;
using System.Text.Json;

namespace Symphony.Areas.Student.Controllers
{
    [Area("student")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HttpClient httpClient = new HttpClient();
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Course/GetAllCourses").Result;
            var data = res.Content.ReadAsStringAsync().Result;
            CourseListApi result = JsonSerializer.Deserialize<CourseListApi>(data);
            if(result.Status)
            {
                return View(result.Data);
            }
            return View(new List<CourseListApi>());
        }
    }
}
