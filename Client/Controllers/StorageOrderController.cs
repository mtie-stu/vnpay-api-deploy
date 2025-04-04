using Client.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class AdminStorageOrderController : Controller
    {
        private readonly HttpClient _httpClient;

        public AdminStorageOrderController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _httpClient.GetFromJsonAsync<List<AdminStorageViewModel>>("AdminStorageOrder/GetAll");
            return View(orders);
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = await _httpClient.GetFromJsonAsync<AdminStorageViewModel>($"AdminStorageOrder/Get/{id}");
            if (order == null) return NotFound();
            return View(order);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var order = await _httpClient.GetFromJsonAsync<AdminStorageViewModel>($"AdminStorageOrder/Get/{id}");
            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AdminStorageViewModel model)
        {
            var response = await _httpClient.PutAsJsonAsync($"AdminStorageOrder/Edit/{id}", model);
            if (!response.IsSuccessStatusCode) return BadRequest("Không thể chỉnh sửa đơn hàng");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Import(int id)
        {
            var response = await _httpClient.PutAsync($"AdminStorageOrder/Import/{id}", null);
            if (!response.IsSuccessStatusCode) return BadRequest("Không thể nhập hàng");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Export(int id, DateTime dateOfShipment)
        {
            var response = await _httpClient.PutAsync($"AdminStorageOrder/Export/{id}?dateOfShipment={dateOfShipment:yyyy-MM-ddTHH:mm:ss}", null);
            if (!response.IsSuccessStatusCode) return BadRequest("Không thể xuất hàng");
            return RedirectToAction("Index");
        }
    }
}
