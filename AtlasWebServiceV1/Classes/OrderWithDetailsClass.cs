using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class OrderWithDetailsClass
    {
        [DataMember(Order = 1)]
        public OrderClass Order { get; set; }
        [DataMember(Order = 2)]
        public List<OrderDetailClass> OrderDetails { get; set; }
        [DataMember(Order = 3)]
        public List<OrderDetailSeriesClass> OrderDetailsSeries { get; set; }
    }
}