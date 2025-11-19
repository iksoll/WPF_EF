using System.Globalization;
using System.Windows.Controls;

namespace WpfApp12.ValidationRules
{
    public class RequiredRule : ValidationRule
    {
        public string FieldName { get; set; } = "Поле";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = (value ?? "").ToString().Trim();
            if (string.IsNullOrEmpty(input))
                return new(false, $"{FieldName} обязательно для заполнения.");
            return ValidationResult.ValidResult;
        }
    }
}