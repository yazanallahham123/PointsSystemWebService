using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class FatoraCheckPaymentStatusResultClass
    {
        [DataMember(Order = 1)]
        public FatoraCheckPaymentStatusDataClass Data { get; set; }
        [DataMember(Order = 2)]
        public int ErrorCode { get; set; }
        [DataMember(Order = 3)]
        public string ErrorMessage { get; set; }
    }
}