using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class OrderDetailSeriesClass
    {
        [DataMember(Order = 1)]
        public OrderDetailClass OrderDetail { get; set; }
        [DataMember(Order = 1)]
        public List<ItemSeriesClass> Series { get; set; }
    }
}