using System.ComponentModel.DataAnnotations;

namespace User.Models.AuthenViewModel
{
    public class UserProfileViewModel
    {
        public string Id { get; set; }
        public string NameND { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Hinh { get; set; }
    }

}
