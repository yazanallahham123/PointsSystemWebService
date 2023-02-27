using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class UserTypeClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public string Name { get; set; }
      [DataMember(Order = 3)]
      public int Order { get; set; }



      public UserTypeClass PopulateUserType(string[] fieldNames, SqlDataReader reader)
      {
         var userType = new UserTypeClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               userType.Id = (int)reader["Id"];

         if (fieldNames.Contains("Name"))
            if (!Convert.IsDBNull(reader["Name"]))
               userType.Name = reader["Name"].ToString();

         return userType;
      }
   }
}