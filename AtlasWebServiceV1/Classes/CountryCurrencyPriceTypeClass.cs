using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class CountryCurrencyPriceTypeClass
    {
        [DataMember(Order = 1)]
        public List<ItemPriceClass> Prices { get; set; }

        [DataMember(Order = 2)]
        public List<ItemPriceClass> ConfigPrices { get; set; }
    }
}