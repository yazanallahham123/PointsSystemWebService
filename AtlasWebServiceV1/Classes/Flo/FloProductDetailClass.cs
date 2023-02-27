using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointsSystemWebService.Classes.Flo
{
    public class FloProductDetailClass
    {
        public FLO_ProductModel productModel { get; set; }
        public FLO_Status status { get; set; }
    }

    public class FLO_Option
    {
        public string imageUrl { get; set; }
        public bool isSelected { get; set; }
        public string prodId { get; set; }
        public string prodSku { get; set; }
        public int quantity { get; set; }
        public bool isExist { get; set; }
        public string color { get; set; }
    }

    public class FLO_Size
    {
        public bool isExist { get; set; }
        public string prodSizeId { get; set; }
        public int quantity { get; set; }
        public string shoppingCartId { get; set; }
        public int sizeId { get; set; }
        public string value { get; set; }
    }

    public class FLO_DescriptionField
    {
        public string title { get; set; }
        public string value { get; set; }
    }


    public class FLO_Shipping
    {
        public string title { get; set; }
        public double value { get; set; }
        public int limit { get; set; }
    }

    public class FLO_DeliveryDate
    {
        public string firstDate { get; set; }
        public string lastDate { get; set; }
    }

    public class FLO_ProductFooter
    {
        public FLO_Shipping shipping { get; set; }
        public FLO_DeliveryDate deliveryDate { get; set; }
        public int max_installment { get; set; }
    }

    public class FLO_ProductModel
    {
        public List<int> categoryIds { get; set; }
        public string brand { get; set; }
        public string brandDescription { get; set; }
        public string color { get; set; }
        public string gender { get; set; }
        public List<string> images { get; set; }
        public string installmentOptions { get; set; }
        public string modelCode { get; set; }
        public string name { get; set; }
        public List<FLO_Option> options { get; set; }
        public double price { get; set; }
        public List<object> productBadges { get; set; }
        public string productDescription { get; set; }
        public string productId { get; set; }
        public string productMaterial { get; set; }
        public int screenSku { get; set; }
        public string season { get; set; }
        public string shareUrl { get; set; }
        public string shortDescription { get; set; }
        public string sizeChartLink { get; set; }
        public string sku { get; set; }
        public List<string> thumbs { get; set; }
        public List<FLO_Size> sizes { get; set; }
        public int discountRate { get; set; }
        public List<FLO_DescriptionField> descriptionFields { get; set; }
        public double oldPrice { get; set; }
        public string discountInfo { get; set; }
        public double thirdPrice { get; set; }
        public List<FLO_RuleInfo> ruleInfo { get; set; }
        public FLO_ProductFooter productFooter { get; set; }
    }
}