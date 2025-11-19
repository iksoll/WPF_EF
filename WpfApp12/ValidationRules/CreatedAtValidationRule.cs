using System.Globalization;
using System.Windows.Controls;

namespace WpfApp12.ValidationRules
{
    public class CreatedAtValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is DateTime dt)
            {
                if (dt > DateTime.Now.AddSeconds(1))
                    return new(false, "Дата создания не может быть в будущем.");
                if (dt < new DateTime(2000, 1, 1))
                    return new(false, "Недопустимая дата.");
            }
            return ValidationResult.ValidResult;
        }
    }
}