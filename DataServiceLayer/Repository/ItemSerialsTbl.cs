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
    
    public partial class ItemSerialsTbl
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Serial { get; set; }
        public Nullable<bool> IsScanned { get; set; }
        public Nullable<int> ScannerUserId { get; set; }
        public Nullable<System.DateTime> ScanningDate { get; set; }
        public Nullable<int> ScanningPoints { get; set; }
        public Nullable<bool> Disabled { get; set; }
        public string Notes { get; set; }
        public Nullable<bool> IsChecked { get; set; }
        public Nullable<System.DateTime> CheckDate { get; set; }
        public Nullable<int> CheckerUserId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> GiftedPoints { get; set; }
    
        public virtual ItemsTbl ItemsTbl { get; set; }
    }
}