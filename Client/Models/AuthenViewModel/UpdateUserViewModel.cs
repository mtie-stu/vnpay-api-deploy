namespace Client.Models.AuthenViewModel
{
    public class UpdateUserViewModel
    {
        public string NameND { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile? ImageFile { get; set; } // Ảnh đại diện gửi lên API
    }
}
