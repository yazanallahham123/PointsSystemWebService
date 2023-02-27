using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class ItemResultClass
    {
        [DataMember(Order = 1)]
        public ItemClass Item;
        [DataMember(Order = 2)]
        public int Status;
    }
}