using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class CountryViewModel
    {
        [DataMember(Order = 1)]
        public string nativeName { get; set; }
        [DataMember(Order = 2)]
        public string flag { get; set; }
        [DataMember(Order = 3)]
        public string alpha2Code { get; set; }
        [DataMember(Order = 4)]
        public List<string> callingCodes { get; set; }
    }
}