using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class ItemColorPriceAddClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int ItemColorId { get; set; }
        [DataMember(Order = 3)]
        public double PriceAdd { get; set; }

        [DataMember(Order = 4)]
        public int TypeId { get; set; }
        [DataMember(Order = 4)]
        public string TypeArabicName { get; set; }
        [DataMember(Order = 4)]
        public string TypeEnglishName { get; set; }
        [DataMember(Order = 5)]
        public int CountryId { get; set; }

        [DataMember(Order = 6)]
        public string CountryArabicName { get; set; }

        [DataMember(Order = 7)]
        public string CountryEnglishName { get; set; }

        [DataMember(Order = 8)]
        public string CurrencyArabicName { get; set; }

        [DataMember(Order = 9)]
        public string CurrencyEnglishName { get; set; }

        [DataMember(Order = 10)]
        public string CurrencyArabicCode { get; set; }

        [DataMember(Order = 11)]
        public string CurrencyEnglishCode { get; set; }
        [DataMember(Order = 12)]
        public int CountryCurrencyId { get; set; }

        [DataMember(Order = 13)]
        public int Order { get; set; }
        [DataMember(Order = 14)]
        public int CurrencyId { get; set; }
        [DataMember(Order = 15)]
        public int ColorId { get; set; }

        [DataMember(Order = 16)]
        public int RequiredPointsAdd { get; set; }

        [DataMember(Order = 17)]
        public int GrantedPointsAdd { get; set; }

        public ItemColorPriceAddClass PopulateItemColorPriceAdd(string[] fieldNames, SqlDataReader reader)
        {
            var itemColorPrice = new ItemColorPriceAddClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    itemColorPrice.Id = Convert.ToInt32(reader["Id"]);

            if (fieldNames.Contains("ItemColorId"))
                if (!Convert.IsDBNull(reader["ItemColorId"]))
                    itemColorPrice.ItemColorId = Convert.ToInt32(reader["ItemColorId"]);

            if (fieldNames.Contains("PriceAdd"))
                if (!Convert.IsDBNull(reader["PriceAdd"]))
                    itemColorPrice.PriceAdd = Convert.ToDouble(reader["PriceAdd"]);

            if (fieldNames.Contains("TypeId"))
                if (!Convert.IsDBNull(reader["TypeId"]))
                    itemColorPrice.TypeId = Convert.ToInt32(reader["TypeId"]);

            if (fieldNames.Contains("TypeArabicName"))
                if (!Convert.IsDBNull(reader["TypeArabicName"]))
                    itemColorPrice.TypeArabicName = reader["TypeArabicName"].ToString();

            if (fieldNames.Contains("TypeEnglishName"))
                if (!Convert.IsDBNull(reader["TypeEnglishName"]))
                    itemColorPrice.TypeEnglishName = reader["TypeEnglishName"].ToString();

            if (fieldNames.Contains("CountryId"))
                if (!Convert.IsDBNull(reader["CountryId"]))
                    itemColorPrice.CountryId = Convert.ToInt32(reader["CountryId"]);

            if (fieldNames.Contains("CountryArabicName"))
                if (!Convert.IsDBNull(reader["CountryArabicName"]))
                    itemColorPrice.CountryArabicName = reader["CountryArabicName"].ToString();

            if (fieldNames.Contains("CountryEnglishName"))
                if (!Convert.IsDBNull(reader["CountryEnglishName"]))
                    itemColorPrice.CountryEnglishName = reader["CountryEnglishName"].ToString();

            if (fieldNames.Contains("CurrencyArabicName"))
                if (!Convert.IsDBNull(reader["CurrencyArabicName"]))
                    itemColorPrice.CurrencyArabicName = reader["CurrencyArabicName"].ToString();

            if (fieldNames.Contains("CurrencyEnglishName"))
                if (!Convert.IsDBNull(reader["CurrencyEnglishName"]))
                    itemColorPrice.CurrencyEnglishName = reader["CurrencyEnglishName"].ToString();

            if (fieldNames.Contains("CurrencyArabicCode"))
                if (!Convert.IsDBNull(reader["CurrencyArabicCode"]))
                    itemColorPrice.CurrencyArabicCode = reader["CurrencyArabicCode"].ToString();

            if (fieldNames.Contains("CurrencyEnglishCode"))
                if (!Convert.IsDBNull(reader["CurrencyEnglishCode"]))
                    itemColorPrice.CurrencyEnglishCode = reader["CurrencyEnglishCode"].ToString();

            if (fieldNames.Contains("CountryCurrencyId"))
                if (!Convert.IsDBNull(reader["CountryCurrencyId"]))
                    itemColorPrice.CountryCurrencyId = Convert.ToInt32(reader["CountryCurrencyId"]);

            if (fieldNames.Contains("CurrencyId"))
                if (!Convert.IsDBNull(reader["CurrencyId"]))
                    itemColorPrice.CurrencyId = Convert.ToInt32(reader["CurrencyId"]);

            if (fieldNames.Contains("ColorId"))
                if (!Convert.IsDBNull(reader["ColorId"]))
                    itemColorPrice.ColorId = Convert.ToInt32(reader["ColorId"]);

            if (fieldNames.Contains("RequiredPointsAdd"))
                if (!Convert.IsDBNull(reader["RequiredPointsAdd"]))
                    itemColorPrice.RequiredPointsAdd = Convert.ToInt32(reader["RequiredPointsAdd"]);

            if (fieldNames.Contains("GrantedPointsAdd"))
                if (!Convert.IsDBNull(reader["GrantedPointsAdd"]))
                    itemColorPrice.GrantedPointsAdd = Convert.ToInt32(reader["GrantedPointsAdd"]);

            return itemColorPrice;
        }

    }
}