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
    
    public partial class BarcodesTbl
    {
        public int Id { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<int> SizeId { get; set; }
        public Nullable<int> ColorId { get; set; }
        public string Barcode { get; set; }
        public string Barcode2 { get; set; }
        public Nullable<int> ServerId { get; set; }
        public Nullable<double> Quantity { get; set; }
    
        public virtual ColorsTbl ColorsTbl { get; set; }
        public virtual ItemsTbl ItemsTbl { get; set; }
        public virtual SizesTbl SizesTbl { get; set; }
    }
}
