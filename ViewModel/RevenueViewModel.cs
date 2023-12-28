using Phanmemquanlybanhang.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Phanmemquanlybanhang.ViewModel
{
    public class RevenueViewModel:BaseViewModel
    {
        private ObservableCollection<Revenue> _List;
        public ObservableCollection<Revenue> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private Revenue _SelectedItem;
        public Revenue SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Id = SelectedItem.Id;
                    TotalRevenue = (Decimal)SelectedItem.TotalRevenue;
                    Date = SelectedItem.Date;
                   
                }
            }
        }
        private int _Id;
        public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private Decimal _TotalRevenue;
        public Decimal TotalRevenue { get => _TotalRevenue; set { _TotalRevenue = value; OnPropertyChanged(); } }
        
        private DateTime? _Date;
        public DateTime? Date { get => _Date; set { _Date = value; OnPropertyChanged(); } }
      
        public ICommand AddCommand { get; set; }
        public ICommand ChangeCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public RevenueViewModel()
        {
            List = new ObservableCollection<Revenue>(DataProvider.Ins.DB.Revenues);
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var Revenue = new Revenue() { Id = Id, TotalRevenue=TotalRevenue, Date = Date };

                DataProvider.Ins.DB.Revenues.Add(Revenue);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Revenue);
            });
            ChangeCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Revenues.Where(x => x.Id == SelectedItem.Id);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Revenue = DataProvider.Ins.DB.Revenues.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                Revenue.TotalRevenue = TotalRevenue;
                Revenue.Date = Date;
                Revenue.Id = Id;
               

                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.TotalRevenue=TotalRevenue;
            });
            DeleteCommand = new RelayCommand<object>((p) => SelectedItem != null, (p) =>
            {
                var revenue = DataProvider.Ins.DB.Revenues.Find(SelectedItem.Id);

                if (revenue != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this Revenue?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        DataProvider.Ins.DB.Revenues.Remove(revenue);
                        DataProvider.Ins.DB.SaveChanges();
                        List.Remove(revenue);
                    }
                    DataProvider.Ins.DB.Revenues.Load();

                }
            });

            SearchCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var revenue = new Revenue() { Id = Id, TotalRevenue = TotalRevenue, Date = Date };
                var listSearch = DataProvider.Ins.DB.Revenues.Where(x => x.Date == revenue.Date).ToList();
                List.Clear();
                foreach (Revenue Revenue in listSearch)
                {
                    List.Add(Revenue);
                }
            });

        }
    }
}
