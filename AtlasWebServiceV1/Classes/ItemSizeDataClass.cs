using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class ItemSizeDataClass
    {
        [DataMember(Order = 1)]
        public ItemSizeClass ItemSize;
        [DataMember(Order = 2)]
        public List<ItemSizePriceAddClass> ItemSizePrices;
    }
}