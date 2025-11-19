using System.Globalization;
using System.Windows.Controls;

namespace WpfApp12.ValidationRules
{
    public class EmailValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = (value ?? "").ToString().Trim();
            if (!email.Contains("@"))
                return new(false, "Email должен содержать символ '@'.");
            return ValidationResult.ValidResult;
        }
    }
}