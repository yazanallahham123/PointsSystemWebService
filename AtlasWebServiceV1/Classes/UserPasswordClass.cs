using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class UserPasswordClass
    {
        [DataMember(Order = 1)]
        public int UserId { get; set; }
        [DataMember(Order = 2)]
        public string Password { get; set; }
    }
}