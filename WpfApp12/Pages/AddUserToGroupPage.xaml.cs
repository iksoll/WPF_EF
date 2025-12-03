using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WpfApp12.Models;
using WpfApp12.Services;

namespace WpfApp12.Pages
{
    public partial class AddUserToGroupPage : Page
    {
        public ObservableCollection<User> Users => UserService.Instance.Users;
        public User? SelectedUser { get; set; }
        public bool IsModerator { get; set; }
        public DateTime JoinedAt { get; set; } = DateTime.Now;
        public InterestGroup Group { get; }

        private readonly InterestGroupService _service = InterestGroupService.Instance;

        public AddUserToGroupPage(InterestGroup group)
        {
            InitializeComponent();
            Group = group;
            DataContext = this;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedUser == null)
            {
                MessageBox.Show("Выберите пользователя.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            bool success = _service.AddUserToGroup(SelectedUser, Group, JoinedAt, IsModerator);
            if (success)
                NavigationService?.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => NavigationService?.GoBack();
    }
}