using Client.Models;
using Client.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using PDP104.ViewModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PDP104.MVC.Controllers
{
    public class InventoryController : Controller
    {
        private readonly HttpClient _httpClient;

      
        public InventoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }

        public async Task<IActionResult> Index()
        {
            /* var inventory = await _httpClient.GetFromJsonAsync<List<InventoryViewModel>>("Inventory/GetAll");
             return View(inventory);*/
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token))
            {
                // Nếu không có token thì redirect về login hoặc báo lỗi
                return RedirectToAction("Login", "Account");
            }
            var request = new HttpRequestMessage(HttpMethod.Get, "Inventory/GetAll");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                // xử lý lỗi, ví dụ: return Unauthorized(), hoặc View("Error")
                return View("Error");
            }
            var orders = await response.Content.ReadFromJsonAsync<List<InventoryViewModel>>();

            return View(orders);
        }

        public async Task<IActionResult> GetItemsByInventoryId(int Id)
        {
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token))
            {
                // Nếu không có token thì redirect về login hoặc báo lỗi
                return RedirectToAction("Login", "Account");
            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"Inventory/GetItems/{Id}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                // xử lý lỗi, ví dụ: return Unauthorized(), hoặc View("Error")
                return View("Error");
            }
            var orders = await response.Content.ReadFromJsonAsync<List<InventoryItemViewModel>>();

            return View(orders);

            /* var items = await _httpClient.GetFromJsonAsync<List<InventoryViewModel>>($"Inventory/GetItems/{inventoryId}");
             return View(items);*/
        }


        public async Task<IActionResult> Create(int Id)
        {
            var model = new InventoryItemViewModel
            {
                InventoryId = Id // Gán vào property tương ứng
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(int inventoryId, string model)
        {
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            var request = new HttpRequestMessage(HttpMethod.Post, $"Inventory/Create?inventoryId={inventoryId}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Gửi model dưới dạng JSON string (ví dụ: "iPhone 14")
            request.Content = JsonContent.Create(model);

            var response = await _httpClient.SendAsync(request);
        
            return RedirectToAction("GetItemsByInventoryId", new { id = inventoryId }); // Quay lại trang chi tiết

        }



        public async Task<IActionResult> GetInVentoryItem(int Id)
        {
            /*  var item = await _httpClient.GetFromJsonAsync<InventoryViewModel>($"Inventory/GetItem/{inventoryItemId}");
              if (item == null) return NotFound();
              return View(item);*/
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token))
            {
                // Nếu không có token thì redirect về login hoặc báo lỗi
                return RedirectToAction("Login", "Account");
            }
            var request = new HttpRequestMessage(HttpMethod.Get, $"Inventory/GetItem/{Id}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                // xử lý lỗi, ví dụ: return Unauthorized(), hoặc View("Error")
                return View("Error");
            }
            var order = await response.Content.ReadFromJsonAsync<InventoryItemViewModel>();

            return View(order);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int inventoryItemId, int newQuantity)
        {
            /*var response = await _httpClient.PutAsJsonAsync($"Inventory/UpdateQuantity/{inventoryItemId}", newQuantity);
            if (!response.IsSuccessStatusCode) return BadRequest("Không thể cập nhật số lượng");
            return RedirectToAction("GetItem", new { inventoryItemId });*/
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            var request = new HttpRequestMessage(HttpMethod.Put, $"Inventory/UpdateQuantity/{inventoryItemId}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Content = JsonContent.Create(newQuantity); // Đính kèm nội dung JSON

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            return RedirectToAction("GetInVentoryItem", new { id = inventoryItemId }); // Quay lại trang chi tiết
        }

        [HttpPost]
        public async Task<IActionResult> AddQuantity(int inventoryId, string model)
        {
            var response = await _httpClient.PostAsJsonAsync($"Inventory/AddQuantity?inventoryId={inventoryId}", model);
            if (!response.IsSuccessStatusCode) return BadRequest("Không thể thêm số lượng");
            return RedirectToAction("GetItems", new { inventoryId });
        }
    }
}
