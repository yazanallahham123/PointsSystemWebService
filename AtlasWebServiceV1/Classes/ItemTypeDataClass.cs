using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class ItemTypeDataClass
    {
        [DataMember(Order = 1)]
        public ItemTypeClass ItemType;
        [DataMember(Order = 2)]
        public List<ItemDepartmentClass> ItemDepartments;
    }
}