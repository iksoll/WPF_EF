using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WpfApp12.Data;
using WpfApp12.Models;

namespace WpfApp12.Services
{
    public class UserService
    {
        private static UserService? _instance;
        public static UserService Instance => _instance ??= new();

        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<User> Users { get; } = new();

        private UserService() => LoadAll();

        public void LoadAll()
        {
            var users = _db.Users
                .Include(u => u.UserProfile)
                .Include(u => u.Role)
                .Include(u => u.InterestGroups)
                    .ThenInclude(ug => ug.InterestGroup)
                .ToList();

            Users.Clear();
            foreach (var u in users) Users.Add(u);
        }

        public bool Add(User user)
        {
            try
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                Users.Add(user);
                return true;
            }
            catch { return false; }
        }

        public bool Update(User user) => _db.SaveChanges() > 0;

        public void Remove(User user)
        {
            _db.Users.Remove(user);
            if (_db.SaveChanges() > 0)
                Users.Remove(user);
        }
    }
}
