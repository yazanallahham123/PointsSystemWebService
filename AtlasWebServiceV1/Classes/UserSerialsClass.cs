using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class UserSerialsClass
    {
        [DataMember(Order = 1)]
        public List<ItemSerialClass> ItemSerials { get; set; }

        [DataMember(Order = 2)]
        public List<UnknownSerialClass> UnknownSerials { get; set; }
    }
}