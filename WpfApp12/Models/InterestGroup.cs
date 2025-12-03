using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp12.Models
{
    public class InterestGroup : ObservableObject
    {
        private int _id;
        private string _title = "";
        private string _description = "";
        private ObservableCollection<UserInterestGroup> _userGroups = new();

        public int Id { get => _id; set => SetProperty(ref _id, value); }
        public string Title { get => _title; set => SetProperty(ref _title, value); }
        public string Description { get => _description; set => SetProperty(ref _description, value); }
        public ObservableCollection<UserInterestGroup> UserGroups { get => _userGroups; set => SetProperty(ref _userGroups, value); }
    }
}
