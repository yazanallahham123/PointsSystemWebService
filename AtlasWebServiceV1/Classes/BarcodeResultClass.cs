using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class BarcodeResultClass
    {
        [DataMember(Order = 1)]
        public List<BarcodesClass> SuccessBarcodes { get; set; }
        [DataMember(Order = 1)]
        public List<BarcodesClass> FailedBarcodes { get; set; }
    }
}