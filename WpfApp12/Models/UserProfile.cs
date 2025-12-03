using System.ComponentModel.DataAnnotations.Schema;
using WpfApp12.Models;

namespace WpfApp12
{
    public class UserProfile : ObservableObject
    {
        private int _id;
        private string _avatarUrl = "";
        private string _phone = "";
        private DateTime _birthday = DateTime.Now;
        private string _bio = "";
        private int? _userId;
        private User? _user;

        public int Id { get => _id; set => SetProperty(ref _id, value); }
        public string AvatarUrl { get => _avatarUrl; set => SetProperty(ref _avatarUrl, value); }
        public string Phone { get => _phone; set => SetProperty(ref _phone, value); }
        public DateTime Birthday { get => _birthday; set => SetProperty(ref _birthday, value); }
        public string Bio { get => _bio; set => SetProperty(ref _bio, value); }

        [ForeignKey("User")]
        public int? UserId { get => _userId; set => SetProperty(ref _userId, value); }

        public User? User { get => _user; set => SetProperty(ref _user, value); }

    }
}