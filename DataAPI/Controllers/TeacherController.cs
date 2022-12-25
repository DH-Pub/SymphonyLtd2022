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
    public class TeacherController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddTeacher(Teacher teacher)
        {
            ResultInfo resultInfo = new ResultInfo { Status = false, Message = "Can not add new teacher!"};
            var addTeacherResult = TeacherDB.Instance.AddTeacher(teacher);
            if (!addTeacherResult)
            {
                return Ok(resultInfo);
            }
            resultInfo.Status = true;
            resultInfo.Message = "Add new teacher successfully!";
            resultInfo.Data = teacher;
            return Ok(resultInfo);
        }

        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            ResultInfo resultInfo = new ResultInfo { Status = false, Message = "Can not get information of any teacher!" };
            var allTeachersResult = TeacherDB.Instance.GetAllTeachers();
            if (allTeachersResult == null) return Ok(resultInfo);
            resultInfo.Status = true;
            resultInfo.Message = "Get information of all teachers successfully!";
            resultInfo.Data = allTeachersResult;
            return Ok(resultInfo);
        }

        [HttpPost]
        public IActionResult GetTeacherById(TeacherId teacher)
        {
            ResultInfo resultInfo = new ResultInfo { Status = false, Message = "Can not get information of this teacher!" };
            var getTeacherByIdResult = TeacherDB.Instance.GetTeacherById(teacher.Id);
            if(getTeacherByIdResult == null) return Ok(resultInfo);
            resultInfo.Status = true;
            resultInfo.Message = "Get information of this teacher successfully!";
            resultInfo.Data = getTeacherByIdResult;
            return Ok(resultInfo);
        }

        [HttpPost] 
        public IActionResult DeleteTeacher(TeacherId teacher)
        {
            ResultInfo resultInfo = new ResultInfo { Status = false, Message = "Can not delete this teacher!" };
            var deleteTeacherResult = TeacherDB.Instance.DeleteTeacher(teacher.Id);
            if (!deleteTeacherResult) return Ok(resultInfo);
            resultInfo.Status = true;
            resultInfo.Message = "Delete this teacher successfully!";
            resultInfo.Data = new
            {
                deletedTeacherId = teacher.Id
            };
            return Ok(resultInfo);
        }

        [HttpPost]
        public IActionResult UpdateTeacher(Teacher teacher)
        {
            ResultInfo resultInfo = new ResultInfo { Status = false, Message = "Can not update this teacher!" };
            var updateTeacherResult = TeacherDB.Instance.UpdateTeacher(teacher);
            if (!updateTeacherResult) return Ok(resultInfo);
            resultInfo.Status = true;
            resultInfo.Message = "Update this teacher successfully!";
            resultInfo.Data = teacher;
            return Ok(resultInfo);
        }
    }
}
