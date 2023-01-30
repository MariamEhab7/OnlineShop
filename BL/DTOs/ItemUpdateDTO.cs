using DAL;
using System;
using System.Collections.Generic;
namespace BL;

public class ItemUpdateDTO
{
    public ItemUpdateDTO()
    {
        this.VariationValues = new HashSet<ValuesVarReadDTO>();
    }

    public string? ItemName { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public Product? Product { get; set; }

    public ICollection<ValuesVarReadDTO> VariationValues { get; set; }
}
