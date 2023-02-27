using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointsSystemWebService.Classes.Flo
{
    public class FloProductsClass
    {
        public List<FLO_Product> products { get; set; }
        public string categoryTitle { get; set; }
        public int totalResultCount { get; set; }
        public List<FLO_SortingOption> sortingOptions { get; set; }
        public List<FLO_Filter> filters { get; set; }
        public FLO_SelectedFiltersInfo selectedFiltersInfo { get; set; }
        public FLO_Status status { get; set; }
    }


    public class FLO_SnapBuyFilters
    {
    }

    public class FLO_RuleInfo
    {
        public double third_price { get; set; }
        public double amount { get; set; }
        public string name { get; set; }
        public string label { get; set; }
        public string description { get; set; }
    }

    public class FLO_Product
    {
        public string brandName { get; set; }
        public List<object> productBadges { get; set; }
        public string productId { get; set; }
        public string sku { get; set; }
        public List<int> categoryIds { get; set; }
        public double price { get; set; }
        public string price_currency { get; set; }
        public string imageUrl { get; set; }
        public string thumbUrl { get; set; }
        public FLO_SnapBuyFilters snapBuyFilters { get; set; }
        public bool available { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public int discountRate { get; set; }
        public double oldPrice { get; set; }
        public string discountInfo { get; set; }
        public double? thirdPrice { get; set; }
        public List<FLO_RuleInfo> ruleInfo { get; set; }
    }

    public class FLO_SortingOption
    {
        public string selectedMessage { get; set; }
        public string value { get; set; }
        public string key { get; set; }
    }

    public class FLO_Item
    {
        public string filterId { get; set; }
        public bool selected { get; set; }
        public string filterValue { get; set; }
        public string colorValue { get; set; }
        public string colorUrl { get; set; }
    }

    public class FLO_Filter
    {
        public string filterKey { get; set; }
        public string filterTitle { get; set; }
        public string filterItemType { get; set; }
        public bool singleChoice { get; set; }
        public List<FLO_Item> items { get; set; }
    }

    public class FLO_SelectedFiltersInfo
    {
    }

    public class FLO_Status
    {
        public int code { get; set; }
        public string message { get; set; }
        public string token { get; set; }
    }

}