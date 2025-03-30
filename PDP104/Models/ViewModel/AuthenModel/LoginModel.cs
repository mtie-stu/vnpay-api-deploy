using System.ComponentModel.DataAnnotations;

namespace PDP104.Models.ViewModel.AuthenModel
{
    public class LoginModel
    {
        [Required][EmailAddress] public string Email { get; set; }
        [Required] public string Password { get; set; }
    }
}
