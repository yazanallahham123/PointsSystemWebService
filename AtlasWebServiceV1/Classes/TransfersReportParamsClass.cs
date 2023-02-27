using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   public class TransfersReportParamsClass
   {
      [DataMember(Order = 1)]
      public List<int> Sender_UserIds { get; set; }
      [DataMember(Order = 2)]
      public List<int> Receiver_UserIds { get; set; }
      [DataMember(Order = 3)]
      public bool FilterDates { get; set; }
      [DataMember(Order = 4)]
      public string FromDate { get; set; }
      [DataMember(Order = 5)]
      public string ToDate { get; set; }
      [DataMember(Order = 6)]
      public bool FilterTransferMethod { get; set; }
      [DataMember(Order = 7)]
      public string TransferMethodId { get; set; }
      [DataMember(Order = 8)]
      public bool FilterTransferStatus { get; set; }
      [DataMember(Order = 9)]
      public string TransferStatusId { get; set; }

   }
}