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
    
    public partial class WeightsTbl
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public Nullable<int> TypeId { get; set; }
        public Nullable<int> DeptId { get; set; }
        public Nullable<decimal> Weight { get; set; }
    }
}
