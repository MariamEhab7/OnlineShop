namespace DAL;

public class Address
{
    public Guid AddressId { get; set; }
    public string Description { get; set; }
    public Country Country { get; set; }
}
