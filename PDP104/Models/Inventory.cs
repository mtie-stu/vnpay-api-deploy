
using System.ComponentModel.DataAnnotations;

public class Inventory
{
    [Key]
    public int Id { get; set; }


    [DataType(DataType.Date)]
    public DateTime RequestDate { get; set; }

}
