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
    using System.Windows;

    public partial class Customer:BaseViewModel
    {
      
        private int _Id {  get; set; }
        public int Id { get=>_Id; set { _Id = value;OnPropertyChanged(); } }
        private string _Name { get; set; }
        public string Name { get=>_Name; set { _Name = value;OnPropertyChanged(); } }
        private string _Address { get; set; }
        public string Address { get=>_Address; set { _Address = value;OnPropertyChanged(); } }
        private string _Phone { get; set; }
        public string Phone { get=>_Phone; set { _Phone = value;OnPropertyChanged(); } }
        private string _Email { get; set; }
        public string Email { get=>_Email; set { _Email = value;OnPropertyChanged(); } }
        Nullable<System.DateTime> _Day;
        public Nullable<System.DateTime> Day { get=>_Day; set { _Day = value;OnPropertyChanged(); } }
    }
}
