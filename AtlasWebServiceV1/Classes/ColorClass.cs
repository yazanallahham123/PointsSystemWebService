using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class ColorClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public string ArabicName { get; set; }
      [DataMember(Order = 3)]
      public string EnglishName { get; set; }
      [DataMember(Order = 4)]
      public string Code { get; set; }
      [DataMember(Order = 5)]
      public int Order { get; set; }

      public ColorClass PopulateColor(string[] fieldNames, SqlDataReader reader)
      {
         var color = new ColorClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               color.Id = (int)reader["Id"];

         if (fieldNames.Contains("ArabicName"))
            if (!Convert.IsDBNull(reader["ArabicName"]))
               color.ArabicName = reader["ArabicName"].ToString();

         if (fieldNames.Contains("EnglishName"))
            if (!Convert.IsDBNull(reader["EnglishName"]))
               color.EnglishName = reader["EnglishName"].ToString();

         if (fieldNames.Contains("Code"))
            if (!Convert.IsDBNull(reader["Code"]))
               color.Code = reader["Code"].ToString();

         return color;
      }
   }
}