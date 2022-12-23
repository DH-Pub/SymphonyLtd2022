using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Symphony.Areas.Admin.Models;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Symphony.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class ClassController : Controller
    {
        private const string _tokenName = "token";
        public IActionResult Index()
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Class/GetAllClasses").Result;
            var data = res.Content.ReadAsStringAsync().Result;
            ClassInfoListApi result = JsonSerializer.Deserialize<ClassInfoListApi>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return View(new List<ClassInfoModel>());
        }
        public IActionResult Details(string id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Class/GetClass?id=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            ClassInfoApi result = JsonSerializer.Deserialize<ClassInfoApi>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ClassModel model)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var res = httpClient.PostAsync(Program.ApiAddress + "api/Class/CreateClass", stringContent).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            ClassInfoApi result = JsonSerializer.Deserialize<ClassInfoApi>(data);
            if (result.Status)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Update(string id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Class/GetClass?id=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            ClassInfoApi result = JsonSerializer.Deserialize<ClassInfoApi>(data);
            if (result.Status)
            {
                ClassModel model = new ClassModel
                {
                    Id = result.Data.Id,
                    StartDate = result.Data.StartDate,
                    EndDate = result.Data.EndDate,
                    Room = result.Data.Room,
                    IsBasic = result.Data.IsBasic,
                    Fee = result.Data.Fee,
                    TeacherId = result.Data.TeacherId,
                    CourseId = result.Data.CourseId,
                    CentreId = result.Data.CentreId,
                };
                return View(model);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(ClassModel model)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var res = httpClient.PostAsync(Program.ApiAddress + "api/Class/UpdateClass", stringContent).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            ClassInfoApi result = JsonSerializer.Deserialize<ClassInfoApi>(data);
            if (result.Status)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(string id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.DeleteAsync(Program.ApiAddress + "api/Class/DeleteClass?id=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            ClassInfoApi result = JsonSerializer.Deserialize<ClassInfoApi>(data);
            if (result.Status)
            {
                return RedirectToAction("Index");
            }
            ViewData["err"] = "Error, unable to delete";
            return RedirectToAction("Index");
        }


        // For ClassDetails ------------------------------------------------------
        public IActionResult DetailsList()
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Class/GetAllClassDetails").Result;
            var data = res.Content.ReadAsStringAsync().Result;
            ClassDetailWithReceiptListApi result = JsonSerializer.Deserialize<ClassDetailWithReceiptListApi>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return View(new List<ClassDetailWithReceiptModel>());
        }
        public IActionResult DetailsShow(string id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Class/GetClassDetail?id=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            ClassDetailWithReceiptApi result = JsonSerializer.Deserialize<ClassDetailWithReceiptApi>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return RedirectToAction("DetailsList");
        }
        public IActionResult CreateDetails()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateDetails(ClassDetailModel model)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var res = httpClient.PostAsync(Program.ApiAddress + "api/Class/CreateClassDetail", stringContent).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            ClassDetailWithReceiptApi result = JsonSerializer.Deserialize<ClassDetailWithReceiptApi>(data);
            if (result.Status)
            {
                return RedirectToAction("DetailsList");
            }
            return View(model);
        }
        public IActionResult UpdateDetails(long id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Class/GetClassDetail?id=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            ClassDetailWithReceiptApi result = JsonSerializer.Deserialize<ClassDetailWithReceiptApi>(data);
            if (result.Status)
            {
                ClassDetailModel model = new ClassDetailModel
                {
                    Id = result.Data.Id,
                    RollNumber = result.Data.RollNumber,
                    ClassId = result.Data.ClassId,
                    PaymentId = result.Data.PaymentId,
                    Details = result.Data.Details,
                    IsPass = result.Data.IsPass,
                    IsLabSession = result.Data.IsLabSession
                };
                return View(model);
            }
            return RedirectToAction("DetailsList");
        }
        [HttpPost]
        public IActionResult UpdateDetails(ClassDetailModel model)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var res = httpClient.PostAsync(Program.ApiAddress + "api/Class/UpdateClassDetail", stringContent).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            ClassDetailWithReceiptApi result = JsonSerializer.Deserialize<ClassDetailWithReceiptApi>(data);
            if (result.Status)
            {
                return RedirectToAction("DetailsList");
            }
            return View(model);
        }
        public IActionResult DeleteDetails(long id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.DeleteAsync(Program.ApiAddress + "api/Class/DeleteCLassDetail?id=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            ClassDetailWithReceiptApi result = JsonSerializer.Deserialize<ClassDetailWithReceiptApi>(data);
            if (result.Status)
            {
                return RedirectToAction("DetailsList");
            }
            ViewData["err"] = "Error, unable to delete";
            return RedirectToAction("DetailsList");

        }
    }
}
