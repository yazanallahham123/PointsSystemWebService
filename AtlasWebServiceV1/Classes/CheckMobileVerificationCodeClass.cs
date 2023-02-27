using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class CheckMobileVerificationCodeClass
    {
        [DataMember(Order = 1)]
        public string status { get; set; }

        [DataMember(Order = 2)]
        public string error_text { get; set; }

        [DataMember(Order = 3)]
        public UserClass User { get; set; }

        [DataMember(Order = 3)]
        public bool IsAlreadyRegistered { get; set; }

    }
}