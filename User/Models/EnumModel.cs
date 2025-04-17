using System.ComponentModel.DataAnnotations;

namespace User.Models
{
    public enum StatusOrder
    {
        [Display(Name = "Đang xác nhận")]
        Confirming,

        [Display(Name = "Đã xác nhận")]
        Confirmed,
        [Display(Name = "Đã thanh toán")]

        PAID,
        [Display(Name = "Đã nhập hàng")]
        Imported,

        [Display(Name = "Đã xuất hàng")]
        Exported
    }

    public enum StatusInventory
    {
        Active,
        Inactive
    }
    public enum TypeOfGoods
    {
        [Display(Name = "Balet")]
        Balet,
        [Display(Name = "Container 18ft")]
        Container18ft,
        [Display(Name = "Container 20ft")]
        Container20ft,
        [Display(Name = "Container 22ft")]
        Container22ft
    }
    public enum StatusStorage
    {
       
        [Display(Name = "Trống")]
        empty,

        [Display(Name = "Đã đặt chỗ")]
        booked,

        [Display(Name = "Đã Đầy")]
        full
    }
    public enum InventoryStatus
    {
        Incomplete,
        Complete

    }
    public enum TypeService
    {
        Inventory18ft,
        Inventory20ft,
        Inventory22ft,
        Balet,
        Container18ft,
        Container20ft,
        Container22ft


    }
    public enum StatusService
    {
        Active,
        Inactive

    }
}
