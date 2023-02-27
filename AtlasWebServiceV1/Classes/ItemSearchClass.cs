using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class ItemSearchClass
    {
        [DataMember(Order = 1)]
        public string ArabicName { get; set; }
        [DataMember(Order = 2)]
        public string EnglishName { get; set; }
        [DataMember(Order = 3)]
        public string Code { get; set; }
        [DataMember(Order = 4)]
        public string ArabicDescription { get; set; }
        [DataMember(Order = 5)]
        public string EnglishDescription { get; set; }
        [DataMember(Order = 6)]
        public bool FilterByBrandId { get; set; }
        [DataMember(Order = 7)]
        public List<int> BrandIds { get; set; }
        [DataMember(Order = 8)]
        public bool FilterByColorId { get; set; }
        [DataMember(Order = 9)]
        public List<int> ColorIds { get; set; }
        [DataMember(Order = 10)]
        public string Size { get; set; }
        [DataMember(Order = 11)]
        public bool FilterByCountryId { get; set; }
        [DataMember(Order = 12)]
        public List<int> CountryIds { get; set; }
        [DataMember(Order = 13)]
        public bool FilterByPrice { get; set; }
        [DataMember(Order = 13)]
        public double MinPrice { get; set; }
        [DataMember(Order = 13)]
        public double MaxPrice { get; set; }
        [DataMember(Order = 13)]
        public bool FilterByRequiredPoints { get; set; }
        [DataMember(Order = 14)]
        public double MinRequiredPoints { get; set; }
        [DataMember(Order = 14)]
        public double MaxRequiredPoints { get; set; }
        [DataMember(Order = 15)]
        public bool FilterByDisabled { get; set; }
        [DataMember(Order = 16)]
        public bool Disabled { get; set; }
        [DataMember(Order = 17)]
        public string Notes { get; set; }
        [DataMember(Order = 18)]
        public bool FilterByCategoryId { get; set; }
        [DataMember(Order = 19)]
        public List<int> CategoryIds { get; set; }
        [DataMember(Order = 20)]
        public bool FilterByOffers { get; set; }
        [DataMember(Order = 21)]
        public bool ShowOnlyItemsWithOffers { get; set; }


        [DataMember(Order = 22)]
        public bool FilterByUserGovernorate { get; set; }
        [DataMember(Order = 23)]
        public List<int> UserGovernorateIds { get; set; }
        [DataMember(Order = 24)]
        public bool FilterByUserCompany { get; set; }
        [DataMember(Order = 25)]
        public List<int> UserCompanyIds { get; set; }
        [DataMember(Order = 26)]
        public bool FilterByUserType { get; set; }
        [DataMember(Order = 27)]
        public List<int> UserTypes { get; set; }

        [DataMember(Order = 28)]
        public bool FilterBySizeId { get; set; }
        [DataMember(Order = 29)]
        public List<int> SizeIds { get; set; }

        [DataMember(Order = 30)]
        public bool FilterByUserCountry { get; set; }
        [DataMember(Order = 31)]
        public List<int> UserCountryIds { get; set; }

        [DataMember(Order = 32)]
        public bool ForReports { get; set; }

        [DataMember(Order = 33)]
        public string Text { get; set; }

        [DataMember(Order = 34)]
        public bool FilterByItemTypeId { get; set; }
        [DataMember(Order = 35)]
        public List<int> ItemTypeIds { get; set; }
        [DataMember(Order = 36)]
        public bool FilterByItemDepartmentId { get; set; }
        [DataMember(Order = 37)]
        public List<int> ItemDepartmentIds { get; set; }
        [DataMember(Order = 38)]
        public bool FilterByTags { get; set; }
        [DataMember(Order = 39)]
        public List<int> TagsIds { get; set; }

        [DataMember(Order = 40)]
        public bool FilterByItemIds { get; set; }

        [DataMember(Order = 41)]
        public List<int> ItemIds { get; set; }
        [DataMember(Order = 42)]
        public bool ShowOnlyItemsWithSpecialOffers { get; set; }
    }
}