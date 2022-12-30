using Microsoft.AspNetCore.Mvc;
using Symphony.Areas.Admin.Models;
using Symphony.Areas.Student.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Symphony.Areas.Student.Controllers
{
    [Area("student")]

    public class FAQController : Controller
    {
        private const string _tokenName = "token";
        public IActionResult Index(string search = "")
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token); // send header token for api authentication
            string param = (string.IsNullOrWhiteSpace(search)) ? "" : "?search=";
            var res = httpClient.GetAsync(Program.ApiAddress + "api/FAQ/ShowFAQs" + param + search).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            FAQListApiShow result = JsonSerializer.Deserialize<FAQListApiShow>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return View() ;
        }
    }
}
