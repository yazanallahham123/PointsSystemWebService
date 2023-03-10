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
    
    public partial class UsersTypesTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsersTypesTbl()
        {
            this.ItemsUsersTypesTbl = new HashSet<ItemsUsersTypesTbl>();
            this.OffersUsersTypesTbl = new HashSet<OffersUsersTypesTbl>();
            this.UserGiftsRulesTbl = new HashSet<UserGiftsRulesTbl>();
            this.UserSendRulesTbl = new HashSet<UserSendRulesTbl>();
            this.UsersPermissionsTemplatesTbl = new HashSet<UsersPermissionsTemplatesTbl>();
            this.UserTypeGiftsRulesTbl = new HashSet<UserTypeGiftsRulesTbl>();
            this.UserTypeGiftsRulesTbl1 = new HashSet<UserTypeGiftsRulesTbl>();
            this.UserTypeSendRulesTbl = new HashSet<UserTypeSendRulesTbl>();
            this.UserTypeSendRulesTbl1 = new HashSet<UserTypeSendRulesTbl>();
            this.UserTypeWithdrawRulesTbl = new HashSet<UserTypeWithdrawRulesTbl>();
            this.UserTypeWithdrawRulesTbl1 = new HashSet<UserTypeWithdrawRulesTbl>();
            this.UserWithdrawRulesTbl = new HashSet<UserWithdrawRulesTbl>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> LoggedUser { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemsUsersTypesTbl> ItemsUsersTypesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OffersUsersTypesTbl> OffersUsersTypesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserGiftsRulesTbl> UserGiftsRulesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSendRulesTbl> UserSendRulesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersPermissionsTemplatesTbl> UsersPermissionsTemplatesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserTypeGiftsRulesTbl> UserTypeGiftsRulesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserTypeGiftsRulesTbl> UserTypeGiftsRulesTbl1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserTypeSendRulesTbl> UserTypeSendRulesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserTypeSendRulesTbl> UserTypeSendRulesTbl1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserTypeWithdrawRulesTbl> UserTypeWithdrawRulesTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserTypeWithdrawRulesTbl> UserTypeWithdrawRulesTbl1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserWithdrawRulesTbl> UserWithdrawRulesTbl { get; set; }
    }
}
