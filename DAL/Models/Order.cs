using System.ComponentModel.DataAnnotations;

namespace DAL;

public class Order
{
    public Order()
    {
        this.Items = new HashSet<Items>();
    }
    public Guid OrderId { get; set; }

    public DateTime OrderDate = DateTime.Now;

    [Required]
    public double OrderTotal { get;  set; }

    public User? Customer { get; set; }
    public ICollection<Items> Items { get; set; }
}
