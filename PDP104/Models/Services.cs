using System.ComponentModel.DataAnnotations;

namespace PDP104.Models
{
    public enum TypeService
    {
      Container,
      Balet

    }
    public class Services
    {

        [Key]
        public int Id { get; set; }


        [StringLength(100)]
        [Display(Name = "Tên Dịch Vụ")]
        public string NameServices { get; set; }

         public TypeService TypeService { get; set; }   
        [StringLength(100)]
        [Display(Name = "Giá tiền dịch vụ/ Ngày")]
        public decimal UnitPrice { get; set; }
    }
}
