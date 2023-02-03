using System.Security.Cryptography;
using System.Text;
using BL.Manager.Interfaces;

namespace BL;

public class PasswordHasher : IPasswordHasher
{
    public string PasswordHashing(string password)
    {
        var sha = SHA256.Create();
        var bytesArray = Encoding.Default.GetBytes(password);
        var bytesHashedPassword = sha.ComputeHash(bytesArray);
        var hashedString = Encoding.UTF8.GetString(bytesHashedPassword);
        return hashedString;
    }
}
