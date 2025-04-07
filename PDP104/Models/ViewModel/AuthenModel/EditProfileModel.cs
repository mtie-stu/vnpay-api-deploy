using System.ComponentModel.DataAnnotations;

namespace PDP104.Models.ViewModel.AuthenModel
{
    public class EditProfileModel
    {
        [Required]
        public string NameND { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string? Hinh { get; set; }
    }
}
