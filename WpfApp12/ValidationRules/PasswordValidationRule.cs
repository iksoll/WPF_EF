using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WpfApp12.ValidationRules
{
    public class PasswordValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string pwd = (value ?? "").ToString();
            if (pwd.Length < 8)
                return new(false, "Пароль должен содержать не менее 8 символов.");
            if (!Regex.IsMatch(pwd, @"[a-z]"))
                return new(false, "Пароль должен содержать хотя бы одну строчную букву.");
            if (!Regex.IsMatch(pwd, @"[A-Z]"))
                return new(false, "Пароль должен содержать хотя бы одну заглавную букву.");
            if (!Regex.IsMatch(pwd, @"\d"))
                return new(false, "Пароль должен содержать хотя бы одну цифру.");
            if (!Regex.IsMatch(pwd, @"[^a-zA-Z0-9]"))
                return new(false, "Пароль должен содержать хотя бы один спецсимвол.");
            return ValidationResult.ValidResult;
        }
    }
}