using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class ItemDepartmentImageCountryClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int ItemDepartmentImageId { get; set; }
        [DataMember(Order = 3)]
        public int CountryId { get; set; }
        [DataMember(Order = 4)]
        public string CountryArabicName { get; set; }
        [DataMember(Order = 5)]
        public string CountryEnglishName { get; set; }


        public ItemDepartmentImageCountryClass PopulateItemDepartmentImageCountry(string[] fieldNames, SqlDataReader reader)
        {
            var itemDepartmentImageCountry = new ItemDepartmentImageCountryClass();


            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    itemDepartmentImageCountry.Id = Convert.ToInt32(reader["Id"]);

            if (fieldNames.Contains("ItemDepartmentImageId"))
                if (!Convert.IsDBNull(reader["ItemDepartmentImageId"]))
                    itemDepartmentImageCountry.ItemDepartmentImageId = Convert.ToInt32(reader["ItemDepartmentImageId"]);

            if (fieldNames.Contains("CountryId"))
                if (!Convert.IsDBNull(reader["CountryId"]))
                    itemDepartmentImageCountry.CountryId = Convert.ToInt32(reader["CountryId"]);

            if (fieldNames.Contains("CountryArabicName"))
                if (!Convert.IsDBNull(reader["CountryArabicName"]))
                    itemDepartmentImageCountry.CountryArabicName = reader["CountryArabicName"].ToString();

            if (fieldNames.Contains("CountryEnglishName"))
                if (!Convert.IsDBNull(reader["CountryEnglishName"]))
                    itemDepartmentImageCountry.CountryEnglishName = reader["CountryEnglishName"].ToString();

            return itemDepartmentImageCountry;
        }
    }
}