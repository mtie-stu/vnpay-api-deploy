using System.ComponentModel.DataAnnotations;

namespace Client.Models.AuthenViewModel
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

}
