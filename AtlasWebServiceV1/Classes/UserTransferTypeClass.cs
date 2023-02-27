using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class UserTransferTypeClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int UserId { get; set; }
      [DataMember(Order = 3)]
      public int UserTypeId { get; set; }
      [DataMember(Order = 4)]
      public string UserUsername { get; set; }
      [DataMember(Order = 5)]
      public string UserFullName { get; set; }
      [DataMember(Order = 6)]
      public string UserTypeName { get; set; }
      [DataMember(Order = 7)]
      public int Order { get; set; }



      public UserTransferTypeClass PopulateUserTransferType(string[] fieldNames, SqlDataReader reader)
      {
         var userTransferType = new UserTransferTypeClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               userTransferType.Id = (int)reader["Id"];

         if (fieldNames.Contains("UserId"))
            if (!Convert.IsDBNull(reader["UserId"]))
               userTransferType.UserId = Convert.ToInt32(reader["UserId"]);

         if (fieldNames.Contains("UserTypeId"))
            if (!Convert.IsDBNull(reader["UserTypeId"]))
               userTransferType.UserTypeId = Convert.ToInt32(reader["UserTypeId"]);

         if (fieldNames.Contains("UserUsername"))
            if (!Convert.IsDBNull(reader["UserUsername"]))
               userTransferType.UserUsername = reader["UserUsername"].ToString();

         if (fieldNames.Contains("UserFullName"))
            if (!Convert.IsDBNull(reader["UserFullName"]))
               userTransferType.UserFullName = reader["UserFullName"].ToString();

         if (fieldNames.Contains("UserTypeName"))
            if (!Convert.IsDBNull(reader["UserTypeName"]))
               userTransferType.UserTypeName = reader["UserTypeName"].ToString();

         return userTransferType;
      }
   }
}