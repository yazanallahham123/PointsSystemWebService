using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class ItemsGovernorateClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int ItemId { get; set; }
      [DataMember(Order = 3)]
      public int GovernorateId { get; set; }
      [DataMember(Order = 4)]
      public string ItemArabicName { get; set; }
      [DataMember(Order = 5)]
      public string ItemEnglishName { get; set; }
      [DataMember(Order = 6)]
      public string GovernorateArabicName { get; set; }
      [DataMember(Order = 7)]
      public string GovernorateEnglishName { get; set; }
      [DataMember(Order = 8)]
      public int Order { get; set; }



      public ItemsGovernorateClass PopulateItemsGovernorate(string[] fieldNames, SqlDataReader reader)
      {
         var itemsGovernorate = new ItemsGovernorateClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               itemsGovernorate.Id = (int)reader["Id"];

         if (fieldNames.Contains("ItemId"))
            if (!Convert.IsDBNull(reader["ItemId"]))
               itemsGovernorate.ItemId = (int)reader["ItemId"];

         if (fieldNames.Contains("GovernorateId"))
            if (!Convert.IsDBNull(reader["GovernorateId"]))
               itemsGovernorate.GovernorateId = (int)reader["GovernorateId"];

         if (fieldNames.Contains("ItemArabicName"))
            if (!Convert.IsDBNull(reader["ItemArabicName"]))
               itemsGovernorate.ItemArabicName = reader["ItemArabicName"].ToString();

         if (fieldNames.Contains("ItemEnglishName"))
            if (!Convert.IsDBNull(reader["ItemEnglishName"]))
               itemsGovernorate.ItemEnglishName = reader["ItemEnglishName"].ToString();

         if (fieldNames.Contains("GovernorateArabicName"))
            if (!Convert.IsDBNull(reader["GovernorateArabicName"]))
               itemsGovernorate.GovernorateArabicName = reader["GovernorateArabicName"].ToString();

         if (fieldNames.Contains("GovernorateEnglishName"))
            if (!Convert.IsDBNull(reader["GovernorateEnglishName"]))
               itemsGovernorate.GovernorateEnglishName = reader["GovernorateEnglishName"].ToString();

         return itemsGovernorate;
      }
   }
}