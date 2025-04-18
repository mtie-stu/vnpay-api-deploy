using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDP104.Data;
using PDP104.Library;

namespace PDP104.Controllers
{
    [ApiController]
    [Route("api/vnpay")]
    public class VnPayController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;

        public VnPayController(IConfiguration config, ApplicationDbContext context)
        {
            _config = config;
            _context = context;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreatePayment([FromBody] int storageOrderId)
        {
            var order = await _context.StorageOrders.FindAsync(storageOrderId);
            if (order == null) return NotFound("Không tìm thấy đơn hàng");

            var vnp = new VnPayLibrary();
            vnp.AddRequestData("vnp_Version", "2.1.0");
            vnp.AddRequestData("vnp_Command", "pay");
            vnp.AddRequestData("vnp_TmnCode", _config["Vnpay:TmnCode"]);

            var amount = Convert.ToInt64(order.Price * 100);
            vnp.AddRequestData("vnp_Amount", amount.ToString());
            vnp.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            vnp.AddRequestData("vnp_ExpireDate", DateTime.Now.AddMinutes(15).ToString("yyyyMMddHHmmss"));
            vnp.AddRequestData("vnp_CurrCode", "VND");

            string ip = HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString() ?? "127.0.0.1";
            vnp.AddRequestData("vnp_IpAddr", ip == "::1" ? "127.0.0.1" : ip);

            vnp.AddRequestData("vnp_Locale", "vn");
            vnp.AddRequestData("vnp_OrderInfo", "TestPayment"); // KHÔNG dấu
            vnp.AddRequestData("vnp_OrderType", "other");
            vnp.AddRequestData("vnp_TxnRef", storageOrderId.ToString());

            // ✅ ReturnUrl phải encode đúng theo RFC 3986
            vnp.AddRequestData("vnp_ReturnUrl", _config["Vnpay:ReturnUrl"]);

            // ❌ KHÔNG ADD vnp_IpnUrl nếu đang chạy ở môi trường test
            // vnp.AddRequestData("vnp_IpnUrl", _config["Vnpay:IpnUrl"]);

            var paymentUrl = vnp.CreateRequestUrl(
                _config["Vnpay:Url"],
                _config["Vnpay:HashSecret"]);

            Console.WriteLine("✅ Final URL = " + paymentUrl);
            return Ok(new { paymentUrl });
        }




        [HttpGet("ipn")]
        public async Task<IActionResult> Ipn()
        {
            var vnp = new VnPayLibrary();

            // ✅ Kiểm tra chữ ký
            if (!vnp.ValidateSignature(Request.Query, _config["Vnpay:HashSecret"]))
                return Content("INVALID_SIGNATURE");

            // ✅ Lấy dữ liệu cần thiết
            var orderId = int.Parse(Request.Query["vnp_TxnRef"]);
            var status = Request.Query["vnp_TransactionStatus"];
            var responseCode = Request.Query["vnp_ResponseCode"];

            // ✅ Xử lý logic đơn hàng
            var order = await _context.StorageOrders.FindAsync(orderId);
            if (order == null)
                return Content("ORDER_NOT_FOUND");

            if (status == "00" && responseCode == "00")
            {
                order.StatusOrder = Models.StatusOrder.PAID;
                await _context.SaveChangesAsync();
                return Content("SUCCESS");
            }

            return Content("FAIL");
        }

        [HttpGet("return")]
        public IActionResult Return()
        {
            var vnp = new VnPayLibrary();
            var isValid = vnp.ValidateSignature(Request.Query, _config["Vnpay:HashSecret"]);

            var orderId = Request.Query["vnp_TxnRef"];
            if (!isValid)
                return Content("Chữ ký không hợp lệ");

            var responseCode = Request.Query["vnp_ResponseCode"];
            if (responseCode == "00")
            {
                // ✅ Sau khi hiển thị thông báo → Redirect về trang chi tiết
                return Redirect($"https://localhost:7023/UserStorageOrder/Details/{orderId}");

            }

            return Redirect($"https://localhost:7023/UserStorageOrder/Details/{orderId}");

        }

    }

}
