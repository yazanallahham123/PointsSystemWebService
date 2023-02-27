using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class FatoraCheckPaymentStatusDataClass
    {
        [DataMember(Order = 1)]
        public string status { get; set; }
        [DataMember(Order = 2)]
        public string creationTimestamp { get; set; }
        [DataMember(Order = 3)]
        public string rrn { get; set; }
        [DataMember(Order = 4)]
        public double amount { get; set; }
        [DataMember(Order = 5)]
        public string terminalId { get; set; }
        [DataMember(Order = 6)]
        public string notes { get; set; }
    }
}