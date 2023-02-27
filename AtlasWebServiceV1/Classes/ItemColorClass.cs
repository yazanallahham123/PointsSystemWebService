using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class ItemColorClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int ItemId { get; set; }
      [DataMember(Order = 3)]
      public int ColorId { get; set; }
      [DataMember(Order = 4)]
      public string ColorImageURL { get; set; }
      [DataMember(Order = 5)]
      public string ArabicDescription { get; set; }
      [DataMember(Order = 6)]
      public string EnglishDescription { get; set; }
      [DataMember(Order = 7)]
      public string HexValue { get; set; }
      [DataMember(Order = 8)]
      public string ItemArabicName { get; set; }
      [DataMember(Order = 9)]
      public string ItemEnglishName { get; set; }
      [DataMember(Order = 10)]
      public string ColorArabicName { get; set; }
      [DataMember(Order = 11)]
      public string ColorEnglishName { get; set; }
      [DataMember(Order = 12)]
      public int Order { get; set; }
      [DataMember(Order = 13)]
      public int ItemImageIndex { get; set; }

        [DataMember(Order = 14)]
        public bool Disabled { get; set; }
        [DataMember(Order = 15)]
        public bool HasPriceOffer { get; set; }
        [DataMember(Order = 16)]
        public string PriceAdd { get; set; }
        [DataMember(Order = 17)]
        public string OfferPriceAdd { get; set; }
        [DataMember(Order = 18)]
        public bool HasPointsOffer { get; set; }
        [DataMember(Order = 19)]
        public int RequiredPointsAdd { get; set; }
        [DataMember(Order = 20)]
        public int OfferRequiredPointsAdd { get; set; }
        [DataMember(Order = 21)]
        public int GrantedPointsAdd { get; set; }

        public ItemColorClass PopulateItemColor(string[] fieldNames, SqlDataReader reader)
      {
         var itemColor = new ItemColorClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               itemColor.Id = (int)reader["Id"];

         if (fieldNames.Contains("ItemId"))
            if (!Convert.IsDBNull(reader["ItemId"]))
               itemColor.ItemId = (int)reader["ItemId"];

         if (fieldNames.Contains("ColorId"))
            if (!Convert.IsDBNull(reader["ColorId"]))
               itemColor.ColorId = (int)reader["ColorId"];

         if (fieldNames.Contains("ColorImageURL"))
            if (!Convert.IsDBNull(reader["ColorImageURL"]))
               itemColor.ColorImageURL = reader["ColorImageURL"].ToString();

         if (fieldNames.Contains("ArabicDescription"))
            if (!Convert.IsDBNull(reader["ArabicDescription"]))
               itemColor.ArabicDescription = reader["ArabicDescription"].ToString();

         if (fieldNames.Contains("EnglishDescription"))
            if (!Convert.IsDBNull(reader["EnglishDescription"]))
               itemColor.EnglishDescription = reader["EnglishDescription"].ToString();

         if (fieldNames.Contains("ItemArabicName"))
            if (!Convert.IsDBNull(reader["ItemArabicName"]))
               itemColor.ItemArabicName = reader["ItemArabicName"].ToString();

         if (fieldNames.Contains("ItemEnglishName"))
            if (!Convert.IsDBNull(reader["ItemEnglishName"]))
               itemColor.ItemEnglishName = reader["ItemEnglishName"].ToString();

         if (fieldNames.Contains("ColorArabicName"))
            if (!Convert.IsDBNull(reader["ColorArabicName"]))
               itemColor.ColorArabicName = reader["ColorArabicName"].ToString();

         if (fieldNames.Contains("ColorEnglishName"))
            if (!Convert.IsDBNull(reader["ColorEnglishName"]))
               itemColor.ColorEnglishName = reader["ColorEnglishName"].ToString();

         if (fieldNames.Contains("HexValue"))
            if (!Convert.IsDBNull(reader["HexValue"]))
               itemColor.HexValue = reader["HexValue"].ToString();

         if (fieldNames.Contains("ItemImageIndex"))
             if (!Convert.IsDBNull(reader["ItemImageIndex"]))
                itemColor.ItemImageIndex = (int)reader["ItemImageIndex"];

            if (fieldNames.Contains("Disabled"))
                if (!Convert.IsDBNull(reader["Disabled"]))
                    itemColor.Disabled = Convert.ToBoolean(reader["Disabled"]);



            if (fieldNames.Contains("HasPriceOffer"))
                if (!Convert.IsDBNull(reader["HasPriceOffer"]))
                    itemColor.HasPriceOffer = Convert.ToBoolean(reader["HasPriceOffer"]);

            if (fieldNames.Contains("PriceAdd"))
                if (!Convert.IsDBNull(reader["PriceAdd"]))
                    itemColor.PriceAdd = reader["PriceAdd"].ToString();

            if (fieldNames.Contains("OfferPriceAdd"))
                if (!Convert.IsDBNull(reader["OfferPriceAdd"]))
                    itemColor.OfferPriceAdd = reader["OfferPriceAdd"].ToString();

            if (fieldNames.Contains("HasPointsOffer"))
                if (!Convert.IsDBNull(reader["HasPointsOffer"]))
                    itemColor.HasPointsOffer = Convert.ToBoolean(reader["HasPointsOffer"]);

            if (fieldNames.Contains("RequiredPointsAdd"))
                if (!Convert.IsDBNull(reader["RequiredPointsAdd"]))
                    itemColor.RequiredPointsAdd = Convert.ToInt32(reader["RequiredPointsAdd"]);

            if (fieldNames.Contains("OfferRequiredPointsAdd"))
                if (!Convert.IsDBNull(reader["OfferRequiredPointsAdd"]))
                    itemColor.OfferRequiredPointsAdd = Convert.ToInt32(reader["OfferRequiredPointsAdd"]);

            if (fieldNames.Contains("GrantedPointsAdd"))
                if (!Convert.IsDBNull(reader["GrantedPointsAdd"]))
                    itemColor.GrantedPointsAdd = Convert.ToInt32(reader["GrantedPointsAdd"]);

            
            return itemColor;
      }
   }
}