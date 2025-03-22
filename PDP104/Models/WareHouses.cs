using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDP104.Models
{
    public enum StatusWareHouse
    {
        Active,
        Inactive
    }

    public class WareHouses
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "Vị Trí")]
        public string Location { get; set; }

        [NotMapped]
        public int Space => StorageSpaces?.Count() ?? 0; // Đếm số lượng StorageSpaces

        public StatusWareHouse Status { get; set; }

        public ICollection<StorageSpaces>? StorageSpaces { get; set; }
    }
}
