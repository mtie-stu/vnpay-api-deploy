using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Vui lòng nhập email.")]
		[EmailAddress(ErrorMessage = "Email không hợp lệ.")]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }
	}
}
