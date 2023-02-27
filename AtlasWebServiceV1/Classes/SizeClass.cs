using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class SizeClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public int SizeGroupId { get; set; }
      [DataMember(Order = 3)]
      public string ArabicName { get; set; }
      [DataMember(Order = 4)]
      public string EnglishName { get; set; }
      [DataMember(Order = 5)]
      public string Code { get; set; }
      [DataMember(Order = 6)]
      public string SizeGroupArabicName { get; set; }
      [DataMember(Order = 7)]
      public string SizeGroupEnglishName { get; set; }
      [DataMember(Order = 8)]
      public int Order { get; set; }


      public SizeClass PopulateSize(string[] fieldNames, SqlDataReader reader)
      {
         var size = new SizeClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               size.Id = (int)reader["Id"];

         if (fieldNames.Contains("SizeGroupId"))
            if (!Convert.IsDBNull(reader["SizeGroupId"]))
               size.SizeGroupId = (int)reader["SizeGroupId"];

         if (fieldNames.Contains("ArabicName"))
            if (!Convert.IsDBNull(reader["ArabicName"]))
               size.ArabicName = reader["ArabicName"].ToString();

         if (fieldNames.Contains("EnglishName"))
            if (!Convert.IsDBNull(reader["EnglishName"]))
               size.EnglishName = reader["EnglishName"].ToString();

         if (fieldNames.Contains("Code"))
            if (!Convert.IsDBNull(reader["Code"]))
               size.Code = reader["Code"].ToString();

         if (fieldNames.Contains("SizeGroupArabicName"))
            if (!Convert.IsDBNull(reader["SizeGroupArabicName"]))
               size.SizeGroupArabicName = reader["SizeGroupArabicName"].ToString();

         if (fieldNames.Contains("SizeGroupEnglishName"))
            if (!Convert.IsDBNull(reader["SizeGroupEnglishName"]))
               size.SizeGroupEnglishName = reader["SizeGroupEnglishName"].ToString();

         return size;
      }

   }
}