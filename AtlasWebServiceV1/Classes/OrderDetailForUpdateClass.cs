using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class OrderDetailForUpdateClass
    {
        [DataMember(Order = 1)]
        public int Id;
        [DataMember(Order = 2)]
        public int ItemColorId;
        [DataMember(Order = 3)]
        public int ItemSizeId;
        [DataMember(Order = 4)]
        public int Qty;
        [DataMember(Order = 5)]
        public int StatusId;
        [DataMember(Order = 6)]
        public string AdminNote;
        [DataMember(Order = 7)]
        public bool IsPartialDelivery;
        [DataMember(Order = 8)]
        public bool IsFullyDelivered;

    }
}