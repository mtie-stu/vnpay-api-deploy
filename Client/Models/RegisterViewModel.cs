using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Vui lòng nhập tên người dùng.")]
		[Display(Name = "User Name")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập email.")]
		[EmailAddress(ErrorMessage = "Email không hợp lệ.")]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
		[DataType(DataType.Password)]
		[MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự.")]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Vui lòng xác nhận mật khẩu.")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp.")]
		[Display(Name = "Confirm Password")]
		public string ConfirmPassword { get; set; }
	
}
}
