using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class VerifyMobileNumberClass
    {
        [DataMember(Order = 1)]
        public string request_id { get; set; }

        [DataMember(Order = 2)]
        public string status{ get; set; }

        [DataMember(Order = 3)]
        public string error_text { get; set; }
    }
}