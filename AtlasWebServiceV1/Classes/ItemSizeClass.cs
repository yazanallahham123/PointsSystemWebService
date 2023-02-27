using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class ItemSizeClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int ItemId { get; set; }
        [DataMember(Order = 3)]
        public int SizeId { get; set; }
        [DataMember(Order = 4)]
        public string ArabicDescription { get; set; }
        [DataMember(Order = 5)]
        public string EnglishDescription { get; set; }
        [DataMember(Order = 6)]
        public string ItemArabicName { get; set; }
        [DataMember(Order = 7)]
        public string ItemEnglishName { get; set; }
        [DataMember(Order = 8)]
        public string SizeArabicName { get; set; }
        [DataMember(Order = 9)]
        public string SizeEnglishName { get; set; }
        [DataMember(Order = 10)]
        public int Order { get; set; }
        [DataMember(Order = 11)]
        public bool HasPriceOffer { get; set; }
        [DataMember(Order = 12)]
        public string PriceAdd { get; set; }
        [DataMember(Order = 13)]
        public string OfferPriceAdd { get; set; }
        [DataMember(Order = 14)]
        public bool HasPointsOffer { get; set; }
        [DataMember(Order = 15)]
        public int RequiredPointsAdd { get; set; }
        [DataMember(Order = 16)]
        public int OfferRequiredPointsAdd { get; set; }
        [DataMember(Order = 17)]
        public int PriceTypeId { get; set; }
        [DataMember(Order = 17)]
        public int CountryCurrencyId { get; set; }
        [DataMember(Order = 17)]
        public bool Disabled { get; set; }
        [DataMember(Order = 15)]
        public int GrantedPointsAdd { get; set; }


        public ItemSizeClass PopulateItemSize(string[] fieldNames, SqlDataReader reader)
        {
            var itemSize = new ItemSizeClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    itemSize.Id = (int)reader["Id"];

            if (fieldNames.Contains("ItemId"))
                if (!Convert.IsDBNull(reader["ItemId"]))
                    itemSize.ItemId = (int)reader["ItemId"];

            if (fieldNames.Contains("SizeId"))
                if (!Convert.IsDBNull(reader["SizeId"]))
                    itemSize.SizeId = (int)reader["SizeId"];

            if (fieldNames.Contains("ArabicDescription"))
                if (!Convert.IsDBNull(reader["ArabicDescription"]))
                    itemSize.ArabicDescription = reader["ArabicDescription"].ToString();

            if (fieldNames.Contains("EnglishDescription"))
                if (!Convert.IsDBNull(reader["EnglishDescription"]))
                    itemSize.EnglishDescription = reader["EnglishDescription"].ToString();

            if (fieldNames.Contains("ItemArabicName"))
                if (!Convert.IsDBNull(reader["ItemArabicName"]))
                    itemSize.ItemArabicName = reader["ItemArabicName"].ToString();

            if (fieldNames.Contains("ItemEnglishName"))
                if (!Convert.IsDBNull(reader["ItemEnglishName"]))
                    itemSize.ItemEnglishName = reader["ItemEnglishName"].ToString();

            if (fieldNames.Contains("SizeArabicName"))
                if (!Convert.IsDBNull(reader["SizeArabicName"]))
                    itemSize.SizeArabicName = reader["SizeArabicName"].ToString();

            if (fieldNames.Contains("SizeEnglishName"))
                if (!Convert.IsDBNull(reader["SizeEnglishName"]))
                    itemSize.SizeEnglishName = reader["SizeEnglishName"].ToString();

            if (fieldNames.Contains("Disabled"))
                if (!Convert.IsDBNull(reader["Disabled"]))
                    itemSize.Disabled = Convert.ToBoolean(reader["Disabled"]);

            if (fieldNames.Contains("HasPriceOffer"))
                if (!Convert.IsDBNull(reader["HasPriceOffer"]))
                    itemSize.HasPriceOffer = Convert.ToBoolean(reader["HasPriceOffer"]);

            if (fieldNames.Contains("PriceAdd"))
                if (!Convert.IsDBNull(reader["PriceAdd"]))
                    itemSize.PriceAdd = reader["PriceAdd"].ToString();

            if (fieldNames.Contains("OfferPriceAdd"))
                if (!Convert.IsDBNull(reader["OfferPriceAdd"]))
                    itemSize.OfferPriceAdd = reader["OfferPriceAdd"].ToString();

            if (fieldNames.Contains("HasPointsOffer"))
                if (!Convert.IsDBNull(reader["HasPointsOffer"]))
                    itemSize.HasPointsOffer = Convert.ToBoolean(reader["HasPointsOffer"]);

            if (fieldNames.Contains("RequiredPointsAdd"))
                if (!Convert.IsDBNull(reader["RequiredPointsAdd"]))
                    itemSize.RequiredPointsAdd = Convert.ToInt32(reader["RequiredPointsAdd"]);

            if (fieldNames.Contains("OfferRequiredPointsAdd"))
                if (!Convert.IsDBNull(reader["OfferRequiredPointsAdd"]))
                    itemSize.OfferRequiredPointsAdd = Convert.ToInt32(reader["OfferRequiredPointsAdd"]);

            if (fieldNames.Contains("GrantedPointsAdd"))
                if (!Convert.IsDBNull(reader["GrantedPointsAdd"]))
                    itemSize.GrantedPointsAdd = Convert.ToInt32(reader["GrantedPointsAdd"]);

            return itemSize;
        }    }
}