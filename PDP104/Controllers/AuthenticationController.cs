using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDP104.Data;
using PDP104.Models;
using PDP104.Models.ViewModel.AuthenModel;
using PDP104.Service;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace PDP104.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<NguoiDung> _userManager;
        private readonly SignInManager<NguoiDung> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthenticationController(ApplicationDbContext context,
                                        SignInManager<NguoiDung> signInManager,
                                        UserManager<NguoiDung> userManager,
                                        ITokenService tokenService)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message =
                    "Dữ liệu không hợp lệ",
                    errors =
                    ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                });
            }

            // Kiểm tra xem email đã tồn tại chưa
            var existingUser = await
                _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return BadRequest(new
                {
                    message =
                    "Email đã được sử dụng!"
                });
            }

            var user = new NguoiDung
            {
                UserName = model.NameND,
                NormalizedUserName = model.NameND.ToUpper(),
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(),
                EmailConfirmed = true
            };

            var result = await
                _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(
                    new
                    {
                        message = "Đăng ký thất bại!",
                        errors = result.Errors
                    });
            }

            await _userManager.AddToRoleAsync(user, "User");
            return Ok(new
            {
                message = "Đăng ký thành công!",
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Dữ liệu không hợp lệ",
                    errors = ModelState.Values.SelectMany
                    (v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            // Tìm người dùng theo email (chuẩn hóa email để tránh lỗi)
            var normalizeddEmail = model.Email;
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.Email == normalizeddEmail);

            if (user == null)
            {
                return Unauthorized(new
                { message = "Sai tài khoản hoặc mật khẩu" });
            }

            // Kiểm tra email đã xác nhận chưa
            if (!user.EmailConfirmed)
            {
                return Unauthorized(new
                {
                    message = "Email chưa được xác nhận. " +
                              "Vui lòng kiểm tra email để kích hoạt tài khoản."
                });
            }

            // Kiểm tra đăng nhập
            var result = await _signInManager
                .PasswordSignInAsync(user, model.Password, false, false);

            if (!result.Succeeded)
            {
                return Unauthorized(new { message = "Sai tài khoản hoặc mật khẩu" });
            }
            var token = _tokenService.GenerateJwtToken(user);
            // Trả về thông tin người dùng
            return Ok(new
            {
                message = "Đăng nhập thành công!",
                token = token.Result
            });
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { message = "Đăng xuất thành công!" });
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            return Ok(new
            {
                message = "Lấy thông tin người dùng thành công!",
                user = new
                {
                    user.Id,
                    user.NameND,
                    user.Email,
                    user.PhoneNumber,
                    user.Hinh
                }
            });
        }

        [HttpPut("EditProfile")]
        [Authorize]
        public async Task<IActionResult> EditProfile([FromBody] EditProfileModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dữ liệu không hợp lệ!" });
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound(new { message = "Người dùng không tồn tại!" });
            }

            // Cập nhật thông tin người dùng
            user.NameND = model.NameND;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.Hinh = model.Hinh;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Cập nhật thất bại!", errors = result.Errors });
            }
            return Ok(new { message = "Cập nhật thông tin thành công!" });
        }

        [HttpGet("loginGoogle")]
        public IActionResult LoginWithGoogle()
        {
            var redirectUrl = Url.Action(nameof(GoogleResponse), "GoogleAuth", null, Request.Scheme);
            var properties = new AuthenticationProperties
            {
                RedirectUri = redirectUrl
            };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("callback")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            if (!result.Succeeded)
            {
                return BadRequest("Đăng nhập thất bại!");
            }

            var claims = result.Principal.Identities.FirstOrDefault()?.Claims;
            var userEmail = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(userEmail))
            {
                return BadRequest("Không lấy được thông tin từ Google.");
            }
            return Ok(userEmail);
        }
    }
}
