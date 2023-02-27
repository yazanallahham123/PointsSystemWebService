using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class CategoryDataClass
    {
        [DataMember(Order = 1)]
        public CategoryClass CategoryClass { get; set; }
        [DataMember(Order = 2)]
        public List<CategoryCountryClass> Countries { get; set; }
    }
}