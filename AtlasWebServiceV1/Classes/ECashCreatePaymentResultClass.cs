using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class ECashCreatePaymentResultClass
    {
        [DataMember(Order = 1)]
        public string Url {get; set;}
    }
}