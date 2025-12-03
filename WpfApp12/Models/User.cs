using System;
using System.Collections.ObjectModel;

namespace WpfApp12.Models
{
    public class User : ObservableObject
    {
        private int _id;
        private string _login = "";
        private string _name = "";
        private string _email = "";
        private string _password = "";
        private DateTime _createdAt = DateTime.Now;

        private UserProfile? _userProfile;
        private int _roleId = 1;
        private Role? _role;
        private ObservableCollection<UserInterestGroup> _interestGroups = new();

        public int Id { get => _id; set => SetProperty(ref _id, value); }
        public string Login { get => _login; set => SetProperty(ref _login, value); }
        public string Name { get => _name; set => SetProperty(ref _name, value); }
        public string Email { get => _email; set => SetProperty(ref _email, value); }
        public string Password { get => _password; set => SetProperty(ref _password, value); }
        public DateTime CreatedAt { get => _createdAt; set => SetProperty(ref _createdAt, value); }

        public UserProfile? UserProfile
        {
            get => _userProfile;
            set => SetProperty(ref _userProfile, value);
        }

        public int RoleId
        {
            get => _roleId;
            set => SetProperty(ref _roleId, value);
        }

        public Role? Role
        {
            get => _role;
            set => SetProperty(ref _role, value);
        }

        public ObservableCollection<UserInterestGroup> InterestGroups
        {
            get => _interestGroups;
            set => SetProperty(ref _interestGroups, value);
        }
    }
}