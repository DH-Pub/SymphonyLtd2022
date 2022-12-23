using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAPI.Data.Models;
using DataAPI.Data.Access;
using DataAPI.Models;

namespace DataAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAbout(int Number)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = true;
            var about = AboutDB.Instance.GetAboutByNumber(Number);
            resultInfo.Data = new
            {
                Number = about.Number,
                Description = about.Description,


            };
            return Ok(resultInfo);
        }
        [HttpGet]
        public IActionResult ShowAbouts(string search)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = true;
            var abouts = AboutDB.Instance.GetAllAbouts(search);
            resultInfo.Data = abouts.Select(a => new { a.Number, a.Description }).ToList(); // don't return password
            return Ok(resultInfo);
        }
        [HttpPost]
        public IActionResult CreateAbout(About Model)
        {
            ResultInfo resultInfo = new ResultInfo();
            var kqua = AboutDB.Instance.CreateAbout(Model);
            if (!kqua)
            {
                resultInfo.Status = false;
                resultInfo.Message = "That bai";
                return Ok(resultInfo);
            }
            resultInfo.Status = true;
            resultInfo.Message = "Thanh cong";
            resultInfo.Data = Model;
            return Ok(resultInfo);

        }

        [HttpPost]
        public IActionResult UpdateAboutDetails(About aboutUpdate)
        {
            ResultInfo resultInfo = new ResultInfo();


            resultInfo.Status = AboutDB.Instance.UpdateAboutDetails(aboutUpdate);
            return Ok(resultInfo);
        }


        [HttpDelete]
        public IActionResult DeleteAbout(int Number)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = AboutDB.Instance.DeleteAbout(Number);
            return Ok(resultInfo);
        }

    }
}
