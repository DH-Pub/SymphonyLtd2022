using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Symphony.Areas.Admin.Models;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;


namespace Symphony.Areas.Student.Controllers
{
    [Area("student")]
    public class CentreController : Controller
    {
        public IActionResult Index()
        {
            HttpClient httpClient = new HttpClient();
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Centre/GetAllCentres").Result;
            var data = res.Content.ReadAsStringAsync().Result;
            ListCentreModel result = JsonSerializer.Deserialize<ListCentreModel>(data);
            if (result.Status)
            { 
                return View(result.Data);
            }
            return View(new List<CentreModel>());
        }
    }
}
