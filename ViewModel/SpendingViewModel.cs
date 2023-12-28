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
    public  class SpendingViewModel:BaseViewModel
    {
        private ObservableCollection<Spending> _List;
        public ObservableCollection<Spending> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private Spending _SelectedItem;
        public Spending SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Id = SelectedItem.Id;
                    TotalSpending = (Decimal)SelectedItem.TotalSpending;
                    Date = SelectedItem.Date;
                    Describe=SelectedItem.Describe;

                }
            }
        }
        private int _Id;
        public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private Decimal _TotalSpending;
        public Decimal TotalSpending { get => _TotalSpending; set { _TotalSpending = value; OnPropertyChanged(); } }

        private DateTime? _Date;
        public DateTime? Date { get => _Date; set { _Date = value; OnPropertyChanged(); } }
        private string _Describe;
        public string Describe { get => _Describe; set { _Describe = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand ChangeCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        public SpendingViewModel()
        {
            List = new ObservableCollection<Spending>(DataProvider.Ins.DB.Spendings);
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var Spending = new Spending() { Id = Id, TotalSpending = TotalSpending, Date = Date,Describe=Describe };

                DataProvider.Ins.DB.Spendings.Add(Spending);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(Spending);
            });
            ChangeCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Spendings.Where(x => x.Id == SelectedItem.Id);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Spending = DataProvider.Ins.DB.Spendings.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                Spending.TotalSpending=TotalSpending;
                Spending.Date = Date;
                Spending.Id = Id;
                Spending.Describe = Describe;


                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.TotalSpending = TotalSpending;
            });
            DeleteCommand = new RelayCommand<object>((p) => SelectedItem != null, (p) =>
            {
                var spending = DataProvider.Ins.DB.Spendings.Find(SelectedItem.Id);

                if (spending != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this Spending?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        DataProvider.Ins.DB.Spendings.Remove(spending);
                        DataProvider.Ins.DB.SaveChanges();
                        List.Remove(spending);
                    }
                    DataProvider.Ins.DB.Spendings.Load();

                }
            });
            SearchCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var Spending = new Spending() { Id = Id, TotalSpending = TotalSpending, Date = Date, Describe = Describe };

                var listSearch = DataProvider.Ins.DB.Spendings.Where(x => x.Date == Spending.Date).ToList();
                List.Clear();
                foreach (Spending spending in listSearch)
                {
                    List.Add(spending);
                }
            });


        }
    }
}
