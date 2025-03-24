using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDP104.Models
{
    public enum StatusOrder
    {
        Confirming,
        Confirmed,
        Imported,
        Exported

    }
    public class StorageOrders
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Ngày đặt dịch vụ")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Ngày Nhâp Kho")]
        public DateTime DateOfEntry { get; set; }

        [Display(Name = "Ngày Xuất Kho")]
        public DateTime DateOfShipment { get; set; }

        public StatusOrder SatusOrder { get; set; }

        [Display(Name = "Tổng Giá ")]
        public decimal Price { get; set; }


        [Display(Name = "Số Lượng")]
        public int Quanity { get; set; }

        [StringLength(100)]
        [Display(Name = "Hình")]
        public string? Hinh { get; set; }

        [NotMapped]
        [Display(Name = "Chọn Hình")]
        public IFormFile? ImageFile { get; set; }

        [ForeignKey("NguoiDung")]
        public string? NguoiDungId { get; set; }
        public NguoiDung? NguoiDung { get; set; }

        [ForeignKey("Inventory")]
        public int? InventoryId { get; set; }
        public Inventory? Inventory { get; set; }

        public ICollection<Services>? Services { get; set; }
        public ICollection<StorageSpaces>? StorageSpaces { get; set; }
    }
}
