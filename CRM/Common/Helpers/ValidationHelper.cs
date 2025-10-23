using System.Text.RegularExpressions;

public static class ValidationHelper
{
    public static bool IsValidEmail(string email)
        => Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
}
