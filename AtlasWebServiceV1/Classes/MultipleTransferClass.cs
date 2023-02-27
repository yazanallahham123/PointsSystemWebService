using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class MultipleTransferClass
    {
        [DataMember(Order = 1)]
        public bool Successful { get; set; }
        [DataMember(Order = 2)]
        public TransferClass TransferResult{ get; set; }
    }
}