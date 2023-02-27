using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class GovernorateClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public string ArabicName { get; set; }
      [DataMember(Order = 3)]
      public string EnglishName { get; set; }
      [DataMember(Order = 4)]
      public int CountryId { get; set; }
      [DataMember(Order = 5)]
      public int Order { get; set; }


      public GovernorateClass PopulateGovernorate(string[] fieldNames, SqlDataReader reader)
      {
         var governorate = new GovernorateClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               governorate.Id = (int)reader["Id"];

         if (fieldNames.Contains("ArabicName"))
            if (!Convert.IsDBNull(reader["ArabicName"]))
               governorate.ArabicName = reader["ArabicName"].ToString();

         if (fieldNames.Contains("EnglishName"))
            if (!Convert.IsDBNull(reader["EnglishName"]))
               governorate.EnglishName = reader["EnglishName"].ToString();

         if (fieldNames.Contains("CountryId"))
            if (!Convert.IsDBNull(reader["CountryId"]))
               governorate.CountryId = Convert.ToInt32(reader["CountryId"]);

         return governorate;
      }

   }
}