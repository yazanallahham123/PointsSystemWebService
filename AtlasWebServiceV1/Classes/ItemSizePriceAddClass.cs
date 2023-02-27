using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class ItemSizePriceAddClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public int ItemSizeId { get; set; }
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
        public int SizeId { get; set; }
        [DataMember(Order = 16)]
        public int SizeGroupId { get; set; }


        [DataMember(Order = 17)]
        public int RequiredPointsAdd { get; set; }

        [DataMember(Order = 18)]
        public int GrantedPointsAdd { get; set; }

        public ItemSizePriceAddClass PopulateItemSizePriceAdd(string[] fieldNames, SqlDataReader reader)
        {
            var itemSizePrice = new ItemSizePriceAddClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    itemSizePrice.Id = Convert.ToInt32(reader["Id"]);

            if (fieldNames.Contains("ItemSizeId"))
                if (!Convert.IsDBNull(reader["ItemSizeId"]))
                    itemSizePrice.ItemSizeId = Convert.ToInt32(reader["ItemSizeId"]);

            if (fieldNames.Contains("PriceAdd"))
                if (!Convert.IsDBNull(reader["PriceAdd"]))
                    itemSizePrice.PriceAdd = Convert.ToDouble(reader["PriceAdd"]);

            if (fieldNames.Contains("TypeId"))
                if (!Convert.IsDBNull(reader["TypeId"]))
                    itemSizePrice.TypeId = Convert.ToInt32(reader["TypeId"]);

            if (fieldNames.Contains("TypeArabicName"))
                if (!Convert.IsDBNull(reader["TypeArabicName"]))
                    itemSizePrice.TypeArabicName = reader["TypeArabicName"].ToString();

            if (fieldNames.Contains("TypeEnglishName"))
                if (!Convert.IsDBNull(reader["TypeEnglishName"]))
                    itemSizePrice.TypeEnglishName = reader["TypeEnglishName"].ToString();

            if (fieldNames.Contains("CountryId"))
                if (!Convert.IsDBNull(reader["CountryId"]))
                    itemSizePrice.CountryId = Convert.ToInt32(reader["CountryId"]);

            if (fieldNames.Contains("CountryArabicName"))
                if (!Convert.IsDBNull(reader["CountryArabicName"]))
                    itemSizePrice.CountryArabicName = reader["CountryArabicName"].ToString();

            if (fieldNames.Contains("CountryEnglishName"))
                if (!Convert.IsDBNull(reader["CountryEnglishName"]))
                    itemSizePrice.CountryEnglishName = reader["CountryEnglishName"].ToString();

            if (fieldNames.Contains("CurrencyArabicName"))
                if (!Convert.IsDBNull(reader["CurrencyArabicName"]))
                    itemSizePrice.CurrencyArabicName = reader["CurrencyArabicName"].ToString();

            if (fieldNames.Contains("CurrencyEnglishName"))
                if (!Convert.IsDBNull(reader["CurrencyEnglishName"]))
                    itemSizePrice.CurrencyEnglishName = reader["CurrencyEnglishName"].ToString();

            if (fieldNames.Contains("CurrencyArabicCode"))
                if (!Convert.IsDBNull(reader["CurrencyArabicCode"]))
                    itemSizePrice.CurrencyArabicCode = reader["CurrencyArabicCode"].ToString();

            if (fieldNames.Contains("CurrencyEnglishCode"))
                if (!Convert.IsDBNull(reader["CurrencyEnglishCode"]))
                    itemSizePrice.CurrencyEnglishCode = reader["CurrencyEnglishCode"].ToString();

            if (fieldNames.Contains("CountryCurrencyId"))
                if (!Convert.IsDBNull(reader["CountryCurrencyId"]))
                    itemSizePrice.CountryCurrencyId = Convert.ToInt32(reader["CountryCurrencyId"]);

            if (fieldNames.Contains("CurrencyId"))
                if (!Convert.IsDBNull(reader["CurrencyId"]))
                    itemSizePrice.CurrencyId = Convert.ToInt32(reader["CurrencyId"]);

            if (fieldNames.Contains("SizeId"))
                if (!Convert.IsDBNull(reader["SizeId"]))
                    itemSizePrice.SizeId = Convert.ToInt32(reader["SizeId"]);

            if (fieldNames.Contains("SizeGroupId"))
                if (!Convert.IsDBNull(reader["SizeGroupId"]))
                    itemSizePrice.SizeGroupId = Convert.ToInt32(reader["SizeGroupId"]);

            if (fieldNames.Contains("RequiredPointsAdd"))
                if (!Convert.IsDBNull(reader["RequiredPointsAdd"]))
                    itemSizePrice.RequiredPointsAdd = Convert.ToInt32(reader["RequiredPointsAdd"]);

            if (fieldNames.Contains("GrantedPointsAdd"))
                if (!Convert.IsDBNull(reader["GrantedPointsAdd"]))
                    itemSizePrice.GrantedPointsAdd = Convert.ToInt32(reader["GrantedPointsAdd"]);


            return itemSizePrice;
        }

    }
}