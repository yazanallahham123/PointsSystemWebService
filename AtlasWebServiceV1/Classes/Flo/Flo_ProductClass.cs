using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes.Flo
{
    [DataContract]
    public class Flo_ProductClass
    {
        [DataMember(Order = 1)]
        public string sku { get; set; }
        [DataMember(Order = 2)]
        public string imageUrl { get; set; }
        [DataMember(Order = 3)]
        public double price { get; set; }
        [DataMember(Order = 4)]
        public string brandName { get; set; }
        [DataMember(Order = 5)]
        public string name { get; set; }
    }
}