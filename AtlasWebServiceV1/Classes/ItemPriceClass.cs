using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class ItemPriceClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int ItemId { get; set; }
      [DataMember(Order = 3)]
      public string Price { get; set; }
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
        [DataMember(Order = 14)]
        public int RequiredPoints { get; set; }
        [DataMember(Order = 14)]
        public int GrantedPoints { get; set; }
        

        public ItemPriceClass PopulateItemPrice(string[] fieldNames, SqlDataReader reader)
      {
         var itemPrice = new ItemPriceClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               itemPrice.Id = Convert.ToInt32(reader["Id"]);

         if (fieldNames.Contains("ItemId"))
            if (!Convert.IsDBNull(reader["ItemId"]))
               itemPrice.ItemId = Convert.ToInt32(reader["ItemId"]);

            if (fieldNames.Contains("Price"))
                if (!Convert.IsDBNull(reader["Price"]))
                    itemPrice.Price = reader["Price"].ToString();

         if (fieldNames.Contains("TypeId"))
            if (!Convert.IsDBNull(reader["TypeId"]))
               itemPrice.TypeId = Convert.ToInt32(reader["TypeId"]);

         if (fieldNames.Contains("TypeArabicName"))
            if (!Convert.IsDBNull(reader["TypeArabicName"]))
               itemPrice.TypeArabicName = reader["TypeArabicName"].ToString();

         if (fieldNames.Contains("TypeEnglishName"))
            if (!Convert.IsDBNull(reader["TypeEnglishName"]))
               itemPrice.TypeEnglishName = reader["TypeEnglishName"].ToString();

         if (fieldNames.Contains("CountryId"))
            if (!Convert.IsDBNull(reader["CountryId"]))
               itemPrice.CountryId = Convert.ToInt32(reader["CountryId"]);

         if (fieldNames.Contains("CountryArabicName"))
            if (!Convert.IsDBNull(reader["CountryArabicName"]))
               itemPrice.CountryArabicName = reader["CountryArabicName"].ToString();

         if (fieldNames.Contains("CountryEnglishName"))
            if (!Convert.IsDBNull(reader["CountryEnglishName"]))
               itemPrice.CountryEnglishName = reader["CountryEnglishName"].ToString();

         if (fieldNames.Contains("CurrencyArabicName"))
            if (!Convert.IsDBNull(reader["CurrencyArabicName"]))
               itemPrice.CurrencyArabicName = reader["CurrencyArabicName"].ToString();

         if (fieldNames.Contains("CurrencyEnglishName"))
            if (!Convert.IsDBNull(reader["CurrencyEnglishName"]))
               itemPrice.CurrencyEnglishName = reader["CurrencyEnglishName"].ToString();

         if (fieldNames.Contains("CurrencyArabicCode"))
            if (!Convert.IsDBNull(reader["CurrencyArabicCode"]))
               itemPrice.CurrencyArabicCode = reader["CurrencyArabicCode"].ToString();

         if (fieldNames.Contains("CurrencyEnglishCode"))
            if (!Convert.IsDBNull(reader["CurrencyEnglishCode"]))
               itemPrice.CurrencyEnglishCode = reader["CurrencyEnglishCode"].ToString();

         if (fieldNames.Contains("CountryCurrencyId"))
            if (!Convert.IsDBNull(reader["CountryCurrencyId"]))
               itemPrice.CountryCurrencyId = Convert.ToInt32(reader["CountryCurrencyId"]);

            if (fieldNames.Contains("CurrencyId"))
                if (!Convert.IsDBNull(reader["CurrencyId"]))
                    itemPrice.CurrencyId = Convert.ToInt32(reader["CurrencyId"]);

            if (fieldNames.Contains("RequiredPoints"))
                if (!Convert.IsDBNull(reader["RequiredPoints"]))
                    itemPrice.RequiredPoints = Convert.ToInt32(reader["RequiredPoints"]);

            if (fieldNames.Contains("GrantedPoints"))
                if (!Convert.IsDBNull(reader["GrantedPoints"]))
                    itemPrice.GrantedPoints = Convert.ToInt32(reader["GrantedPoints"]);

            return itemPrice;
      }

   }
}