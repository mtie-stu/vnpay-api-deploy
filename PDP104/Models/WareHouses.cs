using System.ComponentModel.DataAnnotations;

namespace PDP104.Models
{
    public class WareHouses
    {
        [Key]
        public int Id { get; set; }


        [StringLength(100)]
        [Display(Name = "Vị Trí")]
        public string Loacation { get; set; }


        [StringLength(100)]
        [Display(Name = "Tổng Số lượng lưu trữ")]
        public int Space { get; set; }

        public ICollection<StorageSpaces>? StorageSpaces { get; set; }
    }
}
