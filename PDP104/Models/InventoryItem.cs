using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PDP104.Models
{
    public class InventoryItem
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Inventory")]
        public int? InventoryId { get; set; }
        public Inventory? Inventory { get; set; }

        [Required]
        [StringLength(100)]
        public string Model { get; set; }

        [Required]
        public int Quantity { get; set; }



    }
}
