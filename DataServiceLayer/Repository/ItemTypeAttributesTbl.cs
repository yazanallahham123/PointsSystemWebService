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
    
    public partial class ItemTypeAttributesTbl
    {
        public int Id { get; set; }
        public Nullable<int> ItemTypeId { get; set; }
        public string AttributeArabicName { get; set; }
        public string AttributeEnglishName { get; set; }
        public Nullable<int> AttributeType { get; set; }
        public Nullable<int> AttrbuteListId { get; set; }
    
        public virtual AttributesListsTbl AttributesListsTbl { get; set; }
        public virtual ItemTypesTbl ItemTypesTbl { get; set; }
    }
}
