using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   public class UsernameAvailableClass
   {
      [DataMember(Order = 1)]
      public bool IsAvailable { get; set; }
      [DataMember(Order = 2)]
      public string SuggestedUsername { get; set; }


      public UsernameAvailableClass PopulateUsernameAvailable(string[] fieldNames, SqlDataReader reader)
      {
         var UsernameAvailable = new UsernameAvailableClass();

         if (fieldNames.Contains("IsAvailable"))
            if (!Convert.IsDBNull(reader["IsAvailable"]))
               UsernameAvailable.IsAvailable = Convert.ToBoolean(reader["IsAvailable"]);

         if (fieldNames.Contains("SuggestedUsername"))
            if (!Convert.IsDBNull(reader["SuggestedUsername"]))
               UsernameAvailable.SuggestedUsername = reader["SuggestedUsername"].ToString();

         return UsernameAvailable;
      }
   }
}