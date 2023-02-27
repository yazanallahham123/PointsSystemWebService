using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class CountryCurrencyClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int CountryId { get; set; }
      [DataMember(Order = 3)]
      public int CurrencyId { get; set; }
      [DataMember(Order = 4)]
      public bool Disabled { get; set; }
      [DataMember(Order = 5)]
      public string CurrencyArabicName { get; set; }
      [DataMember(Order = 6)]
      public string CurrencyEnglishName { get; set; }
      [DataMember(Order = 7)]
      public string CountryArabicName { get; set; }
      [DataMember(Order = 8)]
      public string CountryEnglishName { get; set; }

      [DataMember(Order = 9)]
      public int Order { get; set; }



      public CountryCurrencyClass PopulateCountryCurrency(string[] fieldNames, SqlDataReader reader)
      {
         var countryCurrency = new CountryCurrencyClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               countryCurrency.Id = Convert.ToInt32(reader["Id"]);

         if (fieldNames.Contains("CountryId"))
            if (!Convert.IsDBNull(reader["CountryId"]))
               countryCurrency.CountryId = Convert.ToInt32(reader["CountryId"]);

         if (fieldNames.Contains("CurrencyId"))
            if (!Convert.IsDBNull(reader["CurrencyId"]))
               countryCurrency.CurrencyId = Convert.ToInt32(reader["CurrencyId"]);

         if (fieldNames.Contains("Disabled"))
            if (!Convert.IsDBNull(reader["Disabled"]))
               countryCurrency.Disabled = Convert.ToBoolean(reader["Disabled"]);

         if (fieldNames.Contains("CountryArabicName"))
            if (!Convert.IsDBNull(reader["CountryArabicName"]))
               countryCurrency.CountryArabicName = reader["CountryArabicName"].ToString();

         if (fieldNames.Contains("CountryEnglishName"))
            if (!Convert.IsDBNull(reader["CountryEnglishName"]))
               countryCurrency.CountryEnglishName = reader["CountryEnglishName"].ToString();

         if (fieldNames.Contains("CurrencyArabicName"))
            if (!Convert.IsDBNull(reader["CurrencyArabicName"]))
               countryCurrency.CurrencyArabicName = reader["CurrencyArabicName"].ToString();

         if (fieldNames.Contains("CurrencyEnglishName"))
            if (!Convert.IsDBNull(reader["CurrencyEnglishName"]))
               countryCurrency.CurrencyEnglishName = reader["CurrencyEnglishName"].ToString();


         return countryCurrency;
      }
   }
}