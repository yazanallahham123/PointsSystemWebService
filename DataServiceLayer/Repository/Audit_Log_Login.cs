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
    
    public partial class Audit_Log_Login
    {
        public int Id { get; set; }
        public string LoginType { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> CreatedData { get; set; }
        public string AccessToken { get; set; }
    }
}
