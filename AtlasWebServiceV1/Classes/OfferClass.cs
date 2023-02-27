using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class OfferClass
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
        public string StartDate { get; set; }
        [DataMember(Order = 8)]
        public bool HasEndDate { get; set; }
        [DataMember(Order = 9)]
        public string EndDate { get; set; }
        [DataMember(Order = 10)]
        public bool Disabled { get; set; }
        [DataMember(Order = 11)]
        public string Notes { get; set; }
        [DataMember(Order = 12)]
        public int CreatedBy { get; set; }
        [DataMember(Order = 13)]
        public int UpdatedBy { get; set; }
        [DataMember(Order = 14)]
        public string CreateDate { get; set; }
        [DataMember(Order = 15)]
        public string UpdateDate { get; set; }
        [DataMember(Order = 16)]
        public string CreatedByUsername { get; set; }
        [DataMember(Order = 17)]
        public string CreatedByFullName { get; set; }
        [DataMember(Order = 18)]
        public string UpdatedByUsername { get; set; }
        [DataMember(Order = 19)]
        public string UpdatedByFullName { get; set; }

        [DataMember(Order = 20)]
        public int OfferTypeId { get; set; }
        [DataMember(Order = 2)]
        public string OfferTypeArabicName { get; set; }
        [DataMember(Order = 3)]
        public string OfferTypeEnglishName { get; set; }

        [DataMember(Order = 21)]
        public bool HasRequiredPoints { get; set; }
        [DataMember(Order = 21)]
        public double RequiredPoints { get; set; }
        [DataMember(Order = 21)]
        public bool HasRequiredPrice { get; set; }
        [DataMember(Order = 21)]
        public double RequiredPrice { get; set; }

        [DataMember(Order = 21)]
        public bool CanGrantPoints { get; set; }
        [DataMember(Order = 21)]
        public int GrantPointsType { get; set; }
        [DataMember(Order = 21)]
        public double GrantPointsValue { get; set; } // 1- amount  2- percentage

        [DataMember(Order = 21)]
        public bool HasPointsDiscount { get; set; }
        [DataMember(Order = 21)]
        public int PointsDiscountType { get; set; } // 1- amount  2- percentage
        [DataMember(Order = 21)]
        public double PointsDiscountValue { get; set; }

        [DataMember(Order = 21)]
        public bool HasPriceDiscount { get; set; }
        [DataMember(Order = 21)]
        public int PriceDiscountType { get; set; }  // 1- amount  2- percentage
        [DataMember(Order = 21)]
        public double PriceDiscountValue { get; set; }

        [DataMember(Order = 22)]
        public bool HasQuantityOffer { get; set; }
        [DataMember(Order = 23)]
        public double RequiredQuantity { get; set; }  // 1- amount  2- percentage
        [DataMember(Order = 24)]
        public bool CanGrantQuantity { get; set; }
        [DataMember(Order = 25)]
        public double GrantQuantity { get; set; }
        [DataMember(Order = 26)]
        public int GrantedQuantityOrderTypeId { get; set; }  // 1- amount  2- percentage
        [DataMember(Order = 27)]
        public string GrantedQuantityOrderTypeArabicName { get; set; }
        [DataMember(Order = 28)]
        public string GrantedQuantityOrderTypeEnglishName { get; set; }


        [DataMember(Order = 29)]
        public int Order { get; set; }


        public OfferClass PopulateOffer(string[] fieldNames, SqlDataReader reader)
        {
            var offer = new OfferClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    offer.Id = Convert.ToInt32(reader["Id"]);

            if (fieldNames.Contains("ArabicName"))
                if (!Convert.IsDBNull(reader["ArabicName"]))
                    offer.ArabicName = reader["ArabicName"].ToString();

            if (fieldNames.Contains("EnglishName"))
                if (!Convert.IsDBNull(reader["EnglishName"]))
                    offer.EnglishName = reader["EnglishName"].ToString();

            if (fieldNames.Contains("Code"))
                if (!Convert.IsDBNull(reader["Code"]))
                    offer.Code = reader["Code"].ToString();

            if (fieldNames.Contains("ArabicDescription"))
                if (!Convert.IsDBNull(reader["ArabicDescription"]))
                    offer.ArabicDescription = reader["ArabicDescription"].ToString();

            if (fieldNames.Contains("EnglishDescription"))
                if (!Convert.IsDBNull(reader["EnglishDescription"]))
                    offer.EnglishDescription = reader["EnglishDescription"].ToString();

            if (fieldNames.Contains("StartDate"))
                if (!Convert.IsDBNull(reader["StartDate"]))
                    offer.StartDate = reader["StartDate"].ToString();

            if (fieldNames.Contains("HasEndDate"))
                if (!Convert.IsDBNull(reader["HasEndDate"]))
                    offer.HasEndDate = Convert.ToBoolean(reader["HasEndDate"]);

            if (fieldNames.Contains("EndDate"))
                if (!Convert.IsDBNull(reader["EndDate"]))
                    offer.EndDate = reader["EndDate"].ToString();

            if (fieldNames.Contains("Disabled"))
                if (!Convert.IsDBNull(reader["Disabled"]))
                    offer.Disabled = Convert.ToBoolean(reader["Disabled"]);

            if (fieldNames.Contains("Notes"))
                if (!Convert.IsDBNull(reader["Notes"]))
                    offer.Notes = reader["Notes"].ToString();

            if (fieldNames.Contains("CreatedBy"))
                if (!Convert.IsDBNull(reader["CreatedBy"]))
                    offer.CreatedBy = Convert.ToInt32(reader["CreatedBy"]);

            if (fieldNames.Contains("UpdatedBy"))
                if (!Convert.IsDBNull(reader["UpdatedBy"]))
                    offer.UpdatedBy = Convert.ToInt32(reader["UpdatedBy"]);

            if (fieldNames.Contains("UpdatedBy"))
                if (!Convert.IsDBNull(reader["UpdatedBy"]))
                    offer.UpdatedBy = Convert.ToInt32(reader["UpdatedBy"]);

            if (fieldNames.Contains("CreateDate"))
                if (!Convert.IsDBNull(reader["CreateDate"]))
                    offer.CreateDate = reader["CreateDate"].ToString();

            if (fieldNames.Contains("UpdateDate"))
                if (!Convert.IsDBNull(reader["UpdateDate"]))
                    offer.UpdateDate = reader["UpdateDate"].ToString();

            if (fieldNames.Contains("CreatedByUsername"))
                if (!Convert.IsDBNull(reader["CreatedByUsername"]))
                    offer.CreatedByUsername = reader["CreatedByUsername"].ToString();

            if (fieldNames.Contains("CreatedByFullName"))
                if (!Convert.IsDBNull(reader["CreatedByFullName"]))
                    offer.CreatedByFullName = reader["CreatedByFullName"].ToString();

            if (fieldNames.Contains("UpdatedByUsername"))
                if (!Convert.IsDBNull(reader["UpdatedByUsername"]))
                    offer.UpdatedByUsername = reader["UpdatedByUsername"].ToString();

            if (fieldNames.Contains("UpdatedByFullName"))
                if (!Convert.IsDBNull(reader["UpdatedByFullName"]))
                    offer.UpdatedByFullName = reader["UpdatedByFullName"].ToString();


            if (fieldNames.Contains("OfferTypeId"))
                if (!Convert.IsDBNull(reader["OfferTypeId"]))
                    offer.OfferTypeId = Convert.ToInt32(reader["OfferTypeId"]);

            if (fieldNames.Contains("OfferTypeArabicName"))
                if (!Convert.IsDBNull(reader["OfferTypeArabicName"]))
                    offer.OfferTypeArabicName = reader["OfferTypeArabicName"].ToString();

            if (fieldNames.Contains("OfferTypeEnglishName"))
                if (!Convert.IsDBNull(reader["OfferTypeEnglishName"]))
                    offer.OfferTypeEnglishName = reader["OfferTypeEnglishName"].ToString();

            if (fieldNames.Contains("HasRequiredPoints"))
                if (!Convert.IsDBNull(reader["HasRequiredPoints"]))
                    offer.HasRequiredPoints = Convert.ToBoolean(reader["HasRequiredPoints"]);

            if (fieldNames.Contains("RequiredPoints"))
                if (!Convert.IsDBNull(reader["RequiredPoints"]))
                    offer.RequiredPoints = Convert.ToDouble(reader["RequiredPoints"]);

            if (fieldNames.Contains("HasRequiredPrice"))
                if (!Convert.IsDBNull(reader["HasRequiredPrice"]))
                    offer.HasRequiredPrice = Convert.ToBoolean(reader["HasRequiredPrice"]);

            if (fieldNames.Contains("RequiredPrice"))
                if (!Convert.IsDBNull(reader["RequiredPrice"]))
                    offer.RequiredPrice = Convert.ToDouble(reader["RequiredPrice"]);

            if (fieldNames.Contains("CanGrantPoints"))
                if (!Convert.IsDBNull(reader["CanGrantPoints"]))
                    offer.CanGrantPoints = Convert.ToBoolean(reader["CanGrantPoints"]);

            if (fieldNames.Contains("GrantPointsType"))
                if (!Convert.IsDBNull(reader["GrantPointsType"]))
                    offer.GrantPointsType = Convert.ToInt32(reader["GrantPointsType"]);

            if (fieldNames.Contains("GrantPointsValue"))
                if (!Convert.IsDBNull(reader["GrantPointsValue"]))
                    offer.GrantPointsValue = Convert.ToDouble(reader["GrantPointsValue"]);

            if (fieldNames.Contains("HasPointsDiscount"))
                if (!Convert.IsDBNull(reader["HasPointsDiscount"]))
                    offer.HasPointsDiscount = Convert.ToBoolean(reader["HasPointsDiscount"]);

            if (fieldNames.Contains("PointsDiscountType"))
                if (!Convert.IsDBNull(reader["PointsDiscountType"]))
                    offer.PointsDiscountType = Convert.ToInt32(reader["PointsDiscountType"]);

            if (fieldNames.Contains("PointsDiscountValue"))
                if (!Convert.IsDBNull(reader["PointsDiscountValue"]))
                    offer.PointsDiscountValue = Convert.ToDouble(reader["PointsDiscountValue"]);

            if (fieldNames.Contains("HasPriceDiscount"))
                if (!Convert.IsDBNull(reader["HasPriceDiscount"]))
                    offer.HasPriceDiscount = Convert.ToBoolean(reader["HasPriceDiscount"]);

            if (fieldNames.Contains("PriceDiscountType"))
                if (!Convert.IsDBNull(reader["PriceDiscountType"]))
                    offer.PriceDiscountType = Convert.ToInt32(reader["PriceDiscountType"]);

            if (fieldNames.Contains("PriceDiscountValue"))
                if (!Convert.IsDBNull(reader["PriceDiscountValue"]))
                    offer.PriceDiscountValue = Convert.ToDouble(reader["PriceDiscountValue"]);

            if (fieldNames.Contains("HasQuantityOffer"))
                if (!Convert.IsDBNull(reader["HasQuantityOffer"]))
                    offer.HasQuantityOffer = Convert.ToBoolean(reader["HasQuantityOffer"]);

            if (fieldNames.Contains("RequiredQuantity"))
                if (!Convert.IsDBNull(reader["RequiredQuantity"]))
                    offer.RequiredQuantity = Convert.ToDouble(reader["RequiredQuantity"]);

            if (fieldNames.Contains("CanGrantQuantity"))
                if (!Convert.IsDBNull(reader["CanGrantQuantity"]))
                    offer.CanGrantQuantity = Convert.ToBoolean(reader["CanGrantQuantity"]);

            if (fieldNames.Contains("GrantQuantity"))
                if (!Convert.IsDBNull(reader["GrantQuantity"]))
                    offer.GrantQuantity = Convert.ToDouble(reader["GrantQuantity"]);

            if (fieldNames.Contains("GrantedQuantityOrderTypeId"))
                if (!Convert.IsDBNull(reader["GrantedQuantityOrderTypeId"]))
                    offer.GrantedQuantityOrderTypeId = Convert.ToInt32(reader["GrantedQuantityOrderTypeId"]);

            if (fieldNames.Contains("GrantedQuantityOrderTypeArabicName"))
                if (!Convert.IsDBNull(reader["GrantedQuantityOrderTypeArabicName"]))
                    offer.GrantedQuantityOrderTypeArabicName = reader["GrantedQuantityOrderTypeArabicName"].ToString();

            if (fieldNames.Contains("GrantedQuantityOrderTypeEnglishName"))
                if (!Convert.IsDBNull(reader["GrantedQuantityOrderTypeEnglishName"]))
                    offer.GrantedQuantityOrderTypeEnglishName = reader["GrantedQuantityOrderTypeEnglishName"].ToString();
            return offer;
        }
    }
}