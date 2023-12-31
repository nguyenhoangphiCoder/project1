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
    
    public partial class Staff:BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            this.Revenues = new HashSet<Revenue>();
            this.Spendings = new HashSet<Spending>();
            this.Users = new HashSet<User>();
        }
    
        private int _Id { get; set; }
        public int Id { get=>_Id; set { _Id = value; OnPropertyChanged(); } }
        private  string _Name { get; set; }
        public string Name { get=>_Name; set { _Name = value;OnPropertyChanged(); } }
        Nullable<System.DateTime> _BirthDate { get; set; }
        public Nullable<System.DateTime> BirthDate { get=>_BirthDate; set { _BirthDate = value;OnPropertyChanged(); }}

        private string _PhoneNumber { get; set; }
        public string PhoneNumber { get => _PhoneNumber; set {  _PhoneNumber = value;OnPropertyChanged(); }}

        private string _Email { get; set; }
        public string Email { get => _Email; set { _Email = value;OnPropertyChanged(); }}

        private string _Position { get; set; }
        public string Position { get => _Position;set { _Position = value;OnPropertyChanged(); }}
        Nullable<int> _Wage { get; set; }
        public Nullable<int> Wage { get=>_Wage; set { _Wage = value;OnPropertyChanged(); } }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Revenue> Revenues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Spending> Spendings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
