using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class OfferDetailPriceClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int OfferDetailId { get; set; }
        [DataMember(Order = 3)]
        public int CountryCurrencyId { get; set; }
        [DataMember(Order = 4)]
        public int TypeId { get; set; }
        [DataMember(Order = 5)]
        public string Price { get; set; }

        [DataMember(Order = 6)]
        public string PriceTypeArabicName { get; set; }
        [DataMember(Order = 7)]
        public string PriceTypeEnglishName { get; set; }

        [DataMember(Order = 8)]
        public string CurrencyArabicName { get; set; }
        [DataMember(Order = 9)]
        public string CurrencyEnglishName { get; set; }

        [DataMember(Order = 10)]
        public string CountryArabicName { get; set; }
        [DataMember(Order = 11)]
        public string CountryEnglishName { get; set; }

        [DataMember(Order = 12)]
        public int CountryId { get; set; }

        [DataMember(Order = 13)]
        public int Order { get; set; }
        [DataMember(Order = 14)]
        public bool HasPointsOffer { get; set; }
        [DataMember(Order = 15)]
        public int RequiredPoints { get; set; }
        [DataMember(Order = 16)]
        public int GrantedPoints { get; set; }
        [DataMember(Order = 16)]
        public bool IsSpecialOffer { get; set; }


        public OfferDetailPriceClass PopulateOfferDetailPrice(string[] fieldNames, SqlDataReader reader)
        {
            var offerDetailPrice = new OfferDetailPriceClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    offerDetailPrice.Id = Convert.ToInt32(reader["Id"]);

            if (fieldNames.Contains("OfferDetailId"))
                if (!Convert.IsDBNull(reader["OfferDetailId"]))
                    offerDetailPrice.OfferDetailId = Convert.ToInt32(reader["OfferDetailId"]);

            if (fieldNames.Contains("CountryCurrencyId"))
                if (!Convert.IsDBNull(reader["CountryCurrencyId"]))
                    offerDetailPrice.CountryCurrencyId = Convert.ToInt32(reader["CountryCurrencyId"]);

            if (fieldNames.Contains("Price"))
                if (!Convert.IsDBNull(reader["Price"]))
                    offerDetailPrice.Price = reader["Price"].ToString();

            if (fieldNames.Contains("TypeId"))
                if (!Convert.IsDBNull(reader["TypeId"]))
                    offerDetailPrice.TypeId = Convert.ToInt32(reader["TypeId"]);

            if (fieldNames.Contains("PriceTypeArabicName"))
                if (!Convert.IsDBNull(reader["PriceTypeArabicName"]))
                    offerDetailPrice.PriceTypeArabicName = (reader["PriceTypeArabicName"]).ToString();

            if (fieldNames.Contains("PriceTypeEnglishName"))
                if (!Convert.IsDBNull(reader["PriceTypeEnglishName"]))
                    offerDetailPrice.PriceTypeEnglishName = (reader["PriceTypeEnglishName"]).ToString();

            if (fieldNames.Contains("CurrencyArabicName"))
                if (!Convert.IsDBNull(reader["CurrencyArabicName"]))
                    offerDetailPrice.CurrencyArabicName = (reader["CurrencyArabicName"]).ToString();

            if (fieldNames.Contains("CurrencyEnglishName"))
                if (!Convert.IsDBNull(reader["CurrencyEnglishName"]))
                    offerDetailPrice.CurrencyEnglishName = (reader["CurrencyEnglishName"]).ToString();

            if (fieldNames.Contains("CountryArabicName"))
                if (!Convert.IsDBNull(reader["CountryArabicName"]))
                    offerDetailPrice.CountryArabicName = (reader["CountryArabicName"]).ToString();

            if (fieldNames.Contains("CountryEnglishName"))
                if (!Convert.IsDBNull(reader["CountryEnglishName"]))
                    offerDetailPrice.CountryEnglishName = (reader["CountryEnglishName"]).ToString();

            if (fieldNames.Contains("CountryId"))
                if (!Convert.IsDBNull(reader["CountryId"]))
                    offerDetailPrice.CountryId = Convert.ToInt32(reader["CountryId"]);

            if (fieldNames.Contains("HasPointsOffer"))
                if (!Convert.IsDBNull(reader["HasPointsOffer"]))
                    offerDetailPrice.HasPointsOffer = Convert.ToBoolean(reader["HasPointsOffer"]);

            if (fieldNames.Contains("RequiredPoints"))
                if (!Convert.IsDBNull(reader["RequiredPoints"]))
                    offerDetailPrice.RequiredPoints = Convert.ToInt32(reader["RequiredPoints"]);

            if (fieldNames.Contains("GrantedPoints"))
                if (!Convert.IsDBNull(reader["GrantedPoints"]))
                    offerDetailPrice.GrantedPoints = Convert.ToInt32(reader["GrantedPoints"]);


            if (fieldNames.Contains("IsSpecialOffer"))
                if (!Convert.IsDBNull(reader["IsSpecialOffer"]))
                    offerDetailPrice.IsSpecialOffer = Convert.ToBoolean(reader["IsSpecialOffer"]);

            return offerDetailPrice;
        }

    }
}