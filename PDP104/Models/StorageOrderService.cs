using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PDP104.Models
{
    public class StorageOrderServices
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("StorageOrder")]
        public int StorageOrderId { get; set; }
        public StorageOrders StorageOrder { get; set; }

        [ForeignKey("ServiceId")]
        public int ServiceId { get; set; }
        public Services Service { get; set; }
    }
}
