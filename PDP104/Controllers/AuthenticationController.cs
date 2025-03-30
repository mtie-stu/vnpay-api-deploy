using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDP104.Data;
using PDP104.Models;
using PDP104.Models.ViewModel.AuthenModel;
using PDP104.Service;
using System.IdentityModel.Tokens.Jwt;

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
                UserName = model.NameND, // Sử dụng NameND làm UserName
                NormalizedUserName = model.NameND.ToUpper(), // Chuẩn hóa NameND
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(), // Chuẩn hóa Email
                EmailConfirmed = true // Cho phép đăng nhập ngay (hoặc có thể gửi email xác nhận)
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

            // Gán quyền mặc định "User"
            await _userManager.AddToRoleAsync(user, "User");

            return Ok(new
            {
                message = "Đăng ký thành công!",
                userId = user.Id
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
            // Lấy danh sách Role của người dùng
            var roles = await _userManager.GetRolesAsync(user);
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
    }
}
