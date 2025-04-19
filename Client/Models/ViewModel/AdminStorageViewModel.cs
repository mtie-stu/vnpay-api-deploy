using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Client.Models.ViewModel
{
    
    public class AdminStorageViewModel
    {
       
        public int Id { get; set; }

        [Display(Name = "Ngày đặt dịch vụ")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Ngày Nhâp Kho")]
        public DateTime DateOfEntry { get; set; }

        [Display(Name = "Ngày Xuất Kho")]
        public DateTime DateOfShipment { get; set; }

        public StatusOrder StatusOrder { get; set; }
        public StatusInventory StatusInventory { get; set; }
        public TypeOfGoods TypeOfGoods { get; set; }
        public StatusStorage StatusStorage { get; set; }



        [Display(Name = "Tổng Giá ")]
        public decimal Price { get; set; }


        [Display(Name = "Số Lượng")]
        public int Quantity { get; set; }

        [StringLength(100)]
        [Display(Name = "Hình")]
        public string? Hinh { get; set; }

        [NotMapped]
        [Display(Name = "Chọn Hình")]
        public IFormFile? ImageFile { get; set; }

        public string? NguoiDungId { get; set; }
        public int ServiceId { get; set; }
        [Display(Name = "Tầng")]
        public int Floor { get; set; }

        [Display(Name = "Vị Trí Lưu Trữ")]
        public string LocationStorage { get; set; }

        public int StorageSpaceId { get; set; }

        public List<string> ImageUrls { get; set; }

    }
}
