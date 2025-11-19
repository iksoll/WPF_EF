using System;

namespace WpfApp12
{
    public class User : ObservableObject
    {
        private int _id;
        private string _login = "";
        private string _name = "";
        private string _email = "";
        private string _password = "";
        private DateTime _createdAt = DateTime.Now;

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public DateTime CreatedAt
        {
            get => _createdAt;
            set => SetProperty(ref _createdAt, value);
        }

        public override string ToString() => $"User({Id}): {Login}";
    }
}