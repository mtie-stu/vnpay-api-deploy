using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDP104.Models;
using PDP104.Service;

namespace PDP104.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WareHouseController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IWareHousesSvc _wareHousesSvc;

        public WareHouseController(IWebHostEnvironment webHostEnvironment, IWareHousesSvc wareHousesSvc)
        {

            _webHostEnvironment = webHostEnvironment;
            _wareHousesSvc = wareHousesSvc;
        }

        // GET: api/MonAn  
        [HttpGet]
        public ActionResult<IEnumerable<WareHouses>> GetallWareHouses()
        {
            var wareHousesList = _wareHousesSvc.GetWareHousesAll();
            return Ok(wareHousesList); // Trả về danh sách món ăn  
        }
        // GET: api/MonAn/{id}  
        [HttpGet("{id}")]
        public ActionResult<WareHouses> GetWareHouse(int id)
        {
            var wareHouses = _wareHousesSvc.GetWareHouses(id);
            if (wareHouses == null)
            {
                return NotFound(); // Trả về mã 404 nếu không tìm thấy  
            }
            return Ok(wareHouses); // Trả về món ăn với mã 200  
        }

        [HttpPost]
        // /* [ValidateAntiForgeryToken]*/  
        public async Task<ActionResult<WareHouses>> Create([FromForm] WareHouses wareHouses)
        {
            

            // Giả định bạn có một dịch vụ để thêm danh mục  
            var createdMonAn = _wareHousesSvc.AddWareHouse(wareHouses); // Thêm sản phẩm vào cơ sở dữ liệu  

            // Trả về mã 201 nếu thành công  
            return Ok(wareHouses); // Trả về category vừa tạo  
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<WareHouses>> Edit(int id, [FromForm] WareHouses wareHouses)
        {
            // Kiểm tra xem MonAn có tồn tại không   
            var existingwareHouse = _wareHousesSvc.GetWareHouses(id); // Giả định bạn có phương thức để lấy MonAn theo ID  
            if (existingwareHouse == null)
            {
                return NotFound("WareHouses not found.");
            }

            // Cập nhật thông tin không phải file  
            existingwareHouse.Location = wareHouses.Location; // Ví dụ cập nhật tên món ăn  
            existingwareHouse.Status = wareHouses.Status; // Cập nhật giá (hoặc các thuộc tính khác)  

            

            // Lưu lại thay đổi trong cơ sở dữ liệu  
            _wareHousesSvc.EditWareHouses(id, existingwareHouse); // Giả định bạn có phương thức để cập nhật MonAn  

            // Trả về mã 200 nếu thành công  
            return Ok(existingwareHouse); // Trả về MonAn đã cập nhật  
        }
    }
}
