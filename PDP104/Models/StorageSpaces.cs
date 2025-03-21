using System.ComponentModel.DataAnnotations;

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
        public int Id{ get; set; }

        [StringLength(100)]
        [Display(Name = "Tầng")]
        public int Floor { get; set; }

        [StringLength(100)]
        [Display(Name = "Vị Trí Lưu Trữ")]
        public string LoacationStorage { get; set; }

        public SatusStorage Satus { get; set; }
       
    }
}
