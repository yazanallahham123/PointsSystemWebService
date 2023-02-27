using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class NotificationsUserClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int NotificationsTypeId { get; set; }
      [DataMember(Order = 3)]
      public int UserId { get; set; }
      [DataMember(Order = 4)]
      public int Order { get; set; }




      public NotificationsUserClass PopulateNotificationsUser(string[] fieldNames, SqlDataReader reader)
      {
         var notificationsUser = new NotificationsUserClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               notificationsUser.Id = (int)reader["Id"];

         if (fieldNames.Contains("NotificationsTypeId"))
            if (!Convert.IsDBNull(reader["NotificationsTypeId"]))
               notificationsUser.NotificationsTypeId = (int)reader["NotificationsTypeId"];

         if (fieldNames.Contains("UserId"))
            if (!Convert.IsDBNull(reader["UserId"]))
               notificationsUser.UserId = (int)reader["UserId"];

         return notificationsUser;
      }
   }
}