using DataAPI.Data.Access;
using DataAPI.Data.Models;
using DataAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DataAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Finance,Main")]
    public class PaymentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPayment(long id)
        {
            ResultInfo resultInfo = new ResultInfo { Status = true };
            resultInfo.Data = PaymentDB.Instance.GetPaymentById(id);
            return Ok(resultInfo);
        }
        [HttpGet]
        public IActionResult GetAllPayments()
        {
            ResultInfo resultInfo = new ResultInfo { Status = true };
            resultInfo.Data = PaymentDB.Instance.GetAllPayments();
            return Ok(resultInfo);
        }
        [HttpPost]
        public IActionResult CreatePayment(Payment payment)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = PaymentDB.Instance.CreatePayment(payment);
            return Ok(resultInfo);
        }
        [HttpPost]
        public IActionResult UpdatePayment(Payment payment)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = PaymentDB.Instance.UpdatePayment(payment);
            return Ok(resultInfo);
        }
        [HttpDelete]
        public IActionResult DeletePayment(long id)
        {
            ResultInfo resultInfo = new ResultInfo();
            resultInfo.Status = PaymentDB.Instance.DeletePayment(id);
            return Ok(resultInfo);
        }
    }
}
