using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class CurrencyClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public string ArabicName { get; set; }
      [DataMember(Order = 3)]
      public string EnglishName { get; set; }
      [DataMember(Order = 4)]
      public string ArabicCode { get; set; }
      [DataMember(Order = 5)]
      public string EnglishCode { get; set; }
      [DataMember(Order = 6)]
      public double Equal { get; set; }
      [DataMember(Order = 7)]
      public bool IsMainCurrency { get; set; }
      [DataMember(Order = 8)]
      public int CalculationType { get; set; }
      [DataMember(Order = 9)]
      public int CountryId { get; set; }
      [DataMember(Order = 10)]
      public string CountryArabicName { get; set; }
      [DataMember(Order = 11)]
      public string CountryEnglishName { get; set; }
      [DataMember(Order = 12)]
      public bool Disabled { get; set; }
      [DataMember(Order = 13)]
      public int Order { get; set; }


      public CurrencyClass PopulateCurrency(string[] fieldNames, SqlDataReader reader)
      {
         var currency = new CurrencyClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               currency.Id = (int)reader["Id"];

         if (fieldNames.Contains("ArabicName"))
            if (!Convert.IsDBNull(reader["ArabicName"]))
               currency.ArabicName = reader["ArabicName"].ToString();

         if (fieldNames.Contains("EnglishName"))
            if (!Convert.IsDBNull(reader["EnglishName"]))
               currency.EnglishName = reader["EnglishName"].ToString();

         if (fieldNames.Contains("ArabicCode"))
            if (!Convert.IsDBNull(reader["ArabicCode"]))
               currency.ArabicCode = reader["ArabicCode"].ToString();

         if (fieldNames.Contains("EnglishCode"))
            if (!Convert.IsDBNull(reader["EnglishCode"]))
               currency.EnglishCode = reader["EnglishCode"].ToString();

         if (fieldNames.Contains("Equal"))
            if (!Convert.IsDBNull(reader["Equal"]))
               currency.Equal = Convert.ToDouble(reader["Equal"]);

         if (fieldNames.Contains("IsMainCurrency"))
            if (!Convert.IsDBNull(reader["IsMainCurrency"]))
               currency.IsMainCurrency = Convert.ToBoolean(reader["IsMainCurrency"]);

         if (fieldNames.Contains("CalculationType"))
            if (!Convert.IsDBNull(reader["CalculationType"]))
               currency.CalculationType = Convert.ToInt32(reader["CalculationType"]);

         if (fieldNames.Contains("CountryId"))
            if (!Convert.IsDBNull(reader["CountryId"]))
               currency.CountryId = Convert.ToInt32(reader["CountryId"]);

         if (fieldNames.Contains("CountryArabicName"))
            if (!Convert.IsDBNull(reader["CountryArabicName"]))
               currency.CountryArabicName = reader["CountryArabicName"].ToString();

         if (fieldNames.Contains("CountryEnglishName"))
            if (!Convert.IsDBNull(reader["CountryEnglishName"]))
               currency.CountryEnglishName = reader["CountryEnglishName"].ToString();

         if (fieldNames.Contains("Disabled"))
            if (!Convert.IsDBNull(reader["Disabled"]))
               currency.Disabled = Convert.ToBoolean(reader["Disabled"]);

         return currency;
      }


   }
}