using System.ComponentModel.DataAnnotations;

namespace User.Models.ViewModel
{
    public class ServicesViewModel
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên Dịch Vụ")]
        public string NameServices { get; set; }

        public TypeService TypeService { get; set; }
        public StatusService StatusService { get; set; }

        [Display(Name = "Giá tiền dịch vụ/ Ngày")]
        public decimal UnitPrice { get; set; }

    }
}
