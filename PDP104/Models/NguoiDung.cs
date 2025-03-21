using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDP104.Models
{
    /* public enum Role
     {
         [Display(Name = "Admin")]
         Admin=1,
         [Display(Name = "Khách Hàng")]
         KhachHang=2 ,
         [Display(Name = "Nhân Viên ")]
         NhanVien=3,



     }*/
    public class NguoiDung : IdentityUser
    {
        [Required(ErrorMessage = "Vui Lòng Nhập Tên ")]
        [Display(Name = "Tên Người Dùng")]
        [StringLength(255)]
        public string NameND { get; set; }



        [StringLength(100)]
        [Display(Name = "Hình")]
        public string Hinh { get; set; }

        [NotMapped]
        [Display(Name = "Chọn Hình")]
        public IFormFile? ImageFile { get; set; }


        public ICollection<StorageOrders>? StorageOrders { get; set; }


    }
}
