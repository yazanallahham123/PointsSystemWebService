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
    
    public partial class ItemBookingDaysTbl
    {
        public int Id { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<int> DayId { get; set; }
    
        public virtual DaysTbl DaysTbl { get; set; }
        public virtual DaysTbl DaysTbl1 { get; set; }
        public virtual ItemsTbl ItemsTbl { get; set; }
    }
}
