using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class ResourceClass
   {
      [DataMember(Order = 1)]
      public string Keyword { get; set; }
      [DataMember(Order = 2)]
      public string ArabicName { get; set; }
      [DataMember(Order = 3)]
      public string EnglishName { get; set; }
      [DataMember(Order = 4)]
      public int Order { get; set; }


      public ResourceClass PopulateResource(string[] fieldNames, SqlDataReader reader)
      {
         var resource = new ResourceClass();
         if (fieldNames.Contains("Keyword"))
            if (!Convert.IsDBNull(reader["Keyword"]))
               resource.Keyword = reader["Keyword"].ToString();

         if (fieldNames.Contains("ArabicName"))
            if (!Convert.IsDBNull(reader["ArabicName"]))
               resource.ArabicName = reader["ArabicName"].ToString();

         if (fieldNames.Contains("EnglishName"))
            if (!Convert.IsDBNull(reader["EnglishName"]))
               resource.EnglishName = reader["EnglishName"].ToString();

         return resource;
      }


   }
}