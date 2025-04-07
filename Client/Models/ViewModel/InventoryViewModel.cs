using System.ComponentModel.DataAnnotations;

namespace Client.Models.ViewModel
{
    public class InventoryViewModel
    {
        public int Id { get; set; }


        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; }

        [Display(Name = "Trạng thái kho")]
        public StatusInventory StatusInventory { get; set; }
        public InventoryStatus InventoryStatus { get; set; }


        [Display(Name = "Ngày Nhập Kho")]
        [DataType(DataType.Date)]
        public DateTime DateOfEntry { get; set; }

        [Display(Name = "Ngày Xuất Kho")]
        [DataType(DataType.Date)]
        public DateTime DateOfShipment { get; set; }

        [Display(Name = "Mã đơn hàng kho")]
        public int StorageOrderId { get; set; }

        [StringLength(100)]
        public string Model { get; set; }

        public int Quantity { get; set; }

    }
}
