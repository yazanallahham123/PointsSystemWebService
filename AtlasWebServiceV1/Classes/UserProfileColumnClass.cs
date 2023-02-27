using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class UserProfileColumnClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public string Name { get; set; }
      [DataMember(Order = 3)]
      public string ArabicName { get; set; }
      [DataMember(Order = 4)]
      public int Order { get; set; }


      public UserProfileColumnClass PopulateUserProfileColumn(string[] fieldNames, SqlDataReader reader)
      {
         var userProfileColumn = new UserProfileColumnClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               userProfileColumn.Id = (int)reader["Id"];

         if (fieldNames.Contains("Name"))
            if (!Convert.IsDBNull(reader["Name"]))
               userProfileColumn.Name = reader["Name"].ToString();

         if (fieldNames.Contains("ArabicName"))
            if (!Convert.IsDBNull(reader["ArabicName"]))
               userProfileColumn.ArabicName = reader["ArabicName"].ToString();

         return userProfileColumn;
      }

   }
}