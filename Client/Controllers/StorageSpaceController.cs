using Client.Models;
using Client.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;

namespace Client.Controllers
{
    public class StorageSpacesController : Controller
    {
        private readonly HttpClient _httpClient;

        public StorageSpacesController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");

        }

        public async Task<IActionResult> Index()
        {
           
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            // Gọi API lấy đơn hàng có xác thực
            var orderRequest = new HttpRequestMessage(HttpMethod.Get, $"StorageSpaces");
            orderRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var orderResponse = await _httpClient.SendAsync(orderRequest);
            if (!orderResponse.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var orders = await orderResponse.Content.ReadFromJsonAsync<List<StorageSpacesViewModel>>();
            return View(orders);
        }

        public async Task<IActionResult> Create()
        {
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            
            var orderRequest = new HttpRequestMessage(HttpMethod.Get, $"WareHouse");
            orderRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var orderResponse = await _httpClient.SendAsync(orderRequest);
            if (!orderResponse.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var wareHouses = await orderResponse.Content.ReadFromJsonAsync<List<WareHouses>>();
            ViewBag.WareHouses = wareHouses != null && wareHouses.Count > 0
                      ? new SelectList(wareHouses, "Id", "Location")
                      : new SelectList(Enumerable.Empty<WareHouses>(), "Id", "Location");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(StorageSpacesViewModel model)
        {
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            var request = new HttpRequestMessage(HttpMethod.Post, "StorageSpaces");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Content = JsonContent.Create(model); // Đính kèm nội dung JSON

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            return RedirectToAction("Index"); // Chuyển hướng về Index nếu thành công
        }



    }
}
