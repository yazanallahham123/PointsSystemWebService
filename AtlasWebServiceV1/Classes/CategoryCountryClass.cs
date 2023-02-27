using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class CategoryCountryClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int CategoryId { get; set; }
        [DataMember(Order = 3)]
        public int CountryId { get; set; }
        [DataMember(Order = 4)]
        public string CategoryArabicName { get; set; }
        [DataMember(Order = 5)]
        public string CategoryEnglishName { get; set; }
        [DataMember(Order = 6)]
        public string CountryArabicName { get; set; }
        [DataMember(Order = 7)]
        public string CountryEnglishName { get; set; }
        [DataMember(Order = 8)]
        public int Order { get; set; }


        public CategoryCountryClass PopulateCategoryCountry(string[] fieldNames, SqlDataReader reader)
        {
            var categoryCountry = new CategoryCountryClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    categoryCountry.Id = Convert.ToInt32(reader["Id"]);

            if (fieldNames.Contains("CategoryId"))
                if (!Convert.IsDBNull(reader["CategoryId"]))
                    categoryCountry.CategoryId = Convert.ToInt32(reader["CategoryId"]);

            if (fieldNames.Contains("CountryId"))
                if (!Convert.IsDBNull(reader["CountryId"]))
                    categoryCountry.CountryId = (int)reader["CountryId"];

            if (fieldNames.Contains("CategoryArabicName"))
                if (!Convert.IsDBNull(reader["CategoryArabicName"]))
                    categoryCountry.CategoryArabicName = reader["CategoryArabicName"].ToString();

            if (fieldNames.Contains("CategoryEnglishName"))
                if (!Convert.IsDBNull(reader["CategoryEnglishName"]))
                    categoryCountry.CategoryEnglishName = reader["CategoryEnglishName"].ToString();

            if (fieldNames.Contains("CountryArabicName"))
                if (!Convert.IsDBNull(reader["CountryArabicName"]))
                    categoryCountry.CountryArabicName = reader["CountryArabicName"].ToString();

            if (fieldNames.Contains("CountryEnglishName"))
                if (!Convert.IsDBNull(reader["CountryEnglishName"]))
                    categoryCountry.CountryEnglishName = reader["CountryEnglishName"].ToString();

            return categoryCountry;
        }

    }
}