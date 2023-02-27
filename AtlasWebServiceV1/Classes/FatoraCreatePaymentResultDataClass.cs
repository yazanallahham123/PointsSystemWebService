using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class FatoraCreatePaymentResultDataClass
    {
        [DataMember(Order = 1)]
        public string paymentId { get; set; }
        [DataMember(Order = 2)]
        public string url { get; set; }
    }
}