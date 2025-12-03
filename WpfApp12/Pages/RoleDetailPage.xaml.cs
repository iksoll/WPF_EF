using System.Windows.Controls;
using WpfApp12.Models;
using WpfApp12.Services;

namespace WpfApp12.Pages
{
    public partial class RoleDetailPage : Page
    {
        public Role Role { get; }

        public RoleDetailPage(Role role)
        {
            InitializeComponent();
            Role = role;

            RoleService.Instance.LoadUsersForRole(Role);

            DataContext = this;
        }

        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}