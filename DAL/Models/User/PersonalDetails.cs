using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DAL;

public class PersonalDetails
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    public Address Address { get; set; }

    public string Country { get; set; }

    [Required]
    public string Email { get; set; }

    [JsonIgnore]
    [Required]
    public string Password { get; set; }

    public Customer Customer { get; set; }
}
