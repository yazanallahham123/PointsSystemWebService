using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class BrandDepartmentClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public ItemDepartmentClass Department { get; set; }
        [DataMember(Order = 3)]
        public string ImageURL { get; set; }
        [DataMember(Order = 4)]
        public string WebImageURL { get; set; }
    }
}