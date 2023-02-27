using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class NotificationTypesClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public string Name { get; set; }
      [DataMember(Order = 3)]
      public int Order { get; set; }



      public NotificationTypesClass PopulateNotificationType(string[] fieldNames, SqlDataReader reader)
      {
         var notificationType = new NotificationTypesClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               notificationType.Id = (int)reader["Id"];

         if (fieldNames.Contains("Name"))
            if (!Convert.IsDBNull(reader["Name"]))
               notificationType.Name = reader["Name"].ToString();



         return notificationType;
      }
   }
}