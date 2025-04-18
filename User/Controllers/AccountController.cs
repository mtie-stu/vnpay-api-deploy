using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using User.Models.AuthenViewModel;
using User.Services;

namespace User.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService) => _accountService = accountService;

        public IActionResult Register() => View();
        public IActionResult Login() => View();
        public IActionResult ForgotPassword() => View();
        public IActionResult ResetPassword(string email, string token)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
            {
                ViewBag.Message = "Liên kết không hợp lệ hoặc đã hết hạn.";
                return View(); // view này phải kiểm tra nếu Model null
            }

            var model = new ResetPasswordViewModel
            {
                Email = email,
                Token = token
            };

            return View(model); // ✔ Model không null
        }
        public IActionResult AcessDeniedModel() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var isSuccess = await _accountService.RegisterAsync(model);
            if (isSuccess != null && isSuccess.Errors != null && isSuccess.Errors.Values.Any())
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
                ModelState.AddModelError(string.Empty, "Sai thông tin đăng nhập.");
                return View(model);
            }

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            // Tạo ClaimsPrincipal từ token
            var claims = jwtSecurityToken.Claims;
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            // Đăng nhập bằng Cookie Auth
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
            {
                IsPersistent = true
            });
            Response.Cookies.Append("JwtToken", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });

            return RedirectToAction("Index2", "Home");
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
            if (!ModelState.IsValid)
                return View(model);

            var result = await _accountService.ForgotPasswordAsync(model);

            ViewBag.Message = result.Message;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var (success, message) = await _accountService.ResetPasswordAsync(model);
            ViewBag.Message = message;

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            var user = await _accountService.GetUserProfileAsync(token);
            if (user == null)
            {
                ViewBag.Error = "Không thể lấy thông tin người dùng.";
                return View();
            }

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token)) return RedirectToAction("Login");

            var user = await _accountService.GetUserProfileAsync(token);
            if (user == null) return RedirectToAction("Login");

            var model = new EditProfileViewModel
            {
                NameND = user.NameND,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Hinh = user.Hinh
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model)
        {
            var token = Request.Cookies["JwtToken"];
            if (string.IsNullOrEmpty(token)) return RedirectToAction("Login");

            var result = await _accountService.EditProfileAsync(model, token);

            if (result)
            {
                TempData["Success"] = "Cập nhật thành công!";
                return RedirectToAction("Profile");
            }

            ModelState.AddModelError("", "Cập nhật thất bại!");
            return View(model);
        }


        // LẤY TOKEN NGƯỜI DÙNG  
        private string? GetJwtToken()
        {
            return HttpContext.Request.Cookies["JwtToken"];
        }
    }
}