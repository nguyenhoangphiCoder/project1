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
    
    public partial class User:BaseViewModel
    {
        private int _Id { get; set; }
        public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Username { get; set; }
        public string Username { get => _Username; set {  _Username = value; OnPropertyChanged(); } }

        private string _Password { get; set; }
        public string Password { get => _Password; set {  _Password = value; OnPropertyChanged(); } }

        private string _Name { get; set; }
        public string Name { get => _Name; set {  _Name = value; OnPropertyChanged(); } }
        private string _Role { get; set; }
        public string Role { get => _Role; set {  _Role = value; OnPropertyChanged(); } }
        public Nullable<int> StaffId { get; set; }
    
        public virtual Staff Staff { get; set; }
    }
}