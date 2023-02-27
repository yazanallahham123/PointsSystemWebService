using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class FCMRegistrationClass
    {
        [DataMember(Order = 1)]
        public int UserId { get; set; }
        [DataMember(Order = 2)]
        public string RegistrationId { get; set; }
        [DataMember(Order = 3)]
        public string Platform { get; set; }
    }
}