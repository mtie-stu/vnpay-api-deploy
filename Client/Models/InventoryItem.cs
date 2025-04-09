using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Client.Models.ViewModel;

namespace Client.Models
{
    public class InventoryItemViewModel
    {
        public int Id { get; set; }

        public int InventoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Model { get; set; }

        public int Quantity { get; set; }



    }
}
