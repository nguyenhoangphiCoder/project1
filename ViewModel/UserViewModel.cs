using Phanmemquanlybanhang.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Phanmemquanlybanhang.ViewModel
{
    public class UserViewModel:BaseViewModel
    {
        private ObservableCollection<User> _List;
        public ObservableCollection<User> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private User _SelectedItem;
        public User SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Id = SelectedItem.Id;
                    Role = SelectedItem.Role;
                    Password = SelectedItem.Password;
                    Username =SelectedItem.Username;
                    Name = SelectedItem.Name;
                }
            }
        }
        private int _Id;
        public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Username;
        public string Username { get => _Username; set { _Username = value; OnPropertyChanged(); } }

        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _Role;
        public string Role { get => _Role; set { _Role = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand ChangeCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public UserViewModel()
        {
            List = new ObservableCollection<User>(DataProvider.Ins.DB.Users);
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var User = new User() {Id=Id,Role=Role,Name=Name,Password= Password,Username= Username };

                DataProvider.Ins.DB.Users.Add(User);
                DataProvider.Ins.DB.SaveChanges();
                DataProvider.Ins.DB.Users.Load();
                List.Add(User);
            });
            ChangeCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Users.Where(x => x.Name == SelectedItem.Name);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var User = DataProvider.Ins.DB.Users.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                string userId = string.Format("{0}",SelectedItem.Id);   
                MessageBox.Show(Name);
               
                User.Name = Name;
                User.Username =Username;
                User.Role = SelectedItem.Role;
                User.Password = SelectedItem.Password;

                DataProvider.Ins.DB.SaveChanges();
                DataProvider.Ins.DB.Users.Load();
            });
            DeleteCommand = new RelayCommand<object>((p) => SelectedItem != null, (p) =>
            {
                var user = DataProvider.Ins.DB.Users.Find(SelectedItem.Id);

                if (user != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this User?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        DataProvider.Ins.DB.Users.Remove(user);
                        DataProvider.Ins.DB.SaveChanges();
                        List.Remove(user);
                    }
                    DataProvider.Ins.DB.Users.Load();

                }
            });
            SearchCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var User = new User() { Id = Id, Role = Role, Name = Name, Password = Password, Username = Username };

                var listSearch = DataProvider.Ins.DB.Users.Where(x => x.Name == User.Name).ToList();
                List.Clear();
                foreach (User user in listSearch)
                {
                    List.Add(user);
                }
            });


        }
    }
}
