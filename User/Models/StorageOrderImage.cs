using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace User.Models
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

    }
}
