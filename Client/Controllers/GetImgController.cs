using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class ImagesController : Controller
    {
        private readonly HttpClient _httpClient;

        public ImagesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> GetImages(int orderId)
        {
            var images = await _httpClient.GetFromJsonAsync<List<object>>($"Images/GetImgForId/{orderId}");
            if (images == null || images.Count == 0) return NotFound("Không tìm thấy hình ảnh nào cho đơn hàng này.");
            return View(images);
        }

        public async Task<IActionResult> GetImage(string filename)
        {
            var response = await _httpClient.GetAsync($"Images/{filename}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var contentType = response.Content.Headers.ContentType.ToString();
            var imageStream = await response.Content.ReadAsStreamAsync();

            return File(imageStream, contentType);
        }
    }
}
