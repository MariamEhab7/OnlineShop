using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL;

public class Items
{
    public Items()
    {
        this.VariationValues = new HashSet<VariationValues>();
        this.Orders = new HashSet<Order>();
    }
    [Key]
    public Guid ItemId { get; set; }

    public string? ItemName { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public string ItemImage { get; set; } = "";
    
    [ForeignKey("ProductId")]
    public Product? Product { get; set; }

    public ICollection<VariationValues> VariationValues { get; set; }
    public ICollection<Order> Orders { get; set; }

}
