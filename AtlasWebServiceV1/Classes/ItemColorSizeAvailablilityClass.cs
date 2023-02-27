using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PointsSystemWebService.Classes
{
    public class ItemColorSizeAvailabilityClass
    {

        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int ItemId { get; set; }
        [DataMember(Order = 3)]
        public int ItemColorId { get; set; }
        [DataMember(Order = 4)]
        public int ItemSizeId { get; set; }
        [DataMember(Order = 5)]
        public int ColorId { get; set; }
        [DataMember(Order = 6)]
        public int SizeGroupId { get; set; }
        [DataMember(Order = 7)]
        public int SizeId { get; set; }
        [DataMember(Order = 8)]
        public bool Disabled { get; set; }
        [DataMember(Order = 9)]
        public string SizeArabicName { get; set; }
        [DataMember(Order = 10)]
        public string SizeEnglishName { get; set; }
        [DataMember(Order = 11)]
        public string SizeGroupArabicName { get; set; }
        [DataMember(Order = 12)]
        public string SizeGroupEnglishName { get; set; }
        [DataMember(Order = 13)]
        public string ColorArabicName { get; set; }
        [DataMember(Order = 14)]
        public string ColorEnglishName { get; set; }
        [DataMember(Order = 15)]
        public int Order{ get; set; }
        [DataMember(Order = 16)]
        public int CountryId { get; set; }
        [DataMember(Order = 17)]
        public string CountryArabicName { get; set; }
        [DataMember(Order = 18)]
        public string CountryEnglishName { get; set; }

        public ItemColorSizeAvailabilityClass PopulateItemColorSizeAvailability(string[] fieldNames, SqlDataReader reader)
        {
            var itemColorSizeAvailabilityClass = new ItemColorSizeAvailabilityClass();

            if (fieldNames.Contains("Id"))
                if (!Convert.IsDBNull(reader["Id"]))
                    itemColorSizeAvailabilityClass.Id = (int)reader["Id"];

            if (fieldNames.Contains("ItemId"))
                if (!Convert.IsDBNull(reader["ItemId"]))
                    itemColorSizeAvailabilityClass.ItemId = (int)reader["ItemId"];

            if (fieldNames.Contains("ColorId"))
                if (!Convert.IsDBNull(reader["ColorId"]))
                    itemColorSizeAvailabilityClass.ColorId = (int)reader["ColorId"];

            if (fieldNames.Contains("SizeId"))
                if (!Convert.IsDBNull(reader["SizeId"]))
                    itemColorSizeAvailabilityClass.SizeId = (int)reader["SizeId"];

            if (fieldNames.Contains("ItemSizeId"))
                if (!Convert.IsDBNull(reader["ItemSizeId"]))
                    itemColorSizeAvailabilityClass.ItemSizeId = (int)reader["ItemSizeId"];

            if (fieldNames.Contains("ItemColorId"))
                if (!Convert.IsDBNull(reader["ItemColorId"]))
                    itemColorSizeAvailabilityClass.ItemColorId = (int)reader["ItemColorId"];

            if (fieldNames.Contains("SizeGroupId"))
                if (!Convert.IsDBNull(reader["SizeGroupId"]))
                    itemColorSizeAvailabilityClass.SizeGroupId = (int)reader["SizeGroupId"];

            if (fieldNames.Contains("SizeArabicName"))
                if (!Convert.IsDBNull(reader["SizeArabicName"]))
                    itemColorSizeAvailabilityClass.SizeArabicName = reader["SizeArabicName"].ToString();

            if (fieldNames.Contains("SizeEnglishName"))
                if (!Convert.IsDBNull(reader["SizeEnglishName"]))
                    itemColorSizeAvailabilityClass.SizeEnglishName = reader["SizeEnglishName"].ToString();


            if (fieldNames.Contains("SizeGroupArabicName"))
                if (!Convert.IsDBNull(reader["SizeGroupArabicName"]))
                    itemColorSizeAvailabilityClass.SizeGroupArabicName = reader["SizeGroupArabicName"].ToString();


            if (fieldNames.Contains("SizeGroupEnglishName"))
                if (!Convert.IsDBNull(reader["SizeGroupEnglishName"]))
                    itemColorSizeAvailabilityClass.SizeGroupEnglishName = reader["SizeGroupEnglishName"].ToString();


            if (fieldNames.Contains("ColorArabicName"))
                if (!Convert.IsDBNull(reader["ColorArabicName"]))
                    itemColorSizeAvailabilityClass.ColorArabicName = reader["ColorArabicName"].ToString();


            if (fieldNames.Contains("ColorEnglishName"))
                if (!Convert.IsDBNull(reader["ColorEnglishName"]))
                    itemColorSizeAvailabilityClass.ColorEnglishName = reader["ColorEnglishName"].ToString();


            if (fieldNames.Contains("CountryId"))
                if (!Convert.IsDBNull(reader["CountryId"]))
                    itemColorSizeAvailabilityClass.CountryId = (int)reader["CountryId"];

            if (fieldNames.Contains("CountryArabicName"))
                if (!Convert.IsDBNull(reader["CountryArabicName"]))
                    itemColorSizeAvailabilityClass.CountryArabicName = reader["CountryArabicName"].ToString();


            if (fieldNames.Contains("CountryEnglishName"))
                if (!Convert.IsDBNull(reader["CountryEnglishName"]))
                    itemColorSizeAvailabilityClass.CountryEnglishName = reader["CountryEnglishName"].ToString();

            return itemColorSizeAvailabilityClass;
        }
    }
}