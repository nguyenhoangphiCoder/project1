using Phanmemquanlybanhang.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Phanmemquanlybanhang.ViewModel
{
    public class StaffViewModel : BaseViewModel
    {
        private ObservableCollection<Staff> _List;
        public ObservableCollection<Staff> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        
        private Staff _SelectedItem;
        public Staff SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Id = SelectedItem.Id;
                    Name = SelectedItem.Name;
                    BirthDate = SelectedItem.BirthDate;
                    Position = SelectedItem.Position;
                    Wage  = (int)SelectedItem.Wage;
                    PhoneNumber = SelectedItem.PhoneNumber;
                    Email = SelectedItem.Email;
                }
            }
        }
        private int _Id;
        public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _PhoneNumber;
        public string PhoneNumber { get => _PhoneNumber; set { _PhoneNumber = value; OnPropertyChanged(); } }
        private string _Position;
        public string Position { get => _Position; set { _Position = value; OnPropertyChanged(); } }
        private DateTime? _BirthDate;
        public DateTime? BirthDate { get => _BirthDate; set { _BirthDate = value; OnPropertyChanged(); } }
        private int _Wage;
        public int Wage { get => _Wage; set { _Wage = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand ChangeCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public StaffViewModel()
        {
            List = new ObservableCollection<Staff>(DataProvider.Ins.DB.Staffs);
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var Staff = new Staff() { Id = Id,Name=Name,PhoneNumber=PhoneNumber,Wage = Wage,Position = Position,Email = Email ,BirthDate = BirthDate };

                DataProvider.Ins.DB.Staffs.Add(Staff);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Staff);
            });
            ChangeCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Staffs.Where(x => x.Id == SelectedItem.Id);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Staff = DataProvider.Ins.DB.Staffs.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                Staff.Name = Name;
                Staff.PhoneNumber = PhoneNumber;
                Staff.Position = Position;
                Staff.Email = Email;
                Staff.BirthDate=BirthDate;
                Staff.Id = Id;
                Staff.Wage = Wage;

                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.Name = Name;
            });
            DeleteCommand = new RelayCommand<object>((p) => SelectedItem != null, (p) =>
            {
                var staff = DataProvider.Ins.DB.Staffs.Find(SelectedItem.Id);

                if (staff != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this Staff?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        DataProvider.Ins.DB.Staffs.Remove(staff);
                        DataProvider.Ins.DB.SaveChanges();
                        List.Remove(staff);
                    }
                    DataProvider.Ins.DB.Staffs.Load();

                }
            });
            SearchCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var Staff = new Staff() { Id = Id, Name = Name, PhoneNumber = PhoneNumber, Wage = Wage, Position = Position, Email = Email, BirthDate = BirthDate };

                var listSearch = DataProvider.Ins.DB.Staffs.Where(x => x.Name == Staff.Name).ToList();
                List.Clear();
                foreach (Staff staff in listSearch)
                {
                    List.Add(staff);
                }
            });


        }
    }
}

