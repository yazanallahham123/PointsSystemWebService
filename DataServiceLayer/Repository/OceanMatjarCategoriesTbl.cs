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
    
    public partial class OceanMatjarCategoriesTbl
    {
        public int Id { get; set; }
        public string OceanCategoryId { get; set; }
        public Nullable<int> OceanCategoryType { get; set; }
        public string OceanParentCategoryId { get; set; }
        public Nullable<int> OceanParentCategoryType { get; set; }
        public Nullable<int> MatjarCategoryId { get; set; }
        public Nullable<int> MatjarCategoryType { get; set; }
        public Nullable<int> MatjarParentCategoryId { get; set; }
        public Nullable<int> MatjarParentCategoryType { get; set; }
    
        public virtual CategoriesTbl CategoriesTbl { get; set; }
        public virtual CategoriesTbl CategoriesTbl1 { get; set; }
    }
}
