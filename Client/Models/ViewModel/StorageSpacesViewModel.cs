using System.ComponentModel.DataAnnotations;
using Client.Models;

namespace Client.ViewModel
{
    public class StorageSpacesViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tầng không được để trống")]
        [Display(Name = "Tầng")]
        public int Floor { get; set; }

        [Required(ErrorMessage = "Vị trí lưu trữ không được để trống")]
        [StringLength(100)]
        [Display(Name = "Vị Trí Lưu Trữ")]
        public string LocationStorage { get; set; }

        [Required(ErrorMessage = "Trạng thái không được để trống")]
        [Display(Name = "Trạng thái lưu trữ")]
        public StatusStorage Status { get; set; }

        [Required(ErrorMessage = "Kho hàng không được để trống")]
        [Display(Name = "Kho hàng")]
        public int WareHouseId { get; set; }
    }
}
