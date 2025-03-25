using Client.Models;
using Client.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

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
			if (!isSuccess)
			{
				ModelState.AddModelError("", "Đăng ký thất bại. Vui lòng thử lại!");
				return View(model);
			}

			TempData["SuccessMessage"] = "Đăng ký thành công. Vui lòng đăng nhập!";
			return RedirectToAction("Login");
		}

		
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (!ModelState.IsValid) return View(model);

			var token = await _accountService.LoginAsync(model);
			if (token == null)
			{
				ModelState.AddModelError("", "Sai thông tin đăng nhập.");
				return View(model);
			}

			await SignInUser(token);
			return RedirectToAction("EditProfile");
		}

		
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login");
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
		public async Task<IActionResult> Profile()
		{
			var token = GetUserToken();
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

			var token = GetUserToken();
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



		// ĐĂNG NHẬP COOKIE AUTHENTICATION  
		private async Task SignInUser(string token)
		{
			var claims = new List<Claim> { new Claim("AccessToken", token) };
			var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			var principal = new ClaimsPrincipal(identity);

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
		}

		// LẤY TOKEN NGƯỜI DÙNG  
		private string? GetUserToken()
		{
			return User.Claims.FirstOrDefault(c => c.Type == "AccessToken")?.Value; 
		}
	}
}