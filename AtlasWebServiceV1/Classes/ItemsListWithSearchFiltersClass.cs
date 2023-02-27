using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class ItemsListWithSearchFiltersClass
    {
        [DataMember(Order = 1)]
        public List<ItemClass> ItemsList { get; set; }
        [DataMember(Order = 2)]
        public ItemFiltersClass ItemFilters { get; set; }
    }
}