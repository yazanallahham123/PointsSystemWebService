using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class BrandDataClass
    {
        [DataMember(Order = 1)]
        public BrandClass Brand { get; set; }
        [DataMember(Order = 2)]
        public List<BrandDepartmentClass> Departments { get; set; }
    }
}