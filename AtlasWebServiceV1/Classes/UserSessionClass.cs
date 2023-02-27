using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   public class UserSessionClass
   {
      [DataMember(Order = 1)]
      public string Date { get; set; }

      [DataMember(Order = 2)]
      public string Hour { get; set; }

      [DataMember(Order = 3)]
      public int UserCount { get; set; }

      [DataMember(Order = 4)]
      public int TotalCount { get; set; }

      [DataMember(Order = 5)]
      public string PrecentageCount { get; set; }

      [DataMember(Order = 6)]
      public int Order { get; set; }



      public UserSessionClass PopulateUserSession(string[] fieldNames, SqlDataReader reader)
      {
         var userSession = new UserSessionClass();

         if (fieldNames.Contains("Date"))
            if (!Convert.IsDBNull(reader["Date"]))
               userSession.Date = Convert.ToDateTime(reader["Date"]).ToString("d");

         if (fieldNames.Contains("Hour"))
            if (!Convert.IsDBNull(reader["Hour"]))
               userSession.Hour = reader["Hour"].ToString();

         if (fieldNames.Contains("UserCount"))
            if (!Convert.IsDBNull(reader["UserCount"]))
               userSession.UserCount = Convert.ToInt32(reader["UserCount"]);

         if (fieldNames.Contains("TotalCount"))
            if (!Convert.IsDBNull(reader["TotalCount"]))
               userSession.TotalCount = Convert.ToInt32(reader["TotalCount"]);

         if (fieldNames.Contains("PrecentageCount"))
            if (!Convert.IsDBNull(reader["PrecentageCount"]))
               userSession.PrecentageCount = reader["PrecentageCount"].ToString();


         return userSession;
      }

   }
}