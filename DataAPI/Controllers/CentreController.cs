using DataAPI.Data.Access;
using DataAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DataAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CentreController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllCentres(string keySearch)
        {
            ResultInfo resultInfo = new ResultInfo { Status = true };
            var centres = CentreDB.Instance.GetAllCentres(keySearch);
            if(centres == null)
            {
                resultInfo.Status = false;
                resultInfo.Message = "Can not get information of any centre!";
                return Ok(resultInfo);
            }
            resultInfo.Status = true;
            resultInfo.Message = "Get information of all centres successfully!";
            return Ok(resultInfo);
        }
    }
}
