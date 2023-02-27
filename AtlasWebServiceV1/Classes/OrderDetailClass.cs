using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class OrderDetailClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int OrderId { get; set; }
        [DataMember(Order = 3)]
        public int ItemId { get; set; }
        [DataMember(Order = 4)]
        public double Points { get; set; }
        [DataMember(Order = 5)]
        public double Qty { get; set; }
        [DataMember(Order = 6)]
        public string UserNote { get; set; }
        [DataMember(Order = 7)]
        public string AdminNote { get; set; }
        [DataMember(Order = 8)]
        public string ItemArabicName { get; set; }
        [DataMember(Order = 9)]
        public string ItemEnglishName { get; set; }

        [DataMember(Order = 10)]
        public string ImageURL { get; set; }
        [DataMember(Order = 11)]
        public string Code { get; set; }
        [DataMember(Order = 12)]
        public string BrandArabicName { get; set; }
        [DataMember(Order = 13)]
        public string BrandEnglishName { get; set; }
        [DataMember(Order = 14)]
        public string Size { get; set; }
        [DataMember(Order = 15)]
        public string Price { get; set; }
        [DataMember(Order = 16)]
        public string ColorArabicName { get; set; }
        [DataMember(Order = 17)]
        public string ColorEnglishName { get; set; }
        [DataMember(Order = 18)]
        public string CountryArabicName { get; set; }
        [DataMember(Order = 19)]
        public string CountryEnglishName { get; set; }
        [DataMember(Order = 20)]
        public string CreatedDate { get; set; }

        [DataMember(Order = 21)]
        public int QuantityReservationRenewalCount { get; set; }
        [DataMember(Order = 22)]
        public bool HasOffer { get; set; }
        [DataMember(Order = 23)]
        public int OfferId { get; set; }
        [DataMember(Order = 24)]
        public string OfferStartDate { get; set; }
        [DataMember(Order = 25)]
        public bool OfferHasEndDate { get; set; }
        [DataMember(Order = 26)]
        public string OfferEndDate { get; set; }
        [DataMember(Order = 27)]
        public double OfferRequiredPoints { get; set; }
        [DataMember(Order = 28)]
        public bool OfferHasInitQuantity { get; set; }
        [DataMember(Order = 29)]
        public double OfferInitQuantity { get; set; }
        [DataMember(Order = 30)]
        public double OfferRemainingQuantity { get; set; }

        [DataMember(Order = 31)]
        public int UserId { get; set; }
        [DataMember(Order = 32)]
        public int BadgeCount { get; set; }

        [DataMember(Order = 33)]
        public int Order { get; set; }

        [DataMember(Order = 34)]
        public string Notes { get; set; }
        [DataMember(Order = 35)]
        public int ItemColorId { get; set; }
        [DataMember(Order = 36)]
        public int ItemSizeId { get; set; }
        [DataMember(Order = 37)]
        public string DeliveryAddress { get; set; }
        [DataMember(Order = 38)]
        public int CityId { get; set; }
        [DataMember(Order = 39)]
        public int LocationId { get; set; }
        [DataMember(Order = 40)]
        public int GovernorateId { get; set; }
        [DataMember(Order = 41)]
        public string ColorImageURL { get; set; }
        [DataMember(Order = 42)]
        public string HexValue { get; set; }

        [DataMember(Order = 43)]
        public int ColorId { get; set; }
        [DataMember(Order = 44)]
        public int SizeId { get; set; }

        [DataMember(Order = 45)]
        public string SizeArabicName { get; set; }
        [DataMember(Order = 46)]
        public string SizeEnglishName { get; set; }
        [DataMember(Order = 47)]
        public double RequiredPoints { get; set; }
        [DataMember(Order = 48)]
        public double TotalQty { get; set; }
        [DataMember(Order = 49)]
        public bool OfferHasPointsOffer { get; set; }
        [DataMember(Order = 50)]
        public bool OfferHasPriceOffer { get; set; }
        [DataMember(Order = 51)]
        public int PaymentMethodId { get; set; }
        [DataMember(Order = 52)]
        public string OfferPrice { get; set; }
        [DataMember(Order = 53)]
        public string PriceCountryArabicName { get; set; }
        [DataMember(Order = 54)]
        public string PriceCountryEnglishName { get; set; }
        [DataMember(Order = 55)]
        public string PriceCurrencyArabicName { get; set; }
        [DataMember(Order = 56)]
        public string PriceCurrencyEnglishName { get; set; }

        [DataMember(Order = 57)]
        public string PriceTypeArabicName { get; set; }
        [DataMember(Order = 58)]
        public string PriceTypeEnglishName { get; set; }
        [DataMember(Order = 59)]
        public string PriceCurrencyEnglishCode { get; set; }
        [DataMember(Order = 60)]
        public string PriceCurrencyArabicCode { get; set; }
        [DataMember(Order = 61)]
        public string GovernorateArabicName { get; set; }
        [DataMember(Order = 62)]
        public string GovernorateEnglishName { get; set; }
        [DataMember(Order = 63)]
        public string CityArabicName { get; set; }
        [DataMember(Order = 64)]
        public string CityEnglishName { get; set; }
        [DataMember(Order = 65)]
        public string LocationArabicName { get; set; }
        [DataMember(Order = 66)]
        public string LocationEnglishName { get; set; }
        [DataMember(Order = 67)]
        public string PaymentMethodArabicName { get; set; }
        [DataMember(Order = 68)]
        public string PaymentMethodEnglishName { get; set; }
        [DataMember(Order = 69)]
        public string TotalPrice { get; set; }
        [DataMember(Order = 70)]
        public int TotalPoints { get; set; }

        [DataMember(Order = 71)]
        public bool OnRequest { get; set; }
        [DataMember(Order = 72)]
        public int RequestDays { get; set; }
        [DataMember(Order = 73)]
        public int OrderDetailStatusId { get; set; }
        [DataMember(Order = 74)]
        public string OrderDetailStatusArabicName { get; set; }
        [DataMember(Order = 75)]
        public string OrderDetailStatusEnglishName { get; set; }
        [DataMember(Order = 76)]
        public bool IsSeries { get; set; }

        [DataMember(Order = 77)]
        public bool IsPartialDelivery { get; set; }
        [DataMember(Order = 78)]
        public bool IsFullyDelivered { get; set; }

        [DataMember(Order = 78)]
        public int TotalDelivered { get; set; }


        public OrderDetailClass PopulateOrderDetail(string[] fieldNames, SqlDataReader reader)
        {
            var orderDetail = new OrderDetailClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    orderDetail.Id = (int)reader["Id"];

            if (fieldNames.Contains("OrderId"))
                if (!Convert.IsDBNull(reader["OrderId"]))
                    orderDetail.OrderId = (int)reader["OrderId"];

            if (fieldNames.Contains("ItemId"))
                if (!Convert.IsDBNull(reader["ItemId"]))
                    orderDetail.ItemId = (int)reader["ItemId"];

            if (fieldNames.Contains("Points"))
                if (!Convert.IsDBNull(reader["Points"]))
                    orderDetail.Points = Convert.ToDouble(reader["Points"]);

            if (fieldNames.Contains("Qty"))
                if (!Convert.IsDBNull(reader["Qty"]))
                    orderDetail.Qty = Convert.ToDouble(reader["Qty"]);

            if (fieldNames.Contains("UserNote"))
                if (!Convert.IsDBNull(reader["UserNote"]))
                    orderDetail.UserNote = reader["UserNote"].ToString();

            if (fieldNames.Contains("AdminNote"))
                if (!Convert.IsDBNull(reader["AdminNote"]))
                    orderDetail.AdminNote = reader["AdminNote"].ToString();

            if (fieldNames.Contains("ItemArabicName"))
                if (!Convert.IsDBNull(reader["ItemArabicName"]))
                    orderDetail.ItemArabicName = reader["ItemArabicName"].ToString();

            if (fieldNames.Contains("ItemEnglishName"))
                if (!Convert.IsDBNull(reader["ItemEnglishName"]))
                    orderDetail.ItemEnglishName = reader["ItemEnglishName"].ToString();

            if (fieldNames.Contains("ImageURL"))
                if (!Convert.IsDBNull(reader["ImageURL"]))
                    orderDetail.ImageURL = reader["ImageURL"].ToString();

            if (fieldNames.Contains("Code"))
                if (!Convert.IsDBNull(reader["Code"]))
                    orderDetail.Code = reader["Code"].ToString();

            if (fieldNames.Contains("BrandArabicName"))
                if (!Convert.IsDBNull(reader["BrandArabicName"]))
                    orderDetail.BrandArabicName = reader["BrandArabicName"].ToString();

            if (fieldNames.Contains("BrandEnglishName"))
                if (!Convert.IsDBNull(reader["BrandEnglishName"]))
                    orderDetail.BrandEnglishName = reader["BrandEnglishName"].ToString();

            if (fieldNames.Contains("Size"))
                if (!Convert.IsDBNull(reader["Size"]))
                    orderDetail.Size = reader["Size"].ToString();

            if (fieldNames.Contains("Price"))
                if (!Convert.IsDBNull(reader["Price"]))
                    orderDetail.Price = reader["Price"].ToString();

            if (fieldNames.Contains("ColorArabicName"))
                if (!Convert.IsDBNull(reader["ColorArabicName"]))
                    orderDetail.ColorArabicName = reader["ColorArabicName"].ToString();

            if (fieldNames.Contains("ColorEnglishName"))
                if (!Convert.IsDBNull(reader["ColorEnglishName"]))
                    orderDetail.ColorEnglishName = reader["ColorEnglishName"].ToString();

            if (fieldNames.Contains("CountryArabicName"))
                if (!Convert.IsDBNull(reader["CountryArabicName"]))
                    orderDetail.CountryArabicName = reader["CountryArabicName"].ToString();

            if (fieldNames.Contains("CountryEnglishName"))
                if (!Convert.IsDBNull(reader["CountryEnglishName"]))
                    orderDetail.CountryEnglishName = reader["CountryEnglishName"].ToString();

            if (fieldNames.Contains("CreatedDate"))
                if (!Convert.IsDBNull(reader["CreatedDate"]))
                    orderDetail.CreatedDate = reader["CreatedDate"].ToString();

            if (fieldNames.Contains("QuantityReservationRenewalCount"))
                if (!Convert.IsDBNull(reader["QuantityReservationRenewalCount"]))
                    orderDetail.QuantityReservationRenewalCount = (int)reader["QuantityReservationRenewalCount"];


            if (fieldNames.Contains("HasOffer"))
                if (!Convert.IsDBNull(reader["HasOffer"]))
                    orderDetail.HasOffer = (bool)reader["HasOffer"];

            if (fieldNames.Contains("OfferId"))
                if (!Convert.IsDBNull(reader["OfferId"]))
                    orderDetail.OfferId = (int)reader["OfferId"];

            if (fieldNames.Contains("OfferStartDate"))
                if (!Convert.IsDBNull(reader["OfferStartDate"]))
                    orderDetail.OfferStartDate = reader["OfferStartDate"].ToString();

            if (fieldNames.Contains("OfferHasEndDate"))
                if (!Convert.IsDBNull(reader["OfferHasEndDate"]))
                    orderDetail.OfferHasEndDate = (bool)reader["OfferHasEndDate"];

            if (fieldNames.Contains("OfferEndDate"))
                if (!Convert.IsDBNull(reader["OfferEndDate"]))
                    orderDetail.OfferEndDate = reader["OfferEndDate"].ToString();

            if (fieldNames.Contains("OfferRequiredPoints"))
                if (!Convert.IsDBNull(reader["OfferRequiredPoints"]))
                    orderDetail.OfferRequiredPoints = Convert.ToDouble(reader["OfferRequiredPoints"]);

            if (fieldNames.Contains("OfferHasInitQuantity"))
                if (!Convert.IsDBNull(reader["OfferHasInitQuantity"]))
                    orderDetail.OfferHasInitQuantity = (bool)reader["OfferHasInitQuantity"];

            if (fieldNames.Contains("OfferInitQuantity"))
                if (!Convert.IsDBNull(reader["OfferInitQuantity"]))
                    orderDetail.OfferInitQuantity = Convert.ToDouble(reader["OfferInitQuantity"]);

            if (fieldNames.Contains("OfferRemainingQuantity"))
                if (!Convert.IsDBNull(reader["OfferRemainingQuantity"]))
                    orderDetail.OfferRemainingQuantity = Convert.ToDouble(reader["OfferRemainingQuantity"]);

            if (fieldNames.Contains("UserId"))
                if (!Convert.IsDBNull(reader["UserId"]))
                    orderDetail.UserId = (int)reader["UserId"];

            if (fieldNames.Contains("BadgeCount"))
                if (!Convert.IsDBNull(reader["BadgeCount"]))
                    orderDetail.BadgeCount = (int)reader["BadgeCount"];

            if (fieldNames.Contains("Notes"))
                if (!Convert.IsDBNull(reader["Notes"]))
                    orderDetail.Notes = reader["Notes"].ToString();

            if (fieldNames.Contains("ItemColorId"))
                if (!Convert.IsDBNull(reader["ItemColorId"]))
                    orderDetail.ItemColorId = (int)reader["ItemColorId"];

            if (fieldNames.Contains("ItemSizeId"))
                if (!Convert.IsDBNull(reader["ItemSizeId"]))
                    orderDetail.ItemSizeId = (int)reader["ItemSizeId"];

            if (fieldNames.Contains("DeliveryAddress"))
                if (!Convert.IsDBNull(reader["DeliveryAddress"]))
                    orderDetail.DeliveryAddress = reader["DeliveryAddress"].ToString();

            if (fieldNames.Contains("CityId"))
                if (!Convert.IsDBNull(reader["CityId"]))
                    orderDetail.CityId = (int)reader["CityId"];

            if (fieldNames.Contains("LocationId"))
                if (!Convert.IsDBNull(reader["LocationId"]))
                    orderDetail.LocationId = (int)reader["LocationId"];

            if (fieldNames.Contains("GovernorateId"))
                if (!Convert.IsDBNull(reader["GovernorateId"]))
                    orderDetail.GovernorateId = (int)reader["GovernorateId"];

            if (fieldNames.Contains("ColorImageURL"))
                if (!Convert.IsDBNull(reader["ColorImageURL"]))
                    orderDetail.ColorImageURL = reader["ColorImageURL"].ToString();

            if (fieldNames.Contains("HexValue"))
                if (!Convert.IsDBNull(reader["HexValue"]))
                    orderDetail.HexValue = reader["HexValue"].ToString();



            if (fieldNames.Contains("ColorId"))
                if (!Convert.IsDBNull(reader["ColorId"]))
                    orderDetail.ColorId = (int)reader["ColorId"];

            if (fieldNames.Contains("SizeId"))
                if (!Convert.IsDBNull(reader["SizeId"]))
                    orderDetail.SizeId = (int)reader["SizeId"];

            if (fieldNames.Contains("SizeArabicName"))
                if (!Convert.IsDBNull(reader["SizeArabicName"]))
                    orderDetail.SizeArabicName = reader["SizeArabicName"].ToString();

            if (fieldNames.Contains("SizeEnglishName"))
                if (!Convert.IsDBNull(reader["SizeEnglishName"]))
                    orderDetail.SizeEnglishName = reader["SizeEnglishName"].ToString();

            if (fieldNames.Contains("RequiredPoints"))
                if (!Convert.IsDBNull(reader["RequiredPoints"]))
                    orderDetail.RequiredPoints = Convert.ToDouble(reader["RequiredPoints"]);

            if (fieldNames.Contains("TotalQty"))
                if (!Convert.IsDBNull(reader["TotalQty"]))
                    orderDetail.TotalQty = Convert.ToDouble(reader["TotalQty"]);

            if (fieldNames.Contains("OfferPrice"))
                if (!Convert.IsDBNull(reader["OfferPrice"]))
                    orderDetail.OfferPrice = reader["OfferPrice"].ToString();

            if (fieldNames.Contains("OfferHasPointsOffer"))
                if (!Convert.IsDBNull(reader["OfferHasPointsOffer"]))
                    orderDetail.OfferHasPointsOffer = (bool)reader["OfferHasPointsOffer"];

            if (fieldNames.Contains("OfferHasPriceOffer"))
                if (!Convert.IsDBNull(reader["OfferHasPriceOffer"]))
                    orderDetail.OfferHasPriceOffer = (bool)reader["OfferHasPriceOffer"];

            if (fieldNames.Contains("PaymentMethodId"))
                if (!Convert.IsDBNull(reader["PaymentMethodId"]))
                    orderDetail.PaymentMethodId = (int)reader["PaymentMethodId"];

            if (fieldNames.Contains("PaymentMethodArabicName"))
                if (!Convert.IsDBNull(reader["PaymentMethodArabicName"]))
                    orderDetail.PaymentMethodArabicName = reader["PaymentMethodArabicName"].ToString();

            if (fieldNames.Contains("PaymentMethodEnglishName"))
                if (!Convert.IsDBNull(reader["PaymentMethodEnglishName"]))
                    orderDetail.PaymentMethodEnglishName = reader["PaymentMethodEnglishName"].ToString();

            if (fieldNames.Contains("GovernorateArabicName"))
                if (!Convert.IsDBNull(reader["GovernorateArabicName"]))
                    orderDetail.GovernorateArabicName = reader["GovernorateArabicName"].ToString();

            if (fieldNames.Contains("GovernorateEnglishName"))
                if (!Convert.IsDBNull(reader["GovernorateEnglishName"]))
                    orderDetail.GovernorateEnglishName = reader["GovernorateEnglishName"].ToString();

            if (fieldNames.Contains("CityArabicName"))
                if (!Convert.IsDBNull(reader["CityArabicName"]))
                    orderDetail.CityArabicName = reader["CityArabicName"].ToString();

            if (fieldNames.Contains("CityEnglishNAme"))
                if (!Convert.IsDBNull(reader["CityEnglishNAme"]))
                    orderDetail.CityEnglishName = reader["CityEnglishNAme"].ToString();

            if (fieldNames.Contains("LocationArabicName"))
                if (!Convert.IsDBNull(reader["LocationArabicName"]))
                    orderDetail.LocationArabicName = reader["LocationArabicName"].ToString();

            if (fieldNames.Contains("LocationEnglishName"))
                if (!Convert.IsDBNull(reader["LocationEnglishName"]))
                    orderDetail.LocationEnglishName = reader["LocationEnglishName"].ToString();

            if (fieldNames.Contains("PriceCountryArabicName"))
                if (!Convert.IsDBNull(reader["PriceCountryArabicName"]))
                    orderDetail.PriceCountryArabicName = reader["PriceCountryArabicName"].ToString();

            if (fieldNames.Contains("PriceCountryEnglishName"))
                if (!Convert.IsDBNull(reader["PriceCountryEnglishName"]))
                    orderDetail.PriceCountryEnglishName = reader["PriceCountryEnglishName"].ToString();

            if (fieldNames.Contains("PriceCurrencyArabicName"))
                if (!Convert.IsDBNull(reader["PriceCurrencyArabicName"]))
                    orderDetail.PriceCurrencyArabicName = reader["PriceCurrencyArabicName"].ToString();

            if (fieldNames.Contains("PriceCurrencyArabicCode"))
                if (!Convert.IsDBNull(reader["PriceCurrencyArabicCode"]))
                    orderDetail.PriceCurrencyArabicCode = reader["PriceCurrencyArabicCode"].ToString();

            if (fieldNames.Contains("PriceCurrencyEnglishName"))
                if (!Convert.IsDBNull(reader["PriceCurrencyEnglishName"]))
                    orderDetail.PriceCurrencyEnglishName = reader["PriceCurrencyEnglishName"].ToString();

            if (fieldNames.Contains("PriceCurrencyEnglishCode"))
                if (!Convert.IsDBNull(reader["PriceCurrencyEnglishCode"]))
                    orderDetail.PriceCurrencyEnglishCode = reader["PriceCurrencyEnglishCode"].ToString();

            if (fieldNames.Contains("PriceTypeEnglishName"))
                if (!Convert.IsDBNull(reader["PriceTypeEnglishName"]))
                    orderDetail.PriceTypeEnglishName = reader["PriceTypeEnglishName"].ToString();

            if (fieldNames.Contains("PriceTypeArabicName"))
                if (!Convert.IsDBNull(reader["PriceTypeArabicName"]))
                    orderDetail.PriceTypeArabicName = reader["PriceTypeArabicName"].ToString();

            if (fieldNames.Contains("TotalPrice"))
                if (!Convert.IsDBNull(reader["TotalPrice"]))
                    orderDetail.TotalPrice = reader["TotalPrice"].ToString();

            if (fieldNames.Contains("TotalPoints"))
                if (!Convert.IsDBNull(reader["TotalPoints"]))
                    orderDetail.TotalPoints = Convert.ToInt32(reader["TotalPoints"]);

            if (fieldNames.Contains("OnRequest"))
                if (!Convert.IsDBNull(reader["OnRequest"]))
                    orderDetail.OnRequest = Convert.ToBoolean(reader["OnRequest"]);

            if (fieldNames.Contains("RequestDays"))
                if (!Convert.IsDBNull(reader["RequestDays"]))
                    orderDetail.RequestDays = Convert.ToInt32(reader["RequestDays"]);

            if (fieldNames.Contains("OrderDetailStatusId"))
                if (!Convert.IsDBNull(reader["OrderDetailStatusId"]))
                    orderDetail.OrderDetailStatusId = Convert.ToInt32(reader["OrderDetailStatusId"]);

            if (fieldNames.Contains("OrderDetailStatusArabicName"))
                if (!Convert.IsDBNull(reader["OrderDetailStatusArabicName"]))
                    orderDetail.OrderDetailStatusArabicName = reader["OrderDetailStatusArabicName"].ToString();

            if (fieldNames.Contains("OrderDetailStatusEnglishName"))
                if (!Convert.IsDBNull(reader["OrderDetailStatusEnglishName"]))
                    orderDetail.OrderDetailStatusEnglishName = reader["OrderDetailStatusEnglishName"].ToString();

            if (fieldNames.Contains("IsSeries"))
                if (!Convert.IsDBNull(reader["IsSeries"]))
                    orderDetail.IsSeries = (bool)reader["IsSeries"];

            if (fieldNames.Contains("IsPartialDelivery"))
                if (!Convert.IsDBNull(reader["IsPartialDelivery"]))
                    orderDetail.IsPartialDelivery = Convert.ToBoolean(reader["IsPartialDelivery"]);

            if (fieldNames.Contains("IsFullyDelivered"))
                if (!Convert.IsDBNull(reader["IsFullyDelivered"]))
                    orderDetail.IsFullyDelivered = Convert.ToBoolean(reader["IsFullyDelivered"]);

            if (fieldNames.Contains("TotalDelivered"))
                if (!Convert.IsDBNull(reader["TotalDelivered"]))
                    orderDetail.TotalDelivered = (int)reader["TotalDelivered"];

            return orderDetail;
        }

    }
}