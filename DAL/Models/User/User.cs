using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DAL;

public class User
{
    public Guid UserId { get; set; }
    public string? UserName { get; set; }

    [JsonIgnore]
    [Required]
    public string? Password { get; set; }

    public string? Role { get; set; }
    public string? Token { get; set; }

    public PersonalDetails? PersonalDetails { get; set; }
}
