using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class ItemDepartmentDataClass
    {
        [DataMember(Order = 1)]
        public ItemDepartmentClass ItemDepartment { get; set; }
        [DataMember(Order = 2)]
        public List<ItemDepartmentImageClass> ItemDepartmentImages { get; set; }


    }
}