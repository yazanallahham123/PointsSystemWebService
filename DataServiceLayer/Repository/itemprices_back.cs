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
    
    public partial class itemprices_back
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public int TypeId { get; set; }
        public int CountryCurrencyId { get; set; }
        public Nullable<int> LoggedUser { get; set; }
    }
}
