using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class ItemClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string ArabicName { get; set; }
        [DataMember(Order = 3)]
        public string EnglishName { get; set; }
        [DataMember(Order = 4)]
        public string Code { get; set; }
        [DataMember(Order = 5)]
        public string ArabicDescription { get; set; }
        [DataMember(Order = 6)]
        public string EnglishDescription { get; set; }
        [DataMember(Order = 7)]
        public int BrandId { get; set; }
        //[DataMember(Order = 8)]
        //public int ColorId { get; set; }
        //[DataMember(Order = 9)]
        //public string Size { get; set; }
        [DataMember(Order = 10)]
        public int CountryId { get; set; }

        [DataMember(Order = 11)]
        public int DefaultPriceTypeId { get; set; }
        [DataMember(Order = 11)]
        public string DefaultPriceTypeArabicName { get; set; }
        [DataMember(Order = 11)]
        public string DefaultPriceTypeEnglishName { get; set; }

        [DataMember(Order = 12)]
        public string Price { get; set; }
        [DataMember(Order = 13)]
        public double RequiredPoints { get; set; }
        [DataMember(Order = 14)]
        public double GrantedPoints { get; set; }

        [DataMember(Order = 15)]
        public bool Disabled { get; set; }
        [DataMember(Order = 16)]
        public string Notes { get; set; }
        [DataMember(Order = 17)]
        public string ImageURL { get; set; }
        [DataMember(Order = 18)]
        public int CreatedBy { get; set; }
        [DataMember(Order = 19)]
        public int UpdatedBy { get; set; }
        [DataMember(Order = 20)]
        public string CreateDate { get; set; }
        [DataMember(Order = 21)]
        public string UpdateDate { get; set; }
        [DataMember(Order = 22)]
        public int CategoryId { get; set; }
        [DataMember(Order = 23)]
        public string BrandArabicName { get; set; }
        [DataMember(Order = 24)]
        public string BrandEnglishName { get; set; }
        //[DataMember(Order = 23)]
        //public string ColorArabicName { get; set; }
        //[DataMember(Order = 24)]
        //public string ColorEnglishName { get; set; }
        [DataMember(Order = 25)]
        public string CountryArabicName { get; set; }
        [DataMember(Order = 26)]
        public string CountryEnglishName { get; set; }
        [DataMember(Order = 27)]
        public string CreatedByUsername { get; set; }
        [DataMember(Order = 28)]
        public string CreatedByFullName { get; set; }
        [DataMember(Order = 29)]
        public string UpdatedByUsername { get; set; }
        [DataMember(Order = 30)]
        public string UpdatedByFullName { get; set; }
        [DataMember(Order = 31)]
        public string CategoryArabicName { get; set; }
        [DataMember(Order = 32)]
        public string CategoryEnglishName { get; set; }

        [DataMember(Order = 33)]
        public bool HasOffer { get; set; }
        [DataMember(Order = 34)]
        public int OfferId { get; set; }
        [DataMember(Order = 35)]
        public string OfferStartDate { get; set; }
        [DataMember(Order = 36)]
        public bool OfferHasEndDate { get; set; }
        [DataMember(Order = 37)]
        public string OfferEndDate { get; set; }
        [DataMember(Order = 38)]
        public bool OfferItemHasInitQuantity { get; set; }
        [DataMember(Order = 39)]
        public double OfferItemInitQuantity { get; set; }
        [DataMember(Order = 40)]
        public double OfferItemRemainingQuantity { get; set; }
        [DataMember(Order = 41)]
        public double OfferItemSoldQuantity { get; set; }
        [DataMember(Order = 42)]
        public double OfferItemRequiredPoints { get; set; }

        [DataMember(Order = 43)]
        public int Order { get; set; }

        [DataMember(Order = 44)]
        public bool IsLiked { get; set; }
        [DataMember(Order = 45)]
        public int TotalLike { get; set; }
        [DataMember(Order = 46)]
        public bool InWishlist { get; set; }
        [DataMember(Order = 47)]
        public double AvgRating { get; set; }
        [DataMember(Order = 48)]
        public int UserRating { get; set; }
        //[DataMember(Order = 49)]
        //public double ItemPrice { get; set; }
        [DataMember(Order = 50)]
        public string TypeName { get; set; }
        [DataMember(Order = 51)]
        public int TotalCount { get; set; }

        [DataMember(Order = 52)]
        public string Param1 { get; set; }
        [DataMember(Order = 53)]
        public string Param2 { get; set; }

        [DataMember(Order = 53)]
        public int PriceTypeId { get; set; }
        [DataMember(Order = 53)]
        public string PriceTypeArabicName { get; set; }
        [DataMember(Order = 53)]
        public string PriceTypeEnglishName { get; set; }
        [DataMember(Order = 53)]
        public int PriceCountryId { get; set; }
        [DataMember(Order = 53)]
        public string PriceCountryArabicName { get; set; }
        [DataMember(Order = 53)]
        public string PriceCountryEnglishName { get; set; }
        [DataMember(Order = 53)]
        public int PriceCurrencyId { get; set; }
        [DataMember(Order = 53)]
        public string PriceCurrencyArabicName { get; set; }
        [DataMember(Order = 53)]
        public string PriceCurrencyArabicCode { get; set; }
        [DataMember(Order = 53)]
        public string PriceCurrencyEnglishName { get; set; }
        [DataMember(Order = 53)]
        public string PriceCurrencyEnglishCode { get; set; }
        [DataMember(Order = 54)]
        public string SizeImageURL { get; set; }


        [DataMember(Order = 55)]
        public bool OfferHasPointsOffer { get; set; }
        [DataMember(Order = 56)]
        public bool OfferHasPriceOffer { get; set; }
        [DataMember(Order = 57)]
        public int OfferPriceOfferType { get; set; }
        [DataMember(Order = 58)]
        public string OfferPrice { get; set; }
        [DataMember(Order = 59)]
        public int ItemTypeId { get; set; }
        [DataMember(Order = 60)]
        public string ItemTypeArabicName { get; set; }
        [DataMember(Order = 61)]
        public string ItemTypeEnglishName { get; set; }
        [DataMember(Order = 62)]
        public int ItemDepartmentId { get; set; }
        [DataMember(Order = 63)]
        public string ItemDepartmentArabicName { get; set; }
        [DataMember(Order = 64)]
        public string ItemDepartmentEnglishName { get; set; }
        [DataMember(Order = 65)]
        public bool HasStartDateBooking { get; set; }
        [DataMember(Order = 66)]
        public string StartDateBooking { get; set; }
        [DataMember(Order = 67)]
        public bool HasEndDateBooking { get; set; }
        [DataMember(Order = 68)]
        public string EndDateBooking { get; set; }

        [DataMember(Order = 69)]
        public bool IsWholeSale { get; set; }
        [DataMember(Order = 70)]
        public int OrderNo { get; set; }

        [DataMember(Order = 71)]
        public bool OnRequest { get; set; }
        [DataMember(Order = 72)]
        public string OnRequestArabicMessage { get; set; }
        [DataMember(Order = 73)]
        public string OnRequestEnglishMessage { get; set; }
        [DataMember(Order = 74)]
        public int OnRequestDays { get; set; }

        [DataMember(Order = 75)]
        public string ItemURL { get; set; }

        [DataMember(Order = 76)]
        public string ArabicTitle { get; set; }

        [DataMember(Order = 77)]
        public string EnglishTitle { get; set; }

        [DataMember(Order = 78)]
        public bool ShowCarouselInItemsList { get; set; }

        [DataMember(Order = 79)]
        public bool ShowDescriptionInItemsList { get; set; }
        [DataMember(Order = 80)]
        public List<ItemImageClass> ItemImages { get; set; }
        [DataMember(Order = 81)]
        public int StyleId { get; set; }
        [DataMember(Order = 82)]
        public double OfferItemGrantedPoints { get; set; }
        [DataMember(Order = 83)]
        public bool IsSpecialOffer { get; set; }

        [DataMember(Order = 83)]
        public int StockLevel { get; set; }

        public ItemClass PopulateItemClass(string[] fieldNames, SqlDataReader reader)
        {
            var item = new ItemClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    item.Id = Convert.ToInt32(reader["Id"]);

            if (fieldNames.Contains("ArabicName"))
                if (!Convert.IsDBNull(reader["ArabicName"]))
                    item.ArabicName = reader["ArabicName"].ToString();

            if (fieldNames.Contains("EnglishName"))
                if (!Convert.IsDBNull(reader["EnglishName"]))
                    item.EnglishName = reader["EnglishName"].ToString();

            if (fieldNames.Contains("Code"))
                if (!Convert.IsDBNull(reader["Code"]))
                    item.Code = reader["Code"].ToString();

            if (fieldNames.Contains("ArabicDescription"))
                if (!Convert.IsDBNull(reader["ArabicDescription"]))
                    item.ArabicDescription = reader["ArabicDescription"].ToString();

            if (fieldNames.Contains("EnglishDescription"))
                if (!Convert.IsDBNull(reader["EnglishDescription"]))
                    item.EnglishDescription = reader["EnglishDescription"].ToString();

            if (fieldNames.Contains("BrandId"))
                if (!Convert.IsDBNull(reader["BrandId"]))
                    item.BrandId = Convert.ToInt32(reader["BrandId"]);

            //if (fieldNames.Contains("ColorId"))
            //   if (!Convert.IsDBNull(reader["ColorId"]))
            //      item.ColorId = (int)reader["ColorId"];

            //if (fieldNames.Contains("Size"))
            //   if (!Convert.IsDBNull(reader["Size"]))
            //      item.Size = reader["Size"].ToString();


            if (fieldNames.Contains("CountryId"))
                if (!Convert.IsDBNull(reader["CountryId"]))
                    item.CountryId = Convert.ToInt32(reader["CountryId"]);


            if (fieldNames.Contains("DefaultPriceTypeId"))
                if (!Convert.IsDBNull(reader["DefaultPriceTypeId"]))
                    item.DefaultPriceTypeId = Convert.ToInt32(reader["DefaultPriceTypeId"]);

            if (fieldNames.Contains("DefaultPriceTypeArabicName"))
                if (!Convert.IsDBNull(reader["DefaultPriceTypeArabicName"]))
                    item.DefaultPriceTypeArabicName = reader["DefaultPriceTypeArabicName"].ToString();

            if (fieldNames.Contains("DefaultPriceTypeEnglishName"))
                if (!Convert.IsDBNull(reader["DefaultPriceTypeEnglishName"]))
                    item.DefaultPriceTypeEnglishName = reader["DefaultPriceTypeEnglishName"].ToString();

            if (fieldNames.Contains("Price"))
                if (!Convert.IsDBNull(reader["Price"]))
                    item.Price = reader["Price"].ToString();

            if (fieldNames.Contains("RequiredPoints"))
                if (!Convert.IsDBNull(reader["RequiredPoints"]))
                    item.RequiredPoints = Convert.ToDouble(reader["RequiredPoints"]);

            if (fieldNames.Contains("GrantedPoints"))
                if (!Convert.IsDBNull(reader["GrantedPoints"]))
                    item.GrantedPoints = Convert.ToDouble(reader["GrantedPoints"]);

            if (fieldNames.Contains("Disabled"))
                if (!Convert.IsDBNull(reader["Disabled"]))
                    item.Disabled = Convert.ToBoolean(reader["Disabled"]);

            if (fieldNames.Contains("Notes"))
                if (!Convert.IsDBNull(reader["Notes"]))
                    item.Notes = reader["Notes"].ToString();

            if (fieldNames.Contains("ImageURL"))
                if (!Convert.IsDBNull(reader["ImageURL"]))
                    item.ImageURL = reader["ImageURL"].ToString();

            if (fieldNames.Contains("CreatedBy"))
                if (!Convert.IsDBNull(reader["CreatedBy"]))
                    item.CreatedBy = Convert.ToInt32(reader["CreatedBy"]);

            if (fieldNames.Contains("UpdatedBy"))
                if (!Convert.IsDBNull(reader["UpdatedBy"]))
                    item.UpdatedBy = Convert.ToInt32(reader["UpdatedBy"]);

            if (fieldNames.Contains("CreateDate"))
                if (!Convert.IsDBNull(reader["CreateDate"]))
                    item.CreateDate = reader["CreateDate"].ToString();

            if (fieldNames.Contains("UpdateDate"))
                if (!Convert.IsDBNull(reader["UpdateDate"]))
                    item.UpdateDate = reader["UpdateDate"].ToString();

            if (fieldNames.Contains("CategoryId"))
                if (!Convert.IsDBNull(reader["CategoryId"]))
                    item.CategoryId = Convert.ToInt32(reader["CategoryId"]);

            if (fieldNames.Contains("BrandArabicName"))
                if (!Convert.IsDBNull(reader["BrandArabicName"]))
                    item.BrandArabicName = reader["BrandArabicName"].ToString();

            if (fieldNames.Contains("BrandEnglishName"))
                if (!Convert.IsDBNull(reader["BrandEnglishName"]))
                    item.BrandEnglishName = reader["BrandEnglishName"].ToString();

            //if (fieldNames.Contains("ColorArabicName"))
            //   if (!Convert.IsDBNull(reader["ColorArabicName"]))
            //      item.ColorArabicName = reader["ColorArabicName"].ToString();

            //if (fieldNames.Contains("ColorEnglishName"))
            //   if (!Convert.IsDBNull(reader["ColorEnglishName"]))
            //      item.ColorEnglishName = reader["ColorEnglishName"].ToString();


            if (fieldNames.Contains("CountryArabicName"))
                if (!Convert.IsDBNull(reader["CountryArabicName"]))
                    item.CountryArabicName = reader["CountryArabicName"].ToString();

            if (fieldNames.Contains("CountryEnglishName"))
                if (!Convert.IsDBNull(reader["CountryEnglishName"]))
                    item.CountryEnglishName = reader["CountryEnglishName"].ToString();

            if (fieldNames.Contains("CreatedByUsername"))
                if (!Convert.IsDBNull(reader["CreatedByUsername"]))
                    item.CreatedByUsername = reader["CreatedByUsername"].ToString();

            if (fieldNames.Contains("CreatedByFullName"))
                if (!Convert.IsDBNull(reader["CreatedByFullName"]))
                    item.CreatedByFullName = reader["CreatedByFullName"].ToString();

            if (fieldNames.Contains("UpdatedByUsername"))
                if (!Convert.IsDBNull(reader["UpdatedByUsername"]))
                    item.UpdatedByUsername = reader["UpdatedByUsername"].ToString();

            if (fieldNames.Contains("UpdatedByFullName"))
                if (!Convert.IsDBNull(reader["UpdatedByFullName"]))
                    item.UpdatedByFullName = reader["UpdatedByFullName"].ToString();

            if (fieldNames.Contains("CategoryArabicName"))
                if (!Convert.IsDBNull(reader["CategoryArabicName"]))
                    item.CategoryArabicName = reader["CategoryArabicName"].ToString();

            if (fieldNames.Contains("CategoryEnglishName"))
                if (!Convert.IsDBNull(reader["CategoryEnglishName"]))
                    item.CategoryEnglishName = reader["CategoryEnglishName"].ToString();


            if (fieldNames.Contains("HasOffer"))
                if (!Convert.IsDBNull(reader["HasOffer"]))
                    item.HasOffer = Convert.ToBoolean(reader["HasOffer"]);

            if (fieldNames.Contains("OfferId"))
                if (!Convert.IsDBNull(reader["OfferId"]))
                    item.OfferId = Convert.ToInt32(reader["OfferId"]);

            if (fieldNames.Contains("OfferStartDate"))
                if (!Convert.IsDBNull(reader["OfferStartDate"]))
                    item.OfferStartDate = reader["OfferStartDate"].ToString();

            if (fieldNames.Contains("OfferHasEndDate"))
                if (!Convert.IsDBNull(reader["OfferHasEndDate"]))
                    item.OfferHasEndDate = Convert.ToBoolean(reader["OfferHasEndDate"]);

            if (fieldNames.Contains("OfferEndDate"))
                if (!Convert.IsDBNull(reader["OfferEndDate"]))
                    item.OfferEndDate = reader["OfferEndDate"].ToString();

            if (fieldNames.Contains("OfferItemHasInitQuantity"))
                if (!Convert.IsDBNull(reader["OfferItemHasInitQuantity"]))
                    item.OfferItemHasInitQuantity = Convert.ToBoolean(reader["OfferItemHasInitQuantity"]);

            if (fieldNames.Contains("OfferItemRemainingQuantity"))
                if (!Convert.IsDBNull(reader["OfferItemRemainingQuantity"]))
                    item.OfferItemRemainingQuantity = Convert.ToDouble(reader["OfferItemRemainingQuantity"]);

            if (fieldNames.Contains("OfferItemSoldQuantity"))
                if (!Convert.IsDBNull(reader["OfferItemSoldQuantity"]))
                    item.OfferItemSoldQuantity = Convert.ToDouble(reader["OfferItemSoldQuantity"]);

            if (fieldNames.Contains("OfferItemInitQuantity"))
                if (!Convert.IsDBNull(reader["OfferItemInitQuantity"]))
                    item.OfferItemInitQuantity = Convert.ToDouble(reader["OfferItemInitQuantity"]);

            if (fieldNames.Contains("OfferItemRequiredPoints"))
                if (!Convert.IsDBNull(reader["OfferItemRequiredPoints"]))
                    item.OfferItemRequiredPoints = Convert.ToDouble(reader["OfferItemRequiredPoints"]);

            if (fieldNames.Contains("IsLiked"))
                if (!Convert.IsDBNull(reader["IsLiked"]))
                    item.IsLiked = Convert.ToBoolean(reader["IsLiked"]);

            if (fieldNames.Contains("TotalLike"))
                if (!Convert.IsDBNull(reader["TotalLike"]))
                    item.TotalLike = Convert.ToInt32(reader["TotalLike"]);

            if (fieldNames.Contains("InWishlist"))
                if (!Convert.IsDBNull(reader["InWishlist"]))
                    item.InWishlist = Convert.ToBoolean(reader["InWishlist"]);

            if (fieldNames.Contains("AvgRating"))
                if (!Convert.IsDBNull(reader["AvgRating"]))
                    item.AvgRating = Convert.ToDouble(reader["AvgRating"]);

            if (fieldNames.Contains("UserRating"))
                if (!Convert.IsDBNull(reader["UserRating"]))
                    item.UserRating = Convert.ToInt32(reader["UserRating"]);

            //if (fieldNames.Contains("ItemPrice"))
            //    if (!Convert.IsDBNull(reader["ItemPrice"]))
            //        item.ItemPrice = Convert.ToDouble(reader["ItemPrice"]);

            if (fieldNames.Contains("TypeName"))
                if (!Convert.IsDBNull(reader["TypeName"]))
                    item.TypeName = (reader["TypeName"]).ToString();

            if (fieldNames.Contains("TotalCount"))
                if (!Convert.IsDBNull(reader["TotalCount"]))
                    item.TotalCount = Convert.ToInt32(reader["TotalCount"]);

            if (fieldNames.Contains("Param1"))
                if (!Convert.IsDBNull(reader["Param1"]))
                    item.Param1 = reader["Param1"].ToString();

            if (fieldNames.Contains("Param2"))
                if (!Convert.IsDBNull(reader["Param2"]))
                    item.Param2 = reader["Param2"].ToString();
            //

            if (fieldNames.Contains("PriceTypeId"))
                if (!Convert.IsDBNull(reader["PriceTypeId"]))
                    item.PriceTypeId = Convert.ToInt32(reader["PriceTypeId"]);

            if (fieldNames.Contains("PriceTypeArabicName"))
                if (!Convert.IsDBNull(reader["PriceTypeArabicName"]))
                    item.PriceTypeArabicName = reader["PriceTypeArabicName"].ToString();

            if (fieldNames.Contains("PriceTypeEnglishName"))
                if (!Convert.IsDBNull(reader["PriceTypeEnglishName"]))
                    item.PriceTypeEnglishName = reader["PriceTypeEnglishName"].ToString();

            if (fieldNames.Contains("PriceCountryId"))
                if (!Convert.IsDBNull(reader["PriceCountryId"]))
                    item.PriceCountryId = Convert.ToInt32(reader["PriceCountryId"]);

            if (fieldNames.Contains("PriceCountryArabicName"))
                if (!Convert.IsDBNull(reader["PriceCountryArabicName"]))
                    item.PriceCountryArabicName = reader["PriceCountryArabicName"].ToString();

            if (fieldNames.Contains("PriceCountryEnglishName"))
                if (!Convert.IsDBNull(reader["PriceCountryEnglishName"]))
                    item.PriceCountryEnglishName = reader["PriceCountryEnglishName"].ToString();

            if (fieldNames.Contains("PriceCurrencyId"))
                if (!Convert.IsDBNull(reader["PriceCurrencyId"]))
                    item.PriceCurrencyId = Convert.ToInt32(reader["PriceCurrencyId"]);

            if (fieldNames.Contains("PriceCurrencyArabicName"))
                if (!Convert.IsDBNull(reader["PriceCurrencyArabicName"]))
                    item.PriceCurrencyArabicName = reader["PriceCurrencyArabicName"].ToString();

            if (fieldNames.Contains("PriceCurrencyArabicCode"))
                if (!Convert.IsDBNull(reader["PriceCurrencyArabicCode"]))
                    item.PriceCurrencyArabicCode = reader["PriceCurrencyArabicCode"].ToString();

            if (fieldNames.Contains("PriceCurrencyEnglishName"))
                if (!Convert.IsDBNull(reader["PriceCurrencyEnglishName"]))
                    item.PriceCurrencyEnglishName = reader["PriceCurrencyEnglishName"].ToString();

            if (fieldNames.Contains("PriceCurrencyEnglishCode"))
                if (!Convert.IsDBNull(reader["PriceCurrencyEnglishCode"]))
                    item.PriceCurrencyEnglishCode = reader["PriceCurrencyEnglishCode"].ToString();

            if (fieldNames.Contains("SizeImageURL"))
                if (!Convert.IsDBNull(reader["SizeImageURL"]))
                    item.SizeImageURL = reader["SizeImageURL"].ToString();


            if (fieldNames.Contains("OfferHasPointsOffer"))
                if (!Convert.IsDBNull(reader["OfferHasPointsOffer"]))
                    item.OfferHasPointsOffer = Convert.ToBoolean(reader["OfferHasPointsOffer"]);

            if (fieldNames.Contains("OfferHasPriceOffer"))
                if (!Convert.IsDBNull(reader["OfferHasPriceOffer"]))
                    item.OfferHasPriceOffer = Convert.ToBoolean(reader["OfferHasPriceOffer"]);

            if (fieldNames.Contains("OfferPriceOfferType"))
                if (!Convert.IsDBNull(reader["OfferPriceOfferType"]))
                    item.OfferPriceOfferType = Convert.ToInt32(reader["OfferPriceOfferType"]);

            if (fieldNames.Contains("OfferPrice"))
                if (!Convert.IsDBNull(reader["OfferPrice"]))
                    item.OfferPrice = reader["OfferPrice"].ToString();

            if (fieldNames.Contains("ItemTypeId"))
                if (!Convert.IsDBNull(reader["ItemTypeId"]))
                    item.ItemTypeId = Convert.ToInt32(reader["ItemTypeId"]);

            if (fieldNames.Contains("ItemTypeArabicName"))
                if (!Convert.IsDBNull(reader["ItemTypeArabicName"]))
                    item.ItemTypeArabicName = reader["ItemTypeArabicName"].ToString();
            if (fieldNames.Contains("ItemTypeEnglishName"))
                if (!Convert.IsDBNull(reader["ItemTypeEnglishName"]))
                    item.ItemTypeEnglishName = reader["ItemTypeEnglishName"].ToString();




            if (fieldNames.Contains("ItemDepartmentId"))
                if (!Convert.IsDBNull(reader["ItemDepartmentId"]))
                    item.ItemDepartmentId = Convert.ToInt32(reader["ItemDepartmentId"]);

            if (fieldNames.Contains("ItemDepartmentArabicName"))
                if (!Convert.IsDBNull(reader["ItemDepartmentArabicName"]))
                    item.ItemDepartmentArabicName = reader["ItemDepartmentArabicName"].ToString();

            if (fieldNames.Contains("ItemDepartmentEnglishName"))
                if (!Convert.IsDBNull(reader["ItemDepartmentEnglishName"]))
                    item.ItemDepartmentEnglishName = reader["ItemDepartmentEnglishName"].ToString();



            if (fieldNames.Contains("HasStartDateBooking"))
                if (!Convert.IsDBNull(reader["HasStartDateBooking"]))
                    item.HasStartDateBooking = (bool)reader["HasStartDateBooking"];

            if (fieldNames.Contains("StartDateBooking"))
                if (!Convert.IsDBNull(reader["StartDateBooking"]))
                    item.StartDateBooking = reader["StartDateBooking"].ToString();

            if (fieldNames.Contains("HasEndDateBooking"))
                if (!Convert.IsDBNull(reader["HasEndDateBooking"]))
                    item.HasEndDateBooking = (bool)reader["HasEndDateBooking"];

            if (fieldNames.Contains("EndDateBooking"))
                if (!Convert.IsDBNull(reader["EndDateBooking"]))
                    item.EndDateBooking = reader["EndDateBooking"].ToString();

            if (fieldNames.Contains("OnRequest"))
                if (!Convert.IsDBNull(reader["OnRequest"]))
                    item.OnRequest = Convert.ToBoolean(reader["OnRequest"]);

            if (fieldNames.Contains("OnRequestArabicMessage"))
                if (!Convert.IsDBNull(reader["OnRequestArabicMessage"]))
                    item.OnRequestArabicMessage = reader["OnRequestArabicMessage"].ToString();

            if (fieldNames.Contains("OnRequestEnglishMessage"))
                if (!Convert.IsDBNull(reader["OnRequestEnglishMessage"]))
                    item.OnRequestEnglishMessage = reader["OnRequestEnglishMessage"].ToString();

            if (fieldNames.Contains("OnRequestDays"))
                if (!Convert.IsDBNull(reader["OnRequestDays"]))
                    item.OnRequestDays = Convert.ToInt32(reader["OnRequestDays"]);


            if (fieldNames.Contains("ItemURL"))
                if (!Convert.IsDBNull(reader["ItemURL"]))
                    item.ItemURL = reader["ItemURL"].ToString();

            if (fieldNames.Contains("ArabicTitle"))
                if (!Convert.IsDBNull(reader["ArabicTitle"]))
                    item.ArabicTitle = reader["ArabicTitle"].ToString();

            if (fieldNames.Contains("EnglishTitle"))
                if (!Convert.IsDBNull(reader["EnglishTitle"]))
                    item.EnglishTitle = reader["EnglishTitle"].ToString();

            if (fieldNames.Contains("ShowCarouselInItemsList"))
                if (!Convert.IsDBNull(reader["ShowCarouselInItemsList"]))
                    item.ShowCarouselInItemsList = Convert.ToBoolean(reader["ShowCarouselInItemsList"]);

            if (fieldNames.Contains("ShowDescriptionInItemsList"))
                if (!Convert.IsDBNull(reader["ShowDescriptionInItemsList"]))
                    item.ShowDescriptionInItemsList = Convert.ToBoolean(reader["ShowDescriptionInItemsList"]);

            if (fieldNames.Contains("StyleId"))
                if (!Convert.IsDBNull(reader["StyleId"]))
                    item.StyleId = Convert.ToInt32(reader["StyleId"]);

            if (fieldNames.Contains("OfferItemGrantedPoints"))
                if (!Convert.IsDBNull(reader["OfferItemGrantedPoints"]))
                    item.OfferItemGrantedPoints = Convert.ToDouble(reader["OfferItemGrantedPoints"]);

            if (fieldNames.Contains("IsSpecialOffer"))
                if (!Convert.IsDBNull(reader["IsSpecialOffer"]))
                    item.IsSpecialOffer = Convert.ToBoolean(reader["IsSpecialOffer"]);


            if (fieldNames.Contains("StockLevel"))
                if (!Convert.IsDBNull(reader["StockLevel"]))
                    item.StockLevel = Convert.ToInt32(reader["StockLevel"]);

            return item;
        }

    }

    [DataContract]
    public class ItemClass_Short
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string ArabicName { get; set; }
        [DataMember(Order = 3)]
        public string EnglishName { get; set; }
        [DataMember(Order = 4)]
        public string Code { get; set; }
        [DataMember(Order = 5)]
        public string Price { get; set; }
        [DataMember(Order = 6)]
        public double RequiredPoints { get; set; }
        [DataMember(Order = 6)]
        public string ImageURL { get; set; }
        [DataMember(Order = 7)]
        public int CategoryId { get; set; }
        [DataMember(Order = 8)]
        public bool HasOffer { get; set; }
        [DataMember(Order = 9)]
        public string OfferStartDate { get; set; }
        [DataMember(Order = 10)]
        public bool OfferHasEndDate { get; set; }
        [DataMember(Order = 11)]
        public string OfferEndDate { get; set; }
        [DataMember(Order = 12)]
        public double OfferItemRequiredPoints { get; set; }
        [DataMember(Order = 12)]
        public bool IsLiked { get; set; }
        [DataMember(Order = 13)]
        public bool InWishlist { get; set; }

        [DataMember(Order = 14)]
        public int PriceTypeId { get; set; }
        [DataMember(Order = 15)]
        public string PriceTypeArabicName { get; set; }
        [DataMember(Order = 16)]
        public string PriceTypeEnglishName { get; set; }
        [DataMember(Order = 17)]
        public int PriceCountryId { get; set; }
        [DataMember(Order = 18)]
        public string PriceCountryArabicName { get; set; }
        [DataMember(Order = 19)]
        public string PriceCountryEnglishName { get; set; }
        [DataMember(Order = 20)]
        public int PriceCurrencyId { get; set; }
        [DataMember(Order = 21)]
        public string PriceCurrencyArabicName { get; set; }
        [DataMember(Order = 22)]
        public string PriceCurrencyArabicCode { get; set; }
        [DataMember(Order = 23)]
        public string PriceCurrencyEnglishName { get; set; }
        [DataMember(Order = 24)]
        public string PriceCurrencyEnglishCode { get; set; }

        [DataMember(Order = 25)]
        public int Order { get; set; }


        [DataMember(Order = 26)]
        public bool OfferHasPointsOffer { get; set; }
        [DataMember(Order = 27)]
        public bool OfferHasPriceOffer { get; set; }
        [DataMember(Order = 28)]
        public int OfferPriceOfferType { get; set; }
        [DataMember(Order = 29)]
        public string OfferPrice { get; set; }

        [DataMember(Order = 30)]
        public bool OnRequest {get; set; }

        [DataMember(Order = 31)]
        public string ArabicTitle { get; set; }

        [DataMember(Order = 32)]
        public string EnglishTitle { get; set; }

        [DataMember(Order = 33)]
        public bool ShowCarouselInItemsList { get; set; }

        [DataMember(Order = 34)]
        public bool ShowDescriptionInItemsList { get; set; }
        [DataMember(Order = 35)]
        public int StyleId { get; set; }

        [DataMember(Order = 36)]
        public double OfferItemGrantedPoints { get; set; }
        [DataMember(Order = 34)]
        public bool IsSpecialOffer { get; set; }

        [DataMember(Order = 34)]
        public int StockLevel { get; set; }


        public ItemClass_Short PopulateItem(ItemClass item)
        {
            var result = new ItemClass_Short
            {
                Id = item.Id,
                ArabicName = item.ArabicName,
                EnglishName = item.EnglishName,
                Code = item.Code,
                Price = item.Price,
                RequiredPoints = item.RequiredPoints,
                ImageURL = item.ImageURL,
                CategoryId = item.CategoryId,
                HasOffer = item.HasOffer,
                OfferStartDate = item.OfferStartDate,
                OfferHasEndDate = item.OfferHasEndDate,
                OfferEndDate = item.OfferEndDate,
                OfferItemRequiredPoints = item.OfferItemRequiredPoints,
                IsLiked = item.IsLiked,
                InWishlist = item.InWishlist,
                //ItemPrice = item.ItemPrice,

                PriceTypeId = item.PriceTypeId,
                PriceTypeArabicName = item.PriceTypeArabicName,
                PriceTypeEnglishName = item.PriceTypeEnglishName,
                PriceCountryId = item.PriceCountryId,
                PriceCountryArabicName = item.PriceCountryArabicName,
                PriceCountryEnglishName = item.PriceCountryEnglishName,
                PriceCurrencyId = item.PriceCurrencyId,
                PriceCurrencyArabicName = item.PriceCurrencyArabicName,
                PriceCurrencyArabicCode = item.PriceCurrencyArabicCode,
                PriceCurrencyEnglishName = item.PriceCurrencyEnglishName,
                PriceCurrencyEnglishCode = item.PriceCurrencyEnglishCode,

                OfferHasPointsOffer = item.OfferHasPointsOffer,
                OfferHasPriceOffer = item.OfferHasPriceOffer,
                OfferPrice = item.OfferPrice,
                OfferPriceOfferType = item.OfferPriceOfferType,
                OnRequest = item.OnRequest,
                Order = item.Order,
                ArabicTitle = item.ArabicTitle,
                EnglishTitle = item.EnglishTitle,
                ShowCarouselInItemsList = item.ShowCarouselInItemsList,
                ShowDescriptionInItemsList = item.ShowDescriptionInItemsList,
                StyleId = item.StyleId,
                OfferItemGrantedPoints = item.OfferItemGrantedPoints,
                IsSpecialOffer = item.IsSpecialOffer,
                StockLevel = item.StockLevel

            };

            return result;
        }

        public List<ItemClass_Short> PopulateItems(List<ItemClass> items)
        {
            List<ItemClass_Short> resultList = new List<ItemClass_Short>();

            if (items != null)
            {
                foreach (var item in items)
                {
                    resultList.Add(new ItemClass_Short
                    {
                        Id = item.Id,
                        ArabicName = item.ArabicName,
                        EnglishName = item.EnglishName,
                        Code = item.Code,
                        Price = item.Price,
                        RequiredPoints = item.RequiredPoints,
                        ImageURL = item.ImageURL,
                        CategoryId = item.CategoryId,
                        HasOffer = item.HasOffer,
                        OfferStartDate = item.OfferStartDate,
                        OfferHasEndDate = item.OfferHasEndDate,
                        OfferEndDate = item.OfferEndDate,
                        OfferItemRequiredPoints = item.OfferItemRequiredPoints,
                        IsLiked = item.IsLiked,
                        InWishlist = item.InWishlist,
                        //ItemPrice = item.ItemPrice,
                        PriceTypeId = item.PriceTypeId,
                        PriceTypeArabicName = item.PriceTypeArabicName,
                        PriceTypeEnglishName = item.PriceTypeEnglishName,
                        PriceCountryId = item.PriceCountryId,
                        PriceCountryArabicName = item.PriceCountryArabicName,
                        PriceCountryEnglishName = item.PriceCountryEnglishName,
                        PriceCurrencyId = item.PriceCurrencyId,
                        PriceCurrencyArabicName = item.PriceCurrencyArabicName,
                        PriceCurrencyArabicCode = item.PriceCurrencyArabicCode,
                        PriceCurrencyEnglishName = item.PriceCurrencyEnglishName,
                        PriceCurrencyEnglishCode = item.PriceCurrencyEnglishCode,

                        OfferHasPointsOffer = item.OfferHasPointsOffer,
                        OfferHasPriceOffer = item.OfferHasPriceOffer,
                        OfferPrice = item.OfferPrice,
                        OfferPriceOfferType = item.OfferPriceOfferType,
                        OnRequest = item.OnRequest,

                        Order = item.Order,
                        ArabicTitle = item.ArabicTitle,
                        EnglishTitle = item.EnglishTitle,
                        ShowCarouselInItemsList = item.ShowCarouselInItemsList,
                        ShowDescriptionInItemsList = item.ShowDescriptionInItemsList,
                        StyleId = item.StyleId,
                        OfferItemGrantedPoints = item.OfferItemGrantedPoints,
                        IsSpecialOffer = item.IsSpecialOffer,
                        StockLevel = item.StockLevel

                    });
                }
                return resultList;
            }
            else
            { return null; }
        }

    }

    [DataContract]
    public class ItemColumnExcelClass
    {
        [DataMember(Order = 1)]
        public string Id { get; set; }
        [DataMember(Order = 2)]
        public string ArabicName { get; set; }
        [DataMember(Order = 3)]
        public string EnglishName { get; set; }
        [DataMember(Order = 4)]
        public string Code { get; set; }
        [DataMember(Order = 5)]
        public string ArabicDescription { get; set; }
        [DataMember(Order = 6)]
        public string EnglishDescription { get; set; }
        [DataMember(Order = 7)]
        public string BrandId { get; set; }
        [DataMember(Order = 10)]
        public string CountryId { get; set; }

        [DataMember(Order = 11)]
        public string DefaultPriceTypeId { get; set; }
        [DataMember(Order = 11)]
        public string DefaultPriceTypeArabicName { get; set; }
        [DataMember(Order = 11)]
        public string DefaultPriceTypeEnglishName { get; set; }

        [DataMember(Order = 12)]
        public string Price { get; set; }
        [DataMember(Order = 13)]
        public string RequiredPoints { get; set; }
        [DataMember(Order = 14)]
        public string GrantedPoints { get; set; }

        [DataMember(Order = 15)]
        public string Disabled { get; set; }
        [DataMember(Order = 16)]
        public string Notes { get; set; }
        [DataMember(Order = 17)]
        public string ImageURL { get; set; }
        [DataMember(Order = 18)]
        public string CreatedBy { get; set; }
        [DataMember(Order = 19)]
        public string UpdatedBy { get; set; }
        [DataMember(Order = 20)]
        public string CreateDate { get; set; }
        [DataMember(Order = 21)]
        public string UpdateDate { get; set; }
        [DataMember(Order = 22)]
        public string CategoryId { get; set; }
        [DataMember(Order = 23)]
        public string BrandArabicName { get; set; }
        [DataMember(Order = 24)]
        public string BrandEnglishName { get; set; }
        [DataMember(Order = 25)]
        public string CountryArabicName { get; set; }
        [DataMember(Order = 26)]
        public string CountryEnglishName { get; set; }
        [DataMember(Order = 27)]
        public string CreatedByUsername { get; set; }
        [DataMember(Order = 28)]
        public string CreatedByFullName { get; set; }
        [DataMember(Order = 29)]
        public string UpdatedByUsername { get; set; }
        [DataMember(Order = 30)]
        public string UpdatedByFullName { get; set; }
        [DataMember(Order = 31)]
        public string CategoryArabicName { get; set; }
        [DataMember(Order = 32)]
        public string CategoryEnglishName { get; set; }

        [DataMember(Order = 33)]
        public string HasOffer { get; set; }
        [DataMember(Order = 34)]
        public string OfferId { get; set; }
        [DataMember(Order = 35)]
        public string OfferStartDate { get; set; }
        [DataMember(Order = 36)]
        public string OfferHasEndDate { get; set; }
        [DataMember(Order = 37)]
        public string OfferEndDate { get; set; }
        [DataMember(Order = 38)]
        public string OfferItemHasInitQuantity { get; set; }
        [DataMember(Order = 39)]
        public string OfferItemInitQuantity { get; set; }
        [DataMember(Order = 40)]
        public string OfferItemRemainingQuantity { get; set; }
        [DataMember(Order = 41)]
        public string OfferItemSoldQuantity { get; set; }
        [DataMember(Order = 42)]
        public string OfferItemRequiredPoints { get; set; }

        [DataMember(Order = 43)]
        public string Order { get; set; }

        [DataMember(Order = 44)]
        public string IsLiked { get; set; }
        [DataMember(Order = 45)]
        public string TotalLike { get; set; }
        [DataMember(Order = 46)]
        public string InWishlist { get; set; }
        [DataMember(Order = 47)]
        public string AvgRating { get; set; }
        [DataMember(Order = 48)]
        public string UserRating { get; set; }
        //[DataMember(Order = 49)]
        //public string ItemPrice { get; set; }
        [DataMember(Order = 50)]
        public string TypeName { get; set; }
        [DataMember(Order = 51)]
        public string TotalCount { get; set; }

        [DataMember(Order = 52)]
        public string Param1 { get; set; }
        [DataMember(Order = 53)]
        public string Param2 { get; set; }

        [DataMember(Order = 53)]
        public string PriceTypeId { get; set; }
        [DataMember(Order = 53)]
        public string PriceTypeArabicName { get; set; }
        [DataMember(Order = 53)]
        public string PriceTypeEnglishName { get; set; }
        [DataMember(Order = 53)]
        public string PriceCountryId { get; set; }
        [DataMember(Order = 53)]
        public string PriceCountryArabicName { get; set; }
        [DataMember(Order = 53)]
        public string PriceCountryEnglishName { get; set; }
        [DataMember(Order = 53)]
        public string PriceCurrencyId { get; set; }
        [DataMember(Order = 53)]
        public string PriceCurrencyArabicName { get; set; }
        [DataMember(Order = 53)]
        public string PriceCurrencyArabicCode { get; set; }
        [DataMember(Order = 53)]
        public string PriceCurrencyEnglishName { get; set; }
        [DataMember(Order = 53)]
        public string PriceCurrencyEnglishCode { get; set; }
        [DataMember(Order = 54)]
        public string SizeImageURL { get; set; }

        [DataMember(Order = 55)]
        public string OfferHasPointsOffer { get; set; }
        [DataMember(Order = 56)]
        public string OfferHasPriceOffer { get; set; }
        [DataMember(Order = 57)]
        public string OfferPriceOfferType { get; set; }
        [DataMember(Order = 58)]
        public string OfferPrice { get; set; }

        [DataMember(Order = 59)]
        public int ItemTypeId { get; set; }
        [DataMember(Order = 60)]
        public string ItemTypeArabicName { get; set; }
        [DataMember(Order = 61)]
        public string ItemTypeEnglishName { get; set; }
        [DataMember(Order = 62)]
        public int ItemDepartmentId { get; set; }
        [DataMember(Order = 63)]
        public string ItemDepartmentArabicName { get; set; }
        [DataMember(Order = 64)]
        public string ItemDepartmentEnglishName { get; set; }

        [DataMember(Order = 65)]
        public bool HasStartDateBooking { get; set; }
        [DataMember(Order = 66)]
        public string StartDateBooking { get; set; }
        [DataMember(Order = 67)]
        public bool HasEndDateBooking { get; set; }
        [DataMember(Order = 68)]
        public string EndDateBooking { get; set; }
        [DataMember(Order = 69)]
        public bool OnRequest { get; set; }
        [DataMember(Order = 70)]
        public string OnRequestArabicMessage { get; set; }
        [DataMember(Order = 71)]
        public string OnRequestEnglishMessage { get; set; }
        [DataMember(Order = 72)]
        public int OnRequestDays { get; set; }

        [DataMember(Order = 73)]
        public string ArabicTitle { get; set; }

        [DataMember(Order = 74)]
        public string EnglishTitle { get; set; }

        [DataMember(Order = 75)]
        public bool ShowCarouselInItemsList { get; set; }

        [DataMember(Order = 76)]
        public bool ShowDescriptionInItemsList { get; set; }
        [DataMember(Order = 42)]
        public string OfferItemGrantedPoints { get; set; }

        [DataMember(Order = 76)]
        public bool IsSpecialOffer { get; set; }
        [DataMember(Order = 76)]
        public int StockLevel { get; set; }

    }
}