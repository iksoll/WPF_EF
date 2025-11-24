using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using WpfApp12.Data;

namespace WpfApp12.Services
{
    public class UserService
    {
        private static UserService? _instance;
        public static UserService Instance => _instance ??= new();

        private readonly AppDbContext _db = BaseDbService.Instance.Context;

        public ObservableCollection<User> Users { get; } = new();
        public ObservableCollection<Role> Roles { get; } = new();

        private UserService()
        {
            LoadAllRoles();
            LoadAll();
        }

        private void LoadAllRoles()
        {
            var roles = _db.Roles.ToList();
            Roles.Clear();
            foreach (var r in roles) Roles.Add(r);
        }

        public void LoadAll()
        {
            var users = _db.Users
                .Include(u => u.UserProfile)
                .Include(u => u.Role)
                .ToList();

            Users.Clear();
            foreach (var u in users) Users.Add(u);
        }

        public bool Add(User user)
        {
            if (Users.Any(u => u.Id != user.Id && string.Equals(u.Login, user.Login, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }
            if (Users.Any(u => u.Id != user.Id && string.Equals(u.Email, user.Email, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            _db.Users.Add(user);
            try
            {
                _db.SaveChanges();
                Users.Add(user);
                return true;
            }
            catch { return false; }
        }

        public bool Update(User user)
        {
            try
            {
                _db.Update(user);
                _db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public void Remove(User user)
        {
            try
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
                Users.Remove(user);
            }
            catch { }
        }
    }
}