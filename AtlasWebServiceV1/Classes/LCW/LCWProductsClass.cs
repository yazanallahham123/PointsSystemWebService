using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointsSystemWebService.Classes.LCW
{
    public class LCWProductsClass
    {
        public List<LCWSortingOption> sortingOptions { get; set; }
        public List<LCWFilter> filters { get; set; }
        public bool isDiscountedProducts { get; set; }
        public LCWSelectedFiltersInfo selectedFiltersInfo { get; set; }
        public List<LCWProduct> products { get; set; }
        public LCWStatus status { get; set; }
    }

    public class LCWSortingOption
    {
        public string value { get; set; }
        public string key { get; set; }
        public string selectedMessage { get; set; }
    }

    public class LCWFilterItem
    {
        public int value { get; set; }
        public string title { get; set; }
        public string filterItemStatus { get; set; }
        public string instanceType { get; set; }
        public string iconPath { get; set; }
    }

    public class LCWFilter
    {
        public string title { get; set; }
        public string filterType { get; set; }
        public bool justSelected { get; set; }
        public string filterId { get; set; }
        public List<LCWFilterItem> filterItems { get; set; }
        public string instanceType { get; set; }
        public int displayOrder { get; set; }
    }

    public class LCWSelectedFiltersInfo
    {
    }

    public class LCWProduct
    {
        public string title { get; set; }
        public bool outlet { get; set; }
        public bool discounted { get; set; }
        public string productCode { get; set; }
        public int modelId { get; set; }
        public bool favourite { get; set; }
        public int optionId { get; set; }
        public string productGroup { get; set; }
        public double originalPrice { get; set; }
        public string brandName { get; set; }
        public string price { get; set; }
        public string imageUrl { get; set; }
        public string oldPrice { get; set; }
        public double? originalOldPrice { get; set; }
    }

    public class LCWStatus
    {
        public string message { get; set; }
        public int code { get; set; }
    }

}