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
    
    public partial class ItemMatchedItemsTbl
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int MatchedItemId { get; set; }
    
        public virtual ItemsTbl ItemsTbl { get; set; }
        public virtual ItemsTbl ItemsTbl1 { get; set; }
    }
}
