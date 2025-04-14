using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;
using PDP104.Data;
using Microsoft.CodeAnalysis;

namespace PDP104.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StatisticsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("OrdersPerWarehouse")]
        public async Task<IActionResult> GetOrdersPerWarehouse()
        {
            var result = await _context.StorageSpaces
                .Where(s => s.StorageOrdersId != null)
                .GroupBy(s => new { s.WareHouseId, s.WareHouse.Location })
                .Select(g => new
                {
                    WarehouseId = g.Key.WareHouseId,
                    Location = g.Key.Location,
                    NumberOfOrders = g.Select(s => s.Id).Distinct().Count()
                }).ToListAsync();

            return Ok(result);
        }
        [HttpGet("WarehouseUsageRate")]
        public async Task<IActionResult> GetWarehouseUsageRate()
        {
            var totalSpaces = await _context.StorageSpaces.CountAsync();
            var usedSpaces = await _context.StorageSpaces
                .CountAsync(s => s.StorageOrdersId != null); // hoặc s.IsOccupied == true nếu có

            double usageRate = totalSpaces == 0 ? 0 : (double)usedSpaces / totalSpaces * 100;

            var result = new
            {
                TotalSpaces = totalSpaces,
                UsedSpaces = usedSpaces,
                UsageRate = Math.Round(usageRate, 2) // Làm tròn 2 chữ số
            };

            return Ok(result);
        }

    }
}
