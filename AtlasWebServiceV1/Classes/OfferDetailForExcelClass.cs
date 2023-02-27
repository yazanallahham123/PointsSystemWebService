using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class OfferDetailForExcelClass
    {
        [DataMember(Order = 1)]
        public int ItemId { get; set; }
        [DataMember(Order = 2)]
        public string OfferPrice { get; set; }
        [DataMember(Order = 2)]
        public string OfferPoints { get; set; }
        [DataMember(Order = 2)]
        public int CountryId { get; set; }
        [DataMember(Order = 2)]
        public int CurrencyId { get; set; }
        [DataMember(Order = 2)]
        public int CountryCurrencyId { get; set; }
        [DataMember(Order = 2)]
        public int PriceTypeId { get; set; }
        [DataMember(Order = 2)]
        public string OfferGrantedPoints { get; set; }
        [DataMember(Order = 2)]
        public int SizeGroupId { get; set; }
        [DataMember(Order = 2)]
        public int SizeId { get; set; }
        [DataMember(Order = 2)]
        public int ColorId { get; set; }
        [DataMember(Order = 2)]
        public bool IsSpecialOffer { get; set; }

    }
}