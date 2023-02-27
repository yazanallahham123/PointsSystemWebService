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
    
    public partial class CouponsTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CouponsTbl()
        {
            this.UsersCouponTbl = new HashSet<UsersCouponTbl>();
        }
    
        public int Id { get; set; }
        public int CouponTypeId { get; set; }
        public string CouponSerial { get; set; }
        public decimal CouponValue { get; set; }
        public System.DateTime StartDate { get; set; }
        public bool HasEndDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public int CouponValueType { get; set; }
    
        public virtual CouponTypesTbl CouponTypesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersCouponTbl> UsersCouponTbl { get; set; }
    }
}
