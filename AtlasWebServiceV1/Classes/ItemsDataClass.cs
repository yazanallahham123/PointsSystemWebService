using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class ItemsDataClass
    {
        [DataMember(Order = 1)]
        public ItemClass ItemClass { get; set; }
        [DataMember(Order = 2)]
        public List<ItemsGovernorateClass> Governorates { get; set; }
        [DataMember(Order = 3)]
        public List<ItemsCompanyClass> Companies { get; set; }
        [DataMember(Order = 4)]
        public List<ItemsUsersTypeClass> UsersTypes { get; set; }
        [DataMember(Order = 5)]
        public List<ItemImageClass> Images { get; set; }
        [DataMember(Order = 6)]
        public List<ItemSizeClass> Sizes { get; set; }
        [DataMember(Order = 7)]
        public List<ItemColorClass> Colors { get; set; }
        [DataMember(Order = 8)]
        public List<ItemPriceClass> Prices { get; set; }
        [DataMember(Order = 9)]
        public List<ItemPriceClass> ConfigPrices { get; set; }
        [DataMember(Order = 10)]
        public List<ItemsCountryClass> Countries { get; set; }

        [DataMember(Order = 11)]
        public CategoriesWithMapClass CategoriesMap { get; set; }
        [DataMember(Order = 12)]
        public List<ItemBookingDayClass> BookingDays { get; set; }

        [DataMember(Order = 13)]
        public List<ItemSeriesClass> Series { get; set; }

        [DataMember(Order = 14)]
        public bool HasSeries { get; set; }


        [DataMember(Order = 15)]
        public List<ItemClass> MatchedItems { get; set; }

        [DataMember(Order = 16)]
        public List<ItemSerialClass> Serials { get; set; }

        [DataMember(Order = 17)]
        public List<ItemTagClass> Tags { get; set; }

        [DataMember(Order = 18)]
        public List<ItemSizePriceAddClass> SizesPrices { get; set; }

        [DataMember(Order = 19)]
        public List<ItemColorPriceAddClass> ColorsPrices { get; set; }

    }
}