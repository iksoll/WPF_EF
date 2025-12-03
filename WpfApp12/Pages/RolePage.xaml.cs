using System.Collections.ObjectModel;
using System.Windows.Controls;

using WpfApp12.Services;

namespace WpfApp12.Pages
{
    public partial class RolePage : Page
    {
        public UserService Service => UserService.Instance;
        public Role? SelectedRole { get; set; }

        public RolePage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
            

        private void RoleDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (SelectedRole != null)
                NavigationService?.Navigate(new RoleDetailPage(SelectedRole));

        }
    }
}