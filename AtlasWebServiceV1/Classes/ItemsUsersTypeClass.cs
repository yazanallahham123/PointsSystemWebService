using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class ItemsUsersTypeClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int ItemId { get; set; }
      [DataMember(Order = 3)]
      public int UserTypeId { get; set; }
      [DataMember(Order = 4)]
      public string ItemArabicName { get; set; }
      [DataMember(Order = 5)]
      public string ItemEnglishName { get; set; }
      [DataMember(Order = 6)]
      public string UserTypeName { get; set; }
      [DataMember(Order = 7)]
      public int Order { get; set; }

      public ItemsUsersTypeClass PopulateItemsUsersType(string[] fieldNames, SqlDataReader reader)
      {
         var itemsUserType = new ItemsUsersTypeClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               itemsUserType.Id = (int)reader["Id"];

         if (fieldNames.Contains("ItemId"))
            if (!Convert.IsDBNull(reader["ItemId"]))
               itemsUserType.ItemId = (int)reader["ItemId"];

         if (fieldNames.Contains("UserTypeId"))
            if (!Convert.IsDBNull(reader["UserTypeId"]))
               itemsUserType.UserTypeId = (int)reader["UserTypeId"];

         if (fieldNames.Contains("ItemArabicName"))
            if (!Convert.IsDBNull(reader["ItemArabicName"]))
               itemsUserType.ItemArabicName = reader["ItemArabicName"].ToString();

         if (fieldNames.Contains("ItemEnglishName"))
            if (!Convert.IsDBNull(reader["ItemEnglishName"]))
               itemsUserType.ItemEnglishName = reader["ItemEnglishName"].ToString();

         if (fieldNames.Contains("UserTypeName"))
            if (!Convert.IsDBNull(reader["UserTypeName"]))
               itemsUserType.UserTypeName = reader["UserTypeName"].ToString();

         return itemsUserType;
      }
   }
}