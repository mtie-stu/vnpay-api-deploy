using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Models
{
    public enum StatusWareHouse
    {
        Active,
        Inactive
    }

    public class WareHouses
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "Vị Trí")]
        public string Location { get; set; }



        public StatusWareHouse Status { get; set; }

    }
}
