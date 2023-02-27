using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class OffersGovernorateClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int OfferId { get; set; }
      [DataMember(Order = 3)]
      public int GovernorateId { get; set; }
      [DataMember(Order = 4)]
      public string OfferArabicName { get; set; }
      [DataMember(Order = 5)]
      public string OfferEnglishName { get; set; }
      [DataMember(Order = 6)]
      public string GovernorateArabicName { get; set; }
      [DataMember(Order = 7)]
      public string GovernorateEnglishName { get; set; }
      [DataMember(Order = 8)]
      public int Order { get; set; }


      public OffersGovernorateClass PopulateOffersGovernorate(string[] fieldNames, SqlDataReader reader)
      {
         var offersGovernorate = new OffersGovernorateClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               offersGovernorate.Id = (int)reader["Id"];

         if (fieldNames.Contains("OfferId"))
            if (!Convert.IsDBNull(reader["OfferId"]))
               offersGovernorate.OfferId = (int)reader["OfferId"];

         if (fieldNames.Contains("GovernorateId"))
            if (!Convert.IsDBNull(reader["GovernorateId"]))
               offersGovernorate.GovernorateId = (int)reader["GovernorateId"];

         if (fieldNames.Contains("OfferArabicName"))
            if (!Convert.IsDBNull(reader["OfferArabicName"]))
               offersGovernorate.OfferArabicName = reader["OfferArabicName"].ToString();

         if (fieldNames.Contains("OfferEnglishName"))
            if (!Convert.IsDBNull(reader["OfferEnglishName"]))
               offersGovernorate.OfferEnglishName = reader["OfferEnglishName"].ToString();

         if (fieldNames.Contains("GovernorateArabicName"))
            if (!Convert.IsDBNull(reader["GovernorateArabicName"]))
               offersGovernorate.GovernorateArabicName = reader["GovernorateArabicName"].ToString();

         if (fieldNames.Contains("GovernorateEnglishName"))
            if (!Convert.IsDBNull(reader["GovernorateEnglishName"]))
               offersGovernorate.GovernorateEnglishName = reader["GovernorateEnglishName"].ToString();


         return offersGovernorate;
      }
   }
}