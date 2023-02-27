using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class OffersUsersTypeClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int OfferId { get; set; }
      [DataMember(Order = 3)]
      public int UserTypeId { get; set; }
      [DataMember(Order = 4)]
      public string OfferArabicName { get; set; }
      [DataMember(Order = 5)]
      public string OfferEnglishName { get; set; }
      [DataMember(Order = 6)]
      public string UserTypeName { get; set; }
      [DataMember(Order = 7)]
      public int Order { get; set; }

      internal OffersUsersTypeClass PopulateOffersUsersType(string[] fieldNames, SqlDataReader reader)
      {
         var offersUsersType = new OffersUsersTypeClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               offersUsersType.Id = (int)reader["Id"];

         if (fieldNames.Contains("OfferId"))
            if (!Convert.IsDBNull(reader["OfferId"]))
               offersUsersType.OfferId = (int)reader["OfferId"];

         if (fieldNames.Contains("UserTypeId"))
            if (!Convert.IsDBNull(reader["UserTypeId"]))
               offersUsersType.UserTypeId = (int)reader["UserTypeId"];

         if (fieldNames.Contains("OfferArabicName"))
            if (!Convert.IsDBNull(reader["OfferArabicName"]))
               offersUsersType.OfferArabicName = reader["OfferArabicName"].ToString();

         if (fieldNames.Contains("OfferEnglishName"))
            if (!Convert.IsDBNull(reader["OfferEnglishName"]))
               offersUsersType.OfferEnglishName = reader["OfferEnglishName"].ToString();

         if (fieldNames.Contains("UserTypeName"))
            if (!Convert.IsDBNull(reader["UserTypeName"]))
               offersUsersType.UserTypeName = reader["UserTypeName"].ToString();


         return offersUsersType;
      }
   }
}