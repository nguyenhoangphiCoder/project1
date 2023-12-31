//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Phanmemquanlybanhang.Model
{
    using Phanmemquanlybanhang.ViewModel;
    using System;
    using System.Collections.Generic;
    
    public partial class Product:BaseViewModel
    {
        private int _Id { get; set; }
        public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _ProductName { get; set; }
        public string ProductName { get => _ProductName; set { _ProductName = value;OnPropertyChanged(); } }
        private string _MachineType { get; set; }
        public string MachineType { get => _MachineType; set { _MachineType = value;OnPropertyChanged(); } }
        private int _Quantity { get; set; }
        public int Quantity { get => _Quantity; set { _Quantity = value; OnPropertyChanged(); } }
        private Decimal _Price { get; set; }
        public  Decimal Price { get => _Price; set { _Price = value; OnPropertyChanged(); } }
        private string _Status { get; set; }
        public string Status { get=>_Status; set { _Status = value;OnPropertyChanged(); } }
        private string _Description { get; set; }
        public string Description { get => _Description;set { _Description = value;OnPropertyChanged(); } }

        public Nullable<int> SuplierId { get; set; }

        private Suplier _Suplier;
        public virtual Suplier Suplier { get => _Suplier; set { _Suplier = value; OnPropertyChanged(); } }

        
    }
}
