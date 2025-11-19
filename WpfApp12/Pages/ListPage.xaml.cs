using System.Windows.Controls;
using WpfApp12.Services;

namespace WpfApp12.Pages
{
    public partial class ListPage : Page
    {
        public UserService Service { get; } = new();
        public User? SelectedUser { get; set; }

        public ListPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new UserFormPage());
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
    }
}