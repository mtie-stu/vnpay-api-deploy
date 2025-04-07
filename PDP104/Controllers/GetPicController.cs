using Microsoft.AspNetCore.Mvc;
using PDP104.Data;
using System.IO;

namespace PDP104.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {

            private readonly ApplicationDbContext _context;

            public ImagesController(ApplicationDbContext context)
            {
                _context = context;
            }

        [HttpGet("GetImgForId/{orderId}")]
        public IActionResult GetImages(int orderId)
        {
            var images = _context.StorageOrderImages
                                 .Where(img => img.StorageOrdersId == orderId)
                                 .Select(img => Path.GetFileName(img.ImageUrl)) // Trả về chuỗi trực tiếp
                                 .ToList();

            if (images == null || images.Count == 0)
                return NotFound("Không tìm thấy hình ảnh nào cho đơn hàng này.");

            return Ok(images); // Danh sách chuỗi
        }




        [HttpGet("{filename}")]
        public IActionResult GetImage(string filename)
        {
            var filePath = Path.Combine("D:\\fpt poly\\PDP104\\Project_fearure-Dot\\PDP104\\uploads", filename);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var fileExtension = Path.GetExtension(filename).ToLowerInvariant();
            string contentType;

            switch (fileExtension)
            {
                case ".jpg":
                case ".jpeg":
                    contentType = "image/jpeg";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
                case ".webp":
                    contentType = "image/webp";
                    break;
                default:
                    return BadRequest("Unsupported file type.");
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, contentType);
        }

    }
}                            