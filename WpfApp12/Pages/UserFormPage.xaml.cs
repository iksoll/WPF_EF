using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using MaterialDesignThemes.Wpf;
using WpfApp12;
using WpfApp12.Services;

namespace WpfApp12.Pages
{
    public partial class UserFormPage : Page
    {
        private readonly UserService _service = UserService.Instance;
        public UserService Service => _service;
        public User User { get; set; }
        private bool _isEdit;

        public UserFormPage(User? user = null)
        {
            InitializeComponent();
            User = user ?? new User();
            _isEdit = user != null;

            if (User.UserProfile == null)
                User.UserProfile = new UserProfile();

            DataContext = User;
        }

        private void MarkFieldAsInvalid(FrameworkElement element, string errorMessage)
        {
            BindingExpression? bindingExpr = null;

            if (element is TextBox tb)
                bindingExpr = tb.GetBindingExpression(TextBox.TextProperty);
            else if (element is PasswordBox pb)
                bindingExpr = pb.GetBindingExpression(PasswordBoxAssist.PasswordProperty);
            else if (element is DatePicker dp)
                bindingExpr = dp.GetBindingExpression(DatePicker.SelectedDateProperty);

            if (bindingExpr == null) return;

            Validation.ClearInvalid(bindingExpr);

            var rule = new ExceptionValidationRule();
            var error = new ValidationError(rule, bindingExpr)
            {
                Exception = new Exception(errorMessage)
            };

            Validation.MarkInvalid(bindingExpr, error);

            element.Focus();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
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

            var dupLogin = _service.Users.FirstOrDefault(u =>
                u.Id != User.Id && string.Equals(u.Login, User.Login, StringComparison.OrdinalIgnoreCase));
            if (dupLogin != null)
            {
                MarkFieldAsInvalid(LoginBox, $"Логин '{User.Login}' уже занят.");
                return;
            }

            var dupEmail = _service.Users.FirstOrDefault(u =>
                u.Id != User.Id && string.Equals(u.Email, User.Email, StringComparison.OrdinalIgnoreCase));
            if (dupEmail != null)
            {
                MarkFieldAsInvalid(EmailBox, $"Email '{User.Email}' уже используется.");
                return;
            }

            bool success = _isEdit ? _service.Update(User) : _service.Add(User);
            if (success)
                NavigationService?.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}