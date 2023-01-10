using System.ComponentModel.DataAnnotations;

namespace DAL;

public class Product
{
    public Product()
    {
        this.Orders = new HashSet<Order>();
    }

    public Guid ProductId { get; set; }
    public string ProductName { get; set; }    
    public DateTime ProductionDate { get; set; }
    public DateTime ExpiryDate { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public int Quantity { get; set; }

    public Category Category { get; set; }
    public ICollection<Order> Orders { get; set; }

}
