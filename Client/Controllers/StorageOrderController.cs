using Client.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class AdminStorageOrderController : Controller
    {
        private readonly HttpClient _httpClient;

        public AdminStorageOrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }

        public async Task<IActionResult> Index()
        {
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token))
            {
                // Nếu không có token thì redirect về login hoặc báo lỗi
                return RedirectToAction("Login", "Account");
            }
            var request = new HttpRequestMessage(HttpMethod.Get, "AdminStorageOrder/GetAll");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                // xử lý lỗi, ví dụ: return Unauthorized(), hoặc View("Error")
                return View("Error");
            }

            var orders = await response.Content.ReadFromJsonAsync<List<AdminStorageViewModel>>();
            return View(orders);
        }

        public async Task<IActionResult> Details(int id)
        
        {
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            // Gọi API lấy đơn hàng có xác thực
            var orderRequest = new HttpRequestMessage(HttpMethod.Get, $"AdminStorageOrder/Get/{id}");
            orderRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var orderResponse = await _httpClient.SendAsync(orderRequest);
            if (!orderResponse.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var order = await orderResponse.Content.ReadFromJsonAsync<AdminStorageViewModel>();

            var images = await _httpClient.GetFromJsonAsync<List<string>>($"Images/GetImgForId/{id}");
            if (images == null)
            {
                images = new List<string>();
            }

            var model = new AdminStorageViewModel
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                DateOfEntry = order.DateOfEntry,
                DateOfShipment = order.DateOfShipment,
                StatusOrder = order.StatusOrder,
                StatusStorage = order.StatusStorage,
                TypeOfGoods = order.TypeOfGoods,
                Quantity = order.Quantity,
                Price = order.Price,
                NguoiDungId = order.NguoiDungId,
                Floor = order.Floor,
                LocationStorage = order.LocationStorage,
                ImageUrls = images
            };

            return View(model);
        }



        public async Task<IActionResult> ActiveOrder(int id)
        {
            /* var order = await _httpClient.GetFromJsonAsync<AdminStorageViewModel>($"api/AdminStorageOrder/SetLocation/{id}");
             if (order == null) return NotFound();

           */
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            // Gọi API lấy đơn hàng có xác thực
            var orderRequest = new HttpRequestMessage(HttpMethod.Put, $"AdminStorageOrder/SetLocation/{id}");
            orderRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var orderResponse = await _httpClient.SendAsync(orderRequest);
            if (!orderResponse.IsSuccessStatusCode)
            {
                return View("Error");
            }
            return RedirectToAction("Details", new { id = id });
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, AdminStorageViewModel model)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/AdminStorageOrder/Edit/{id}", model);
            if (!response.IsSuccessStatusCode) return BadRequest("Không thể chỉnh sửa đơn hàng");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Import(int id)
        {
            var response = await _httpClient.PutAsync($"api/AdminStorageOrder/Import/{id}", null);
            if (!response.IsSuccessStatusCode) return BadRequest("Không thể nhập hàng");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Export(int id, DateTime dateOfShipment)
        {
            var response = await _httpClient.PutAsync($"api/AdminStorageOrder/Export/{id}?dateOfShipment={dateOfShipment:yyyy-MM-ddTHH:mm:ss}", null);
            if (!response.IsSuccessStatusCode) return BadRequest("Không thể xuất hàng");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> GetImage(string filename)
        {
            var response = await _httpClient.GetAsync($"api/Images/{filename}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var contentType = response.Content.Headers.ContentType.ToString();
            var imageStream = await response.Content.ReadAsStreamAsync();

            return File(imageStream, contentType);
        }

    }
}
