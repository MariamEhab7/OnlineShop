using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BL;

public class UserNameValidation : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        var usrName = (string?)value;
        var regex = new Regex("^[A-Z][a-zA-Z]*$");
        return regex.IsMatch(usrName);
    }
}
