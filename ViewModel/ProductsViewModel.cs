using Phanmemquanlybanhang.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace Phanmemquanlybanhang.ViewModel
{
    public class ProductsViewModel : BaseViewModel
    {
        private ObservableCollection<Product> _List;
        public ObservableCollection<Product> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private Product _SelectedItem;
        public Product SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                   Id = SelectedItem.Id;
                    ProductName =SelectedItem.ProductName;
                    Quantity = SelectedItem.Quantity;
                    Description = SelectedItem.Description;
                    Price=SelectedItem.Price;
                    Status = SelectedItem.Status;
                    MachineType = SelectedItem.MachineType;



                }
            }
        }
        private int _Id;
        public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _ProductName;
        public string ProductName { get => _ProductName; set { _ProductName = value; OnPropertyChanged(); } }
        private string _Description;
        public string Description { get => _Description; set {  _Description = value; OnPropertyChanged(); } }
        private string _MachineType;
        public string MachineType { get => _MachineType; set { _MachineType = value; OnPropertyChanged(); } }
        private int _Quantity;
        public int Quantity { get => _Quantity;set { _Quantity = value;OnPropertyChanged(); } }
        private Decimal _Price;
        public Decimal Price { get => _Price; set {  _Price = value; OnPropertyChanged(); } }
        private string _Status;
        public string Status { get => _Status; set {  _Status = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand ChangeCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ProductsViewModel()
        {
            List = new ObservableCollection<Product>(DataProvider.Ins.DB.Products);
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var product = new Product() { Id = Id,ProductName=ProductName,Status=Status,Price = Price,Description = Description,MachineType = MachineType,Quantity = Quantity };

                DataProvider.Ins.DB.Products.Add(product);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(product);
            });
            ChangeCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.Products.Where(x => x.Id == SelectedItem.Id);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var production = DataProvider.Ins.DB.Products.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                production.Id = SelectedItem.Id;
                production.Description = Description;
                production.Status = Status;
                production.Price = Price;
                production.Quantity = Quantity;
                production.MachineType = MachineType;
                production.ProductName = ProductName;

                DataProvider.Ins.DB.SaveChanges();

               SelectedItem.ProductName = ProductName;
            });
            DeleteCommand = new RelayCommand<object>((p) => SelectedItem != null, (p) =>
            {
                var product = DataProvider.Ins.DB.Products.Find(SelectedItem.Id);

                if (product != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this Product?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        DataProvider.Ins.DB.Products.Remove(product);
                        DataProvider.Ins.DB.SaveChanges();
                        List.Remove(product);
                    }
                    DataProvider.Ins.DB.Products.Load();

                }
            });
            SearchCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var     Product = new Product() { Id = Id, ProductName = ProductName, Status = Status, Price = Price, Description = Description, MachineType = MachineType, Quantity = Quantity };

                var listSearch = DataProvider.Ins.DB.Products.Where(x => x.ProductName == Product.ProductName).ToList();
                List.Clear();
                foreach (Product product in listSearch)
                {
                    List.Add(product);
                }
            });



        }

    }
}
