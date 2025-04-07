using System.ComponentModel.DataAnnotations;

namespace PDP104.Models.ViewModel.AuthenModel
{
    public class RegisterModel
    {
        [Required] public string NameND { get; set; }
        [Required][EmailAddress] public string Email { get; set; }
        public string? SĐT { get; set; }
        [Required] public string DiaChi { get; set; }
        [Required] public string Password { get; set; }
    }
}
