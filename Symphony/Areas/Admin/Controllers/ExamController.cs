using Microsoft.AspNetCore.Mvc;
using Symphony.Areas.Admin.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Symphony.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ExamController : Controller
    {
        private const string _tokenName = "token";
        public IActionResult Index()
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Exam/GetAllExams").Result;
            var data = res.Content.ReadAsStringAsync().Result;
            ExamCourseListApi result = JsonSerializer.Deserialize<ExamCourseListApi>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return View(new List<ExamCourseModel>());
        }
        public IActionResult Details(string id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Exam/GetExam?id=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            ExamCourseApi result = JsonSerializer.Deserialize<ExamCourseApi>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return View(new ExamCourseModel());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ExamModel model)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var post = new
            {
                Id = model.Id,
                CourseId = model.CourseId,
                Date = model.Date,
                Details = model.Details,
                Fee = model.Fee
            };
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var res = httpClient.PostAsync(Program.ApiAddress + "api/Exam/CreateExam", stringContent).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            ExamCourseApi result = JsonSerializer.Deserialize<ExamCourseApi>(data);
            if (result.Status)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
