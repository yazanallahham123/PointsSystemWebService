using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   public class OrderDetailsReport
   {
      [DataMember(Order = 1)]
      public bool FilterDates { get; set; }
      [DataMember(Order = 2)]
      public string FromDate { get; set; }
      [DataMember(Order = 3)]
      public string ToDate { get; set; }
      [DataMember(Order = 4)]
      public List<int> OfferIds { get; set; }
      [DataMember(Order = 5)]
      public bool FilterUser { get; set; }
      [DataMember(Order = 6)]
      public List<int> UserIds { get; set; }
   }
}