using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace User.Models.ViewModel
{
    public class UserStorageViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Ngày đặt dịch vụ")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Ngày Nhâp Kho")]
        public DateTime DateOfEntry { get; set; }

        [Display(Name = "Ngày Xuất Kho")]
        public DateTime DateOfShipment { get; set; }
        [Display(Name = "Trạng thái đơn hàng")]
        public StatusOrder StatusOrder { get; set; }
        [Display(Name = "Kiểm kê hàng hóa")]
        public StatusInventory StatusInventory { get; set; }
        [Display(Name = "Loại Hàng Hóa")]
        public TypeOfGoods TypeOfGoods { get; set; }


        [Display(Name = "Tổng Giá ")]
        public decimal Price { get; set; }


        [Display(Name = "Số Lượng")]
        public int Quantity { get; set; }

        [StringLength(100)]
        [Display(Name = "Hình")]
        public string? Hinh { get; set; }

        [NotMapped]
        [Display(Name = "Chọn Hình")]
        public List<IFormFile>? ImageFiles { get; set; } // Cho phép upload nhiều ảnh

        public string? NguoiDungId { get; set; }

    }
}
