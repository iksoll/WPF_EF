using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp12.Models
{
    public class UserInterestGroup : ObservableObject
    {
        private int _userId;
        private int _interestGroupId;
        private DateTime _joinedAt = DateTime.Now;
        private bool _isModerator;

        private User? _user;
        private InterestGroup? _interestGroup;

        public int UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        public int InterestGroupId
        {
            get => _interestGroupId;
            set => SetProperty(ref _interestGroupId, value);
        }

        public DateTime JoinedAt
        {
            get => _joinedAt;
            set => SetProperty(ref _joinedAt, value);
        }

        public bool IsModerator
        {
            get => _isModerator;
            set => SetProperty(ref _isModerator, value);
        }

        [ForeignKey("User")]
        public User? User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        [ForeignKey("InterestGroup")]
        public InterestGroup? InterestGroup
        {
            get => _interestGroup;
            set => SetProperty(ref _interestGroup, value);
        }
    }
}
