using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BL;

sealed class PasswordValidation : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        var password = (string)value;
        var regex = new Regex("^(?=.*?[a-z])(?=.*?[0-9]).{4,}$");
        return regex.IsMatch(password);
    }
}

