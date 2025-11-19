using System.Collections.ObjectModel;
using System.Windows;
using WpfApp12.Data;

namespace WpfApp12.Services
{
    public class UserService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;

        public ObservableCollection<User> Users { get; } = new();

        public UserService()
        {
            LoadAll();
        }

        public void LoadAll()
        {
            var users = _db.Users.ToList();
            Users.Clear();
            foreach (var user in users)
                Users.Add(user);
        }

        public bool Add(User user)
        {
            if (Users.Any(u => string.Equals(u.Login, user.Login, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Логин '{user.Login}' уже занят.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (Users.Any(u => string.Equals(u.Email, user.Email, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Email '{user.Email}' уже используется.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            _db.Users.Add(user);
            try
            {
                _db.SaveChanges();
                Users.Add(user);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public bool Update(User user)
        {
            if (Users.Any(u => u.Id != user.Id && string.Equals(u.Login, user.Login, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Логин '{user.Login}' уже занят другим пользователем.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (Users.Any(u => u.Id != user.Id && string.Equals(u.Email, user.Email, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Email '{user.Email}' уже используется другим пользователем.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            try
            {
                _db.Update(user);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public void Remove(User user)
        {
            if (user == null) return;

            if (MessageBox.Show($"Удалить пользователя '{user.Login}'?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    _db.Users.Remove(user);
                    _db.SaveChanges();
                    Users.Remove(user);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}