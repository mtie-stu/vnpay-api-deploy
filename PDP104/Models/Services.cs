using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDP104.Models
{
    public enum TypeService
    {
        Container,
        Balet
        

    }
    public enum StatusService
    {
        Active,
        Inactive

    }
    public class Services
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tên dịch vụ")]
        public string NameServices { get; set; }
        public TypeService TypeService { get; set; }
        public StatusService StatusService { get; set; }
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        [Display(Name = "Giá dịch vụ")]
        public decimal UnitPrice { get; set; }

        // Mối quan hệ nhiều-nhiều với StorageOrders
        public ICollection<StorageOrderServices>? StorageOrderServices { get; set; }
    }
}
