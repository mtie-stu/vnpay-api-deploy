using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PDP104.Models
{
    public class StorageOrderImages
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StorageOrdersId { get; set; }

        [Required]
        [StringLength(255)]
        public string ImageUrl { get; set; }

        [ForeignKey("StorageOrdersId")]
        public virtual StorageOrders StorageOrder { get; set; }
    }
}
