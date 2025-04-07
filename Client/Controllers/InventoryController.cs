using Client.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using PDP104.ViewModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PDP104.MVC.Controllers
{
    public class InventoryController : Controller
    {
        private readonly HttpClient _httpClient;

        public InventoryController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var inventory = await _httpClient.GetFromJsonAsync<List<InventoryViewModel>>("Inventory/GetAll");
            return View(inventory);
        }

        public async Task<IActionResult> GetItems(int inventoryId)
        {
            var items = await _httpClient.GetFromJsonAsync<List<InventoryViewModel>>($"Inventory/GetItems/{inventoryId}");
            return View(items);
        }

        public async Task<IActionResult> GetItem(int inventoryItemId)
        {
            var item = await _httpClient.GetFromJsonAsync<InventoryViewModel>($"Inventory/GetItem/{inventoryItemId}");
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int inventoryId, string model)
        {
            var response = await _httpClient.PostAsJsonAsync($"Inventory/Create?inventoryId={inventoryId}", model);
            if (!response.IsSuccessStatusCode) return BadRequest("Không thể tạo sản phẩm");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int inventoryItemId, int newQuantity)
        {
            var response = await _httpClient.PutAsJsonAsync($"Inventory/UpdateQuantity/{inventoryItemId}", newQuantity);
            if (!response.IsSuccessStatusCode) return BadRequest("Không thể cập nhật số lượng");
            return RedirectToAction("GetItem", new { inventoryItemId });
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
