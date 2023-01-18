using DAL;
using System.ComponentModel.DataAnnotations;

namespace BL;

public class ItemReadDTO
{
    public ItemReadDTO()
    {
        this.VariationValues = new HashSet<ValuesVarReadDTO>();
        this.Orders = new HashSet<OrderReadDTO>();
    }

    public string ItemName { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public Product Product { get; set; }
    public GenreOfItems GenreOfItems { get; set; }

    public ICollection<ValuesVarReadDTO> VariationValues { get; set; }
    public ICollection<OrderReadDTO> Orders { get; set; }
}
