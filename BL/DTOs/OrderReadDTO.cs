using DAL;
namespace BL;

public class OrderReadDTO
{
    public Guid OrderId { get; set; }
    public DateTime OrderDate = DateTime.Now;

    //public double OrderTotal { get; set; }

    //public Customer Customer { get; set; }
}
