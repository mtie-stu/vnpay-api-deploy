using Microsoft.AspNetCore.Mvc;
using Client.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class WareHouseController : Controller
    {
        private readonly HttpClient _httpClient;

        public WareHouseController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var warehouses = await _httpClient.GetFromJsonAsync<List<WareHouses>>("WareHouse");
            return View(warehouses);
        }

        public async Task<IActionResult> Details(int id)
        {
            var warehouse = await _httpClient.GetFromJsonAsync<WareHouses>($"WareHouse/{id}");
            if (warehouse == null) return NotFound();
            return View(warehouse);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WareHouses warehouse)
        {
            var response = await _httpClient.PostAsJsonAsync("WareHouse", warehouse);
            if (!response.IsSuccessStatusCode) return BadRequest("Không thể thêm kho hàng");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, WareHouses warehouse)
        {
            var response = await _httpClient.PutAsJsonAsync($"WareHouse/{id}", warehouse);
            if (!response.IsSuccessStatusCode) return NotFound("Không tìm thấy kho hàng");
            return RedirectToAction("Index");
        }
    }
}
