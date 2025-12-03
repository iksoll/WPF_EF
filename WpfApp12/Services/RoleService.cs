using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WpfApp12.Data;
using WpfApp12.Models;

namespace WpfApp12.Services
{
    public class RoleService
    {
        private static RoleService? _instance;
        public static RoleService Instance => _instance ??= new();

        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<Role> Roles { get; } = new();

        private RoleService() => LoadAll();

        public void LoadAll()
        {
            var roles = _db.Roles.Include(r => r.Users).ToList();
            Roles.Clear();
            foreach (var r in roles) Roles.Add(r);
        }

        public void LoadUsersForRole(Role role)
        {
            _db.Entry(role)
                .Collection(r => r.Users)
                .Query()
                .Include(u => u.UserProfile)
                .Load();
        }
    }
}
