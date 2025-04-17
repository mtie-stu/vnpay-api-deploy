using Client.Models.AuthenViewModel;
using System.Net.Http;
namespace Client.Services
{

    public class UserService 
    {

        private readonly HttpClient _httpClient;

        public UserService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }

        public async Task<string?> GetUserNameAsync(string userId)
        {
            var response = await _httpClient.GetAsync($"GetUser/{userId}");
            if (!response.IsSuccessStatusCode) return null;

            var user = await response.Content.ReadFromJsonAsync<UserViewModel>();
            return user?.userName; // hoặc user?.UserName, tuỳ mục đích bạn cần
        }
        public async Task<string?> GeEmailAsync(string userId)
        {
            var response = await _httpClient.GetAsync($"GetUser/{userId}");
            if (!response.IsSuccessStatusCode) return null;

            var user = await response.Content.ReadFromJsonAsync<UserViewModel>();
            return user?.Email; // hoặc user?.UserName, tuỳ mục đích bạn cần
        }


    }
}
