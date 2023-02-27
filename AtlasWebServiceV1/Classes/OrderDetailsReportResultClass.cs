using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class OrderDetailsReportResultClass
   {
      [DataMember(Order = 1)]
      public OrderClass OrderClass { get; set; }
      [DataMember(Order = 2)]
      public OrderDetailClass OrderDetail { get; set; }
      [DataMember(Order = 3)]
      public int Order { get; set; }
   }
}