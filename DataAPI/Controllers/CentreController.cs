using DataAPI.Data.Access;
using DataAPI.Data.Models;
using DataAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DataAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class CentreController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddCentre(Centre centre)
        {
            ResultInfo resultInfo = new ResultInfo();
            var addCentreResult = CentreDB.Instance.AddCentre(centre);
            if (!addCentreResult)
            {
                resultInfo.Status = false;
                resultInfo.Message = "Can not add centre!";
                return Ok(resultInfo);
            }
            resultInfo.Status = true;
            resultInfo.Message = "Add information of centre successfully!";
            resultInfo.Data = centre;
            return Ok(resultInfo);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllCentres(string keySearch)
        {
            ResultInfo resultInfo = new ResultInfo();
            var centres = CentreDB.Instance.GetAllCentres(keySearch);
            if(centres == null)
            {
                resultInfo.Status = false;
                resultInfo.Message = "Can not get information of any centre!";
                return Ok(resultInfo);
            }
            resultInfo.Status = true;
            resultInfo.Message = "Get information of all centres successfully!";
            resultInfo.Data = centres;
            return Ok(resultInfo);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult GetCentreById(Centre centre)
        {
            ResultInfo resultInfo = new ResultInfo();
            var getCentreByIdResult = CentreDB.Instance.GetCentreById(centre.Id);
            if(getCentreByIdResult == null)
            {
                resultInfo.Status = false;
                resultInfo.Message = "Can not get information of this centre!";
                return Ok(resultInfo);
            }
            resultInfo.Status = true;
            resultInfo.Message = "Get information of this centre successfully!";
            resultInfo.Data = getCentreByIdResult;
            return Ok(resultInfo);
        }

        [HttpPost]
        public IActionResult DeleteCentre(Centre centre)
        {
            ResultInfo resultInfo = new ResultInfo();
            var deleteCentreResult = CentreDB.Instance.DeleteCentre(centre.Id);
            if (!deleteCentreResult)
            {
                resultInfo.Status = false;
                resultInfo.Message = "Can not delete this centre!";
                return Ok(resultInfo);
            }
            resultInfo.Status = true;
            resultInfo.Message = "Delete this centre successfully!";
            resultInfo.Data = "Deleted centre ID: " + centre.Id;
            return Ok(resultInfo);
        }

        [HttpPost]
        public IActionResult UpdateCentre(Centre centre)
        {
            ResultInfo resultInfo = new ResultInfo();
            var updateCentreResult = CentreDB.Instance.UpdateCentre(centre);
            if (!updateCentreResult)
            {
                resultInfo.Status = false;
                resultInfo.Message = "Can not update information of this centre!";
                return Ok(resultInfo);
            }
            resultInfo.Status = true;
            resultInfo.Message = "Update this centre successfully!";
            resultInfo.Data = "Updated centre ID: " + centre.Id;
            return Ok(resultInfo);
        }
    }
}
