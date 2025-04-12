using Client.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class ServicesController : Controller
    {
        private readonly HttpClient _httpClient;

        public ServicesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _httpClient.GetFromJsonAsync<List<ServicesViewModel>>("Services");
            return View(services);
        }

        public async Task<IActionResult> Details(int id)
        {
            var service = await _httpClient.GetFromJsonAsync<ServicesViewModel>($"Services/{id}");
            if (service == null) return NotFound();
            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ServicesViewModel serviceVm)
        {
            var response = await _httpClient.PostAsJsonAsync("Services", serviceVm);
            if (!response.IsSuccessStatusCode) return BadRequest("Không thể thêm dịch vụ");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ServicesViewModel serviceVm)
        {
            var response = await _httpClient.PutAsJsonAsync($"Services/{id}", serviceVm);
            if (!response.IsSuccessStatusCode) return NotFound("Không tìm thấy dịch vụ");
            return RedirectToAction("Index");
        }
    }
}
