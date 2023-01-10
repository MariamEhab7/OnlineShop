using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DAL;

public class Customer
{
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string Gender { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    public string Email { get; set; }

    [JsonIgnore]
    [Required]
    public string Password { get; set; }
}
