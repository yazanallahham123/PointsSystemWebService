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
    
    public partial class StoriesTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StoriesTbl()
        {
            this.StoryDepartmentsTbl = new HashSet<StoryDepartmentsTbl>();
            this.StoryDetailsTbl = new HashSet<StoryDetailsTbl>();
        }
    
        public int Id { get; set; }
        public Nullable<int> TypeId { get; set; }
        public Nullable<int> ReferenceId { get; set; }
        public string ArabicTitle { get; set; }
        public string EnglishTitle { get; set; }
        public string ImageURL { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> VisitsCount { get; set; }
        public Nullable<int> LoggedUser { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoryDepartmentsTbl> StoryDepartmentsTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoryDetailsTbl> StoryDetailsTbl { get; set; }
    }
}
