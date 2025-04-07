using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDP104.Models;
using PDP104.Models.ViewModel.AuthenModel;
using PDP104.Models.ViewModel.UserModel;

namespace PDP104.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<NguoiDung> _userManager;

        public UserController(UserManager<NguoiDung> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(
                users.Select(u =>
                new { u.Id, u.Email, u.NameND, u.PhoneNumber, u.Hinh, u.IsActive }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var userForView = new UserForView
            {
                email = user.Email,
                nameND = user.NameND,
                phoneNumber = user.PhoneNumber,
                hinh = user.Hinh,
            };
            return Ok(userForView);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Dữ liệu không hợp lệ",
                    errors = ModelState.Values.SelectMany(v => v.Errors)
               .Select(e => e.ErrorMessage)
                });
            }

            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return BadRequest(new { message = "Email đã được sử dụng!" });
            }

            var user = new NguoiDung
            {
                NameND = model.NameND,
                Email = model.Email,
                PhoneNumber = model.SĐT,
                UserName = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    message = "Thêm người dùng thất bại",
                    errors = result.Errors.Select(e => e.Description)
                });
            }
            return Ok(new { message = "Thêm người dùng thành công", userId = user.Id });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateModelUser model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Dữ liệu không hợp lệ",
                    errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                });
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "Người dùng không tồn tại!" });
            }

            // Cập nhật thông tin người dùng  
            user.NameND = model.NameND;
            user.Email = model.Email;
            user.PhoneNumber = model.SĐT;
            user.IsActive = model.IsActive;

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                return BadRequest(new
                {
                    message = "Cập nhật thông tin người dùng " +
                    "thất bại!",
                    errors = updateResult.Errors
                });
            }
            return Ok(new { message = "Cập nhật thông tin người dùng thành công!" });
        }
    }
}
