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
    
    public partial class TransfersResultTbl
    {
        public System.Guid Id { get; set; }
        public string Receiver_UserId { get; set; }
        public string Receiver_UserFullName { get; set; }
        public string Sender_UserId { get; set; }
        public string Sender_UserFullName { get; set; }
        public double Amount { get; set; }
        public string Note { get; set; }
        public int TransferResultStatus { get; set; }
        public Nullable<int> TransferErrorCode { get; set; }
    }
}