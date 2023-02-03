namespace BL.Manager.Interfaces;

public interface IPasswordHasher
{
    public string PasswordHashing(string password);
}
