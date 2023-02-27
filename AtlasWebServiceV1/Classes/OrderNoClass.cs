using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class OrderNoClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int OrderNo { get; set; }
    }
}