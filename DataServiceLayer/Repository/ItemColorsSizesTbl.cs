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
    
    public partial class ItemColorsSizesTbl
    {
        public int Id { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<int> ItemColorId { get; set; }
        public Nullable<int> ItemSizeId { get; set; }
        public Nullable<bool> Disabled { get; set; }
        public Nullable<int> CountryId { get; set; }
    
        public virtual ItemsTbl ItemsTbl { get; set; }
    }
}
