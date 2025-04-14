using Client.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Client.Controllers
{

    public class AdminController : Controller
    {
        private readonly HttpClient _httpClient;

        public AdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }
        /* public async Task<IActionResult> Index()
         {
             if (!User.IsInRole("Admin"))
                 return RedirectToAction("AccessDenied", "Account");
             var dashboardViewModel = new AdminDashboardViewModel();

             var response = await _httpClient.GetAsync($"Statistics/OrdersPerWarehouse");
             if (response.IsSuccessStatusCode)
             {
                 var jsonData = await response.Content.ReadAsStringAsync();
                 var warehouseStats = JsonConvert.DeserializeObject<List<WarehouseOrderStatsViewModel>>(jsonData);
                 dashboardViewModel.WarehouseOrderStats = warehouseStats;
             }
             else
             {
                 dashboardViewModel.WarehouseOrderStats = new List<WarehouseOrderStatsViewModel>();
             }

             return View(dashboardViewModel);
         }*/
        public async Task<IActionResult> Index()
        {
            if (!User.IsInRole("Admin"))
                return RedirectToAction("AccessDenied", "Account");

            var dashboardViewModel = new AdminDashboardViewModel();

            // Gọi API lấy thống kê đơn hàng theo kho
            var responseOrders = await _httpClient.GetAsync("Statistics/OrdersPerWarehouse");
            if (responseOrders.IsSuccessStatusCode)
            {
                var jsonData = await responseOrders.Content.ReadAsStringAsync();
                var warehouseStats = JsonConvert.DeserializeObject<List<WarehouseOrderStatsViewModel>>(jsonData);
                dashboardViewModel.WarehouseOrderStats = warehouseStats;
            }
            else
            {
                dashboardViewModel.WarehouseOrderStats = new List<WarehouseOrderStatsViewModel>();
            }

            // Gọi API lấy tỷ lệ sử dụng kho
            var responseUsage = await _httpClient.GetAsync("Statistics/WarehouseUsageRate");
            if (responseUsage.IsSuccessStatusCode)
            {
                var usageData = await responseUsage.Content.ReadAsStringAsync();
                var warehouseUsage = JsonConvert.DeserializeObject<WarehouseUsageViewModel>(usageData);
                dashboardViewModel.WarehouseUsage = warehouseUsage;
            }
            else
            {
                dashboardViewModel.WarehouseUsage = new WarehouseUsageViewModel
                {
                    TotalSpaces = 0,
                    UsedSpaces = 0,
                    UsageRate = 0
                };
            }

            return View(dashboardViewModel);
        }


        public IActionResult QuanLyDichVu()
        {
            return View();
        }

        public IActionResult QuanLyUser()
        {
            return View();
        }
        public IActionResult BaoCaoThongKe()
        {
            return View();
        }
    }
}
