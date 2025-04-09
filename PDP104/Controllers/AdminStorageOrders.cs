using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PDP104.Service;
using PDP104.Models.ViewModel;
using System;
using System.Collections.Generic;
using PDP104.Models;

namespace PDP104.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Chỉ Admin mới có quyền truy cập
    public class AdminStorageOrderController : ControllerBase
    {
        private readonly IAdminStorageOrderSvc _storageOrderService;

        public AdminStorageOrderController(IAdminStorageOrderSvc storageOrderService)
        {
            _storageOrderService = storageOrderService;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<AdminStorageViewModel>> GetAllStorageOrders()
        {
            return Ok(_storageOrderService.GetAllStorageOrder());
        }

        [HttpGet("Get/{id}")]
        public ActionResult<AdminStorageViewModel> GetStorageOrder(int id)
        {
            var order = _storageOrderService.GetStorageOrder(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPut("SetLocation/{orderId}")]
        public ActionResult SetLocationStorageOrder(int orderId)
        {
            int result = _storageOrderService.SetLocationStorageOrder(orderId);
            if (result == -1)
                return BadRequest("Không đủ vị trí lưu trữ");
            if (result == 0)
                return NotFound("Đơn hàng không tồn tại");
            return Ok("Cập nhật vị trí thành công");
        }

        [HttpPut("Edit/{id}")]
        public ActionResult EditOrder(int id, [FromBody] AdminStorageViewModel model)
        {
            int result = _storageOrderService.EditOrder(id, model);
            if (result == 0)
                return BadRequest("Không thể chỉnh sửa đơn hàng do ngày nhập và ngày xuất không hợp lệ");
            return Ok("Chỉnh sửa ngày nhập/ xuất thành công");
        }

        [HttpPut("Import/{id}")]
        public ActionResult ImportOrder(int id)
        {
            int result = _storageOrderService.ImportingOrder(id);
            if (result == 0)
                return BadRequest("Không thể nhập hàng");
            return Ok("Nhập hàng thành công");
        }

        [HttpPut("Export/{id}")]
        public ActionResult ExportOrder(int id)
        {
            int result = _storageOrderService.ExportingOrder(id);
            if (result == 0)
                return BadRequest("Không thể xuất hàng");
            return Ok("Xuất hàng thành công");
        }

        [HttpGet("GetAllActiveInventory")]
        public ActionResult<List<AdminStorageViewModel>> GetAllStorageOrdersWhereInventoryActive()
        {
            return Ok(_storageOrderService.GetAllStorageOrderWhereInventoryActive());
        }
    }
}
