using DataAPI.Data.Access;
using DataAPI.Data.Models;
using DataAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DataAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ExamController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetExam(string id)
        {
            ResultInfo resultInfo = new ResultInfo { Status = true };
            resultInfo.Data = ExamDB.Instance.GetExamById(id);
            return Ok(resultInfo);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllExams()
        {
            ResultInfo resultInfo = new ResultInfo { Status = true };
            resultInfo.Data = ExamDB.Instance.GetAllExamsWithCourses();
            return Ok(resultInfo);
        }
        [HttpPost]
        public IActionResult CreateExam(Exam exam)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = ExamDB.Instance.CreateExam(exam);
            return Ok(resultInfo);
        }
        [HttpPost]
        public IActionResult UpdateExam(Exam exam)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = ExamDB.Instance.UpdateExam(exam);
            return Ok(resultInfo);
        }
        [HttpDelete]
        public IActionResult DeleteExam(string id)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = ExamDB.Instance.DeleteExam(id);
            return Ok(resultInfo);
        }
    }
}
