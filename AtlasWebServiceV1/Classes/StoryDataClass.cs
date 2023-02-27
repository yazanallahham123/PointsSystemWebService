using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class StoryDataClass
    {
        [DataMember(Order = 1)]
        public StoryClass Story { get; set; }
        [DataMember(Order = 2)]
        public List<ItemDepartmentClass> StoryDepartments { get; set; }
    }
}