using System.ComponentModel.DataAnnotations;

namespace DAL;

public class Order
{
    public Order()
    {
        this.Products = new HashSet<Product>();
    }
    public Guid OrderId { get; set; }

    public DateTime OrderDate = DateTime.Now;

    [Required]
    public double OrderTotal { get; set; }

    public Customer Customer { get; set; }
    public ICollection<Product> Products { get; set; }
}
