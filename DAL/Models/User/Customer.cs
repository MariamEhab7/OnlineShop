namespace DAL;

public class Customer
{
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string Gender { get; set; }
    public PersonalDetails PersonalDetails { get; set; }
}
