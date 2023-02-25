using System.ComponentModel.DataAnnotations;

namespace BL;

public class UserRegisterDTO
{
    [UserNameValidation]
    public string? UserName { get; set; }

    [PasswordValidation]
    public string? Password { get; set; }

    [Compare("Password")]
    public string? ConfirmPassword { get; set; }
}
