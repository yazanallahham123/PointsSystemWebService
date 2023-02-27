using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class UserSearchClass
    {

        [DataMember(Order = 1)]
        public int Method { get; set; }
        [DataMember(Order = 2)]
        public UserClass User { get; set; }

    }
}