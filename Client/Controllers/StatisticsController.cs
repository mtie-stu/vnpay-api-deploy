using Client.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly HttpClient _httpClient;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }

        public async Task<IActionResult> OrdersPerWarehouse()
        {
            var response = await _httpClient.GetAsync("api/Statistics/OrdersPerWarehouse");

            if (!response.IsSuccessStatusCode)
            {
                // Xử lý lỗi nếu cần
                return View(new List<WarehouseOrderStatsViewModel>());
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var stats = JsonConvert.DeserializeObject<List<WarehouseOrderStatsViewModel>>(jsonData);

            return View(stats);
        }
    }

}
