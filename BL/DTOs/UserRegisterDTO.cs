using DAL;

namespace BL;

public class UserRegisterDTO
{
    public string? Name { get; set; }

    public string? Phone { get; set; }

    [EmailValidation]
    public string? Email { get; set; }

    public string? Gender { get; set; }
    public Address? Address { get; set; }
    //public User? User { get; set; }
    public UserLoginDTO? User { get; set; }
}
