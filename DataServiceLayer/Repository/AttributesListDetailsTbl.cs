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
    
    public partial class AttributesListDetailsTbl
    {
        public int Id { get; set; }
        public Nullable<int> AttributeListId { get; set; }
        public Nullable<int> ColumnId { get; set; }
        public string ColumnName { get; set; }
        public Nullable<int> ColumnValueType { get; set; }
    
        public virtual AttributesListsTbl AttributesListsTbl { get; set; }
    }
}