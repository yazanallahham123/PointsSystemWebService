using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class OffersCompanyClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int CompanyId { get; set; }
      [DataMember(Order = 3)]
      public int OfferId { get; set; }
      [DataMember(Order = 4)]
      public string CompanyArabicName { get; set; }
      [DataMember(Order = 5)]
      public string CompanyEnglishName { get; set; }
      [DataMember(Order = 6)]
      public string OfferArabicName { get; set; }
      [DataMember(Order = 7)]
      public string OfferEnglishName { get; set; }
      [DataMember(Order = 8)]
      public int Order { get; set; }

      public OffersCompanyClass PopulateOfferCompany(string[] fieldNames, SqlDataReader reader)
      {
         var offerCompany = new OffersCompanyClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               offerCompany.Id = (int)reader["Id"];

         if (fieldNames.Contains("CompanyId"))
            if (!Convert.IsDBNull(reader["CompanyId"]))
               offerCompany.CompanyId = (int)reader["CompanyId"];

         if (fieldNames.Contains("OfferId"))
            if (!Convert.IsDBNull(reader["OfferId"]))
               offerCompany.OfferId = (int)reader["OfferId"];

         if (fieldNames.Contains("CompanyArabicName"))
            if (!Convert.IsDBNull(reader["CompanyArabicName"]))
               offerCompany.CompanyArabicName = reader["CompanyArabicName"].ToString();

         if (fieldNames.Contains("CompanyEnglishName"))
            if (!Convert.IsDBNull(reader["CompanyEnglishName"]))
               offerCompany.CompanyEnglishName = reader["CompanyEnglishName"].ToString();

         if (fieldNames.Contains("OfferArabicName"))
            if (!Convert.IsDBNull(reader["OfferArabicName"]))
               offerCompany.OfferArabicName = reader["OfferArabicName"].ToString();

         if (fieldNames.Contains("OfferEnglishName"))
            if (!Convert.IsDBNull(reader["OfferEnglishName"]))
               offerCompany.OfferEnglishName = reader["OfferEnglishName"].ToString();


         return offerCompany;
      }
   }
}