using Client.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Client.Services
{
	public class AccountService
	{
		private readonly HttpClient _httpClient;

		public AccountService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<bool> RegisterAsync(RegisterViewModel model)
		{
			var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
			var response = await _httpClient.PostAsync("https://your-api.com/api/auth/register", content);
			return response.IsSuccessStatusCode;
		}

		public async Task<string?> LoginAsync(LoginViewModel model)
		{
			var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
			var response = await _httpClient.PostAsync("https://your-api.com/api/auth/login", content);

			if (!response.IsSuccessStatusCode) return null;
			return await response.Content.ReadAsStringAsync();
		}

		public async Task<bool> ForgotPasswordAsync(ForgotPasswordViewModel model)
		{
			var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
			var response = await _httpClient.PostAsync("https://your-api.com/api/auth/forgot-password", content);
			return response.IsSuccessStatusCode;
		}

		public async Task<UserProfileViewModel?> GetUserProfileAsync(string token)
		{
			_httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
			var response = await _httpClient.GetAsync("https://your-api.com/api/auth/profile");

			if (!response.IsSuccessStatusCode) return null;
			return JsonConvert.DeserializeObject<UserProfileViewModel>(await response.Content.ReadAsStringAsync());
		}
		public async Task<bool> UpdateUserProfileAsync(string token, UserProfileViewModel model)
		{
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
			var response = await _httpClient.PutAsync("https://your-api.com/api/account/update-profile", content);

			return response.IsSuccessStatusCode;
		}


	}
}
