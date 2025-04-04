using Client.ViewModel;
using Microsoft.AspNetCore.Mvc;
using PDP104.ViewModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PDP104.MVC.Controllers
{
    public class StorageSpacesController : Controller
    {
        private readonly HttpClient _httpClient;

        public StorageSpacesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var storageSpaces = await _httpClient.GetFromJsonAsync<List<StorageSpacesViewModel>>("StorageSpaces");
            return View(storageSpaces);
        }

        public async Task<IActionResult> Details(int id)
        {
            var storageSpace = await _httpClient.GetFromJsonAsync<StorageSpacesViewModel>($"StorageSpaces/{id}");
            if (storageSpace == null) return NotFound();
            return View(storageSpace);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StorageSpacesViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("StorageSpaces", model);
            if (!response.IsSuccessStatusCode) return BadRequest("Không thể thêm vị trí lưu trữ");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, StorageSpacesViewModel model)
        {
            var response = await _httpClient.PutAsJsonAsync($"StorageSpaces/{id}", model);
            if (!response.IsSuccessStatusCode) return NotFound("Không tìm thấy vị trí lưu trữ");
            return RedirectToAction("Index");
        }
    }
}
