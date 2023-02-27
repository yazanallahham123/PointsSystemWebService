using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class UserBadgesClass
   {
      [DataMember(Order = 1)]
      public int UserId { get; set; }
      [DataMember(Order = 2)]
      public string Username { get; set; }
      [DataMember(Order = 3)]
      public string FullName { get; set; }
      [DataMember(Order = 4)]
      public bool Disabled { get; set; }
      [DataMember(Order = 5)]
      public bool IsActive { get; set; }

      [DataMember(Order = 6)]
      public int LastOpenOrderBadgeCount { get; set; }
      [DataMember(Order = 7)]
      public int AllNotificationsCount { get; set; }

      [DataMember(Order = 8)]
      public int TotalLikesCount { get; set; }
      [DataMember(Order = 9)]
      public int TotalWishlistsCount { get; set; }



      public UserBadgesClass PopulateUserBadges(string[] fieldNames, SqlDataReader reader)
      {
         var userBadge = new UserBadgesClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               userBadge.UserId = Convert.ToInt32(reader["Id"]);

         if (fieldNames.Contains("Username"))
            if (!Convert.IsDBNull(reader["Username"]))
               userBadge.Username = reader["Username"].ToString();

         if (fieldNames.Contains("FullName"))
            if (!Convert.IsDBNull(reader["FullName"]))
               userBadge.FullName = reader["FullName"].ToString();

         if (fieldNames.Contains("Disabled"))
            if (!Convert.IsDBNull(reader["Disabled"]))
               userBadge.Disabled = Convert.ToBoolean(reader["Disabled"]);

         if (fieldNames.Contains("IsActive"))
            if (!Convert.IsDBNull(reader["IsActive"]))
               userBadge.IsActive = Convert.ToBoolean(reader["IsActive"]);

         if (fieldNames.Contains("LastOpenOrderBadgeCount"))
            if (!Convert.IsDBNull(reader["LastOpenOrderBadgeCount"]))
               userBadge.LastOpenOrderBadgeCount = Convert.ToInt32(reader["LastOpenOrderBadgeCount"]);

         if (fieldNames.Contains("AllNotificationsCount"))
            if (!Convert.IsDBNull(reader["AllNotificationsCount"]))
               userBadge.AllNotificationsCount = Convert.ToInt32(reader["AllNotificationsCount"]);

         if (fieldNames.Contains("TotalLikesCount"))
            if (!Convert.IsDBNull(reader["TotalLikesCount"]))
               userBadge.TotalLikesCount = Convert.ToInt32(reader["TotalLikesCount"]);

         if (fieldNames.Contains("TotalWishlistsCount"))
            if (!Convert.IsDBNull(reader["TotalWishlistsCount"]))
               userBadge.TotalWishlistsCount = Convert.ToInt32(reader["TotalWishlistsCount"]);


         return userBadge;
      }

   }
}
