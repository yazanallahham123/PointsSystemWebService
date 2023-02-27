using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class ItemFiltersClass
    {
        [DataMember(Order = 1)]
        public List<ColorClass> Colors { get; set; }
        [DataMember(Order = 2)]
        public List<CountryClass> Countries { get; set; }
        [DataMember(Order = 3)]
        public List<BrandClass> Brands { get; set; }
        //[DataMember(Order = 4)]
        //public List<CategoryClass> Categories { get; set; }
        //[DataMember(Order = 5)]
        //public List<CategoryMapClass> CategoriesMap { get; set; }
        [DataMember(Order = 6)]
        public List<SizeClass> Sizes { get; set; }
        [DataMember(Order = 7)]
        public Tuple<Int64, Int64> MinMaxPrice = new Tuple<Int64, Int64>(0, 0);
        [DataMember(Order = 8)]
        public Tuple<Int64, Int64> MinMaxRequiredPoints = new Tuple<Int64, Int64>(0, 0);

        [DataMember(Order = 9)]
        public string CurrencyArabicCode { get; set; }
        [DataMember(Order = 10)]
        public string CurrencyEnglishCode { get; set; }

        [DataMember(Order = 11)]
        public List<ItemTypeClass> ItemTypes { get; set; }
        [DataMember(Order = 12)]
        public List<ItemDepartmentClass> ItemDepartments { get; set; }
        [DataMember(Order = 13)]
        public List<TagsTypeClass> TagsTypes { get; set; }
    }
}