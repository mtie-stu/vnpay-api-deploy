using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using User.Models.ViewModel;
using static System.Net.WebRequestMethods;
using ClosedXML.Excel;
using User.Extensions;

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
            formData.Add(new StringContent(((int)model.StatusOrder).ToString()), "SatusOrder");
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
            var response = await client.PostAsync($"UserStorageOrder/Add", formData);

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
            var orderRequest = new HttpRequestMessage(HttpMethod.Get, $"UserStorageOrder/{id}");
            orderRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var orderResponse = await client.SendAsync(orderRequest);
            if (!orderResponse.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var order = await orderResponse.Content.ReadFromJsonAsync<DetailsOrderUser>();

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
        // Mới: xuất Excel
        /*[HttpGet]
        public async Task<IActionResult> ExportToExcel()
        {
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Account");

            var client = _httpClientFactory.CreateClient("MyApiClient");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("UserStorageOrder/GetAllByUser");
            if (!response.IsSuccessStatusCode)
                return View("Error", $"Không thể tải đơn hàng để xuất Excel: {response.ReasonPhrase}");

            var ordersJson = await response.Content.ReadAsStringAsync();
            var orders = JsonSerializer.Deserialize<List<UserStorageViewModel>>(ordersJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Đơn hàng");

            // Header
            ws.Cell(1, 1).Value = "Mã đơn hàng";
            ws.Cell(1, 2).Value = "Ngày đặt";
            ws.Cell(1, 3).Value = "Nhập kho";
            ws.Cell(1, 4).Value = "Xuất kho";
            ws.Cell(1, 5).Value = "Loại hàng";
            ws.Cell(1, 6).Value = "Số lượng";
            ws.Cell(1, 7).Value = "Giá (VNĐ)";
            ws.Cell(1, 8).Value = "Trạng thái";

            int row = 2;
            foreach (var o in orders)
            {
                ws.Cell(row, 1).Value = o.Id;
                ws.Cell(row, 2).Value = o.OrderDate.ToString("yyyy-MM-dd");
                ws.Cell(row, 3).Value = o.DateOfEntry.ToString("yyyy-MM-dd");
                ws.Cell(row, 4).Value = o.DateOfShipment.ToString("yyyy-MM-dd");
                ws.Cell(row, 5).Value = o.TypeOfGoods.GetDisplayName();
                ws.Cell(row, 6).Value = o.Quantity;
                ws.Cell(row, 7).Value = o.Price;
                ws.Cell(row, 8).Value = o.SatusOrder.ToString();
                row++;
            }

            ws.Column(7).Style.NumberFormat.Format = "#,##0";
            ws.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            wb.SaveAs(stream);
            var content = stream.ToArray();
            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"DonHang_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            );
        }*/
        [HttpGet]
        public async Task<IActionResult> ExportToExcel()
        {
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Account");

            var client = _httpClientFactory.CreateClient("MyApiClient");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("UserStorageOrder/GetAllByUser");
            if (!response.IsSuccessStatusCode)
                return View("Error", $"Không thể tải đơn hàng để xuất Excel: {response.ReasonPhrase}");

            var ordersJson = await response.Content.ReadAsStringAsync();
            var orders = JsonSerializer.Deserialize<List<UserStorageViewModel>>(ordersJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Đơn hàng");

            // 1. Chèn logo
            var logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "tachnen.png");
            if (System.IO.File.Exists(logoPath))
            {
                var pic = ws.AddPicture(logoPath)
                            .MoveTo(ws.Cell("A1"))
                            .WithSize(100, 60); // điều chỉnh kích thước logo
            }

            // 2. Header bắt đầu từ dòng 4 (để chừa khoảng cho logo)
            var headerRow = 4;
            ws.Cell(headerRow, 1).Value = "Mã đơn hàng";
            ws.Cell(headerRow, 2).Value = "Ngày đặt";
            ws.Cell(headerRow, 3).Value = "Nhập kho";
            ws.Cell(headerRow, 4).Value = "Xuất kho";
            ws.Cell(headerRow, 5).Value = "Loại hàng";
            ws.Cell(headerRow, 6).Value = "Số lượng";
            ws.Cell(headerRow, 7).Value = "Giá (VNĐ)";
            ws.Cell(headerRow, 8).Value = "Trạng thái";

            // 3. Style header
            var headerRange = ws.Range(headerRow, 1, headerRow, 8);
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;
            headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // 4. Ghi dữ liệu bắt đầu từ dòng 5
            int row = headerRow + 1;
            foreach (var o in orders)
            {
                ws.Cell(row, 1).Value = o.Id;
                ws.Cell(row, 2).Value = o.OrderDate.ToString("yyyy-MM-dd");
                ws.Cell(row, 3).Value = o.DateOfEntry.ToString("yyyy-MM-dd");
                ws.Cell(row, 4).Value = o.DateOfShipment.ToString("yyyy-MM-dd");
                ws.Cell(row, 5).Value = o.TypeOfGoods.GetDisplayName();
                ws.Cell(row, 6).Value = o.Quantity;
                ws.Cell(row, 7).Value = o.Price;
                ws.Cell(row, 8).Value = o.StatusOrder.ToString();
                row++;
            }

            // 5. Biến vùng thành table với style
            var tableRange = ws.Range(headerRow, 1, row - 1, 8);
            var table = tableRange.CreateTable();
            table.Theme = XLTableTheme.TableStyleMedium2;

            // 6. Định dạng cột và căn giữa
            ws.Columns(1, 8).AdjustToContents();
            ws.Columns(2, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Column(7).Style.NumberFormat.Format = "#,##0";

            // 7. Xuống lệnh lưu và trả file
            using var stream = new MemoryStream();
            wb.SaveAs(stream);
            var content = stream.ToArray();
            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"DonHang_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            );
        }

    }
}
