using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Symphony.Areas.Admin.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Symphony.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Finance,Main")]
    public class PaymentController : Controller
    {
        private const string _tokenName = "token";
        public IActionResult Index()
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Payment/GetAllPayments").Result;
            var data = res.Content.ReadAsStringAsync().Result;
            PaymentListApi result = JsonSerializer.Deserialize<PaymentListApi>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return View(new List<PaymentModel>());
        }
        public IActionResult Details(long id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Payment/GetPayment?id=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            PaymentApi result = JsonSerializer.Deserialize<PaymentApi>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return View(new PaymentModel());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PaymentModel model)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var res = httpClient.PostAsync(Program.ApiAddress + "api/Payment/CreatePayment", stringContent).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            PaymentApi result = JsonSerializer.Deserialize<PaymentApi>(data);
            if (result.Status)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Update(long id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.GetAsync(Program.ApiAddress + "api/Payment/GetPayment?id=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            PaymentApi result = JsonSerializer.Deserialize<PaymentApi>(data);
            if (result.Status)
            {
                return View(result.Data);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(PaymentModel model)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var res = httpClient.PostAsync(Program.ApiAddress + "api/Payment/UpdatePayment", stringContent).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            PaymentApi result = JsonSerializer.Deserialize<PaymentApi>(data);
            if (result.Status)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(long id)
        {
            string token = Request.Cookies[_tokenName];
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = httpClient.DeleteAsync(Program.ApiAddress + "api/Payment/DeletePayment?id=" + id).Result;
            var data = res.Content.ReadAsStringAsync().Result;
            PaymentApi result = JsonSerializer.Deserialize<PaymentApi>(data);
            if (result.Status)
            {
                return RedirectToAction("Index");
            }
            TempData["err"] = "Error, unable to delete";
            return RedirectToAction("Index");
        }
    }
}
