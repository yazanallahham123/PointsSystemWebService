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
    
    public partial class SizesTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SizesTbl()
        {
            this.BarcodesTbl = new HashSet<BarcodesTbl>();
            this.ItemSizesTbl = new HashSet<ItemSizesTbl>();
            this.OceanMatjarSizesTbl = new HashSet<OceanMatjarSizesTbl>();
        }
    
        public int Id { get; set; }
        public int SizeGroupId { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string Code { get; set; }
        public Nullable<int> LoggedUser { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BarcodesTbl> BarcodesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemSizesTbl> ItemSizesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OceanMatjarSizesTbl> OceanMatjarSizesTbl { get; set; }
        public virtual SizesGroupsTbl SizesGroupsTbl { get; set; }
    }
}
