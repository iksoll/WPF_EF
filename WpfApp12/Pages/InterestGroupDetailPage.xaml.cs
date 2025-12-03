using System.Windows;
using System.Windows.Controls;
using WpfApp12.Models;
using WpfApp12.Services;

namespace WpfApp12.Pages
{
    public partial class InterestGroupDetailPage : Page
    {
        public InterestGroup Group { get; }
        public bool IsEditing { get; }

        private readonly InterestGroupService _service = InterestGroupService.Instance;

        public InterestGroupDetailPage(InterestGroup group)
        {
            InitializeComponent();
            Group = group;
            IsEditing = false;

            _service.LoadUsersForGroup(Group);

            DataContext = this;
        }

        public InterestGroupDetailPage(InterestGroup group, bool isEditing)
        {
            InitializeComponent();
            Group = group;
            IsEditing = isEditing;
            DataContext = this;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bool success = IsEditing && Group.Id == 0
                ? _service.Add(Group)
                : _service.Update(Group);

            if (success)
                NavigationService?.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => NavigationService?.GoBack();

        private void AddMember_Click(object sender, RoutedEventArgs e)
            => NavigationService?.Navigate(new AddUserToGroupPage(Group));

        private void Back_Click(object sender, RoutedEventArgs e) => NavigationService?.GoBack();
    }
}