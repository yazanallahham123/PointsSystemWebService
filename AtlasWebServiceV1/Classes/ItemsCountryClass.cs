using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    [DataContract]
    public class ItemsCountryClass
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int ItemId { get; set; }
        [DataMember(Order = 3)]
        public int CountryId { get; set; }
        [DataMember(Order = 4)]
        public string ItemArabicName { get; set; }
        [DataMember(Order = 5)]
        public string ItemEnglishName { get; set; }
        [DataMember(Order = 6)]
        public string CountryArabicName { get; set; }
        [DataMember(Order = 7)]
        public string CountryEnglishName { get; set; }
        [DataMember(Order = 8)]
        public int Order { get; set; }



        public ItemsCountryClass PopulateItemsCountry(string[] fieldNames, SqlDataReader reader)
        {
            var itemsCountry = new ItemsCountryClass();
            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    itemsCountry.Id = (int)reader["Id"];

            if (fieldNames.Contains("ItemId"))
                if (!Convert.IsDBNull(reader["ItemId"]))
                    itemsCountry.ItemId = (int)reader["ItemId"];

            if (fieldNames.Contains("CountryId"))
                if (!Convert.IsDBNull(reader["CountryId"]))
                    itemsCountry.CountryId = (int)reader["CountryId"];

            if (fieldNames.Contains("ItemArabicName"))
                if (!Convert.IsDBNull(reader["ItemArabicName"]))
                    itemsCountry.ItemArabicName = reader["ItemArabicName"].ToString();

            if (fieldNames.Contains("ItemEnglishName"))
                if (!Convert.IsDBNull(reader["ItemEnglishName"]))
                    itemsCountry.ItemEnglishName = reader["ItemEnglishName"].ToString();

            if (fieldNames.Contains("CountryArabicName"))
                if (!Convert.IsDBNull(reader["CountryArabicName"]))
                    itemsCountry.CountryArabicName = reader["CountryArabicName"].ToString();

            if (fieldNames.Contains("CountryEnglishName"))
                if (!Convert.IsDBNull(reader["CountryEnglishName"]))
                    itemsCountry.CountryEnglishName = reader["CountryEnglishName"].ToString();

            return itemsCountry;
        }
    }
}