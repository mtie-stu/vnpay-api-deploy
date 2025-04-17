using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PDP104.Service;
using PDP104.Models.ViewModel;
using PDP104.Models;
using System.Security.Claims;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using PDP104.Data;

namespace PDP104.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Bảo vệ API bằng JWT
    public class UserStorageOrderController : ControllerBase
    {
        private readonly IUserStorageOrder _userStorageOrderService;
        private readonly ApplicationDbContext _context;

        public UserStorageOrderController(IUserStorageOrder userStorageOrderService, ApplicationDbContext context)
        {
            _userStorageOrderService = userStorageOrderService;
            _context = context;
        }

        // 1. Lấy danh sách đơn hàng theo người dùng
        [HttpGet("GetAllByUser")]
        public IActionResult GetAllByUser()
        {
            string nguoiDungId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (nguoiDungId == null)
                return Unauthorized("Không thể xác định người dùng.");

            var orders = _userStorageOrderService.GetAllStorageOrderByUser(nguoiDungId);
            return Ok(orders);
        }

        // 2. Lấy chi tiết đơn hàng theo ID
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _userStorageOrderService.GetStorageOrder(id);    

            if (order == null)
                return NotFound("Không tìm thấy đơn hàng.");
            return Ok(order);
        }

        // 3. Thêm mới đơn hàng với nhiều ảnh
        [HttpPost("Add")]
        public IActionResult AddOrder([FromForm] UserStorageViewModel orderModel)
        {
            string nguoiDungId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string namend = User.FindFirst(ClaimTypes.Name)?.Value;

            if (nguoiDungId == null)
                return Unauthorized("Không thể xác định người dùng.");

            orderModel.NguoiDungId = nguoiDungId;
            int orderId = _userStorageOrderService.AddStorageOrder(orderModel, orderModel.StatusInventory);

            if (orderModel.ImageFiles != null && orderModel.ImageFiles.Count > 0)
            {
                foreach (var imageFile in orderModel.ImageFiles)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "PAID" + imageFile.FileName;
                    string filePath = Path.Combine("uploads", uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(fileStream);
                    }

                    var imageRecord = new StorageOrderImages
                    {
                        StorageOrdersId = orderId,
                        ImageUrl = filePath
                    };
                    _context.StorageOrderImages.Add(imageRecord);
                }
                _context.SaveChanges();
            }

            return CreatedAtAction(nameof(GetOrderById), new { id = orderId }, orderModel);
        }
    }
}
