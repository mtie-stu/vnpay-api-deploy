
using PDP104.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Inventory
{
    [Key]
    public int Id { get; set; }


    [DataType(DataType.Date)]
    public DateTime RequestDate { get; set; }

    [ForeignKey("StorageOrders")]
    public int StorageOrdersId { get; set; }
    public StorageOrders? StorageOrders { get; set; }

    public ICollection<InventoryItem> inventoryItems { get; set; }
}
