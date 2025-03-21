using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDP104.Models
{
    public enum SatusStorage
    {
        empty,
        full

    }
    public class StorageSpaces
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "Tầng")]
        public int Floor { get; set; }

        [StringLength(100)]
        [Display(Name = "Vị Trí Lưu Trữ")]
        public string LoacationStorage { get; set; }

        public SatusStorage Satus { get; set; }

        [ForeignKey("StorageOrders")]
        public int StorageOrdersId { get; set; }
        public StorageOrders? StorageOrders { get; set; }

        [ForeignKey("WareHouses")]
        public int WareHouseId { get; set; }
        public WareHouses? WareHouse { get; set; }
    }
}
