using Client.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;
using Client.Models.AuthenViewModel;

namespace Client.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService) => _accountService = accountService;

        public IActionResult Register() => View();
        public IActionResult Login() => View();
        public IActionResult ForgotPassword() => View();
        public IActionResult EditProfile() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var isSuccess = await _accountService.RegisterAsync(model);
            if (isSuccess != null)
            {
                ViewBag.Errors = isSuccess.Errors;
                return View(model);
            }

            TempData["SuccessMessage"] = "Đăng ký thành công. Vui lòng đăng nhập!";
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var token = await _accountService.LoginAsync(model);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(new { message = "Sai thông tin đăng nhập." });
            }

            Response.Cookies.Append("JwtToken", token, new CookieOptions
            {
                HttpOnly = true,  // Bảo vệ khỏi XSS (chặn JavaScript đọc token)
                Secure = true,    // Chỉ hoạt động trên HTTPS
                SameSite = SameSiteMode.Strict // Ngăn tấn công CSRF
            });

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7145/"); // Thay bằng URL API thực tế
                string token = HttpContext.Request.Cookies["JwtToken"];

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var response = await client.PostAsync("api/Authentication/logout", null);
                if (response.IsSuccessStatusCode)
                {
                    // ✅ Xóa cookie chứa JWT Token
                    Response.Cookies.Delete("JwtToken");

                    // ✅ Đăng xuất khỏi Identity nếu đang dùng
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                    TempData["Message"] = "Đăng xuất thành công!";
                    return RedirectToAction("Login", "Account");
                }
            }

            TempData["Error"] = "Lỗi khi đăng xuất!";
            return RedirectToAction("Index", "Home");
        }



        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var isSuccess = await _accountService.ForgotPasswordAsync(model);
            if (!isSuccess)
            {
                ModelState.AddModelError("", "Không thể gửi yêu cầu đặt lại mật khẩu.");
                return View(model);
            }

            TempData["SuccessMessage"] = "Email đặt lại mật khẩu đã được gửi!";
            return RedirectToAction("Login");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var token = GetJwtToken();
            if (string.IsNullOrEmpty(token)) return RedirectToAction("Login");

            var userProfile = await _accountService.GetUserProfileAsync(token);
            if (userProfile == null)
            {
                TempData["ErrorMessage"] = "Không thể tải thông tin cá nhân.";
                return RedirectToAction("Login");
            }

            return View("EditProfile", userProfile);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserProfileViewModel model)
        {
            if (!ModelState.IsValid) return View("EditProfile", model);

            var token = GetJwtToken();
            if (string.IsNullOrEmpty(token)) return RedirectToAction("Login");

            var isUpdated = await _accountService.UpdateUserProfileAsync(token, model);
            if (!isUpdated)
            {
                ModelState.AddModelError("", "Cập nhật thất bại.");
                return View("EditProfile", model);
            }

            TempData["SuccessMessage"] = "Cập nhật thành công!";
            return RedirectToAction("Profile");
        }

        // LẤY TOKEN NGƯỜI DÙNG  
        private string? GetJwtToken()
        {
            return HttpContext.Request.Cookies["JwtToken"];
        }
    }
}