using System.ComponentModel.DataAnnotations;

namespace Client.Models.AuthenViewModel
{
	public class ForgotPasswordViewModel
	{
		[Required(ErrorMessage = "Tên đăng nhập hoặc email là bắt buộc.")]
		[EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
		public string UsernameOrEmail { get; set; }

		[Required(ErrorMessage = "Mật khẩu mới là bắt buộc.")]
		[DataType(DataType.Password)]
		public string NewPassword { get; set; }

		[Required(ErrorMessage = "Xác nhận mật khẩu là bắt buộc.")]
		[DataType(DataType.Password)]
		[Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không khớp.")]
		public string ConfirmPassword { get; set; }
	}
}
