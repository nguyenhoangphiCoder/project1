using Phanmemquanlybanhang.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace Phanmemquanlybanhang.ViewModel
{
    public class SuplierViewModel:BaseViewModel
    {
        private ObservableCollection<Suplier> _List;
        public ObservableCollection<Suplier> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private Suplier _SelectedItem;
        public Suplier SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Id = SelectedItem.Id;
                    SuplierName = SelectedItem.SuplierName;
                    Email = SelectedItem.Email;
                    PhoneNumber = SelectedItem.PhoneNumber;
                    Address = SelectedItem.Address;
                    ContracDate = SelectedItem.ContracDate;
                }
            }
        }
        private int _Id;
        public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _SuplierName;
        public string SuplierName { get => _SuplierName; set { _SuplierName = value; OnPropertyChanged(); } }
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _PhoneNumber;
        public string PhoneNumber { get => _PhoneNumber; set { _PhoneNumber = value; OnPropertyChanged(); } }
        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }
        private DateTime? _ContracDate;
        public DateTime? ContracDate { get => _ContracDate; set { _ContracDate = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand ChangeCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public SuplierViewModel()
        {
            List = new ObservableCollection<Suplier>(DataProvider.Ins.DB.Supliers);
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var Suplier = new Suplier() { Id = Id, SuplierName = SuplierName, PhoneNumber = PhoneNumber, Address = Address, Email = Email, ContracDate=ContracDate};

                DataProvider.Ins.DB.Supliers.Add(Suplier);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Suplier);
            });
            ChangeCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Supliers.Where(x => x.Id == SelectedItem.Id);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Suplier = DataProvider.Ins.DB.Supliers.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                Suplier.SuplierName = SuplierName;
                Suplier.PhoneNumber = PhoneNumber;
                Suplier.Address = Address;
                Suplier.Email = Email;
                Suplier.ContracDate =ContracDate;
                Suplier.Id = Id;

                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.SuplierName = SuplierName;
            });
            DeleteCommand = new RelayCommand<object>((p) => SelectedItem != null, (p) =>
            {
                var suplier = DataProvider.Ins.DB.Supliers.Find(SelectedItem.Id);

                if (suplier != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this Suplier?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        DataProvider.Ins.DB.Supliers.Remove(suplier);
                        DataProvider.Ins.DB.SaveChanges();
                        List.Remove(suplier);
                    }
                    DataProvider.Ins.DB.Supliers.Load();

                }
            });
            SearchCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var Suplier = new Suplier() { Id = Id, SuplierName = SuplierName, PhoneNumber = PhoneNumber, Address = Address, Email = Email, ContracDate = ContracDate };

                var listSearch = DataProvider.Ins.DB.Supliers.Where(x => x.SuplierName == Suplier.SuplierName).ToList();
                List.Clear();
                foreach (Suplier suplier in listSearch)
                {
                    List.Add(suplier);
                }
            });


        }

    }
}
