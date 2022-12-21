using DataAPI.Data.Access;
using DataAPI.Data.Models;
using DataAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace DataAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController : Controller
    {
        [HttpPost]
        public IActionResult AddStudent([FromForm] Student model)
        {
            ResultInfo resultInfo = new ResultInfo();
            model.ImageName = model.Image.FileName;
            var createNewStudentResult = StudentDB.Instance.AddStudent(model);
            if (!createNewStudentResult)
            {
                resultInfo.Message = "Can not add a new student!";
                return Ok(resultInfo);
            }
            // getting file original name
            string FileName = model.Image.FileName;

            // combining GUID to create unique name before saving in wwwroot
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + FileName;

            // getting full path inside wwwroot/images
            var imagePath = Path.Combine(Directory.GetCurrentDirectory().Replace("DataAPI", "Symphony"), "wwwroot/images/", FileName);

            // copying file
            model.Image.CopyTo(new FileStream(imagePath, FileMode.Create));
            resultInfo.Status = true;
            resultInfo.Message = "A student is added!";
            resultInfo.Data = new
            {
                RollNumber = model.RollNumber,
                FullName = model.FullName,
                Email = model.Email,
                Phone = model.Phone,
                Gender = model.Gender,
                BirthDate = model.BirthDate,
                Image = model.ImageName
            };
            return Ok(resultInfo);
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            ResultInfo resultInfo = new ResultInfo();
            var getAllStudentsResult = StudentDB.Instance.GetAllStudents();
            if(getAllStudentsResult == null)
            {
                resultInfo.Message = "Can not get all students!";
                return Ok(resultInfo);
            }
            resultInfo.Status = true;
            resultInfo.Message = "Get all students successfully!";
            resultInfo.Data = getAllStudentsResult.ToList();
            return Ok(resultInfo);
        }

        [HttpPost]
        public IActionResult DeleteStudent(StudentToDelete student)
        {
            ResultInfo resultInfo = new ResultInfo();
            var deleteStudentResult = StudentDB.Instance.DeleteStudent(student.RollNumber);
            if(!deleteStudentResult)
            {
                resultInfo.Message = "Can not delete this student!";
                return Ok(resultInfo);
            }
            resultInfo.Status = true;
            resultInfo.Message = "This student is deleted!";
            resultInfo.Data = new
            {
                DeletedStudent = student.RollNumber
            };
            return Ok(resultInfo);
        }
        [HttpPost]
        public IActionResult GetStudentByRollNo(StudentToDelete student)
        {
            ResultInfo resultInfo = new ResultInfo();
            var getStudentResult = StudentDB.Instance.GetStudentByRollNo(student.RollNumber);
            if(getStudentResult == null)
            {
                resultInfo.Message = "Can not get this student!";
                return Ok(resultInfo);
            }
            resultInfo.Status = true;
            resultInfo.Message = "Get this student successfully!";
            resultInfo.Data = getStudentResult;
            return Ok(resultInfo);
        }
    }
}
