using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PDP104.Service;
using PDP104.Models;
using PDP104.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PDP104.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Chỉ Admin mới có quyền truy cập
    public class InventoryController : ControllerBase
    {
        private readonly IInvetorySvc _inventorySvc;

        public InventoryController(IInvetorySvc inventorySvc)
        {
            _inventorySvc = inventorySvc;
        }

        // 1. Lấy danh sách tất cả kho hàng
        [HttpGet("GetAll")]
        public IActionResult GetAllInventory()
        {
            var inventory = _inventorySvc.GetAllInventory();
            return Ok(inventory);
        }

        // 2. Lấy danh sách sản phẩm trong kho theo InventoryId
        [HttpGet("GetItems/{inventoryId}")]
        public IActionResult GetInventoryItems(int inventoryId)
        {
            var items = _inventorySvc.GetInventoryItemsByInventoryId(inventoryId);
            return Ok(items);
        }

        // 3. Lấy thông tin sản phẩm trong kho theo InventoryItemId
        [HttpGet("GetItem/{inventoryItemId}")]
        public async Task<IActionResult> GetInventoryItem(int inventoryItemId)
        {
            var item = await _inventorySvc.GetInventoryItemById(inventoryItemId);
            return Ok(item);
        }

        // 4. Tạo mới sản phẩm trong kho
        [HttpPost("Create")]
        public async Task<IActionResult> CreateInventoryItem(int inventoryId, [FromBody] string model)
        {
            var item = await _inventorySvc.CreateInventoryItem(inventoryId, model);
            return Ok();

        }

        // 5. Cập nhật số lượng sản phẩm trong kho
        [HttpPut("UpdateQuantity/{inventoryItemId}")]
        public async Task<IActionResult> UpdateInventoryItemQuantity(int inventoryItemId, [FromBody] int newQuantity)
        {
            var item = await _inventorySvc.UpdateInventoryItemQuantity(inventoryItemId, newQuantity);
            return Ok(item);
        }

        // 6. Thêm số lượng sản phẩm vào kho
        [HttpPost("AddQuantity")]
        public async Task<IActionResult> AddInventoryItemQuantity(int inventoryId, [FromBody] string model)
        {
            var (item, message) = await _inventorySvc.AddInventoryItemQuantity(inventoryId, model);
            if (item != null)
            {
                return Ok(item);
            }
            return BadRequest(message);
        }
    }
}
