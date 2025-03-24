using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("StorageOrders")]
        public int StorageOrdersId { get; set; }
        public StorageOrders? StorageOrders { get; set; }
    }
}
