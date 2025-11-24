using System.Globalization;
using System.Windows.Controls;
using WpfApp12.Services;

namespace WpfApp12.ValidationRules
{
    public class UniqueLoginRule : ValidationRule
    {
        public UserService Service { get; set; }
        public int? EditingUserId { get; set; } // ID редактируемого пользователя (null при создании)

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string login = (value ?? "").ToString().Trim();
            if (string.IsNullOrWhiteSpace(login))
                return ValidationResult.ValidResult; // базовая валидация — не тут

            var existing = Service?.Users.FirstOrDefault(u =>
                u.Id != EditingUserId &&
                string.Equals(u.Login, login, StringComparison.OrdinalIgnoreCase));

            if (existing != null)
                return new ValidationResult(false, $"Логин '{login}' уже занят.");

            return ValidationResult.ValidResult;
        }
    }
}