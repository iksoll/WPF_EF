using System.Globalization;
using System.Windows.Controls;

namespace WpfApp12.ValidationRules
{
    public class LoginValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string login = (value ?? "").ToString().Trim();
            if (login.Length < 5)
                return new(false, "Логин должен содержать не менее 5 символов.");
            return ValidationResult.ValidResult;
        }
    }
}