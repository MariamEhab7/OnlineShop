using System.ComponentModel.DataAnnotations;

namespace DAL;

public class PersonalDetails
{
    public Guid Id { get; set; }
    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Phone { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Gender { get; set; }

    public Address? Address { get; set; }

    public User? User { get; set; }
}
