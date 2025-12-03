using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WpfApp12.Data;
using WpfApp12.Models;

namespace WpfApp12.Services
{
    public class InterestGroupService
    {
        private static InterestGroupService? _instance;
        public static InterestGroupService Instance => _instance ??= new();

        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<InterestGroup> Groups { get; } = new();

        private InterestGroupService() => LoadAll();

        public void LoadAll()
        {
            var groups = _db.InterestGroups
                .Include(g => g.UserGroups)
                    .ThenInclude(ug => ug.User)
                .ToList();

            Groups.Clear();
            foreach (var g in groups) Groups.Add(g);
        }

        public bool Add(InterestGroup group)
        {
            try
            {
                _db.InterestGroups.Add(group);
                _db.SaveChanges();
                Groups.Add(group);
                return true;
            }
            catch { return false; }
        }

        public bool Update(InterestGroup group) => _db.SaveChanges() > 0;

        public void Remove(InterestGroup group)
        {
            _db.InterestGroups.Remove(group);
            if (_db.SaveChanges() > 0)
                Groups.Remove(group);
        }

        public void LoadUsersForGroup(InterestGroup group)
        {
            _db.Entry(group)
                .Collection(g => g.UserGroups)
                .Query()
                .Include(ug => ug.User)
                    .ThenInclude(u => u.UserProfile)
                .Load();
        }

        public bool AddUserToGroup(User user, InterestGroup group, DateTime joinedAt, bool isModerator)
        {
            if (group.UserGroups.Any(ug => ug.UserId == user.Id)) return false;

            var link = new UserInterestGroup
            {
                UserId = user.Id,
                InterestGroupId = group.Id,
                JoinedAt = joinedAt,
                IsModerator = isModerator
            };

            try
            {
                _db.UserInterestGroups.Add(link);
                _db.SaveChanges();

                group.UserGroups.Add(link);
                user.InterestGroups.Add(link);
                return true;
            }
            catch { return false; }
        }
    }
}
