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
    
    public partial class ItemDepartmentImagesTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemDepartmentImagesTbl()
        {
            this.ItemDepartmentImageCountriesTbl = new HashSet<ItemDepartmentImageCountriesTbl>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ItemDepartmentId { get; set; }
        public string ImageURL { get; set; }
        public Nullable<int> ReferenceTypeId { get; set; }
        public Nullable<int> ReferenceId { get; set; }
        public string WebImageURL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemDepartmentImageCountriesTbl> ItemDepartmentImageCountriesTbl { get; set; }
        public virtual ItemDepartmentsTbl ItemDepartmentsTbl { get; set; }
    }
}
