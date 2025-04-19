using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace PDP104.Models
{
    public enum StatusOrder
    {
        Confirming,
        Confirmed,
        PAID,
        Imported,
        Exported
        

    }

    public enum StatusInventory
    {
        Active,
        Inactive
    }
    public enum TypeOfGoods
    {
        Balet,
        Container18ft,
        Container20ft,
        Container22ft
    }

    public class StorageOrders
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Ngày đặt dịch vụ")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Ngày Nhập Kho")]
        public DateTime DateOfEntry { get; set; }

        [Display(Name = "Ngày Xuất Kho")]
        public DateTime DateOfShipment { get; set; }

        public StatusOrder StatusOrder { get; set; }
        public StatusInventory StatusInventory { get; set; }
        public TypeOfGoods TypeOfGoods { get; set; }


        [Display(Name = "Tổng Giá")]
        public decimal Price { get; set; }

        [Display(Name = "Số Lượng")]
        public int Quantity { get; set; }

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

        // Mối quan hệ nhiều-nhiều với Services
        public ICollection<StorageOrderServices>? StorageOrderServices { get; set; }

        // Mối quan hệ 1-nhiều với StorageSpaces
        public ICollection<StorageSpaces>? StorageSpaces { get; set; }
        public virtual ICollection<StorageOrderImages> StorageOrderImages { get; set; } = new List<StorageOrderImages>();

    }
}