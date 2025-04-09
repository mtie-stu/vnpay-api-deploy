using System.ComponentModel.DataAnnotations;

namespace PDP104.Models.ViewModel
{
    public class WareHouseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Vị trí")]
        public string Location { get; set; }

        public StatusWareHouse Status { get; set; }
    }

}
