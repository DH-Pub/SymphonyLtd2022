using Microsoft.AspNetCore.Mvc;
using Symphony.Areas.Admin.Models;
using Symphony.Areas.Student.Models;
using System.Text.Json;

namespace Symphony.Areas.Student.Controllers
{
    [Area("student")]
    public class ExamController : Controller
    {
        public IActionResult Index()
        {
            HttpClient httpClient = new HttpClient();
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Exam/GetAllExams").Result;
            var data = res.Content.ReadAsStringAsync().Result;
            ExamCourseListApi result = JsonSerializer.Deserialize<ExamCourseListApi>(data);
            if (result.Status)
            {
                DateTime today = DateTime.Today;
                // get exams that has upcoming date after current date
                List<ExamCourseModel> upcomingExams = result.Data.Where(e => e.Date >= today).OrderBy(e => e.Date).ToList();
                return View(upcomingExams);
            }
            return View(new List<ExamCourseModel>());
        }
        public IActionResult Result(string? rollNumber = "")
        {
            if (string.IsNullOrWhiteSpace(rollNumber))
            {
                return View(new List<ExamResult>());
            }
            HttpClient httpClient = new HttpClient();
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Exam/GetExamResults?rollNumber=" + rollNumber).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            ExamResultListApi result = JsonSerializer.Deserialize<ExamResultListApi>(data);
            if (result.Status && result.Data.Count > 0)
            {
                DateTime today = DateTime.Today;
                List<ExamResult> examResults = result.Data.Where(r => r.Mark != null && r.ExamDate <= today).OrderBy(r => r.ExamDate).ToList();
                return View(examResults);
            }
            TempData["err"] = "There is no such roll number";
            return View(new List<ExamResult>());
        }
    }
}
