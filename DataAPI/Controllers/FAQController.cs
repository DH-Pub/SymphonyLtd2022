using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAPI.Data.Models;
using DataAPI.Data.Access;
using DataAPI.Models;

namespace DataAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FAQController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetFAQ(int id)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = true;
            var faq = FAQDB.Instance.GetFAQByNumber(id);
            resultInfo.Data = new
            {
                Number = faq.Number,
                Question = faq.Question,
                Answer = faq.Answer,

            };
            return Ok(resultInfo);
        }
        [HttpGet]
        public IActionResult ShowFAQs(string search)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = true;
            var faqs = FAQDB.Instance.GetAllFAQs(search);
            resultInfo.Data = faqs.Select(a => new { a.Number, a.Question, a.Answer }).ToList(); // don't return password
            return Ok(resultInfo);
        }
        [HttpPost]
        public IActionResult CreateFAQ(FAQ Model)
        {
            ResultInfo resultInfo = new ResultInfo();
            var kqua = FAQDB.Instance.CreateFAQ(Model);
            if (!kqua)
            {
                resultInfo.Status = false;
                resultInfo.Message = "THat bai";
                return Ok(resultInfo);
            }
            resultInfo.Status = true;
            resultInfo.Message = "Thanh cong";
            //resultInfo.Data = Model;
            return Ok(resultInfo);
            
        }

        

        [HttpPost]
        public IActionResult UpdateFAQDetails(FAQ faqUpdate)
        {
            ResultInfo resultInfo = new ResultInfo();
         
            resultInfo.Status = FAQDB.Instance.UpdateFAQDetails(faqUpdate);
            return Ok(resultInfo);
        }

        [HttpDelete]
        public IActionResult DeleteFAQ(int Number)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = FAQDB.Instance.DeleteFAQ(Number);
            return Ok(resultInfo);
        }

    }
}
