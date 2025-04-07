using Microsoft.AspNetCore.Mvc;
using PDP104.Data;
using System.IO;

namespace PDP104.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {

        [Route("api/[controller]")]
        [ApiController]
        public class GetImgStorageOrder : ControllerBase
        {

            private readonly ApplicationDbContext _context;

            public GetImgStorageOrder(ApplicationDbContext context)
            {
                _context = context;
            }
            [HttpGet("GetImages/{orderId}")]
            public IActionResult GetImages(int orderId)
            {
                var images = _context.StorageOrderImages
                                     .Where(img => img.StorageOrdersId == orderId)
                                     .Select(img => new
                                     {
                                         img.Id,
                                         ImageUrl = Path.GetFileName(img.ImageUrl) // Ensure no leading slash
                                     })
                                     .ToList();

                if (images == null || images.Count == 0)
                    return NotFound("Không tìm thấy hình ảnh nào cho đơn hàng này.");

                return Ok(images);
            }


        }
        [HttpGet("{filename}")]
        public IActionResult GetImage(string filename)
        {
            var filePath = Path.Combine("D:\\fpt poly\\PDP104\\Project_fearure-Dot\\PDP104\\uploads", filename); // Thay 'path_to_your_image_folder' bằng đường dẫn thực tế  


            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var fileExtension = Path.GetExtension(filename).ToLowerInvariant();
            string contentType;

            // Xác định loại MIME dựa trên phần mở rộng  
            switch (fileExtension)
            {
                case ".jpg":
                case ".jpeg":
                    contentType = "image/jpeg";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
                case ".webp": // Thêm hỗ trợ cho định dạng webp  
                    contentType = "image/webp";
                    break;
                default:
                    return BadRequest("Unsupported file type.");
            }

            var fileStream = new FileStream(filePath, FileMode.Open);
            return File(fileStream, contentType); // Hoặc loại ảnh tương ứng  
        }
    }
}                            