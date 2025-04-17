
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PDP104.Models;

namespace PDP104.Service
{
    public interface IUserService
    {
        Task<NguoiDung?> GetUserByIdAsync(string userId);
    }
    public class UserService : IUserService
    {
        private readonly UserManager<NguoiDung> _userManager;

        public UserService(UserManager<NguoiDung> userManager)
        {
            _userManager = userManager;
        }

        public async Task<NguoiDung?> GetUserByIdAsync(string userId)
        {
            return await _userManager.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();
        }
    }
}
