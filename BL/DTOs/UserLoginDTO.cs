namespace BL;

public class UserLoginDTO
{
    [UserNameValidation]
    public string? UserName { get; set; }

    [PasswordValidation]
    public string? Password { get; set; }
}