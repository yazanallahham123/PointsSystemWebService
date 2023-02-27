using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class CategoriesWithMapClass
   {
      [DataMember(Order = 1)]
      public List<CategoryClass> Categories { get; set; }
      [DataMember(Order = 2)]
      public List<CategoryMapClass> CategoriesMap { get; set; }
   }

   [DataContract]
   public class CategoryMapClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public string ArabicName { get; set; }
      [DataMember(Order = 2)]
      public string EnglishName { get; set; }
        [DataMember(Order = 3)]
        public int TypeId { get; set; }

        public CategoryMapClass PopulateCategoryMap(string[] fieldNames, SqlDataReader reader)
      {
         var categoryMap = new CategoryMapClass();

         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               categoryMap.Id = (int)reader["Id"];

         if (fieldNames.Contains("ArabicName"))
            if (!Convert.IsDBNull(reader["ArabicName"]))
               categoryMap.ArabicName = reader["ArabicName"].ToString();

         if (fieldNames.Contains("EnglishName"))
            if (!Convert.IsDBNull(reader["EnglishName"]))
               categoryMap.EnglishName = reader["EnglishName"].ToString();

            if (fieldNames.Contains("Type"))
                if (!Convert.IsDBNull(reader["Type"]))
                    categoryMap.TypeId = (int)reader["Type"];

            return categoryMap;
      }
   }


}