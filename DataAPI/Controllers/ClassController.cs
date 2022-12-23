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
    public class ClassController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetClass(string id)
        {
            ResultInfo resultInfo = new ResultInfo { Status = true };
            resultInfo.Data = ClassDB.Instance.GetClassById(id);
            return Ok(resultInfo);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllClasses()
        {
            ResultInfo resultInfo = new ResultInfo { Status = true };
            resultInfo.Data = ClassDB.Instance.GetAllClasses();
            return Ok(resultInfo);
        }
        [HttpPost]
        public IActionResult CreateClass(Class model)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = ClassDB.Instance.CreateClass(model);
            return Ok(resultInfo);
        }
        [HttpPost]
        public IActionResult UpdateClass(Class model)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = ClassDB.Instance.UpdateClass(model);
            return Ok(resultInfo);
        }
        [HttpDelete]
        public IActionResult DeleteClass(string id)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = ClassDB.Instance.DeleteClass(id);
            return Ok(resultInfo);
        }

        // For ClassDetails -------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult GetClassDetail(long id)
        {
            ResultInfo resultInfo = new ResultInfo { Status = true };
            resultInfo.Data = ClassDB.Instance.GetClassDetailById(id);
            return Ok(resultInfo);
        }
        [HttpGet]
        public IActionResult GetAllClassDetails()
        {
            ResultInfo resultInfo = new ResultInfo { Status = true };
            resultInfo.Data = ClassDB.Instance.GetAllClassDetails();
            return Ok(resultInfo);
        }
        [HttpPost]
        public IActionResult CreateClassDetail(ClassDetail classDetail)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = ClassDB.Instance.CreateClassDetail(classDetail);
            return Ok(resultInfo);
        }
        [HttpPost]
        public IActionResult UpdateClassDetail(ClassDetail classDetail)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = ClassDB.Instance.UpdateClassDetail(classDetail);
            return Ok(resultInfo);
        }
        [HttpDelete]
        public IActionResult DeleteCLassDetail(long id)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = ClassDB.Instance.DeleteClassDetail(id);
            return Ok(resultInfo);
        }
    }
}
