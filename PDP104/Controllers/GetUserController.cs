using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDP104.Service;

namespace PDP104.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserController : ControllerBase
    {
        private readonly IUserService _userService;

        public GetUserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                user.Id,
                user.UserName,
                user.NameND,
                user.Email,
                user.Hinh,
                user.PhoneNumber,
            });
        }
    }
}
