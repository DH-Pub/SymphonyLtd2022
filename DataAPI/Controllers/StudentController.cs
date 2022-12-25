using DataAPI.Data.Access;
using DataAPI.Data.Models;
using DataAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace DataAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
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

            // getting full path inside wwwroot/images
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", FileName);

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
        [AllowAnonymous]
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
            foreach (var student in getAllStudentsResult)
            {
                student.Image = Program.ApiAddress + "/images/" + student.Image;
            }
            resultInfo.Data = getAllStudentsResult;
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
            getStudentResult.Image = Program.ApiAddress + "/images/" + getStudentResult.Image;
            resultInfo.Data = getStudentResult;
            return Ok(resultInfo);
        }
        [HttpPost]
        public IActionResult UpdateStudent([FromForm] Student student)
        {
            ResultInfo resultInfo = new ResultInfo();
            var updateStudentResult = StudentDB.Instance.UpdateStudent(student);
            if (!updateStudentResult)
            {
                resultInfo.Message = "Can not update information for this student!";
                return Ok(resultInfo);
            }
            if (student.Image == null) { 
                student.ImageName = "";
            }
            else
            {
                // getting file original name
                string FileName = student.Image.FileName;

                // getting full path inside wwwroot/images
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", FileName);

                // copying file
                student.Image.CopyTo(new FileStream(imagePath, FileMode.Create));
            }
            resultInfo.Status = true;
            resultInfo.Message = "Update information successfully!";
            resultInfo.Data = new
            {
                RollNumber = student.RollNumber,
                FullName = student.FullName,
                Email = student.Email,
                Phone = student.Phone,
                Gender = student.Gender,
                BirthDate = student.BirthDate,
                Image = student.ImageName
            }; 
            return Ok(resultInfo);
        }
    }
}
