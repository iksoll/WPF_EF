using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using WpfApp12.Services;

namespace WpfApp12.Pages
{
    public partial class UserFormPage : Page
    {
        private readonly UserService _service = new();
        public User User { get; set; }
        private bool _isEdit;

        public UserFormPage(User? user = null)
        {
            InitializeComponent();

            if (user != null)
            {
                User = user;
                _isEdit = true;
            }
            else
            {
                User = new User();
            }

            DataContext = User;
        }

        private void SaveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var pwdBinding = PasswordBox.GetBindingExpression(PasswordBoxAssist.PasswordProperty);
            pwdBinding?.UpdateSource();
            if (Validation.GetErrors(LoginBox).Count > 0 ||
                Validation.GetErrors(EmailBox).Count > 0 ||
                Validation.GetErrors(PasswordBox).Count > 0 ||
                Validation.GetErrors(CreatedAtPicker).Count > 0)
            {
                return;
            }

            bool success = _isEdit ? _service.Update(User) : _service.Add(User);
            if (success)
                NavigationService?.GoBack();
        }

        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}