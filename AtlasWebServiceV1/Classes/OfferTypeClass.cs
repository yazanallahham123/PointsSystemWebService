using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class OfferTypeClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public string ArabicName { get; set; }
      [DataMember(Order = 3)]
      public string EnglishName { get; set; }
      [DataMember(Order = 4)]
      public int Order { get; set; }


      public OfferTypeClass PopulateOfferType(string[] fieldNames, SqlDataReader reader)
      {
         var offerType = new OfferTypeClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               offerType.Id = Convert.ToInt32(reader["Id"]);

         if (fieldNames.Contains("ArabicName"))
            if (!Convert.IsDBNull(reader["ArabicName"]))
               offerType.ArabicName = reader["ArabicName"].ToString();

         if (fieldNames.Contains("EnglishName"))
            if (!Convert.IsDBNull(reader["EnglishName"]))
               offerType.EnglishName = reader["EnglishName"].ToString();

         return offerType;
      }

   }
}
