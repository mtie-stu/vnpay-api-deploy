using System.ComponentModel.DataAnnotations;

namespace User.Models.AuthenViewModel
{
    public class ResetPasswordViewModel
    {
        public string? Email { get; set; }
        public string? Token { get; set; }
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
