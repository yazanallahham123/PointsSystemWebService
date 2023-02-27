using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class BrandClass
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
      [DataMember(Order = 6)]
      public string LogoURL { get; set; }
      [DataMember(Order = 7)]
      public string CoverImageURL { get; set; }
        [DataMember(Order = 8)]
        public bool Disabled { get; set; }
        [DataMember(Order = 9)]
        public string DepartmentImageURL { get; set; }

        public BrandClass PopulateBrand(string[] fieldNames, SqlDataReader reader)
      {
         var street = new BrandClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               street.Id = (int)reader["Id"];

         if (fieldNames.Contains("ArabicName"))
            if (!Convert.IsDBNull(reader["ArabicName"]))
               street.ArabicName = reader["ArabicName"].ToString();

         if (fieldNames.Contains("EnglishName"))
            if (!Convert.IsDBNull(reader["EnglishName"]))
               street.EnglishName = reader["EnglishName"].ToString();

         if (fieldNames.Contains("Code"))
            if (!Convert.IsDBNull(reader["Code"]))
               street.Code = reader["Code"].ToString();

            if (fieldNames.Contains("LogoURL"))
                if (!Convert.IsDBNull(reader["LogoURL"]))
                    street.LogoURL = reader["LogoURL"].ToString();

            if (fieldNames.Contains("CoverImageURL"))
                if (!Convert.IsDBNull(reader["CoverImageURL"]))
                    street.CoverImageURL = reader["CoverImageURL"].ToString();

            if (fieldNames.Contains("Disabled"))
                if (!Convert.IsDBNull(reader["Disabled"]))
                    street.Disabled = Convert.ToBoolean(reader["Disabled"]);

            if (fieldNames.Contains("DepartmentImageURL"))
                if (!Convert.IsDBNull(reader["DepartmentImageURL"]))
                    street.DepartmentImageURL = reader["DepartmentImageURL"].ToString();


            if (fieldNames.Contains("Order"))
                if (!Convert.IsDBNull(reader["Order"]))
                    street.Order = Convert.ToInt32(reader["Order"]);
            return street;
      }

   }
}