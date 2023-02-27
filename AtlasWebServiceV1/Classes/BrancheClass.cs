using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
   [DataContract]
   public class BrancheClass
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public string ArabicName { get; set; }
      [DataMember(Order = 3)]
      public string EnglishName { get; set; }

      [DataMember(Order = 4)]
      public int CountryId { get; set; }
      [DataMember(Order = 5)]
      public string CountryArabicName { get; set; }
      [DataMember(Order = 6)]
      public string CountryEnglishName { get; set; }
      [DataMember(Order = 7)]
      public int GovernorateId { get; set; }
      [DataMember(Order = 8)]
      public string GovernorateArabicName { get; set; }
      [DataMember(Order = 9)]
      public string GovernorateEnglishName { get; set; }
      [DataMember(Order = 10)]
      public int CityId { get; set; }
      [DataMember(Order = 11)]
      public string CityArabicName { get; set; }
      [DataMember(Order = 12)]
      public string CityEnglishName { get; set; }
      [DataMember(Order = 13)]
      public int LocationId { get; set; }
      [DataMember(Order = 14)]
      public string LocationArabicName { get; set; }
      [DataMember(Order = 15)]
      public string LocationEnglishName { get; set; }

      [DataMember(Order = 16)]
      public string Address { get; set; }

      [DataMember(Order = 17)]
      public int BrandId { get; set; }
      [DataMember(Order = 18)]
      public bool IsActive { get; set; }

        [DataMember(Order = 18)]
        public string Phone { get; set; }
        [DataMember(Order = 19)]
        public string Phone2 { get; set; }
        [DataMember(Order = 20)]
        public string Email { get; set; }
        [DataMember(Order = 21)]
        public double Longitude { get; set; }
        [DataMember(Order = 22)]
        public double Latitude { get; set; }
        [DataMember(Order = 23)]
      public int Order { get; set; }


      public BrancheClass PopulateBranche(string[] fieldNames, SqlDataReader reader)
      {
         var branche = new BrancheClass();
         if (fieldNames.Contains("Id"))
            if (!Convert.IsDBNull(reader["Id"]))
               branche.Id = Convert.ToInt32(reader["Id"]);

         if (fieldNames.Contains("ArabicName"))
            if (!Convert.IsDBNull(reader["ArabicName"]))
               branche.ArabicName = reader["ArabicName"].ToString();

         if (fieldNames.Contains("EnglishName"))
            if (!Convert.IsDBNull(reader["EnglishName"]))
               branche.EnglishName = reader["EnglishName"].ToString();


         if (fieldNames.Contains("CountryId"))
            if (!Convert.IsDBNull(reader["CountryId"]))
               branche.CountryId = Convert.ToInt32(reader["CountryId"]);

         if (fieldNames.Contains("CountryArabicName"))
            if (!Convert.IsDBNull(reader["CountryArabicName"]))
               branche.CountryArabicName = reader["CountryArabicName"].ToString();

         if (fieldNames.Contains("CountryEnglishName"))
            if (!Convert.IsDBNull(reader["CountryEnglishName"]))
               branche.CountryEnglishName = reader["CountryEnglishName"].ToString();


         if (fieldNames.Contains("GovernorateId"))
            if (!Convert.IsDBNull(reader["GovernorateId"]))
               branche.GovernorateId = Convert.ToInt32(reader["GovernorateId"]);

         if (fieldNames.Contains("GovernorateArabicName"))
            if (!Convert.IsDBNull(reader["GovernorateArabicName"]))
               branche.GovernorateArabicName = reader["GovernorateArabicName"].ToString();

         if (fieldNames.Contains("GovernorateEnglishName"))
            if (!Convert.IsDBNull(reader["GovernorateEnglishName"]))
               branche.GovernorateEnglishName = reader["GovernorateEnglishName"].ToString();


         if (fieldNames.Contains("CityId"))
            if (!Convert.IsDBNull(reader["CityId"]))
               branche.CityId = Convert.ToInt32(reader["CityId"]);

         if (fieldNames.Contains("CityArabicName"))
            if (!Convert.IsDBNull(reader["CityArabicName"]))
               branche.CityArabicName = reader["CityArabicName"].ToString();

         if (fieldNames.Contains("CityEnglishName"))
            if (!Convert.IsDBNull(reader["CityEnglishName"]))
               branche.CityEnglishName = reader["CityEnglishName"].ToString();


         if (fieldNames.Contains("LocationId"))
            if (!Convert.IsDBNull(reader["LocationId"]))
               branche.LocationId = Convert.ToInt32(reader["LocationId"]);

         if (fieldNames.Contains("LocationArabicName"))
            if (!Convert.IsDBNull(reader["LocationArabicName"]))
               branche.LocationArabicName = reader["LocationArabicName"].ToString();

         if (fieldNames.Contains("LocationEnglishName"))
            if (!Convert.IsDBNull(reader["LocationEnglishName"]))
               branche.LocationEnglishName = reader["LocationEnglishName"].ToString();


         if (fieldNames.Contains("Address"))
            if (!Convert.IsDBNull(reader["Address"]))
               branche.Address = reader["Address"].ToString();

         if (fieldNames.Contains("BrandId"))
            if (!Convert.IsDBNull(reader["BrandId"]))
               branche.BrandId = Convert.ToInt32(reader["BrandId"]);

         if (fieldNames.Contains("IsActive"))
            if (!Convert.IsDBNull(reader["IsActive"]))
               branche.IsActive = Convert.ToBoolean(reader["IsActive"]);

            if (fieldNames.Contains("Phone"))
                if (!Convert.IsDBNull(reader["Phone"]))
                    branche.Phone = reader["Phone"].ToString();

            if (fieldNames.Contains("Phone2"))
                if (!Convert.IsDBNull(reader["Phone2"]))
                    branche.Phone2 = reader["Phone2"].ToString();

            if (fieldNames.Contains("Email"))
                if (!Convert.IsDBNull(reader["Email"]))
                    branche.Email = reader["Email"].ToString();

            if (fieldNames.Contains("Longitude"))
                if (!Convert.IsDBNull(reader["Longitude"]))
                    branche.Longitude = Convert.ToDouble(reader["Longitude"]);

            if (fieldNames.Contains("Latitude"))
                if (!Convert.IsDBNull(reader["Latitude"]))
                    branche.Latitude = Convert.ToDouble(reader["Latitude"]);

            return branche;
      }
   }
}
