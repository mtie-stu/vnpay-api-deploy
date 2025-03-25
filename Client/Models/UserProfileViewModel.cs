using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
	public class UserProfileViewModel
	{
		

		[Required(ErrorMessage = "Mã Khách Hàng là bắt buộc.")]
		public string CustomerCode { get; set; }

		[Required(ErrorMessage = "Họ và Tên là bắt buộc.")]
		public string FullName { get; set; }

		[Required(ErrorMessage = "Ngày Sinh là bắt buộc.")]
		[DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }

		[Required(ErrorMessage = "Số Điện Thoại là bắt buộc.")]
		[Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
		[RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại phải có 10 chữ số.")]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Giới Tính là bắt buộc.")]
		public string Gender { get; set; }

		[Required(ErrorMessage = "Tên đăng nhập là bắt buộc.")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Email là bắt buộc.")]
		[EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
		public string Email { get; set; }
	}
}
