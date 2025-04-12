using System.ComponentModel.DataAnnotations;

namespace PDP104.Models.ViewModel.AuthenModel
{
    public class ResetPasswordModels
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}
