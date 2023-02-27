using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class StyleDataClass
    {
        [DataMember(Order = 1)]
        public StyleClass Style { get; set; }
        [DataMember(Order = 2)]
        public List<StyleTagClass> StyleTags { get; set; }
        [DataMember(Order = 3)]
        public List<StyleDetailDataClass> StyleDetailsData { get; set; }
        [DataMember(Order = 4)]
        public List<ItemClass> StyleTagsItems { get; set; }
        [DataMember(Order = 4)]
        public List<StyleActionClass> StyleActions { get; set; }
    }
}