
using PDP104.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PDP104.Models
{
    public enum InventoryStatus

    {
        Incomplete,
        Complete

    }
    public class Inventory
    {
        [Key]
        public int Id { get; set; }


        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; }
        public InventoryStatus InventoryStatus { get; set; }


        [ForeignKey("StorageOrders")]
        public int StorageOrdersId { get; set; }
        public StorageOrders? StorageOrders { get; set; }

        public ICollection<InventoryItem> inventoryItems { get; set; }
    }
}