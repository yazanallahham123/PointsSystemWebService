using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class OrderDetailQtyClass
    {
        [DataMember(Order = 1)]
        public int DetailId;
        [DataMember(Order = 2)]
        public int Qty;
    }
}