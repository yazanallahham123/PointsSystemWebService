using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class FatoraCancelPaymentClass
    {
        [DataMember(Order = 1)]
        public string lang { get; set; }
        [DataMember(Order = 2)]
        public string payment_id { get; set; }
    }
}