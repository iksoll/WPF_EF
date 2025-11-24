using System.Globalization;
using System.Windows.Controls;
using WpfApp12.Services;

namespace WpfApp12.ValidationRules
{
    public class UniqueEmailRule : ValidationRule
    {
        public UserService Service { get; set; }
        public int? EditingUserId { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = (value ?? "").ToString().Trim();
            if (string.IsNullOrWhiteSpace(email))
                return ValidationResult.ValidResult;

            var existing = Service?.Users.FirstOrDefault(u =>
                u.Id != EditingUserId &&
                string.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase));

            if (existing != null)
                return new ValidationResult(false, $"Email '{email}' уже используется пользователем '{existing.Login}'.");

            return ValidationResult.ValidResult;
        }
    }
}