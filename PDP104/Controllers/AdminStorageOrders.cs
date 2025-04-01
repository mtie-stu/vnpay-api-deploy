using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PDP104.Service;
using PDP104.Models.ViewModel;
using System.Collections.Generic;
using System;
using PDP104.Models;

namespace PDP104.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Chỉ Admin mới có quyền truy cập
    public class AdminStorageOrderController : ControllerBase
    {
        private readonly IAdminStorageOrderSvc _adminStorageOrderSvc;

        public AdminStorageOrderController(IAdminStorageOrderSvc adminStorageOrderSvc)
        {
            _adminStorageOrderSvc = adminStorageOrderSvc;
        }

        // 1. Lấy danh sách tất cả đơn hàng lưu trữ
        [HttpGet("GetAll")]
        public IActionResult GetAllStorageOrders()
        {
            var orders = _adminStorageOrderSvc.GetAllStorageOrder();
            return Ok(orders);
        }

        // 2. Lấy danh sách đơn hàng có StatusInventory = Active
        [HttpGet("GetActiveInventoryOrders")]
        public IActionResult GetActiveStorageOrders()
        {
            var orders = _adminStorageOrderSvc.GetAllStorageOrderWhereInventoryActive();
            return Ok(orders);
        }

        // 3. Lấy chi tiết đơn hàng theo ID
        [HttpGet("{id}")]
        public IActionResult GetStorageOrder(int id)
        {
            var order = _adminStorageOrderSvc.GetStorageOrder(id);
            if (order == null) return NotFound("Không tìm thấy đơn hàng.");
            return Ok(order);
        }

        // 4. Cập nhật thông tin đơn hàng
        [HttpPut("Edit/{id}")]
        public IActionResult EditOrder(int id, [FromBody] AdminStorageViewModel orderModel)
        {
            var result = _adminStorageOrderSvc.EditOrder(id, orderModel);
            if (result == 1) return Ok("Cập nhật thành công.");
            return BadRequest("Không thể cập nhật đơn hàng.");
        }

        // 5. Thiết lập vị trí lưu trữ cho đơn hàng
        [HttpPost("SetLocation/{id}")]
        public IActionResult SetLocationStorageOrder(int id, [FromBody] AdminStorageViewModel orderModel, [FromQuery] StatusInventory statusInventory)
        {
            var result = _adminStorageOrderSvc.SetLocationStorageOrder(orderModel, statusInventory);
            if (result == 1) return Ok("Thiết lập vị trí thành công.");
            if (result == -1) return BadRequest("Không đủ vị trí lưu trữ.");
            return NotFound("Không tìm thấy đơn hàng.");
        }

        // 6. Nhập hàng
        [HttpPost("Import/{id}")]
        public IActionResult ImportOrder(int id, [FromBody] AdminStorageViewModel orderModel)
        {
            var result = _adminStorageOrderSvc.ImportingOder(id, orderModel);
            if (result == 1) return Ok("Nhập hàng thành công.");
            return BadRequest("Không thể nhập hàng.");
        }

        // 7. Xuất hàng
        [HttpPost("Export/{id}")]
        public IActionResult ExportOrder(int id, [FromBody] AdminStorageViewModel orderModel)
        {
            var result = _adminStorageOrderSvc.ExportingOrder(id, orderModel);
            if (result == 1) return Ok("Xuất hàng thành công.");
            return BadRequest("Không thể xuất hàng.");
        }
    }
}