using System.ComponentModel.DataAnnotations;

namespace User.Models.AuthenViewModel
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

}
