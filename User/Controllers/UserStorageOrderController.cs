using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using User.Models.ViewModel;
using static System.Net.WebRequestMethods;

namespace User.Controllers
{
    public class UserStorageOrderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserStorageOrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(); // Hiển thị form tạo đơn hàng
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserStorageViewModel model)
        {
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            var client = _httpClientFactory.CreateClient("MyApiClient");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Chuẩn bị content dạng multipart/form-data để gửi lên API
            using var formData = new MultipartFormDataContent();

            // Các trường cơ bản
            formData.Add(new StringContent(model.OrderDate.ToString("o")), "OrderDate");
            formData.Add(new StringContent(model.DateOfEntry.ToString("o")), "DateOfEntry");
            formData.Add(new StringContent(model.DateOfShipment.ToString("o")), "DateOfShipment");
            formData.Add(new StringContent(((int)model.SatusOrder).ToString()), "SatusOrder");
            formData.Add(new StringContent(((int)model.StatusInventory).ToString()), "StatusInventory");
            formData.Add(new StringContent(((int)model.TypeOfGoods).ToString()), "TypeOfGoods");
            formData.Add(new StringContent(model.Price.ToString()), "Price");
            formData.Add(new StringContent(model.Quantity.ToString()), "Quantity");

            // Ảnh
            if (model.ImageFiles != null)
            {
                foreach (var file in model.ImageFiles)
                {
                    if (file.Length > 0)
                    {
                        var fileContent = new StreamContent(file.OpenReadStream());
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                        formData.Add(fileContent, "ImageFiles", file.FileName);
                    }
                }
            }

            // Gửi yêu cầu
            var response = await client.PostAsync("UserStorageOrder/Add", formData);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("MyOrders"); // Hoặc trang phù hợp của bạn
            }

            // Đọc lỗi và hiển thị
            var error = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, $"Tạo đơn hàng thất bại: {error}");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            var client = _httpClientFactory.CreateClient("MyApiClient");

            // Gọi API lấy đơn hàng có xác thực
            var orderRequest = new HttpRequestMessage(HttpMethod.Get, $"AdminStorageOrder/Get/{id}");
            orderRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var orderResponse = await client.SendAsync(orderRequest);
            if (!orderResponse.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var order = await orderResponse.Content.ReadFromJsonAsync<AdminStorageViewModel>();

            // Gọi API lấy danh sách hình ảnh (nếu không cần token)
            var images = await client.GetFromJsonAsync<List<string>>($"Images/GetImgForId/{id}");
            images ??= new List<string>();

            // Gọi API lấy vật phẩm kho có xác thực
            var inventoryRequest = new HttpRequestMessage(HttpMethod.Get, $"Inventory/GetInventorybyStorageId/{id}");
            inventoryRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var inventoryResponse = await client.SendAsync(inventoryRequest);
            if (!inventoryResponse.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var inventoryItem = await inventoryResponse.Content.ReadFromJsonAsync<List<InventoryItem>>();
            inventoryItem ??= new List<InventoryItem>();

            // Gán vào model
            var model = new DetailsOrderUser
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
                ImageUrls = images,
                InventoryItem = inventoryItem
            };

            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            var client = _httpClientFactory.CreateClient("MyApiClient");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("UserStorageOrder/GetAllByUser");

            if (!response.IsSuccessStatusCode)
            {
                return View("Error", $"Không thể tải đơn hàng: {response.ReasonPhrase}");
            }

            var ordersJson = await response.Content.ReadAsStringAsync();
            var orders = JsonSerializer.Deserialize<List<UserStorageViewModel>>(ordersJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(orders);
        }
        [HttpPost]
        public async Task<IActionResult> Pay(int Id)
        {
            // Sử dụng client có tên "MyApiClient"
            var client = _httpClientFactory.CreateClient("MyApiClient");

            // Không cần ghi rõ domain, chỉ cần endpoint thôi vì đã có BaseAddress
            var res = await client.PostAsJsonAsync("vnpay/create", Id);

            if (res.IsSuccessStatusCode)
            {
                var result = await res.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                return Redirect(result["paymentUrl"]);
            }

            TempData["Error"] = "Không thể tạo thanh toán.";
            return RedirectToAction("Details", new { Id });
        }
    }
}
