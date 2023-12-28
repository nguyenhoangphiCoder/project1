using Phanmemquanlybanhang.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace Phanmemquanlybanhang.ViewModel
{
    public class CustomersViewModel: BaseViewModel
    {
        private ObservableCollection<Customer> _List;
        public ObservableCollection<Customer> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private Customer _SelectedItem;
        public Customer SelectedItem 
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
                    Email = SelectedItem.Email;
                    Phone = SelectedItem.Phone;
                    Address = SelectedItem.Address;
                    Day=SelectedItem.Day;
                }
            }
        }


        private int _Id;
        public int Id { get=>_Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name;set { _Name = value;OnPropertyChanged(); } }
        private string _Email;
        public string Email { get => _Email;set { _Email = value;OnPropertyChanged(); } }
        private string _Phone;
        public string Phone { get => _Phone; set {  _Phone = value;OnPropertyChanged(); } }
        private string _Address;
        public string Address { get => _Address; set {  _Address = value;OnPropertyChanged(); } }
        private DateTime? _Day;
        public DateTime? Day { get => _Day; set {  _Day = value;OnPropertyChanged(); } }
       
        public ICommand AddCommand { get; set; }
        public ICommand ChangeCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public CustomersViewModel()
        {
            List = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var Customer = new Customer() { Id = Id, Name = Name, Phone = Phone, Address = Address, Email = Email, Day = Day };

                DataProvider.Ins.DB.Customers.Add(Customer);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Customer);
            });
            ChangeCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                var displayList = DataProvider.Ins.DB.Customers.Where(x => x.Id == SelectedItem.Id);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Customer = DataProvider.Ins.DB.Customers.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                Customer.Name = Name;
                Customer.Phone = Phone;
                Customer.Address = Address;
                Customer.Email = Email;
                Customer.Day = Day;
                Customer.Id = Id;

                DataProvider.Ins.DB.SaveChanges();
                SelectedItem.Name = Name;
            });
            DeleteCommand = new RelayCommand<object>((p) => SelectedItem != null, (p) =>
            {
                var customer = DataProvider.Ins.DB.Customers.Find(SelectedItem.Id);

                if (customer != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        DataProvider.Ins.DB.Customers.Remove(customer);
                        DataProvider.Ins.DB.SaveChanges();
                        List.Remove(customer);
                    }
                    DataProvider.Ins.DB.Customers.Load();

                }
            });
            SearchCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var Customer = new Customer() { Id = Id, Name = Name, Phone = Phone, Address = Address, Email = Email, Day = Day };

                var listSearch = DataProvider.Ins.DB.Customers.Where(x => x.Name == Customer.Name).ToList();
                List.Clear();
                foreach(Customer customer in listSearch)
                {
                    List.Add(customer);
                }
            });

        }
        
    }
}

