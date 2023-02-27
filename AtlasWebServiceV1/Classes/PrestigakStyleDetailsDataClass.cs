using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class PrestigakStyleDetailsDataClass
    {
        [DataMember(Order = 1)]
        public StyleDataClass StyleData { get; set; }
        [DataMember(Order = 2)]
        public List<StoryClass> Stories { get; set; }
    }
}