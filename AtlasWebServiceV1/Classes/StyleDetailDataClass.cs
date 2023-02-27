using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class StyleDetailDataClass
    {
        [DataMember(Order = 3)]
        public StyleDetailClass StyleDetail { get; set; }
        [DataMember(Order = 4)]
        public List<StyleDetailImageClass> StyleDetailsImages { get; set; }
        [DataMember(Order = 5)]
        public List<StyleDetailItemClass> StyleDetailsItems { get; set; }
        [DataMember(Order = 4)]
        public int Order { get; set; }
    }
}