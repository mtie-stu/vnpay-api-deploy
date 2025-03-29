using System.ComponentModel.DataAnnotations;

namespace PDP104.Models.ViewModel
{
    public class InventoryViewModel
    {
        public int Id { get; set; }


        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; }
    }
}
