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
    
    public partial class NotificationsUsersTbl
    {
        public int Id { get; set; }
        public int NotificationsTypeId { get; set; }
        public int UserId { get; set; }
        public Nullable<int> LoggedUser { get; set; }
    
        public virtual NotificationsTypesTbl NotificationsTypesTbl { get; set; }
        public virtual UsersTbl UsersTbl { get; set; }
    }
}
