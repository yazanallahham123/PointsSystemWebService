//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataServiceLayer.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class CitiesTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CitiesTbl()
        {
            this.OrderDetailsTbl = new HashSet<OrderDetailsTbl>();
            this.UsersTbl = new HashSet<UsersTbl>();
        }
    
        public int Id { get; set; }
        public Nullable<int> GovernorateId { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public Nullable<int> LoggedUser { get; set; }
    
        public virtual GovernoratesTbl GovernoratesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetailsTbl> OrderDetailsTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersTbl> UsersTbl { get; set; }
    }
}
