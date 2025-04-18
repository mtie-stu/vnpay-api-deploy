using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using User.Models;
using User.Models.AuthenViewModel;

namespace User.Services
{
    public class AccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiErrorResponse?> RegisterAsync(RegisterViewModel model)
        {
            var content = new StringContent
                (JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient
                .PostAsync("https://localhost:7145/api/Authentication/register", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<ApiErrorResponse>(errorJson);
                return errorResponse;
            }

            return null;
        }

        public async Task<string?> LoginAsync(LoginViewModel model)
        {
            var content = new StringContent
                (JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient
                .PostAsync("https://localhost:7145/api/Authentication/login", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<ApiErrorResponse>(errorJson);
                return null; // Trả về null nếu đăng nhập thất bại
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonConvert.DeserializeObject<dynamic>(jsonResponse);

            return tokenResponse?.token; // Trả về token khi thành công
        }

        public async Task<(bool Success, string Message)> ResetPasswordAsync(ResetPasswordViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("Authentication/resetpassword", model);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(json);
                string message = result?.message ?? "Đặt lại mật khẩu thành công!";
                return (true, message);
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            return (false, $"Lỗi: {errorContent}");
        }

        public async Task<(bool Success, string Message)> ForgotPasswordAsync(ForgotPasswordViewModel model)
        {
            try
            {
                // Encode email để tránh lỗi URL với ký tự đặc biệt (như @)
                var emailEncoded = Uri.EscapeDataString(model.Email);

                // Gửi POST mà không có body
                var response = await _httpClient.PostAsync(
                    $"https://localhost:7145/api/Authentication/forgotpassword/{emailEncoded}",
                    null
                );

                Console.WriteLine($"Response status: {response.StatusCode}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(json);
                    string message = result.message ?? "Yêu cầu thành công nhưng không có thông báo.";
                    return (true, message);
                }
                else
                {
                    var errorJson = await response.Content.ReadAsStringAsync();
                    return (false, $"Yêu cầu thất bại: {errorJson}");
                }
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public async Task<UserProfileViewModel?> GetUserProfileAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("https://localhost:7145/api/Authentication/profile");

            if (!response.IsSuccessStatusCode) return null;

            var jsonString = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(jsonString);

            var user = json["user"]?.ToObject<UserProfileViewModel>();
            return user;
        }

        public async Task<bool> EditProfileAsync(EditProfileViewModel model, string token)
        {
            using var formData = new MultipartFormDataContent();

            // Thêm các trường text
            formData.Add(new StringContent(model.NameND ?? ""), "NameND");
            formData.Add(new StringContent(model.Email ?? ""), "Email");
            formData.Add(new StringContent(model.PhoneNumber ?? ""), "PhoneNumber");

            // Thêm file ảnh nếu có
            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var stream = model.ImageFile.OpenReadStream();
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(model.ImageFile.ContentType);
                formData.Add(fileContent, "ImageFile", model.ImageFile.FileName);
            }

            // Gửi request
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsync("https://localhost:7145/api/Authentication/EditProfile", formData);

            return response.IsSuccessStatusCode;
        }


    }
}
