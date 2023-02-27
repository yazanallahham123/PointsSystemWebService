using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class UserTypeSendRuleClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int UserTypeId { get; set; }
      [DataMember(Order = 3)]
      public int ToUserTypeId { get; set; }
      [DataMember(Order = 4)]
      public string UserTypeName { get; set; }
      [DataMember(Order = 5)]
      public string ToUserTypeName { get; set; }
      [DataMember(Order = 6)]
      public int Order { get; set; }


      public UserTypeSendRuleClass PopulateUserTypeSendRule(string[] fieldNames, SqlDataReader reader)
      {
         var userTypeSendRule = new UserTypeSendRuleClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               userTypeSendRule.Id = (int)reader["Id"];

         if (fieldNames.Contains("UserTypeId"))
            if (!Convert.IsDBNull(reader["UserTypeId"]))
               userTypeSendRule.UserTypeId = Convert.ToInt32(reader["UserTypeId"]);

         if (fieldNames.Contains("ToUserTypeId"))
            if (!Convert.IsDBNull(reader["ToUserTypeId"]))
               userTypeSendRule.ToUserTypeId = Convert.ToInt32(reader["ToUserTypeId"]);

         if (fieldNames.Contains("UserTypeName"))
            if (!Convert.IsDBNull(reader["UserTypeName"]))
               userTypeSendRule.UserTypeName = reader["UserTypeName"].ToString();

         if (fieldNames.Contains("ToUserTypeName"))
            if (!Convert.IsDBNull(reader["ToUserTypeName"]))
               userTypeSendRule.ToUserTypeName = reader["ToUserTypeName"].ToString();

         return userTypeSendRule;
      }

   }
}