using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class ItemsCompanyClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int ItemId { get; set; }
      [DataMember(Order = 3)]
      public int CompanyId { get; set; }
      [DataMember(Order = 4)]
      public string ItemArabicName { get; set; }
      [DataMember(Order = 5)]
      public string ItemEnglishName { get; set; }
      [DataMember(Order = 6)]
      public string CompanyArabicName { get; set; }
      [DataMember(Order = 7)]
      public string CompanyEnglishName { get; set; }
      [DataMember(Order = 8)]
      public int Order { get; set; }

      public ItemsCompanyClass PopulateItemsCompany(string[] fieldNames, SqlDataReader reader)
      {
         var itemsCompany = new ItemsCompanyClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               itemsCompany.Id = (int)reader["Id"];

         if (fieldNames.Contains("ItemId"))
            if (!Convert.IsDBNull(reader["ItemId"]))
               itemsCompany.ItemId = (int)reader["ItemId"];

         if (fieldNames.Contains("CompanyId"))
            if (!Convert.IsDBNull(reader["CompanyId"]))
               itemsCompany.CompanyId = (int)reader["CompanyId"];

         if (fieldNames.Contains("ItemArabicName"))
            if (!Convert.IsDBNull(reader["ItemArabicName"]))
               itemsCompany.ItemArabicName = reader["ItemArabicName"].ToString();

         if (fieldNames.Contains("ItemEnglishName"))
            if (!Convert.IsDBNull(reader["ItemEnglishName"]))
               itemsCompany.ItemEnglishName = reader["ItemEnglishName"].ToString();

         if (fieldNames.Contains("CompanyArabicName"))
            if (!Convert.IsDBNull(reader["CompanyArabicName"]))
               itemsCompany.CompanyArabicName = reader["CompanyArabicName"].ToString();

         if (fieldNames.Contains("CompanyEnglishName"))
            if (!Convert.IsDBNull(reader["CompanyEnglishName"]))
               itemsCompany.CompanyEnglishName = reader["CompanyEnglishName"].ToString();

         return itemsCompany;
      }
   }
}