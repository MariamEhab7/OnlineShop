using System.ComponentModel.DataAnnotations;

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

    [Required]
    public string ItemName { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public int Quantity { get; set; }

    public Product Product { get; set; }
    public GenreOfItems GenreOfItems { get; set; }

    public ICollection<VariationValues> VariationValues { get; set; }
    public ICollection<Order> Orders { get; set; }

}
