using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class ItemColorDataClass
    {
        [DataMember(Order = 1)]
        public ItemColorClass ItemColor;
        [DataMember(Order = 2)]
        public List<ItemColorPriceAddClass> ItemColorPrices;
    }
}