using System.Windows;
using System.Windows.Controls;
using WpfApp12.Models;
using WpfApp12.Services;

namespace WpfApp12.Pages
{
    public partial class InterestGroupListPage : Page
    {
        public InterestGroupService Service => InterestGroupService.Instance;
        public InterestGroup? SelectedGroup { get; set; }

        public InterestGroupListPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var group = new InterestGroup();
            NavigationService?.Navigate(new InterestGroupDetailPage(group, isEditing: true));
        }

        private void GroupDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (SelectedGroup != null)
                NavigationService?.Navigate(new InterestGroupDetailPage(SelectedGroup));
        }

        private void Back_Click(object sender, RoutedEventArgs e) => NavigationService?.GoBack();
    }
}