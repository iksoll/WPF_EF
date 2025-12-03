using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WpfApp12.Models;
using WpfApp12.Services;

namespace WpfApp12.Pages
{
    public partial class ListPage : Page
    {
        public UserService Service => UserService.Instance;
        public ObservableCollection<User> Users => Service.Users;
        public User? SelectedUser { get; set; }

        public ListPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserFormPage());
        }

        private void EditItem_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (SelectedUser != null)
                NavigationService?.Navigate(new UserFormPage(SelectedUser));
        }

        private void DeleteItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (SelectedUser != null)
                Service.Remove(SelectedUser);
        }

        private void RolesButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
             NavigationService.Navigate(new RolePage());
        }

        private void GroupsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InterestGroupListPage());
        }
    }
}