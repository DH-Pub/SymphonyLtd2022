using DataAPI.Data.Access;
using DataAPI.Data.Models;
using DataAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetCourse(string id)
        {
            ResultInfo resultInfo = new ResultInfo { Status = true };
            resultInfo.Data = CourseDB.Instance.GetCourse(id);
            return Ok(resultInfo);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllCourses()
        {
            ResultInfo resultInfo = new ResultInfo { Status = true };
            resultInfo.Data = CourseDB.Instance.GetAllCourses();
            return Ok(resultInfo);
        }
        [HttpPost]
        public IActionResult CreateCourse(Course course)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = CourseDB.Instance.CreateCourse(course);
            return Ok(resultInfo);
        }
        [HttpPost]
        public IActionResult UpdateCourse(Course course)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = CourseDB.Instance.UpdateCourse(course);
            return Ok(resultInfo);
        }
        [HttpDelete]
        public IActionResult DeleteCourse(string id)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = CourseDB.Instance.DeleteCourse(id);
            if (resultInfo.Status == false)
            {
                resultInfo.Message = "Unable to delete";
            }
            return Ok(resultInfo);
        }
    }
}
