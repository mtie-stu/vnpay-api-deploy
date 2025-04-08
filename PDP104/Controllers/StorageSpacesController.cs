using Microsoft.AspNetCore.Mvc;
using PDP104.Service;
using PDP104.ViewModel;

namespace PDP104.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageSpacesController : ControllerBase
    {
        private readonly IStorageSpacesSvc _storageSpaceSvc;

        public StorageSpacesController(IStorageSpacesSvc storageSpaceSvc)
        {
            _storageSpaceSvc = storageSpaceSvc;
        }

        // Lấy tất cả StorageSpaces
        [HttpGet]
        public ActionResult<IEnumerable<StorageSpacesViewModel>> GetAll()
        {
            var list = _storageSpaceSvc.GetStorageSpacesAll();
            return Ok(list);
        }

        // Lấy StorageSpace theo ID
        [HttpGet("{id}")]
        public ActionResult<StorageSpacesViewModel> Get(int id)
        {
            var storageSpace = _storageSpaceSvc.GetStorageSpaces(id);
            if (storageSpace == null)
                return NotFound(new { message = "Không tìm thấy vị trí lưu trữ" });

            return Ok(storageSpace);
        }

        // Thêm mới StorageSpace
        [HttpPost]
        public ActionResult<int> Create([FromBody] StorageSpacesViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newId = _storageSpaceSvc.AddStorageSpace(model);
            if (newId == 0)
                return BadRequest(new { message = "Thêm thất bại" });

            return CreatedAtAction(nameof(Get), new { id = newId },
                new { message = "Thêm thành công", id = newId });
        }

        // Chỉnh sửa StorageSpace theo ID
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] StorageSpacesViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _storageSpaceSvc.EditStorageSpaces(id, model);
            if (result == 0)
                return NotFound(new { message = "Không tìm thấy vị trí lưu trữ để cập nhật" });

            return Ok(new { message = "Cập nhật thành công" });
        }
    }
}
