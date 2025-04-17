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

            // Bắt buộc thứ tự và chính xác tên param
            vnp.AddRequestData("vnp_Version", "2.1.0");
            vnp.AddRequestData("vnp_Command", "pay");
            vnp.AddRequestData("vnp_TmnCode", _config["Vnpay:TmnCode"]);

            // Nhân 100 (VNP yêu cầu) và chuyển thành long
            var amount = Convert.ToInt64(order.Price * 100);
            vnp.AddRequestData("vnp_Amount", amount.ToString());

            vnp.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            vnp.AddRequestData("vnp_ExpireDate", DateTime.Now.AddMinutes(15).ToString("yyyyMMddHHmmss"));

            vnp.AddRequestData("vnp_CurrCode", "VND");

            // Lấy IP
            var ipAddress = HttpContext.Connection.RemoteIpAddress;
            string ip = "127.0.0.1";
            if (ipAddress != null)
            {
                ip = ipAddress.IsIPv4MappedToIPv6 ? ipAddress.MapToIPv4().ToString() : ipAddress.ToString();
                if (ip == "::1") ip = "127.0.0.1";
            }
            vnp.AddRequestData("vnp_IpAddr", ip);

            vnp.AddRequestData("vnp_Locale", "vn");

            // KHÔNG DẤU & KHÔNG URL đặc biệt
            vnp.AddRequestData("vnp_OrderInfo", "TestPayment");
            vnp.AddRequestData("vnp_OrderType", "other");

            // ✅ Không thêm IpnUrl vào đây
            vnp.AddRequestData("vnp_ReturnUrl", _config["Vnpay:ReturnUrl"]);
            vnp.AddRequestData("vnp_TxnRef", storageOrderId.ToString());

            // Tạo URL thanh toán
            var paymentUrl = vnp.CreateRequestUrl(_config["Vnpay:Url"], _config["Vnpay:HashSecret"]);

            Console.WriteLine("✅ Final URL: " + paymentUrl);
            return Ok(new { paymentUrl });
        }


        [HttpGet("ipn")]
        public async Task<IActionResult> Ipn()
        {
            var vnp = new VnPayLibrary();
            if (!vnp.ValidateSignature(Request.Query, _config["Vnpay:HashSecret"]))
                return Content("INVALID SIGNATURE");

            var orderId = int.Parse(Request.Query["vnp_TxnRef"]);
            var status = Request.Query["vnp_TransactionStatus"];
            var order = await _context.StorageOrders.FindAsync(orderId);
            if (order != null && status == "00")
            {
                order.StatusOrder = Models.StatusOrder.PAID;
                await _context.SaveChangesAsync();
                return Content("OK");
            }

            return Content("FAIL");
        }
        [HttpGet("return")]
        public IActionResult Return()
        {
            var vnp = new VnPayLibrary();
            var isValid = vnp.ValidateSignature(Request.Query, _config["Vnpay:HashSecret"]);

            if (!isValid)
                return Content("Chữ ký không hợp lệ");

            var responseCode = Request.Query["vnp_ResponseCode"];
            var txnRef = Request.Query["vnp_TxnRef"];

            if (responseCode == "00")
            {
                return Content($"Thanh toán thành công! Mã đơn: {txnRef}");
            }

            return Content("Thanh toán thất bại hoặc bị huỷ.");
        }
    }

}
