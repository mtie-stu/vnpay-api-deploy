namespace User.Services
{
    public class ImageService
    {
        private readonly HttpClient _httpClient;

        public ImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetImageUrl(string filename)
        {
            var imageUrl = $"https://localhost:7145/api/Images/{filename}";
            return imageUrl; // Trả về URL để sử dụng trong img tag  
        }
    }
}
