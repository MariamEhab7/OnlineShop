using DAL;
using Microsoft.AspNetCore.Http;

namespace BL;

public class ItemAddDTO
{
    public ItemAddDTO()
    {
        this.VariationValues = new HashSet<ValuesVarReadDTO>();
        this.Orders = new HashSet<OrderReadDTO>();
    }

    public string? ItemName { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public string ItemImage { get; set; }

    public Product? Product { get; set; }
    public ICollection<ValuesVarReadDTO> VariationValues { get; set; }
    public ICollection<OrderReadDTO> Orders { get; set; }
}
