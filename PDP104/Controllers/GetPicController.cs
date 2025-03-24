using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ASMC5_Sever.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpGet("{filename}")]
        public IActionResult GetImage(string filename)
        {
            var filePath = Path.Combine("D:\\fpt poly\\NET1051 - C#5\\ASM\\ASM\\ASMC5\\ASMC5_Sever\\Uploads\\", filename); // Thay 'path_to_your_image_folder' bằng đường dẫn thực tế  


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