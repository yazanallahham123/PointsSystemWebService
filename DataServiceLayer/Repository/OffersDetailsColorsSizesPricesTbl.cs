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
    
    public partial class OffersDetailsColorsSizesPricesTbl
    {
        public int Id { get; set; }
        public int OfferDetailId { get; set; }
        public int CountryCurrencyId { get; set; }
        public int PriceTypeId { get; set; }
        public decimal Price { get; set; }
        public Nullable<int> RequiredPoints { get; set; }
        public Nullable<int> ItemColorId { get; set; }
        public Nullable<int> ItemSizeId { get; set; }
        public Nullable<int> GrantedPoints { get; set; }
    
        public virtual OffersDetailsTbl OffersDetailsTbl { get; set; }
    }
}
