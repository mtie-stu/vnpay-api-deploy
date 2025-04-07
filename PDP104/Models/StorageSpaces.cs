using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PDP104.Models
{
    public enum StatusStorage
    {
        empty,
        booked,
        full
    }

    public class StorageSpaces
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tầng")]
        public int Floor { get; set; }

        [StringLength(100)]
        [Display(Name = "Vị Trí Lưu Trữ")]
        public string LocationStorage { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusStorage Status { get; set; }

        [ForeignKey("StorageOrders")]
        public int? StorageOrdersId { get; set; }
/*        [JsonIgnore] // Ngăn chặn vòng lặp
*/
        public StorageOrders? StorageOrders { get; set; }

        [ForeignKey("WareHouses")]
        public int WareHouseId { get; set; }
        public WareHouses? WareHouse { get; set; }
    }
}
