using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class UserCompanyClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int UserId { get; set; }
      [DataMember(Order = 3)]
      public int CompanyId { get; set; }
      [DataMember(Order = 4)]
      public string UserUsername { get; set; }
      [DataMember(Order = 5)]
      public string UserFullName { get; set; }
      [DataMember(Order = 6)]
      public string CompanyArabicName { get; set; }
      [DataMember(Order = 7)]
      public string CompanyEnglishName { get; set; }
      [DataMember(Order = 8)]
      public int Order { get; set; }


      public UserCompanyClass PopulateUserCompany(string[] fieldNames, SqlDataReader reader)
      {
         var userCompany = new UserCompanyClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               userCompany.Id = (int)reader["Id"];

         if (fieldNames.Contains("UserId"))
            if (!Convert.IsDBNull(reader["UserId"]))
               userCompany.UserId = Convert.ToInt32(reader["UserId"]);

         if (fieldNames.Contains("CompanyId"))
            if (!Convert.IsDBNull(reader["CompanyId"]))
               userCompany.CompanyId = Convert.ToInt32(reader["CompanyId"]);

         if (fieldNames.Contains("UserUsername"))
            if (!Convert.IsDBNull(reader["UserUsername"]))
               userCompany.UserUsername = reader["UserUsername"].ToString();

         if (fieldNames.Contains("UserFullName"))
            if (!Convert.IsDBNull(reader["UserFullName"]))
               userCompany.UserFullName = reader["UserFullName"].ToString();

         if (fieldNames.Contains("CompanyArabicName"))
            if (!Convert.IsDBNull(reader["CompanyArabicName"]))
               userCompany.CompanyArabicName = reader["CompanyArabicName"].ToString();

         if (fieldNames.Contains("CompanyEnglishName"))
            if (!Convert.IsDBNull(reader["CompanyEnglishName"]))
               userCompany.CompanyEnglishName = reader["CompanyEnglishName"].ToString();

         return userCompany;
      }
   }
}