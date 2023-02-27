using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   public class MobileAvailableClass
   {
      [DataMember(Order = 1)]
      public bool IsAvailable { get; set; }
      [DataMember(Order = 2)]
      public int CountryId { get; set; }

      public MobileAvailableClass PopulateMobileAvailable(string[] fieldNames, SqlDataReader reader)
      {
         var MobileAvailable = new MobileAvailableClass();

         if (fieldNames.Contains("IsAvailable"))
            if (!Convert.IsDBNull(reader["IsAvailable"]))
               MobileAvailable.IsAvailable = Convert.ToBoolean(reader["IsAvailable"]);

         if (fieldNames.Contains("CountryId"))
            if (!Convert.IsDBNull(reader["CountryId"]))
               MobileAvailable.CountryId = Convert.ToInt32(reader["CountryId"]);

         return MobileAvailable;
      }
   }
}